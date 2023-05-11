﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entitites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //Ürün Listesi tanımlandı.
        List<Product> _products;

        //Uygulama çalıştığı anda ürünler listelenir ve _products değişkenine atanır.
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Masa",UnitPrice=500,UnitsInStock=5},
                new Product{ProductId=2,CategoryId=2,ProductName="Sandalye",UnitPrice=250,UnitsInStock=4},
                new Product{ProductId=3,CategoryId=3,ProductName="Telefon",UnitPrice=12500,UnitsInStock=3},
                new Product{ProductId=4,CategoryId=4,ProductName="Bilgisayar",UnitPrice=30000,UnitsInStock=2},
                new Product{ProductId=5,CategoryId=5,ProductName="Kumanda",UnitPrice=100,UnitsInStock=1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductsDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            //Listedeki ürünün referansı artık gönderilen ürünün referansı olarak güncellendi.
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

            _products.Add(productToUpdate);
        }
    }
}