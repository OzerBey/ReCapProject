using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //We give the value true as default in this class
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message) //base(true, message): send these values to the base class
        {

        }

        //return result without message
        public SuccessResult(bool success) : base(true)
        {

        }
    }
}
