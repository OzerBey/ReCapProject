using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //return result with data
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
