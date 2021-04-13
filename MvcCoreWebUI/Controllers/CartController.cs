using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcCoreWebUI.Services.CartSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Controllers
{
    public class CartController : Controller
    {
        #region Field
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        #endregion

        #region Constructor
        public CartController(
            ICartSessionService cartSessionService,
            ICartService cartService,
            IProductService productService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }
        #endregion
        public IActionResult Index()
        {
            var cart = _cartSessionService.GetCart();
            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var productToBeAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToBeAdded.Data);
            _cartSessionService.SetCart(cart);
            //TempData.Add("message", String.Format("{0} sepete eklendi", productToBeAdded.Name));
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);
            return RedirectToAction("Index", "Cart");
        }
    }
}
