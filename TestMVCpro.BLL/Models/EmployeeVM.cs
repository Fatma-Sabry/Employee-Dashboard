using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Models
{
   public class EmployeeVM
    {
        public EmployeeVM()
        {
            CreationDate = DateTime.Now;
        }
        public int ID { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Salary Is Required")]
        [Range(3000,5000,ErrorMessage ="Rang BTW 3K ,5k ")]
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; }
        [RegularExpression("[0-9]{3,10}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}")]
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }   
       [EmailAddress(ErrorMessage ="Mail  not Valid")]
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public int DistrictID { get; set; }
        public District District { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile CV { get; set; }
    }
}
