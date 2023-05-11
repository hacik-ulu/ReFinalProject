using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public void Add(TEntity entity)
        {
            //Veritabanında dolayı using'deki işlem sonuçlanınca garbage collector devreye girer.
            using (TContext context = new TContext())
            {
                //Veri kaynağı ile ilişkilendirildi.Eşleşm durumu kontrol edildi.Referans yakalandı.
                var addedEntity = context.Entry(entity);
                //Eklenecek nesne olduğu "durumu" belirtildi
                addedEntity.State = EntityState.Added;
                //Eklendi,Değişiklikler kaydedildi.
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //SingleOrDefaultAsync -- Bu methodda aynı şekilde tek bir sonucun döneceği durumlarda kullanılır. 
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // Select * from Product 
                // Filtre boş ise ilki , değilse sonrası çalışır.
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}

