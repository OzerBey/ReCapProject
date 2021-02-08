using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        //GetById,GetAll,Add,Update,Delete,

        List<Car> GetById(int Id);
        List<Car> GetAll(); // It is reference of Car class.
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

    }
}
