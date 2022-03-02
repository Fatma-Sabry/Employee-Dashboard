using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.BLL.Helber;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.UI.Controllers
{
    public class AccountController : Controller
    {
      
        #region Field
         private readonly UserManager<IdentityUserEX> userManager;
        private readonly SignInManager<IdentityUserEX> signInManager;

        #endregion
        public AccountController(UserManager<IdentityUserEX> userManager,SignInManager<IdentityUserEX> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Registration(Sign Up)

        [HttpGet]

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult>  Registration(RegistrationVM model)
        {
            try 
            {
                if (ModelState.IsValid) 
                {
                    var user = new IdentityUserEX
                    {
                        UserName =model.Email,
                        Email = model.Email,
                         IsAgree=model.IsAgree
                    };
            var Result= await userManager.CreateAsync(user,model.Password);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Login");

                    }
                    else 
                    {
                        foreach (var item in Result.Errors)
                        {
                            ModelState.AddModelError("",item.Description);
                        }
                    }
                }
                    return View(model);
            } catch (Exception ex) 
            {
                return View(model);
             
            }
         
        }
        #endregion

        #region Login (Sign In)
        [HttpGet]

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult>  Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                   var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RemeberMe,false);
                    if (result.Succeeded)
                    {

                       return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        
                            ModelState.AddModelError(""," Invaild UswrNameOrPassword"); 
                       // return View(model);  
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);

            }

        }


        #endregion

        #region Logoof (Sign Out)

        public async Task<IActionResult> Logoof() 
        {

            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        
        }


        #endregion

        #region Forget Password 
        [HttpGet]
        public IActionResult ForgetPass()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ConfirmForgetPass()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult>  ForegtPass(ForgetPassVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var user = await userManager.FindByEmailAsync(model.Email);
                        if (user != null)
                        {
                            var token = await userManager.GeneratePasswordResetTokenAsync(user);
                           var PasswordResetLink = Url.Action("ResetPass", "Account", new { Email=model.Email, Token = token }, Request.Scheme);
                            MailSender.SendMail(new MailVM { Mail = model.Email, Title = "Reset Passeord", Message = PasswordResetLink });
                            return RedirectToAction("ConfirmResetPass");
                        }

                        return View(model);

                    }  
                    catch (Exception) 
                    {
                        return View(model);
                    }
           

                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);

            }

        }
        #endregion


        #region Reset Password 
        [HttpGet]
        public IActionResult ResetPass(string Email,string Token)
        {
            return View();
        }

  
        [HttpPost]

        public async Task<IActionResult>  ResetPass(ResetPassVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPass");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }

                    return RedirectToAction("ResetPass");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);

            }
        }

    [HttpGet]
            public IActionResult ConfirmResetPass()
            {
                return View();
            }
        #endregion

    }
}
