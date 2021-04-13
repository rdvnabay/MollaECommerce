using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcCoreWebUI.Services.WishListSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Controllers
{
    public class WishListController : Controller
    {
        #region Field
        private IWishListSessionService _wishListSessionService;
        private IWishListService _wishListService;
        private IProductService _productService;
        #endregion

        #region Constructor
        public WishListController(
            IWishListSessionService wishListSessionService,
            IWishListService wishListService,
            IProductService productService)
        {
            _wishListSessionService = wishListSessionService;
            _wishListService = wishListService;
            _productService = productService;
        }
        #endregion
        public IActionResult Index()
        {
            var wishList = _wishListSessionService.GetWishList();
            return View(wishList);
        }

        public IActionResult AddToWishList(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var wishList = _wishListSessionService.GetWishList();
            _wishListService.AddToWishList(wishList, productToBeAdded.Data);
            _wishListSessionService.SetWishList(wishList);
            //TempData.Add("message", String.Format("{0} sepete eklendi", productToBeAdded.Name));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var wishList = _wishListSessionService.GetWishList();
            _wishListService.RemoveFromWishList(wishList, productId);
            _wishListSessionService.SetWishList(wishList);
            return RedirectToAction("Index", "WishList");
        }
    }
}
