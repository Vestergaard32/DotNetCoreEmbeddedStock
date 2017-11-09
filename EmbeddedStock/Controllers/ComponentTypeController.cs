using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EmbeddedStock.Models;
using EmbeddedStock.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmbeddedStock.Controllers
{
    public class ComponentTypeController : Controller
    {
        private readonly IComponentTypeRepository _componentTypeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IComponentTypeCategoryRepository _componentTypeCategoryRepository;

        public ComponentTypeController(
            IComponentTypeRepository componentTypeRepository, 
            ICategoryRepository categoryRepository,
            IComponentTypeCategoryRepository componentTypeCategoryRepository)
        {
            _componentTypeRepository = componentTypeRepository;
            _categoryRepository = categoryRepository;
            _componentTypeCategoryRepository = componentTypeCategoryRepository;
        }

        // GET
        public IActionResult Index()
        {
            var vm = new ComponentTypeViewModel();
            vm.AllComponentTypes = _componentTypeRepository.GetAllComponentTypes();
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult CreateComponentType(string Button, ComponentType input, IFormFile image, List<long> CategoryIds)
        {
            switch (Button)
            {
                case "Cancel":
                    return RedirectToAction("Index");
                default:
                    ESImage esImage = null;
                    if (image != null)
                    {
                        using (var ms = image.OpenReadStream())
                        {
                            byte[] buffer = new byte[ms.Length];
                            ms.Seek(0, SeekOrigin.Begin);
                            ms.ReadAsync(buffer, 0, (int)ms.Length);
                            esImage = new ESImage();
                            esImage.ImageData = buffer;
                        }
                    }

                    input.Image = esImage;
                    _componentTypeRepository.CreateComponentType(input);

                    var categories = _categoryRepository.GetAllCategories()
                        .Where(category => CategoryIds.Contains(category.CategoryId))
                        .ToList();

                    foreach (var category in categories)
                    {
                        _componentTypeCategoryRepository.CreateComponentTypeCategory(input, category);
                    }
                    return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditComponentType(string button, ComponentType input, IFormFile image, List<long> categoryIds)
        {
            switch (button)
            {
                case "Cancel":
                    return RedirectToAction("Index");
                case "Update":
                    if (image == null)
                    {
                        var oldComponent = _componentTypeRepository.GetComponentType(input.ComponentTypeId);
                        input.Image = oldComponent.Image;
                    }
                    if (image != null)
                    {
                        using (var ms = image.OpenReadStream())
                        {
                            var buffer = new byte[ms.Length];
                            ms.Seek(0, SeekOrigin.Begin);
                            ms.ReadAsync(buffer, 0, (int)ms.Length);
                            var esImage = new ESImage {ImageData = buffer};
                            input.Image = esImage;
                        }
                    }
                    
                    _componentTypeRepository.UpdateComponentType(input);
                    var categories = _categoryRepository.GetAllCategories()
                        .Where(category => categoryIds.Contains(category.CategoryId))
                        .ToList();

                    _componentTypeCategoryRepository.ClearComponentTypeCategoriesForComponentType(input.ComponentTypeId);
                    
                    foreach (var category in categories)
                    {
                        _componentTypeCategoryRepository.CreateComponentTypeCategory(input, category);
                    }
                    return RedirectToAction("Index");
                default:
                    return RedirectToAction("Index");
            }            
        }

        [HttpPost]
        public IActionResult DeleteComponentType(long componentTypeId)
        {
            _componentTypeRepository.DeleteComponentType(componentTypeId);
            return Index();
        }

        [HttpPost]
        public IActionResult ManageComponentType(long componentTypeId, string button)
        {
            switch (button)
            {
                case "Create":
                    ViewBag.CategoryCollection = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "Name");
                    return View("CreateComponentType");
                case "Details":
                    var vmodel = _componentTypeRepository.GetComponentType(componentTypeId);
                    return View("ComponentTypeDetails", vmodel);
                case "Edit":
                    var vm = _componentTypeRepository.GetComponentType(componentTypeId);
                    ViewBag.CategoryCollection = new SelectList(_categoryRepository.GetAllCategories(), "CategoryId", "Name");                    
                    return View("EditComponentType", vm);
                case "Delete":
                    return DeleteComponentType(componentTypeId);
                default:
                    return Index();
            }
        }
    }
}