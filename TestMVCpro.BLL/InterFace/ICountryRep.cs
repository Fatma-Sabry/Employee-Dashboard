using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.InterFace
{
   public interface ICountryRep
    {
        IEnumerable<Country> Get();
        Country GetByID(int ID);
    }
}
