using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Services.WishListSession
{
    public interface IWishListSessionService
    {
        WishList GetWishList();
        void SetWishList(WishList wishList);
    }
}
