using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext>:IEntityRepository<TEntity> // Generic kisitlamalari
    where TEntity : class, IEntity, new() // new() : new'lenebilir bir nesne olmali anlamina gelir
    where TContext : DbContext, new() //TContext DbContext ten inherit etmesi lazim şartı koyuyoruz burada
    {
        //NuGet: DataAccess icinde entityframework kodu yazabilecegimiz anlamına gelir 
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)//filtre verebilir ama vermeyedebilir default u null oldugu icin
        {
            using (TContext context = new TContext()) //context nesnesi bellek için pahalı bir nesnedir o yüzden using kullanırız using kullanmak garbage colleector ü beklemeden bu using bittikten sonra bellekten atılır
            {
                //return context.Products.ToList();
                //ternary operatörü
                return filter == null  //is filter equals null
                   ? context.Set<TEntity>().ToList() //if yes 
                    : context.Set<TEntity>().Where(filter).ToList(); // if no return filtered objects
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // return a product 
            }
        }

        public void Add(TEntity entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (TContext context = new TContext()) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {

                var addedEntity = context.Entry(entity);//git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                addedEntity.State = EntityState.Added; //eklenecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges();//son değişiklik kaydı
            }
        }

        public void Update(TEntity entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (TContext context = new TContext()) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {
                var updatedEntity = context.Entry(entity);//git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                updatedEntity.State = EntityState.Modified; //güncellenecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges();//son değişiklik kaydı
            }
        }

        public void Delete(TEntity entity)
        {
            //IDisposable pattern implemetation of c#  : using bitince bellegi hemen temizler
            using (TContext context = new TContext()) //usingten çıkan islem Garbage collectora giderek hafızadan atılır (daha perfromanslı bir yapı için)
            {
                var deletedEntity = context.Entry(entity);//git ve veri kaynagından gönderilen product'a bir nesneye eşitle (ekle) referansı yakala
                deletedEntity.State = EntityState.Deleted; //silinecek bir n3sne oldugunu belirtiyoruz
                context.SaveChanges();//son değişiklik kaydı
            }
        }
    }
}
