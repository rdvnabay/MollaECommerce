using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos.Panel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<Product> GetAll(string sortBy);
        List<Product> GetProductsImages();
        Product GetImagesByProductId(int productId);
    }
}
