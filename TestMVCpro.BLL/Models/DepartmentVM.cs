using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.BLL.Models
{
     public class DepartmentVM
    {
        public int ID { get; set; }
        [Required (ErrorMessage ="The Name Required")]
        [MaxLength(50,ErrorMessage ="The Max Length is 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Code Required")]
        public int Code { get; set; }
    }
}
