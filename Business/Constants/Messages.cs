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
        //for car
        public static string CarAdded = "Car added";
        public static string CarNameInvalid = "Name of car is invalid";
        public static string CarUpdated = "Car updated";
        public static string CarDeleted = "Car deleted";
        public static string CarListed="Cars listed";
        //for color 
        public static string ColorAdded = "Color added";
        public static string ColorNameInvalid = "Name of Color is invalid"; 
        public static string ColorUpdated = "Color updated";
        public static string ColorDeleted = "Color deleted";
        public static string ColorListed = "Color listed";

        //for general maintenance 
        public static string MaintenanceTime="Maintenance time :( ";
      
    }
}
