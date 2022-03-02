using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.BLL.InterFace;
using TestMVCpro.DAL.Database;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Reposatiry
{
    public class DistrictRep: IDistrictRep
    {
        TestMVCproContext db;
        public DistrictRep(TestMVCproContext db)
        {
            this.db = db;

        }
        public IEnumerable<District> Get(Expression<Func<District, bool>> fliter = null)
        {
            var data = db.District.Select(a => a);
            if (fliter == null)
            {

                return data;
            }
            else
            {
                return db.District.Where(fliter);
            }
        }


        public District GetByID(int ID)
        {
            var data = db.District.Where(a => a.ID == ID).FirstOrDefault();
            return data;
        }

      
    }
}
