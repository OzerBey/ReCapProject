using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //We used for basic voids 
    public interface IResult
    {
        bool Success { get; } //Readonly
        string Message { get; }
    }
}
