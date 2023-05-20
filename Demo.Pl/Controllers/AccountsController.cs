using Demo.DAL.Entities;
using Demo.Pl.Consts;
using Demo.Pl.Helper;
using Demo.Pl.Models.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace Demo.Pl.Controllers
{
    public class AccountsController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }
        public SignInManager<ApplicationUser> SignInManager { get; }

        public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            UserManager = userManager;
          SignInManager = signInManager;
        }
        
        #region Register

        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email.Split('@')[0],
                    Email = model.Email,
                    IsAgree = model.IsAgree
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user, Role.User);   // when user has been  created  its Role will be User
                   return RedirectToAction(nameof(Login));
                }


                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);

        }
        #endregion

        #region Login

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel? model)
        {
            if (ModelState.IsValid) {
                var user =await UserManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var password = await UserManager.CheckPasswordAsync(user, model.Password);
                    if (password)
                    {
                     var result = await SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe ,false);

                        if (result.Succeeded) {
                            return RedirectToAction("Index", "Home");
                        }

                    }

                }

            }

            return View(model);
        }


        #endregion

        #region SignOut
        public async new Task<IActionResult> SignOut() {  /// mvc have function of this name and I use new keyword to tell it i need copy to me  

            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));        
                
                }
        #endregion

        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword() {
            return View();
        }
        [HttpPost]
        public  async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null) {
                    var token = await UserManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordLink = Url.Action("ResetPassword", "Accounts", new { Email = model.Email, Token = token }, Request.Scheme);
                    var email = new Email()
                    {
                        Title = "Reset Passwrod!",
                        To = model.Email,
                        Body = resetPasswordLink
                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CompleteForgetPassword));
                
                }
                ModelState.AddModelError(string.Empty, "Email not Exist!");
            }
            return View(model);
        }

        public IActionResult CompleteForgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword(string email , string token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid) {
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user != null) {

                    var IsPasswordReset = await UserManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                    if (IsPasswordReset.Succeeded)
                        return RedirectToAction(nameof(ResetPasswordComplete));
                    foreach (var error in IsPasswordReset.Errors)

                    {   ModelState.AddModelError(string.Empty, error.Description);
                    
                    }

                    return View(model);

                }
                ModelState.AddModelError(string.Empty, "This email is not exist!");
            
            }
            return View(model);
        }

        public IActionResult ResetPasswordComplete ()
        {
            return View();
        }
        #endregion


        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied() {

            return View();
        }
    }
}
