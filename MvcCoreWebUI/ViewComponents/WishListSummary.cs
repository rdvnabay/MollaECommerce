using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcCoreWebUI.Services.WishListSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.ViewComponents
{
    public class WishListSummary:ViewComponent
    {
        private IWishListSessionService _wishListSessionService;
        public WishListSummary(IWishListSessionService wishListSessionService)
        {
            _wishListSessionService = wishListSessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var data = _wishListSessionService.GetWishList();
            return View(data);
        }
    }
}
