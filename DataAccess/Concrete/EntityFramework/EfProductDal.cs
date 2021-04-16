using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, MollaECommerceDbContext>, IProductDal
    {
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
