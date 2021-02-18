using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //We put the special constants of northwind here.
    public static class Messages  //tool for us 
    {
        //magic strings
        //static structures are not new :)
        //fields of messages
        //public structures are written in Pascal Case. for example (CarAdded)
        //for brand
        public static string BrandAdded = "Brand added";
        public static string BrandNameInvalid = "Name of Brand is invalid";
        public static string BrandUpdated = "Brand updated";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandListed = "Brands listed";
        public static string BrandNameLengthInvalid = "Brand's length is too long!";
        //for car
        public static string CarAdded = "Car added";
        public static string CarNameInvalid = "Name of car is invalid";
        public static string CarUpdated = "Car updated";
        public static string CarDeleted = "Car deleted";
        public static string CarListed = "Cars listed";
        //for color 
        public static string ColorAdded = "Color added";
        public static string ColorNameInvalid = "Name of Color is invalid";
        public static string ColorUpdated = "Color updated";
        public static string ColorDeleted = "Color deleted";
        public static string ColorListed = "Color listed";
        //for user
        public static string UserAdded = "User added";
        public static string UserNameInvalid = "Name of User is invalid";
        public static string UserUpdated = "User updated";
        public static string UserDeleted = "User deleted";
        public static string UserListed = "User listed";
        //for customer
        public static string CustomerAdded = "Customer added";
        public static string CustomerNameInvalid = "Name of Customer is invalid";
        public static string CustomerUpdated = "Customer updated";
        public static string CustomerDeleted = "Customer deleted";
        public static string CustomerListed = "Customer listed";
        //for rental
        public static string RentalAdded = "Rental added";
        public static string RentalNameInvalid = "Name of Rental is invalid";
        public static string RentalUpdated = "Rental updated";
        public static string RentalDeleted = "Rental deleted";
        public static string RentalListed = "RentalRental listed";
        //for general maintenance 
        public static string MaintenanceTime = "Maintenance time :( ";

    }
}
