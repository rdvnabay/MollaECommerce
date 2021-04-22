using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos.Panel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAll(string sortBy);
        IDataResult<Product> GetAllById(int productId);
        IDataResult<Product> GetById(int productId);
        IDataResult<Product> GetImagesByProductId(int productId);
        IResult Add(Product product);
    }
}
