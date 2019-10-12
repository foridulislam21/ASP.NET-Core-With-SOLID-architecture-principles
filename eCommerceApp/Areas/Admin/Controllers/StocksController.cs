using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using eCommerceApp.Abstractions.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eCommerceApp.Models;

namespace eCommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StocksController : Controller
    {
        private readonly IStockManager _stockManager;
        private readonly IProductManager _iProductManager;

        public StocksController(IStockManager stockManager, IProductManager iProductManager)
        {
            _stockManager = stockManager;
            _iProductManager = iProductManager;
        }
        
        [Route("Stock/Index")]
        public async Task<IActionResult> Index()
        {
            var stock = await _stockManager.GetAll();
            return View(stock);
        }
        [Route("Stock/Create")]
        public IActionResult Create()
        {
            PopulateProduct();
            return View();
        }
        [Route("Stock/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Stock stock)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _stockManager.Add(stock);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Added Successfully";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Operation Failed!";
            }
            PopulateProduct(stock.ProductId);
            return RedirectToAction(nameof(Index));
        }

        private  void PopulateProduct(object selectList = null)
        {
            var products =  _iProductManager.GetAll();
            ViewBag.ProductId = new SelectList(products,"Id","Name",selectList);
        }
    }
}