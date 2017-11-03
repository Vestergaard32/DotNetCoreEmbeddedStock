using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmbeddedStock.Repositories;
using EmbeddedStock.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmbeddedStock.Controllers
{
    public class ComponentController : Controller
    {
        private IComponentRepository _componentRepository;
        private IComponentTypeRepository _componentTypeRepository;

        public ComponentController(IComponentRepository componentRepository, IComponentTypeRepository componentTypeRepository)
        {
            _componentRepository = componentRepository;
            _componentTypeRepository = componentTypeRepository;
        }

        public IActionResult Index()
        {
            ViewBag.ComponentTypes = new SelectList(_componentTypeRepository.GetAllComponentTypes(), "ComponentTypeId", "ComponentName");

            return View("Index");
        }

        public IActionResult NewComponent()
        {
            ViewBag.ComponentTypes = new SelectList(_componentTypeRepository.GetAllComponentTypes(), "ComponentTypeId", "ComponentName");

            return View("CreateComponent");
        }

        public IActionResult CreateComponent(string buttonValue, Component input)
        {
            if (buttonValue == "Cancel")
            {
                return RedirectToAction("Index");
            }

            _componentRepository.CreateComponent(input);

            return RedirectToAction("Index");
        }

        public IActionResult EditComponent(Component componentToUpdate)
        {
            _componentRepository.UpdateComponent(componentToUpdate);

            return RedirectToAction("Index");
        }

        public IActionResult SelectComponentType(int componentTypeId)
        {
            ViewBag.Components = _componentRepository.GetComponentsWithComponentType(componentTypeId);
            ViewBag.ComponentTypes = new SelectList(_componentTypeRepository.GetAllComponentTypes(), "ComponentTypeId", "ComponentName");

            return View("Index");
        }

        public IActionResult ManageComponent(long componentId, string buttonValue)
        {
            ViewBag.ComponentTypes = new SelectList(_componentTypeRepository.GetAllComponentTypes(), "ComponentTypeId", "ComponentName");
            var component = _componentRepository.GetComponent(componentId);

            switch (buttonValue)
            {
                case "Details":
                    return Index();
                    break;
                case "Edit":
                    return View("EditComponent", component);
                    break;
                case "Delete":
                    _componentRepository.DeleteComponent(componentId);
                    return Index();
                    break;
                default:
                    return Index();
            }
        }
    }
}