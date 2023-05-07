using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //Veritabanında dolayı using'deki işlem sonuçlanınca garbage collector devreye girer.
            using (NorthwindContext context = new NorthwindContext())
            {
                //Veri kaynağı ile ilişkilendirildi.Eşleşm durumu kontrol edildi.Referans yakalandı.
                var addedEntity = context.Entry(entity);
                //Eklenecek nesne olduğu "durumu" belirtildi
                addedEntity.State = EntityState.Added;
                //Eklendi,Değişiklikler kaydedildi.
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //SingleOrDefaultAsync -- Bu methodda aynı şekilde tek bir sonucun döneceği durumlarda kullanılır. 
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                // Select * from Product 
                // Filtre boş ise ilki , değilse sonrası çalışır.
                return filter == null ?
                    context.Set<Product>().ToList() :
                    context.Set<Product>().Where(filter).ToList();
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
