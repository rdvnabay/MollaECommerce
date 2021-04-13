using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        #region AddToCart
        public IResult AddToCart(Cart cart, Product product)
        {
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.Id == product.Id);
            if (cartLine != null)
            {
                cartLine.Quantity++;
                return new SuccessResult();
            }
            cart.CartLines.Add(new CartLine
            {
                Product = product,
                Quantity = 1
            });
            return new SuccessResult();
        }
        #endregion

        #region List
        public IDataResult<List<CartLine>> List(Cart cart)
        {
            return new SuccessDataResult<List<CartLine>>(cart.CartLines);
        }
        #endregion

        #region RemoveFromCart
        public IResult RemoveFromCart(Cart cart, int productId)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.Id == productId));
            return new SuccessResult();
        }
        #endregion
    }
}
