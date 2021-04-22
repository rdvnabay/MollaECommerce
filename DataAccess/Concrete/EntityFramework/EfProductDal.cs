using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Panel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, MollaECommerceDbContext>, IProductDal
    {

        public List<Product> GetAll(string sortBy)
        {
            using (var context=new MollaECommerceDbContext())
            {
                IQueryable<Product> products = from p in context.Products
                                                 select p;
                switch (sortBy)
                {
                    case "alphaAsc":
                        products = products.OrderBy(p => p.Name);
                        break;

                    case "alphaDesc":
                        products = products.OrderByDescending(p => p.Name);
                            break;

                    case "moneyAsc":
                        products = products.OrderBy(p => p.Price);
                        break;

                    case "moneyDesc":
                        products = products.OrderByDescending(p => p.Price);
                        break;

                    default:
                        products = products.OrderBy(p=>p.Id);
                        break;
                }
                return products.ToList();
            }
   
        }

        public Product GetImagesByProductId(int productId)
        {
            using (var context=new MollaECommerceDbContext())
            {
                return context.Products.Include(p => p.Images).FirstOrDefault(p => p.Id == productId);
            }
        }

        public List<Product> GetProductsImages()
        {
            using (var context=new MollaECommerceDbContext())
            {
                return context.Products.Include(p => p.Images).ToList();
            }
        }
    }
}
