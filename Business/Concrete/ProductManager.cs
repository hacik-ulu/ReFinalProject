﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRudes.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingsConcern.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entitites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Data Access ile iletişim kuracak.
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }


        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            //Data döndürmeliyiz
            if (DateTime.Now.Hour == 13)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));

        }

        public IDataResult<List<ProductDetailDto>> GetProductsDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductsDetail());
        }


    }
}