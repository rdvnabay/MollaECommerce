using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(string sortBy)
        {
            //ViewBag.AlphabeticSortA =String.IsNullOrEmpty(sortBy) ? "alphabeticA": "";
            //ViewBag.AlphabeticSortZ =String.IsNullOrEmpty(sortBy) ? "alphabeticZ": "";
            return View(_productService.GetAll(sortBy).Data);
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult Detail(int productId)
        {
            var data= _productService.GetImagesByProductId(productId).Data;
            return View(data);
        }
    }
}
