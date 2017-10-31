using System;
using EmbeddedStock.Models;
using EmbeddedStock.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmbeddedStock.Controllers
{
    public class ComponentTypeController : Controller
    {
        private readonly IComponentTypeRepository _componentTypeRepository;

        public ComponentTypeController(
            IComponentTypeRepository componentTypeRepository)
        {
            _componentTypeRepository = componentTypeRepository;
        }

        // GET
        public IActionResult Index()
        {
            var vm = new ComponentTypeViewModel();
            vm.AllComponentTypes = _componentTypeRepository.GetAllComponentTypes();
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult CreateComponentType()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult EditComponentType()
        {
            throw new NotImplementedException();
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
            var vm = _componentTypeRepository.GetComponentType(componentTypeId);
            switch (button)
            {
                case "Create":
                    return View("CreateComponentType");
                case "Details":
                    return View("ComponentTypeDetails", vm);
                case "Edit":
                    return View("EditComponentType", vm);
                case "Delete":
                    return DeleteComponentType(componentTypeId);
                default:
                    return Index();
            }
        }
    }
}