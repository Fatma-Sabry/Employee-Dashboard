using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Models
{
   public class DistrictVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
