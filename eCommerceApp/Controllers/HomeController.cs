using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var product = _productRepository.GetAll();

            return View(product);
        }
    }
}