using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.UI.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUserEX> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUserEX> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var Roles = roleManager.Roles;
            return View(Roles);
        }
        [HttpGet]
        public IActionResult Create() 
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model) 
        {
            try { 

                if (ModelState.IsValid) 
                {   var Roles = new IdentityRole
            {
                Name = model.Name,
                NormalizedName = model.Name.ToUpper()
            };
            var Result = await roleManager.CreateAsync(Roles);
                    if (Result.Succeeded)
                        return RedirectToAction("Index");
 
                else  
                {
                    foreach (var item in Result.Errors)
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
        public async Task<IActionResult> Update(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var Roles = await roleManager.FindByIdAsync(model.Id);
                    Roles.Name = model.Name;
                    Roles.NormalizedName = model.Name.ToUpper();
                    var Result = await roleManager.UpdateAsync(Roles);
                    if (Result.Succeeded)
                        return RedirectToAction("Index");

                    else
                    {
                        foreach (var item in Result.Errors)
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
        //[HttpGet]
        //  public async Task<IActionResult> AddOrRemoveUser (string RoleId)
        //  {

        //      ViewBag.RoleId = RoleId;

        //      var role = await roleManager.FindByIdAsync(RoleId);

        //      var model = new List<UserInRoleVM>();

        //      foreach (var user in userManager.Users)
        //      {
        //          var userInRole = new UserInRoleVM()
        //          {
        //              UserId = user.Id,
        //              UserName = user.UserName
        //          };

        //          if (await userManager.IsInRoleAsync(user, role.Name))
        //          {
        //              userInRole.IsSelected = true;
        //          }
        //          else
        //          {
        //              userInRole.IsSelected = false;
        //          }

        //          model.Add(userInRole);
        //      }

        //      return View(model);

        //  }
        [HttpGet]
        public async Task<IActionResult> AddOrRemoveUser(string RoleId) 
        {
            ViewBag.RoleId = RoleId;
            var role = await roleManager.FindByIdAsync(RoleId);
            var model = new List<UserInRoleVM>();
            foreach (var user  in userManager.Users)
            {
                var UserInRole = new UserInRoleVM
                {
                    UserName = user.UserName,
                    UserId = user.Id
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                {

                    UserInRole.IsSelected = true;
                }
                else 
                {
                    UserInRole.IsSelected = false;
                }
                model.Add(UserInRole);
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveUser(List<UserInRoleVM> model, string RoleId)
        {

            var role = await roleManager.FindByIdAsync(RoleId);

            for (int i = 0; i < model.Count; i++)
            {

                var user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {

                    result = await userManager.AddToRoleAsync(user, role.Name);

                }
                else if (!model[i].IsSelected && (await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
            }
            //new { id = RoleId }لو عاوزة اروح لصفحة ب اى دى عن طريق ال نيو وال انا عملته دة
            return RedirectToAction("Update", new { id = RoleId });
        }
    }
}
