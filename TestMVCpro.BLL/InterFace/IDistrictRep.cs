using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.InterFace
{
   public interface IDistrictRep
    {
        IEnumerable<District> Get(Expression<Func<District, bool>> fliter = null);
        District GetByID(int ID);
    }
}
