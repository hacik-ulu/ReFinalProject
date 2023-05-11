using Core.DataAccess;
using Entities.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        //Tamamen ProductDal'aözgü join.
        List<ProductDetailDto> GetProductsDetail();
    }
}