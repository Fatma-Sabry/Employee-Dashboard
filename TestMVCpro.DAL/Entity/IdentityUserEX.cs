using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.DAL.Entity
{
    public class IdentityUserEX:IdentityUser
    {
        public bool IsAgree{ get; set; }
    }
}
