using AutoMapper;
using BLL.Interfaces;
using BLL.Repositories;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using PL.Helpers;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                var employees = await _unitOfWork._EmployeeRepository.GetAll();

                var mappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmployees);
            }
            else
            {
                var employees =  _unitOfWork._EmployeeRepository.GetEmployeesByName(searchValue);
                var mappedEmployees = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
                return View(mappedEmployees);

            }
            
          
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await _unitOfWork._DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid) // Server Side Validation
            {

                #region Manual Mapping
                //var mappedEmployee = new Employee()
                //{
                //Name = employeeVM.Name,
                //Address = employeeVM.Address,
                //Salary = employeeVM.Salary,
                //Age = employeeVM.Age,
                //PhoneNumber = employeeVM.PhoneNumber,
                //Email = employeeVM.Email,
                //DepartmentId = employeeVM.DepartmentId,
                //IsActive = employeeVM.IsActive,
                //};

                #endregion

                employeeVM.ImageName = DocumentSettings.UploadFile(employeeVM.Image, "images");

                var mappedEmployee =  _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                await _unitOfWork._EmployeeRepository.Add(mappedEmployee);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }
        // Employee/Details/10
        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var employee = await _unitOfWork._EmployeeRepository.Get(id.Value);
            if (employee == null)
                return NotFound();
            var mappedEmployee = _mapper.Map<Employee, EmployeeViewModel>(employee);
            return View(viewName, mappedEmployee);
        }
        // Employee/Edit/10
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = await _unitOfWork._DepartmentRepository.GetAll();

            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employeeVM)
        {
            //if (id != employee.Id)
            //    return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    await _unitOfWork._EmployeeRepository.Update(mappedEmployee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(employeeVM);
                }
            }

            return View(employeeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, EmployeeViewModel employeeVM)
        {
  
            try
            {
                var mappedEmployee = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                int count = await _unitOfWork._EmployeeRepository.Delete(mappedEmployee);
                if(count > 0)
                    DocumentSettings.DeleteFile(employeeVM.ImageName, "images");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(employeeVM);
            }
        }
    }
}
