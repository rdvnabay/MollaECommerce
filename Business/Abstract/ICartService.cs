using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICartService
    {
        IResult AddToCart(Cart cart, Product product);
        IResult RemoveFromCart(Cart cart, int productId);
        IDataResult<List<CartLine>> List(Cart cart);

    }
}
