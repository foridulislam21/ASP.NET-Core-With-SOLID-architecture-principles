using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCommerce.DatabaseContext;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Http;
using PagedList.Core;

namespace eCommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductManager _productRepository;
        private readonly ICategoryManager _categoryRepository;

        public ProductsController(IProductManager productRepository, ICategoryManager categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [Route("Product/Index")]
        public async Task<IActionResult> Index()
        {
            var product = await _productRepository.GetAll();

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
        public async Task<IActionResult> Create(Product product, List<IFormFile> file)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in file)
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

                await _productRepository.Add(product);
            }

            PopulateCategory(product.CategoryId);
            return RedirectToAction("Index");
        }

        private async void PopulateCategory(object selectList = null)
        {
            var category = await _categoryRepository.GetAll();
            ViewBag.CategoryId = new SelectList(category.Where(c => c.ParentId != null), "Id", "Name", selectList);
        }

        [Route("product/Details")]
        public async Task<IActionResult> Details(long id)
        {
            var product = await _productRepository
                .GetById(id);
            return View(product);
        }
    }
}