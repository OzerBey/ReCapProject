using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet: DataAccess icinde entityframework kodu yazabilecegimiz anlamına gelir 
    public class EfCarDal : IEntityRepository<Car>
    {


        public void Add(Car entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (ReCapDatabaseContext context = new ReCapDatabaseContext()
            ) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {
                var addedEntity = context.Entry(entity); //git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                addedEntity.State = EntityState.Added; //eklenecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges(); //son değişiklik kaydı
            }
        }

        public void Update(Car entity)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null) //filtre verebilir ama vermeyedebilir default u null oldugu icin
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();

            }
        }


    }
}
