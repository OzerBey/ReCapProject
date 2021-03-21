using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDatabaseContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                //tr_//Rentals tablosunda (re) deki CarId ile CarId i cre deki BrandId ile br deki BrandId i  cr deki ColorId ile ColorId re deki CustomerId ile CustomerId cu daki UserId ile User (Id eşitse) select et (döndür)
               var result = from re in  context.Rentals 
                             join ca in context.Cars on re.CarId equals ca.CarId
                             join cu in context.Customers on re.CustomerId equals cu.Id
                             join us in context.Users on cu.UserId equals us.Id
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = re.RentalId,
                                 CarId = ca.CarId,
                                 CarName = ca.Descriptions,
                                 BrandName = br.BrandName,
                                 CustomerFirstName = cu.FirstName,
                                 CustomerLastName = cu.LastName,
                                 CompanyName = cu.CompanyName,
                                 UserName = us.FirstName + " " + us.LastName,
                                 RentalDate = re.RentDate,
                                 ReturnDate = re.ReturnDate,

                             };

                return result.ToList();
            }
        }

    }
}

