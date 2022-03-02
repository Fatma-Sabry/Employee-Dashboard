using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.BLL.Models
{
   public class ResetPassVM
    {
        [Required(ErrorMessage = "This Filed Is Required")]
        [MinLength(6, ErrorMessage = "The MinLength 6")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This Filed Is Required")]
        [MinLength(6, ErrorMessage = "The MinLength 6")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
