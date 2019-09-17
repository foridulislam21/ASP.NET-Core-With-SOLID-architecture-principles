using System.Linq;
using System.Threading.Tasks;
using eCommerce.DatabaseContext;
using eCommerceApp.BLL;
using eCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private ProductManager _productManager;
        private CategoryManager _categoryManager;

        public ProductsController(ProductManager productManager, CategoryManager categoryManager)
        {
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        [Route("Admin/Index")]
        public IActionResult Index()
        {
            var product = _productManager.GetAll();
            return View(product);
        }

        public IActionResult Create()
        {
            PopulateCategoryList();
            return View();
        }

        private void PopulateCategoryList(object selectCategory = null)
        {
            var category = _categoryManager.GetAll();
            ViewBag.CategoryId = new SelectList(category, "Id", "Name", selectCategory);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                bool isAdded = _productManager.Add(product);
                if (isAdded)
                {
                    ViewBag.SuccessMessage = "Added SuccessFully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Operation Failed";
                }
            }
            return View();
        }
    }
}