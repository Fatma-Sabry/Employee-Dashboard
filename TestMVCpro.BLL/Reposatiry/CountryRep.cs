using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.BLL.InterFace;
using TestMVCpro.DAL.Database;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Reposatiry
{
    public class CountryRep : ICountryRep
    {
        TestMVCproContext db;
        public CountryRep(TestMVCproContext db)
        {
            this.db = db;  
        }
        public IEnumerable<Country> Get()
        {
            var data = db.Country.Select(a=>a);
            return data;
        }


        public Country GetByID(int ID)
        {  var data = db.Country.Where(a => a.ID==ID).FirstOrDefault();
            return data;
        }
    }
}
