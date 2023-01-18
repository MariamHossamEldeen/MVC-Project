using BLL.Interfaces;
using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IActionResult Index()
        {
            // 1 - ViewData
            ViewData["Message"] = "Hello View Data";
            // 2 - ViewBag
            ViewBag.Hamada = "Hello View Bag";
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                _departmentRepository.Add(department);
                // 3 - TempData
                TempData["Message"] = "Department Added Successfully";
                return RedirectToAction("Index");
            }
            return View(department);
        }
        // Department/Details/10
        public IActionResult Details( int? id , string viewName = "Details")
        {
            if(id == null)
                return NotFound();
            var department = _departmentRepository.Get(id.Value);
            if (department == null)
                return NotFound();

            return View(viewName , department);
        }
        // Department/Edit/10
        public IActionResult Edit(int? id)
        {
            return Details(id , "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id , Department department)
        {
            if(id != department.Id)
                return BadRequest();
            if(ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    _departmentRepository.Update(department);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(department);
                }
            }

            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int? id , Department department)
        {
            if (id != department.Id)
                return BadRequest();
            try
            {
                _departmentRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(department);
            }
        }
    }
}
