using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Models
{
    public class CityVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }
}
