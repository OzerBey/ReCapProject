using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //before IResult and IDataResult
        //CRUD operations

        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetAll();
        ////filtered operations
        //List<Car> GetByModelYear(string modelYear);
        //Car GetById(int id);
        //List<Car> GetCarsByBrandId(int brandId);
        //List<Car> GetCarsByColorId(int colorId);
        //List<Car> GetByDailyPrice(decimal min, decimal max);
        //List<CarDetailDto> GetCarDetails();

        //------------------------------------------------------------------

        //after IResult and IDataResult
        //CRUD operations
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        ////filtered operations
        IDataResult<List<Car>> GetByModelYear(string modelYear);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car);
    }

}
