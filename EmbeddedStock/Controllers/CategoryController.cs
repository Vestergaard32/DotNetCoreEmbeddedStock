using System.Collections.Generic;
using EmbeddedStock.Models;
using EmbeddedStock.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmbeddedStock.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View("CategoryIndex");
        }

        public void CreateCategory(string categoryName)
        {
            _categoryRepository.CreateCategory(categoryName);
        }

        public void DeleteCategory()
        {
            
        }

        public void UpdateCategory()
        {
            
        }

        public Category GetSingleCategory()
        {
            return null;
        }

        public List<Category> GetAllCategories()
        {
            return null;
        }
    }
}