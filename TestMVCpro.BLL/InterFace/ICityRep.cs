using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.InterFace
{
   public interface ICityRep
    {
        IEnumerable<City> Get(Expression<Func<City,bool> >fliter = null);
        City GetByID(int ID);
    }
}
