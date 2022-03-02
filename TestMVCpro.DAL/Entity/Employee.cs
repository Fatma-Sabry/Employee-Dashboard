using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.DAL.Entity
{
    [Table("Employee")]
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double  Salary { get; set; }
        public DateTime HireDate{ get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public int DepartmentID{ get; set; }
        public  Department Department { get; set; }
        [ForeignKey("DistrictID")]
        public int DistrictID { get; set; }
        
        public District District { get; set; }
        public string PhotoName { get; set; }
        public string CvName { get; set; }

    }
}
