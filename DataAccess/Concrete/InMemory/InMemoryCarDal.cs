﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>()
            {
                new Car{ Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 2510,ModelYear = "2010",Description = "Rental Car, Urgent sale vehicle"},
                new Car{ Id = 2,BrandId = 1,ColorId = 2,DailyPrice = 1253,ModelYear = "2006",Description = "Offroad rental Car"},
                new Car{ Id = 3,BrandId = 2,ColorId = 3,DailyPrice = 5300,ModelYear = "2019",Description = "Campaign vehicle rental Car"},
                new Car{ Id = 4,BrandId = 2,ColorId = 4,DailyPrice = 2350,ModelYear = "2009",Description = "discounted vehicle rental Car"},
                new Car(){ Id = 5,BrandId = 3,ColorId = 5,DailyPrice = 13000,ModelYear = "2021",Description = "Rental new model Car"},
                new Car(){ Id = 6,BrandId = 3,ColorId = 6,DailyPrice = 2380,ModelYear = "2017",Description = "Rental Car"},
            };
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList(); //veya return (List<Car>) _cars.Where(c=>c.Id==Id);
        }

        public List<Car> GetAll() // return the all of car list
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            //alternative method
            /*foreach (var c in _cars)
            {
                if (c.Id == car.Id)
                {
                    carToDelete = c;
                }
            }
            _cars.Remove(carToDelete);*/

            //if we use the LINQ (Language Integrated Query)

            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);//check the id of car for each c 
            _cars.Remove(carToDelete);
        }
    }
}
