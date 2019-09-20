using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCommerce.DatabaseContext;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Http;
using PagedList.Core;

namespace eCommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [Route("Product/Index")]
        public IActionResult Index()
        {
            var product = _productRepository.GetAll();

            return View(product);
        }

        [Route("Product/Create")]
        public IActionResult Create()
        {
            PopulateCategory();
            return View();
        }

        [Route("Product/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Product product, List<IFormFile> Image)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in Image)
                {
                    if (item.Length > 0)
                    {
                        using (var stream = new MemoryStream())
                        {
                            await item.CopyToAsync(stream);
                            product.Image = stream.ToArray();
                        }
                    }
                }

                _productRepository.Add(product);
            }

            PopulateCategory(product.CategoryId);
            return View();
        }

        private void PopulateCategory(object selectList = null)
        {
            var category = _categoryRepository.GetAll();
            ViewBag.CategoryId = new SelectList(category, "Id", "Name", selectList);
        }

        [Route("product/Details")]
        public ActionResult Details(int id)
        {
            var product = _productRepository
                .GetById(id);
            return View(product);
        }
    }
}