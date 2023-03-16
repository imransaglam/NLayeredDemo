using FluentValidation;
using Nortwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz");
            RuleFor(p=>p.CategoryId).NotEmpty();
            RuleFor(p=>p.UnitPrice).NotEmpty(); 
            RuleFor(p=>p.QuantityPerUnit).NotEmpty();
            RuleFor(p=>p.UnitsInStock).NotEmpty();   

            RuleFor(p=>p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);//ToInt16 oldugu için smallint oldugu için
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p=>p.CategoryId==2);
            //Kendi kuralını yazmak
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A ile Başlamalı");;
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
