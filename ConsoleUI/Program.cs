using System;
using System.Linq;
using Business.Concrete;
using Core.Entities.Concrete;
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
            //CustomerTest();
            // RentalTest();
            #endregion

            //--------------------------CONSOLE SIMULATION-----------------------
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

        Again:
            Console.WriteLine("--------------ReCapProject MENU--------------");
            Console.WriteLine("1. Car List");
            Console.WriteLine("2. Brand List");
            Console.WriteLine("3. Color List");
            Console.WriteLine("4. Add a rent Car");
            Console.WriteLine("5. Add  Brand");
            Console.WriteLine("6. Add Color");
            Console.WriteLine("7. Delete Car");
            Console.WriteLine("8. Update Car");
            Console.WriteLine("9. Vehicle List in Price Range");
            Console.WriteLine("10. Update Brand");
            Console.WriteLine("11. Update Color ");
            Console.WriteLine("12. Add User");
            Console.WriteLine("13. Delete User");
            Console.WriteLine("14. Update User");
            Console.WriteLine("15. User List");
            Console.WriteLine("16. Add Customer");
            Console.WriteLine("17. Delete Customer");
            Console.WriteLine("18. Update Customer");
            Console.WriteLine("19. A rent a car");
            Console.WriteLine("20. Update Rented Vehicle Information");
            Console.WriteLine("21. Rented Car List");
            Console.WriteLine("22. Customer List");
            Console.WriteLine("23. System Exit");
            string mainMenu;
            int choice = 0;
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("wrong character !");
            }
            switch (choice)
            {
                case 1:
                    {
                        var result = carManager.GetCarDetails();
                        if (result.Success)
                        {
                            Console.WriteLine("----------------Car List-------------");
                            foreach (var carDto in carManager.GetCarDetails().Data)
                            {

                                Console.WriteLine(carDto.BrandName + " | " + carDto.ColorName + " | " + carDto.DailyPrice + " | " + carDto.Description);
                                Console.WriteLine("---------------------------------------------");
                            }
                        }

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 2:
                    {
                        var result = brandManager.GetAll();
                        if (result.Success)
                        {
                            Console.WriteLine("----------------Brand List-------------");
                            foreach (var brand in brandManager.GetAll().Data)
                            {
                                Console.WriteLine("Id: " + brand.BrandId + " | " + brand.BrandName);
                                Console.WriteLine("---------------------------------------------");
                            }
                        }

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("------------------Color List----------------");
                        var result = colorManager.GetAll();
                        if (result.Success)
                        {
                            foreach (var color in colorManager.GetAll().Data)
                            {
                                Console.WriteLine("Id: " + color.ColorId + " | " + color.ColorName);
                                Console.WriteLine("---------------------------------------------");
                            }
                        }



                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 4:
                    {
                        string modelYear, description;
                        int brand = 0, color = 0, dailyPrice = 0;
                        Console.WriteLine("Enter the information of the vehicle you want to add");
                        Console.WriteLine("Enter the brand's BrandId value.");
                        brand = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ColorId value of the color");
                        color = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your modelYear");
                        modelYear = Console.ReadLine();
                        Console.WriteLine("Enter the rental fee");
                        dailyPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter description");
                        description = Console.ReadLine();
                        Car car1 = new Car { BrandId = brand, ColorId = color, ModelYear = modelYear, DailyPrice = dailyPrice, Descriptions = description };
                        carManager.Add(car1);
                        Console.WriteLine("The vehicle has been successfully added by the system.");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }


                        break;
                    }
                case 5:
                    {
                        string brand;
                        Console.WriteLine("Write the brand you want to add");
                        brand = Console.ReadLine();
                        Brand brand1 = new Brand { BrandName = brand };
                        brandManager.Add(brand1);
                        Console.WriteLine("Brand addition process has been done successfully");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {

                            goto Again;
                        }
                        break;
                    }
                case 6:
                    {
                        string color;
                        Console.WriteLine("Write the color you want to add");
                        color = Console.ReadLine();
                        Color color1 = new Color { ColorName = color };
                        colorManager.Add(color1);
                        Console.WriteLine("Added color has been done successfully");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 7:
                    {

                        int id = 0;
                        Console.WriteLine("Enter the Id value of the vehicle you want to delete");
                        id = Convert.ToInt32(Console.ReadLine());
                        Car car2 = new Car { CarId = id };
                        carManager.Delete(car2);
                        Console.WriteLine("Deletion completed successfully.");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }


                        break;
                    }
                case 8:
                    {
                        string modelYear, description;
                        int brand = 0, color = 0, dailyPrice = 0, id = 0;
                        Console.WriteLine("Enter the information of the vehicle you want to update");
                        Console.WriteLine("Enter the Id value of the vehicle you want to update");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the brand's BrandId value.");
                        brand = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ColorId value of the color");
                        color = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your modelYear");
                        modelYear = Console.ReadLine();
                        Console.WriteLine("Enter the rental fee");
                        dailyPrice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter description");
                        description = Console.ReadLine();
                        Car car1 = new Car { CarId = id, BrandId = brand, ColorId = color, ModelYear = modelYear, DailyPrice = dailyPrice, Descriptions = description };
                        Console.WriteLine("Update process completed successfully");
                        carManager.Update(car1);

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 9:
                    {

                        int minMoney = 0, maxMoney = 0;
                        Console.WriteLine("Enter the value range you want to rent");
                        Console.WriteLine("Enter the minimum fee");
                        minMoney = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the maximum fee");
                        maxMoney = Convert.ToInt32(Console.ReadLine());
                        var result = carManager.GetByDailyPrice(minMoney, maxMoney);
                        if (result.Success)
                        {
                            foreach (var i in carManager.GetByDailyPrice(minMoney, maxMoney).Data)
                            {
                                Console.WriteLine("Id: " + i.CarId + " | " + brandManager.GetById(i.BrandId).Data.BrandName + " | " + colorManager.GetById(i.ColorId).Data.ColorName + " | " + i.ModelYear + " | " + i.DailyPrice + " | " + i.Descriptions);
                            }
                        }

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }

                case 10:
                    {
                        string brand;
                        int id = 0;
                        Console.WriteLine("Id");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write the new brand");
                        brand = Console.ReadLine();
                        Brand brand1 = new Brand { BrandId = id, BrandName = brand };
                        brandManager.Update(brand1);
                        Console.WriteLine("Brand update has been done successfully");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }

                        break;
                    }
                case 11:
                    {
                        string color;
                        int id = 0;
                        Console.WriteLine("Enter the Id value of the color you want to update.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write the new color");
                        color = Console.ReadLine();
                        Color color1 = new Color { ColorId = id, ColorName = color };
                        colorManager.Update(color1);
                        Console.WriteLine("Color update has been done successfully");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 12:
                    {
                        string name, surname, email, password;
                        Console.WriteLine("Enter your user's name");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter user's surname.");
                        surname = Console.ReadLine();
                        Console.WriteLine("enter eMail");
                        email = Console.ReadLine();
                        Console.WriteLine("enter password");
                        password = Console.ReadLine();
                        //User user = new User { FirstName = name, LastName = surname, Email = email, Password = password };
                        //userManager.Add(user);
                        Console.WriteLine("The user has been successfully added");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }

                        break;
                    }
                case 13:
                    {
                        int id = 0;
                        Console.WriteLine("Enter the ID of the user you want to delete ");
                        id = Convert.ToInt32(Console.ReadLine());
                        User user = new User { Id = id };
                        userManager.Delete(user);
                        Console.WriteLine("The user was deleted successfully ");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 14:
                    {
                        int id = 0;
                        string name, surname, email, password;
                        Console.WriteLine("Enter the ID of the user you want to update.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter name");
                        name = Console.ReadLine();
                        Console.WriteLine("enter surname");
                        surname = Console.ReadLine();
                        Console.WriteLine("Enter email.");
                        email = Console.ReadLine();
                        Console.WriteLine("enter password");
                        password = Console.ReadLine();
                        //User user = new User { FirstName = name, LastName = surname, Email = email, Password = password };
                        //userManager.Update(user);
                        Console.WriteLine("User information has been successfully updated");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 15:
                    {
                        foreach (var user in userManager.GetAll().Data)
                        {
                            Console.WriteLine("Id: " + user.Id + " | " + user.FirstName + " | " + user.LastName +
                                              " | " + user.Email + " | ");// + user.Password);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 16:
                    {
                        int userId;
                        string companyName;
                        Console.WriteLine("Enter the user ID of the customer you want to add ");
                        userId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter name of company");
                        companyName = Console.ReadLine();
                        Customer customer = new Customer { UserId = userId, CompanyName = companyName };
                        customerManager.Add(customer);
                        Console.WriteLine("The customer has been successfully added ");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 17:
                    {
                        int id = 0;
                        Console.WriteLine("Enter the ID of the customer you want to delete.");
                        id = Convert.ToInt32(Console.ReadLine());
                        Customer customer = new Customer { Id = id };
                        customerManager.Delete(customer);
                        Console.WriteLine("The customer was deleted successfully.");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 18:
                    {
                        int userId, id;
                        string companyName;
                        Console.WriteLine("Enter the ID of the customer you want to update");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the user ID of the customer you want to update.");
                        userId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter name of company");
                        companyName = Console.ReadLine();
                        Customer customer = new Customer { Id = id, UserId = userId, CompanyName = companyName };
                        customerManager.Update(customer);
                        Console.WriteLine("Customer information has been updated successfully.");

                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {

                            goto Again;

                        }
                        break;
                    }

                case 19:
                    {
                        DateTime rentDate, returnDate;
                        int carId = 0, customerId = 0;
                        Console.WriteLine("Enter the Id value of the vehicle you want to rent.");
                        carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the id value of the customer you want to rent");
                        customerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the start date");
                        rentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the end date");
                        returnDate = DateTime.Parse(Console.ReadLine());
                        Rental rental = new Rental { CarId = carId, CustomerId = customerId, RentDate = rentDate, ReturnDate = returnDate };
                        var result = rentalManager.Add(rental);
                        if (result.Success)
                        {
                            rentalManager.Add(rental);

                        }
                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 20:
                    {
                        DateTime rentDate, returnDate;
                        int carId = 0, customerId = 0;
                        Console.WriteLine("Enter the Id value of the vehicle you want to update.");
                        carId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the ID of the customer you want to update");
                        customerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter start date");
                        rentDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("enter end date");
                        returnDate = DateTime.Parse(Console.ReadLine());
                        Rental rental = new Rental { CarId = carId, CustomerId = customerId, RentDate = rentDate, ReturnDate = returnDate };
                        var result = rentalManager.Update(rental);
                        if (result.Success)
                        {
                            rentalManager.Update(rental);
                        }
                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 21:
                    {
                        Console.WriteLine("----------------Rented Car List-------------");
                        foreach (var rentalDto in rentalManager.GetAll().Data)
                        {
                            Console.WriteLine("Id: " + rentalDto.RentalId + " | Customer Id :" + rentalDto.CustomerId + " | " + rentalDto.CarId + " | " + rentalDto.RentDate + " | " + rentalDto.ReturnDate);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 22:
                    {
                        Console.WriteLine("----------------Customer List-------------");

                        foreach (var customerDto in customerManager.GetCarDetails().Data)
                        {

                            Console.WriteLine("Id: " + customerDto.Id + " | User name :" + customerDto.UserName);
                            Console.WriteLine("---------------------------------------------");
                        }
                        Console.WriteLine("Would you like to return to the main menu? Yes==y||No==n");
                        mainMenu = Console.ReadLine();
                        if (mainMenu == "y")
                        {
                            goto Again;
                        }
                        break;
                    }
                case 23:
                    {
                        Console.WriteLine("Press to any key");
                        Console.WriteLine("End...");
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong choose please try again later !");
                        goto Again;

                    }
            }
        }

        /*
        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            var result = rentalManager.GetAll().Data;
            foreach (var rental in result)
            {
                Console.WriteLine(rental.CarId);
            }
        }

        private static void CustomerTest()
        {
            CustomerManger customerManger = new CustomerManger(new EfCustomerDal());
            //customerManger.Add(new Customer()
            //{
            //    UserId = 2,
            //    CompanyName = "ShiftBre"
            //});

            var result = customerManger.GetAll().Data;
            foreach (var customer in result)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color()
            {
                ColorName = "Yellow"
            });
            colorManager.Update(colorManager.GetById(1002).Data);


            foreach (var color in colorManager.GetAll().Data)
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

             //foreach (var brand in brandNames)
             //{
             //    brandManager.Add(new Brand()
             //    {
             //        BrandName = brand
             //    });

             //    foreach (var brandRead in brandManager.GetAll().Data)
             //    {
             //        Console.WriteLine(brandRead.BrandName);
             //    }
             //}
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
                Descriptions = "i20 ",
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
                Console.WriteLine(car.CarId + " -> " + car.ModelYear + " : " + car.Descriptions + " " + car.DailyPrice + " TL");
            }


            Console.WriteLine("--------------------Add car ------------------------");
            Car car1 = new Car()
            {
                CarId = 7,
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2019",
                DailyPrice = 2900,
                Descriptions = "Rental car from the owner "
            };
            Car car2 = new Car()
            {
                CarId = 8,
                BrandId = 1,
                ColorId = 1,
                ModelYear = "2017",
                DailyPrice = 1750,
                Descriptions = "Rental car from the owner "
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
        
      */
    }
}
