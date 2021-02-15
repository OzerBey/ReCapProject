using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //We give the value false as default in this class
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message) 
        {

        }

        //return result without message
        public ErrorResult(bool success) : base(false)
        {

        }
    }
}
