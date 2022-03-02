using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.DAL.Entity
{
    public class Country
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public ICollection<City> Cities { get; set; }

    }
}
