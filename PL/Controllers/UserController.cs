using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PL.Helpers;
using PL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization;

namespace PL.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string searchValue)
        {
            var users = Enumerable.Empty<ApplicationUser>().ToList();
            if (string.IsNullOrEmpty(searchValue))
                users.AddRange(_userManager.Users);
            else
                users.Add(await _userManager.FindByEmailAsync(searchValue));

            return View(users);
        }
 
        
       
        public async Task<IActionResult> Details(string id, string viewName = "Details")
        {
            if (id == null)
                return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            
            return View(viewName, user);
        }
     
        public async Task<IActionResult> Edit(string id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, ApplicationUser updatedUser)
        {
            if (id != updatedUser.Id)
                return BadRequest();
            if (ModelState.IsValid) // Server Side Validation
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(id);
                    user.UserName = updatedUser.UserName;
                    user.PhoneNumber = updatedUser.PhoneNumber;

                    //user.Email = updatedUser.Email;
                    //user.SecurityStamp = updatedUser.SecurityStamp;

                    await _userManager.UpdateAsync(user); 
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(updatedUser);
                }
            }

            return View(updatedUser);
        }

        public async Task<IActionResult> Delete(string id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(string id, ApplicationUser deletedUser)
        {
            if (id != deletedUser.Id)
                return BadRequest();
            try
            {
                await _userManager.DeleteAsync(deletedUser); // Will Throw Error
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(deletedUser);
            }
        }
    }
}
