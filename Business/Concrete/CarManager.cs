﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal; // bagımlılıgımızı minimize ediyoruz yine bagımlı ama fazla degil.. cünkü interface üzerinden bagımlılık vardır

        public CarManager(ICarDal carDal) //if CarManager has been, run here
        {
            _carDal = carDal;
        }
        //Araba ismi minimum 2 karakter olmalıdır
        //Araba günlük fiyatı 0'dan büyük olmalıdır.
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            //if (car.DailyPrice > 0 && car.Descriptions.Length > 2)
            //{
            //    _carDal.Add(car);
            //}
            //else
            //{
            //    //extra info =>//Console.WriteLine("invalid car description please try again! description  length of car must be at least 2 character ");
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
            //ValidationTool.Validate(new CarValidator(), car);

            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [PerformanceAspect(5)]//if greater than 5 sec
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)

        {
            //select * from Cars where BrandId = 3
            var getCarId = _carDal.GetCarDetails(p => p.BrandId == brandId).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(getCarId,Messages.CarListed);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            var getColorId = _carDal.GetCarDetails(p => p.ColorId == colorId).ToList();
            return new SuccessDataResult<List<CarDetailDto>>(getColorId);
        }

        public IDataResult<List<CarDetailDto>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.DailyPrice >= min && p.DailyPrice <= max)); //return List<Car> object)
        }


        [CacheAspect] // key ,value in CarManager
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 8) // if we want to close at 8 
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            //works codes here
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetByModelYear(string modelYear)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(p => p.ModelYear == modelYear));
        }

  

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 100)
            {
                throw new Exception("");
            }

            Add(car);
            return null;
        }
    }
}
