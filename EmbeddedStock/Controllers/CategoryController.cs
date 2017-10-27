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
            var vm = new CategoryViewModel();
            vm.AllCategories = _categoryRepository.GetAllCategories();
            return View("Index", vm);
        }
        
        [HttpPost]
        public IActionResult CreateCategory(string categoryName)
        {
            _categoryRepository.CreateCategory(categoryName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(long categoryId)
        {
            _categoryRepository.DeleteCategory(categoryId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCategory(long categoryId, string categoryName)
        {
            _categoryRepository.UpdateCategory(categoryId, categoryName);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ManageCategory(long categoryId, string categoryName, string button)
        {
            switch (button)
            {
                case "Update":
                    return UpdateCategory(categoryId, categoryName);
                case "Delete":
                    return DeleteCategory(categoryId);
                default:
                    return RedirectToAction("Index");
            }
        }
    }
}