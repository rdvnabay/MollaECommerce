using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcCoreWebUI.Identity;
using MvcCoreWebUI.Models;
using MvcCoreWebUI.Services.CartSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Controllers
{
    public class OrderController : Controller
    {
        private UserManager<AppIdentityUser> _userManager;
        private IOrderService _orderService;
        private IMapper _mapper;
        private ICartSessionService _cartSessionService;
        public OrderController(
            UserManager<AppIdentityUser> userManager,
            IOrderService orderService,
            IMapper mapper,
            ICartSessionService cartSessionService
            )
        {
            _userManager = userManager;
            _orderService = orderService;
            _mapper = mapper;
            _cartSessionService = cartSessionService;


        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            var model = new OrderContactCartViewModel
            {
                Cart = _cartSessionService.GetCart()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Contact(OrderContactCartViewModel model)
        {
            var userId = _userManager.GetUserId(User);
            model.UserId = userId;
            var order = _mapper.Map<Order>(model);
            _orderService.Add(order);
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
    }
}
