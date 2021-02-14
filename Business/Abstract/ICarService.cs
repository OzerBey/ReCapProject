using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        //CRUD operasyonlarım
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        //filterelenmis yapılar icin kurulmus operasyonlar
        List<Car> GetByModelYear(string modelYear);
        Car GetById(int id);
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetByDailyPrice(decimal min, decimal max);

        List<CarDetailDto> GetCarDetails();
    }
}
