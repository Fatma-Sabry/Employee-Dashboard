using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.BLL.Models
{
   public class ForgetPassVM
    {
        [EmailAddress(ErrorMessage ="Invaled Mail")]
        [Required(ErrorMessage ="The Filed Requrid")]
        public string Email { get; set; }
    }
}
