using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using MvcCoreWebUI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Services.WishListSession
{
    public class WishListSessionManager: IWishListSessionService
    {
        #region Field
        private IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constuctor
        public WishListSessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        //Methods
        #region GetCart
        public WishList GetWishList()
        {
            WishList wishListToCheck = _httpContextAccessor.HttpContext.Session.GetObject<WishList>("wishList");
            if (wishListToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("wishList", new WishList());
                wishListToCheck = _httpContextAccessor.HttpContext.Session.GetObject<WishList>("wishList");
            }
            return wishListToCheck;
        }
        #endregion

        public void SetWishList(WishList wishList)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("wishList", wishList);
        }
    }
}
