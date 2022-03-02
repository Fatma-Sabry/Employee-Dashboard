using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestMVCpro.BLL.Helber;
using TestMVCpro.BLL.InterFace;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;

namespace TestAPIPRO.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Fialed

        private readonly IEmployeeRep employeee;
        private readonly IMapper mappre;

        #endregion

        #region Ctor
        public EmployeeController(IEmployeeRep employeee, IMapper mappre)
        {
            this.employeee = employeee;
            this.mappre = mappre;
        }
        #endregion

        #region APIS
      [Route("~/Api/GetEmployee")]
        [HttpGet]
        public IActionResult GetEmployee() 
        {
            try
            {

                var data = employeee.Get();
                var model = mappre.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponce<IEnumerable<EmployeeVM>>
                {
                    Code = "200",
                    Message = "Data Retrive",
                    Statues = "OK",
                    Data = model
                }); 
            } catch (Exception ex) 
            {


                return NotFound(new ApiResponce<IEnumerable<EmployeeVM>>
                {
                    Code = "400",
                    Message = "Data NOT Retrive",
                    Statues = "Not Found",
                });

            }
         
        }


        [Route("~/Api/GetEmployeeByID/{id}")]
        [HttpGet]
        public IActionResult GetEmployeeByID(int ID)
        {
            try
            {

                var data = employeee.GetByID(ID);
                var model = mappre.Map<EmployeeVM>(data);
                return Ok(new ApiResponce<EmployeeVM>
                {
                    Code = "200",
                    Message = "Data Retrive",
                    Statues = "OK",
                    Data = model
                });
            }
            catch (Exception ex)
            {


                return NotFound(new ApiResponce<EmployeeVM>
                {
                    Code = "400",
                    Message = "Data NOT Retrive",
                    Statues = "Not Found",
                });

            }

        }


        [Route("~/Api/PostEmployee")]
        [HttpPost]
        public IActionResult PostEmployee(EmployeeVM employeevm)
        {
            try
            {
          var model = mappre.Map<Employee>(employeevm);
                 employeee.Create(model);
              
                return Ok(new ApiResponce<Employee>
                {
                    Code = "200",
                    Message = "Data Created",
                    Statues = "OK",
                });
            }
            catch (Exception ex)
            {


                return NotFound(new ApiResponce<EmployeeVM>
                {
                    Code = "400",
                    Message = "Data NOT Retrive",
                    Statues = "Not Found",
                });

            }

        }


        [Route("~/Api/PUTEmployee")]
        [HttpPut]
        public IActionResult PUTEmployee(EmployeeVM employeevm)
        {
            try
            {
                var model = mappre.Map<Employee>(employeevm);
                employeee.Update(model);

                return Ok(new ApiResponce<Employee>
                {
                    Code = "200",
                    Message = "Data Updated",
                    Statues = "OK",
                  //  Data=R
                });
            }
            catch (Exception ex)
            {


                return NotFound(new ApiResponce<EmployeeVM>
                {
                    Code = "400",
                    Message = "Data NOT Retrive",
                    Statues = "Not Found",
                });

            }

        }

        [Route("~/Api/DelteEmployee")]
        [HttpDelete]
        public IActionResult DelteEmployee(EmployeeVM employeevm)
        {
            try
            {
                var model = mappre.Map<Employee>(employeevm);
                employeee.Delete(model);

                return Ok(new ApiResponce<Employee>
                {
                    Code = "200",
                    Message = "Data Delted",
                    Statues = "OK",
                    //  Data=R
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponce<EmployeeVM>
                {
                    Code = "400",
                    Message = "Data NOT Retrive",
                    Statues = "Not Found",
                });

            }

        }
        #endregion
    }
}
