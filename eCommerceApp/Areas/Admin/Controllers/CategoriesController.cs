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

        [Route("Admin/Index")]
        public IActionResult Index()
        {
            var category = _categoryManager.GetAll();
            return View(category);
        }

        [Route("Admin/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Admin/Create")]
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _categoryManager.Add(category);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Added Successfully";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Operation failed";
            }
            return View(category);
        }
    }
}