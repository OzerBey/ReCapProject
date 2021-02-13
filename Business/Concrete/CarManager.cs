using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
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
        public void Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length > 2)
            {
                _carDal.Add(car);
            }

            Console.WriteLine("new Car added :)");
        }

        public List<Car> GetCarsByBrandId(int brandId)

        {
            //select * from Cars where BrandId = 3
            var getCarId = _carDal.GetAll(p => p.BrandId == brandId).ToList();
            return getCarId;
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            var getColorId = _carDal.GetAll(p => p.ColorId == colorId).ToList();
            return getColorId;
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max); //return List<Car> object
        }

        public List<Car> GetAll()
        {
            //works codes here
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
