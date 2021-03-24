using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //return data default true
    public class SuccessDataResult<T>: DataResult<T>
    {
        //for just data and message
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            
        }
        
        //for just data
        public SuccessDataResult(T data):base(data,true)
        {
            
        }

        //for just message
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }

        //without anything
        public SuccessDataResult() :base(default,true)
        {
            
        }
    }
}
