using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductManager _productManager;

        public HomeController(IProductManager productRepository)
        {
            _productManager = productRepository;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var product = await _productManager.GetAll();

            return View(product);
        }

        public async Task<IActionResult> Details(long id)
        {
            var product = await _productManager.GetById(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult ShopingCart()
        {
            return View();
        }
    }
}