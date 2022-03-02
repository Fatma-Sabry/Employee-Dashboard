using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.DAL.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public  ICollection<Employee> Employee { get; set; }
    }
}
