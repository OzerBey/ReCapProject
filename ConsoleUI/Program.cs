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
            #region Tests 
            //ColorTest();
            //BrandTest();
            //CarTest();
            //newCarAdd(carManager);
            //MyFirstWork();
             
            #endregion

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color()
            {
                ColorName = "Yellow"
            });
            colorManager.Update(colorManager.GetById(1002));


            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("{0}- {1}", color.ColorId, color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand()
            {
                BrandName = "Ford"
            });


            string[] brandNames = new[]
            {
                "Opel",
                "Nissan",
                "Lamborghini",
                "Honda",
                "Toyota",
                "Merdeces"
            };

            foreach (var brand in brandNames)
            {
                brandManager.Add(new Brand()
                {
                    BrandName = brand
                });
                foreach (var brandRead in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brandRead.BrandName);
                }
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll().Data;

            foreach (var car in result)
            {
                Console.WriteLine(car.CarId);
            }

            Console.WriteLine("Description | BrandName | ColorName | DailyPrice");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} -  {2} - {3}", car.Description, car.BrandName, car.ColorName, car.DailyPrice);
            }
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
            foreach (var car in carManager.GetAll().Data)
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
