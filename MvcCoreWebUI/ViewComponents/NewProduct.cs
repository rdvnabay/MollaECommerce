using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.ViewComponents
{
    public class NewProduct:ViewComponent
    {
        private IProductService _productService;
        public NewProduct(IProductService productService)
        {
            _productService = productService;
        }
        public ViewViewComponentResult Invoke()
        {
            var data = _productService.GetAll().Data;
            return View(data);
        }
    }
}
