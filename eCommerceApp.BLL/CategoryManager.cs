using System;
using System.Collections.Generic;
using System.Text;
using eCommerceApp.Models;
using eCommerceApp.Repositories;

namespace eCommerceApp.BLL
{
    public class CategoryManager
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryManager(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICollection<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }
    }
}