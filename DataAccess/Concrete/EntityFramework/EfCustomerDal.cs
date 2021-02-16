using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapDatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users
                                 on cu.UserId equals us.Id
                             select new CustomerDetailDto()
                             {
                                 Id = cu.Id,
                                 UserName = us.FirstName
                             };
                return result.ToList();
            }

        }
    }
}
