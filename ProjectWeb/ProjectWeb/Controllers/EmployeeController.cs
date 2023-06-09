﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectWeb.Models;
using ProjectWeb.Repository.Contracts;

namespace ProjectWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var entity = _employeeRepository.GetAll();
            return View(entity);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var entity = _employeeRepository.GetById(id);
            return View(entity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Male",
                    Value = "0",
                },
                new SelectListItem
                {
                    Text = "Female",
                    Value = "1",
                }
            };

            ViewBag.Gender = gender;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee) 
        {
            _employeeRepository.Insert(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var gender = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Male",
                    Value = "0",
                },
                new SelectListItem
                {
                    Text = "Female",
                    Value = "1",
                }
            };

            ViewBag.Gender = gender;
            var entity = _employeeRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            _employeeRepository.Update(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var entity = _employeeRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(string id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
