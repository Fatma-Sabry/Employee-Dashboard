using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMVCpro.UI.Controllers
{
    [Authorize]
    public class EMPandDEPTController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
