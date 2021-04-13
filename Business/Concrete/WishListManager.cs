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
    public class WishListManager : IWishListService
    {
        public IResult AddToWishList(WishList wishList, Product product)
        {
            WishListLine wishListLine = wishList.WishListLines.FirstOrDefault(c => c.Product.Id == product.Id);
            if (wishListLine != null)
            {
                wishListLine.Quantity++;
                return new SuccessResult();
            }
            wishList.WishListLines.Add(new WishListLine
            {
                Product = product,
                Quantity = 1
            });
            return new SuccessResult();
        }

        public IDataResult<List<WishListLine>> List(WishList wishList)
        {
            return new SuccessDataResult<List<WishListLine>>(wishList.WishListLines);
        }

        public IResult RemoveFromWishList(WishList wishList, int productId)
        {
            wishList.WishListLines.Remove(wishList.WishListLines.FirstOrDefault(c => c.Product.Id == productId));
            return new SuccessResult();
        }
    }
}
