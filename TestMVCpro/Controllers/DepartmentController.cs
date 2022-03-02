using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.BLL;
using TestMVCpro.BLL.InterFace;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.UI.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
 
        private readonly IDepartmentRep rep;
        private readonly IMapper MA;
        public DepartmentController(IDepartmentRep X,IMapper mapper)
        {
            this.rep = X;
            this.MA = mapper;
        }
        public IActionResult Index()
        {
           
            var data = rep.Get();
            var model = MA.Map<IEnumerable<DepartmentVM>>(data);
            return View(model);
        }
        public IActionResult Details(int ID )
        { 
           var data= rep.GetByID(ID);
            var model = MA.Map<DepartmentVM>(data);
            return View(model);
        }
        public IActionResult Detete( int ID)
        {
            var data = rep.GetByID(ID);
            var model = MA.Map<DepartmentVM>(data);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(DepartmentVM model)
        {
            var data = MA.Map<Department>(model);

            rep.Delete(data);
            return View();
        }
        [HttpGet]
        public IActionResult Update(int ID)
        {
            var data = rep.GetByID(ID);
            var model = MA.Map<DepartmentVM>(data);
            return View( model);
        }

        [HttpPost]
        public IActionResult Update(DepartmentVM vM)
        {
            var model = MA.Map<Department>(vM);

            if (ModelState.IsValid)
                {
                    rep.Update(model);
                    return RedirectToAction("Update");
                }
                return View(vM);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM vM)
        {
            try {
                var model = MA.Map<Department>(vM);
                 if (ModelState.IsValid)
                {
                    rep.Create(model);
                    return RedirectToAction("Index");
                }
                return View(vM);
            }
            catch (Exception ex)
            {

                return View(vM);
            }


        }
    }
}
