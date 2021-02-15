using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //return data default false
    public class ErrorDataResult<T> : DataResult<T>
    {
        //for just data and message
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //for just data
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //for just message
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //without anything
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
