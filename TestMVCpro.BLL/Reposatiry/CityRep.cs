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
  public  class CityRep: ICityRep
    {
        TestMVCproContext db;
        public CityRep(TestMVCproContext db)
        { 
        this.db = db;  

        }
        public IEnumerable<City> Get(Expression<Func<City, bool>> fliter = null)
        {
            var data = db.City.Select(a => a);

            if (fliter == null)
            {
                
                return data;
            }
            else  
            { 
                return db.City.Where(fliter);
            }
           
        }


        public City GetByID(int ID)
        {
            var data = db.City.Where(a => a.ID == ID).FirstOrDefault();
            return data;
        }
    }
}
