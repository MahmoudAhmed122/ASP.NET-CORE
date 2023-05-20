using Demo.DAL.Entities;
using Demo.Pl.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Demo.Pl.Controllers
{
    [Authorize(Roles =Role.Admin)]
    public class UsersController : Controller
    {

        public UserManager<ApplicationUser> UserManager { get; }


        public UsersController(UserManager<ApplicationUser> userManager)
        {
            UserManager = userManager;
        }


        public async Task<IActionResult> Index(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue))
            {
                var users = await UserManager.Users.ToListAsync();
                return View(users);

            }
            var searchedUser = await UserManager.FindByEmailAsync(searchValue);
         
             return View(new List<ApplicationUser>() { searchedUser });

         
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser updatedUser)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(updatedUser.Id);
                user.UserName = updatedUser.UserName;
                user.NormalizedUserName = updatedUser.UserName.ToUpper();
                user.PhoneNumber = updatedUser.PhoneNumber;
                await UserManager.UpdateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedUser);

        }
        [HttpGet]

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
                return NotFound();
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();
            return View(user);
        }
        [HttpPost]

        public async Task<IActionResult> Delete(ApplicationUser deletedUser)
        {

            var user = await UserManager.FindByIdAsync(deletedUser.Id);
            var isDeleted = await UserManager.DeleteAsync(user);
            if (isDeleted.Succeeded)
                return RedirectToAction(nameof(Index));

            foreach (var error in isDeleted.Errors)

                ModelState.AddModelError(string.Empty, error.Description);

            return View(deletedUser);

        }


    }
}
