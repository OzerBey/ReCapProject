using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal) //if CarManager has been, run here
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //works codes here
            return _carDal.GetAll();
        }
    }
}
