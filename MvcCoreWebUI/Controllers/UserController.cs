using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcCoreWebUI.Services.WishListSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Controllers
{
    public class UserController : Controller
    {
        private IProductService _productService;
        private IWishListSessionService _wishListSessionService;
        public UserController(IProductService productService,
            IWishListSessionService wishListSessionService)
        {
            _productService = productService;
            _wishListSessionService = wishListSessionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            var wishList = _wishListSessionService.GetWishList();
            return View(wishList);
        }
    }
}
