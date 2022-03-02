using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.BLL.InterFace;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;
using System.IO;
using TestMVCpro.BLL.Helber;
using Microsoft.AspNetCore.Authorization;

namespace TestMVCpro.UI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ICityRep city;
        private readonly IDistrictRep district;
        private readonly IEmployeeRep employee;
        private readonly IMapper mapper;
        private readonly IDepartmentRep department;

        public EmployeeController(ICityRep city,IDistrictRep district,IEmployeeRep employee, IMapper mapper,IDepartmentRep department)
        {
            this.city = city;
            this.district = district;
            this.employee = employee;
            this.mapper = mapper;
            this.department = department;
        }
        public IActionResult Index(string Searchvalue="")
        {
            if (Searchvalue == "")
            {
                var model = employee.Get();
                var data = mapper.Map<IEnumerable<EmployeeVM>>(model);
                return View(data);
            }
            else  
            {

                var model = employee.SearchByName(Searchvalue);
                var data = mapper.Map<IEnumerable<EmployeeVM>>(model);
                return View(data);

            }
         
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM model)
        {
           try
            {
                
               if (ModelState.IsValid) 
               {
                    //#region  Image

                    //string FolderPath = Directory.GetCurrentDirectory() +"/wwwroot/Files/Images/";

                    //string FileName = Guid.NewGuid() +Path.GetFileName(model.Photo.FileName);

                    //string FinalPath = FolderPath+ FileName;

                    //using (var stream = new FileStream(FinalPath,FileMode.Create)) 
                    //{
                    //    model.Photo.CopyTo(stream);

                    //}

                    //#endregion

                    model.PhotoName = FileUploader.FileUploade("/wwwroot/Files/Images/",model.Photo);
                    model.CvName = FileUploader.FileUploade("/wwwroot/Files/Docs/", model.CV);
                    var data = mapper.Map<Employee>(model);

                    employee.Create(data);
                    return  RedirectToAction("Index");
               }
              ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name");
               return View(model);    
            }
            
           catch (Exception ex)
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name");

              return View(model);
  
           }
        
        }
        public IActionResult Details(int ID) 
        {

            var model = employee.GetByID(ID);
            var data = mapper.Map<EmployeeVM>(model);
            ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name",model.ID);
            return View(data);     
        }
        public IActionResult Update(int ID) 
        {

            var data = employee.GetByID(ID);
            var model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name", model.ID);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(EmployeeVM model)
        {
          try
            {
               if (ModelState.IsValid)
               {
                    var m = mapper.Map<Employee>(model);
                     employee.Update(m);
        ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name", model.ID);
                  return RedirectToAction("Index");
                    
                }
                ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name", model.ID);
                return View(model);

           }
          catch (Exception ex)
         {
              ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name", model.ID);

              return View();
           }
            
        }
        [HttpGet]
        public IActionResult Delete(int ID) 
        {
            var data = employee.GetByID(ID);
            var Model = mapper.Map<EmployeeVM>(data);
            ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name",ID);

            return View(Model); 
        }
        [HttpPost]
        public IActionResult Delete(EmployeeVM vM)
        {
            try
            {
                var Model = mapper.Map<Employee>(vM);
                employee.Delete(Model);
                FileUploader.RemoveFile("/wwwroot/Files/Images/", Model.PhotoName);
                FileUploader.RemoveFile("/wwwroot/Files/Images/",vM.CvName);

                ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name", vM.ID);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                ViewBag.DepartmentList = new SelectList(department.Get(), "ID", "Name", vM.ID);

                return View(vM);
            }
          
        }
        #region 
        [HttpPost]
        public JsonResult GetCityDataByCountryID(int CountryID) 
        {
            var data = city.Get(a => a.CountryID == CountryID);
            var model = mapper.Map<IEnumerable<CityVM>>(data);

            return Json(model);
        }

        [HttpPost]
        public JsonResult DistrictDataByCityID(int CityID)
        {
            var data = district.Get(a => a.CityID == CityID);
            var model = mapper.Map<IEnumerable<DistrictVM>>(data);

            return Json(model);
        }
        #endregion

    }
}
