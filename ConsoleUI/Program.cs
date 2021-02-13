using System;
using System.Linq;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Description | BrandName | ColorName | DailyPrice");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} -  {2} - {3}", car.Description, car.BrandName, car.ColorName, car.DailyPrice);
            }

           // newCarAdd(carManager);

            Console.WriteLine("---------Car TEST-----------");
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }


            //MyFirstWork();
        }

        private static void newCarAdd(CarManager carManager)
        {
            carManager.Add(new Car()
            {
                Description = "i20 ",
                DailyPrice = 1500,
                BrandId = 2,
                ColorId = 2,
                ModelYear = "2020"
            });
        }

        private static void MyFirstWork()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ICarDal carDal = new InMemoryCarDal();


            Console.WriteLine("-------------GetAll Method--------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " -> " + car.ModelYear + " : " + car.Description + " " + car.DailyPrice + " TL");
            }


            Console.WriteLine("--------------------Add car ------------------------");
            Car car1 = new Car()
            {
                CarId = 7,
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2019",
                DailyPrice = 2900,
                Description = "Rental car from the owner "
            };
            Car car2 = new Car()
            {
                CarId = 8,
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
            Console.WriteLine(car2.CarId + ". car deleted!!");
            Console.WriteLine("------------------car update---------------------");
            carDal.Update(car1);
            Console.WriteLine("car updated // just simulation");
        }
    }
}
