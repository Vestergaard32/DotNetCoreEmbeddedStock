using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EmbeddedStock.Models;
using EmbeddedStock.Repositories;

namespace EmbeddedStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IComponentTypeRepository _componentTypeRepository;
        private readonly IComponentRepository _componentRepository;

        public HomeController(
            ICategoryRepository categoryRepository, 
            IComponentTypeRepository componentTypeRepository, 
            IComponentRepository componentRepository)
        {
            _categoryRepository = categoryRepository;
            _componentTypeRepository = componentTypeRepository;
            _componentRepository = componentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
