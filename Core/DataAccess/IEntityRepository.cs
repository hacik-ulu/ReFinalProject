using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

//Core katmanı diğer katmanları referans almaz.
namespace Core.DataAccess
{
    //generic constraint
    // class : reference type
    //IEntity -- > IEntity olabilir ya da implemente edebilir.
    //new()--> newlenebilir olmalı.

    //Category ve Product Interfacelerinin operasyonlarının ortak olarak tutacak.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //filter = null --> filtre verilmeyip tüm datalar da gösterilebilir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        //filter --> sadece ilgili kısımdan tek bir datayı getirir.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}