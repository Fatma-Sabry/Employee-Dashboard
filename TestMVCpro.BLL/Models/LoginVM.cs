using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.BLL.Models
{
   public class LoginVM
    {
        [EmailAddress(ErrorMessage = "Invalid Mail ")]
        [Required(ErrorMessage = "This Filed Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This Filed Is Required")]
        [MinLength(6, ErrorMessage = "The MinLength 6")]
        public string Password { get; set; }
        public bool RemeberMe { get; set; }
    }
}
