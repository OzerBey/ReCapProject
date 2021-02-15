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
        public List<RentalDetailDto> GetCarDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                //tr_//Rentals tablosunda (re) deki CarId ile CarId i cre deki BrandId ile br deki BrandId i  cr deki ColorId ile ColorId re deki CustomerId ile CustomerId cu daki UserId ile User (Id eşitse) select et (döndür)
                var result = from re in context.Rentals
                             join cr in context.Cars on re.CarId equals cr.CarId
                             join br in context.Brands on cr.BrandId equals br.BrandId
                             join co in context.Colors on cr.ColorId equals co.ColorId
                             join cu in context.Customers on re.CustomerId equals cu.Id
                             join us in context.Users on cu.UserId equals us.Id
                             select new RentalDetailDto
                             {
                                 Id = re.RentalId,
                                 BrandName = br.BrandName,
                                 ColorName = co.ColorName,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Descriptions
                             };
                return result.ToList();
            }
        }
    }
}

