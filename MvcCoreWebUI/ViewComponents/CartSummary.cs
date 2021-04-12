using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MvcCoreWebUI.Services.CartSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.ViewComponents
{
    public class CartSummary:ViewComponent
    {
        private ICartSessionService _cartSessionService;
        public CartSummary(ICartSessionService cartSessionService)
        {
            _cartSessionService = cartSessionService;
        }
        public ViewViewComponentResult Invoke()
        {
            var model = _cartSessionService.GetCart();

            return View(model);
        }
    }
}
