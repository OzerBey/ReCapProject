using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);

        //IDataResult<List<User>> GetByMail(string email);
        //IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
