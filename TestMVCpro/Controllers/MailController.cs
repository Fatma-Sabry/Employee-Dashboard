using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.BLL.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using TestMVCpro.BLL.Helber;

namespace TestMVCpro.UI.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailVM model)
        {
            try
            {
                TempData["MSG"] = MailSender.SendMail(model);
                return View();
            }
            catch (Exception EX)
            {
                TempData["MSG"] = MailSender.SendMail(model);
                return View();
            }
         
        }
    }

}
