using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Panel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll(string sortBy)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(sortBy));
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IDataResult<Product> GetAllById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<Product> GetById(int productId)
        {
            var data = _productDal.Get(p => p.Id == productId);
            if (data == null)
            {
                return new ErrorDataResult<Product>(Messages.NotFoundProduct);
            }
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        public IDataResult<Product> GetImagesByProductId(int productId)
        {
           return new SuccessDataResult<Product>(_productDal.GetImagesByProductId(productId));
        }
    }
}
