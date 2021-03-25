using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet: DataAccess icinde entityframework kodu yazabilecegimiz anlamına gelir 
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from cr in filter == null ? context.Cars : context.Cars.Where(filter)
                             join br in context.Brands
                                 on cr.BrandId equals br.BrandId
                             join co in context.Colors
                                 on cr.ColorId equals co.ColorId
                             join image in context.CarImages on cr.CarId equals image.CarId
                             select new CarDetailDto //sonucu buradaki kolonlara (verilere) uydurarak verilmesi söyleniliyor
                             {
                                 CarId = cr.CarId,
                                 BrandId = br.BrandId,
                                 ColorId = co.ColorId,
                                 ModelYear = cr.ModelYear,
                                 Description = cr.Descriptions, // döndürülecek olan (istenilen) veri tabanımda carName diye kolon yapmadıgım icin Description verdim
                                 BrandName = br.BrandName, // istenilen degerleri belirlenen bölümlerden cekerek geri döndürür
                                 ColorName = co.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 ImageId = image.Id,
                                 ImagePath = image.ImagePath,
                                 CarImageDate = image.CarImageDate

                             };
                return result.ToList();

            }
        }
    }
}

