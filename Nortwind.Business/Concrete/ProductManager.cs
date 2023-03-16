﻿using FluentValidation;
using Nortwind.Business.Abstract;
using Nortwind.Business.Utilities;
using Nortwind.Business.ValidationRules.FluentValidation;
using Nortwind.DataAccess.Abstract;
using Nortwind.DataAccess.Concrete;
using Nortwind.DataAccess.Concrete.EntityFramework;
using Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Business.Concrete
{
    public class ProductManager: IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal) {
        _productDal= productDal;    
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(),product);
           _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            try
            {
            _productDal.Delete(product);
            }
            catch
            {
                throw new Exception("Silme gerçekleşmedi");
            }          
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p=>p.CategoryId==categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            _productDal.Update(product);
        }
    }
}
