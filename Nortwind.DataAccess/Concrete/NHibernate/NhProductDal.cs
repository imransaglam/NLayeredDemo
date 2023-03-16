using Nortwind.DataAccess.Abstract;
using Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //Nhibernate kodu değil örnek olsun diye yazıldı
            List<Product> produts = new List<Product>
           {
               new Product{ProductId=1,CategoryId=1,ProductName="Laptop",QuantityPerUnit="1 in a box",UnitPrice=3000,UnitsInStock=20},
           };
            return produts;
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }    
    
}
