using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.Panel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreWebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductDetailService _productDetailService;
        private IMapper _mapper;
        public ProductController(
            IProductService productService,
            IProductDetailService productDetailService,
            IMapper mapper)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductForAddDto model) 
        {
            var product = _mapper.Map<Product>(model);
            var productDetail = _mapper.Map<ProductDetail>(model);
            _productService.Add(product);
            productDetail.Id = product.Id;
            _productDetailService.Add(productDetail);
            return View();
        }

        public IActionResult Edit(int productId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            return View();
        }
    }
}
