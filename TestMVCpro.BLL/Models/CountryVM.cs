using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Models
{
   public class CountryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
