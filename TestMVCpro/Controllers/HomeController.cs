using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.UI.Languages;

namespace TestMVCpro.UI.Controllers
{
    [Authorize(Roles="Admin,User,Test")]
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> localizer;

        public HomeController(IStringLocalizer<SharedResource> localizer)
        {
            this.localizer = localizer;
        }
        public IActionResult Index()
        {
            ViewBag.Msg = localizer["DASHBOARD"];
            return View();
        }
    }
}
