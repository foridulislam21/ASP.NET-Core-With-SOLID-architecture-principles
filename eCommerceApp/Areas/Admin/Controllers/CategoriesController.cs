using System.Linq;
using System.Threading.Tasks;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [Route("Category/Index")]
        public async Task<IActionResult> Index()
        {
            var category = await _categoryManager.GetAll();
            return View(category);
        }

        [Route("Category/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Category/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = await _categoryManager.Add(category);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Added Successfully";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Operation failed";
            }
            return RedirectToAction("Index");
        }
    }
}