using System;
using System.Collections.Generic;
using System.Text;
using eCommerceApp.Abstractions.BLL;
using eCommerceApp.Abstractions.Repositories;
using eCommerceApp.BLL.Base;
using eCommerceApp.Models;

namespace eCommerceApp.BLL
{
    public class CategoryManager : Manager<Category>, ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}