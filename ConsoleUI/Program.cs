using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            ICarDal carDal = new InMemoryCarDal();



            Console.WriteLine("-------------GetAll Method--------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " -> " + car.ModelYear + " : " + car.Description + " " + car.DailyPrice + " TL");
            }

            Console.WriteLine("------------------GetById method--------------------------");
            foreach (var carId in carDal.GetById(5))
            {
                Console.WriteLine("5. daily price of car is {0}", carId.DailyPrice);
            }

            Console.WriteLine("--------------------Add car ------------------------");
            Car car1 = new Car()
            {
                Id = 7,
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2019",
                DailyPrice = 2900,
                Description = "Rental car from the owner "
            };
            Car car2 = new Car()
            {
                Id = 8,
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2017",
                DailyPrice = 1750,
                Description = "Rental car from the owner "
            };
            carDal.Add(car1);
            Console.WriteLine("new car added !");
            Console.WriteLine("-----------------Delete car ------------------");
            carDal.Delete(car2);
            Console.WriteLine(car2.Id + ". car deleted!!");
            Console.WriteLine("------------------car update---------------------");
            carDal.Update(car1);
            Console.WriteLine("car updated // just simulation");
        }

    }
}
