using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Concrete of abstract class (IResult)
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success) //Send it to the single parameter constructor of this class and execute
        {
            Message = message;  //The getter structures are read only.. Read only can be set in the constructor
        }

        //overloading
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
