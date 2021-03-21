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
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from cr in context.Cars
                             join br in context.Brands
                                 on cr.BrandId equals br.BrandId
                             join co in context.Colors
                                 on cr.ColorId equals co.ColorId
                             select new CarDetailDto //sonucu buradaki kolonlara (verilere) uydurarak verilmesi söyleniliyor
                             {
                                 CarId = cr.CarId,
                                 ModelYear = cr.ModelYear,
                                 Description = cr.Descriptions, // döndürülecek olan (istenilen) veri tabanımda carName diye kolon yapmadıgım icin Description verdim
                                 BrandName = br.BrandName, // istenilen degerleri belirlenen bölümlerden cekerek geri döndürür
                                 ColorName = co.ColorName,
                                 DailyPrice = cr.DailyPrice

                             };
                return result.ToList();

            }
        }
    }
}

