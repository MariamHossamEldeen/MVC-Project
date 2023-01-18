using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System;
using PL.Helpers;
using PL.Models;

namespace PL.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index(string searchValue)
        {
            var roles = Enumerable.Empty<IdentityRole>().ToList();
            if (string.IsNullOrEmpty(searchValue))
                roles.AddRange(_roleManager.Roles);
            else
                roles.Add(await _roleManager.FindByNameAsync(searchValue));

            return View(roles);
        }


        public IActionResult Create()
        {
            return  View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid) // Server Side Validation
            {
                await _roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }


        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            return View(viewName, role);
        }

        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, IdentityRole updatedRole)
        {
            if (id != updatedRole.Id)
                return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    role.Name = updatedRole.Name;
                    await _roleManager.UpdateAsync(role);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(updatedRole);
                }
            }

            return View(updatedRole);
        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(string id, IdentityRole deletedRole)
        {
            if (id != deletedRole.Id)
                return BadRequest();
            try
            {
                await _roleManager.DeleteAsync(deletedRole); // Will Throw Error
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(deletedRole);
            }
        }
    }
}
