
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUserEX> userManager;

        public UserController(UserManager<IdentityUserEX> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var DataOfUsers = userManager.Users;
            return View(DataOfUsers);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string ID)
        {
            var Data = await userManager.FindByIdAsync(ID);
            return View(Data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IdentityUser model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByIdAsync(model.Id);
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    var R = await userManager.UpdateAsync(user);
                    if (R.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    else
                    {
                        foreach (var item in R.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }

                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }


        }
        [HttpGet]
        public async Task<IActionResult>  Delete(string Id) 
        {
         var Data =await userManager.FindByIdAsync(Id);
            return View(Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IdentityUser model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByIdAsync(model.Id);
                    var r = await userManager.DeleteAsync(user);
                    if (r.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }

                    else
                    {
                        foreach (var item in r.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }

                    }

                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }
        [HttpGet]
        public async Task<IActionResult> Details(IdentityUser model) 
        {
           // var data = userManager.Users.Select(a=>a).Where(a=>a.Id=model.Id);
          var user = await userManager.FindByIdAsync(model.Id);
            
            return View(user);
        }
    }
}
