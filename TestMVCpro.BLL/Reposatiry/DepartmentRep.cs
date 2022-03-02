using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.BLL.InterFace;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Database;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL
{
   public class DepartmentRep : IDepartmentRep
    {
        
        private readonly TestMVCproContext db;

        public DepartmentRep(TestMVCproContext db)
        {
            this.db = db;
        }
        public void Create(Department model)
        {
         
            db.Department.Add(model);
            db.SaveChanges();
        }

        public void Delete(Department model)
        {
          
            db.Department.Remove(model);
            db.SaveChanges();
        }

        public void Update(Department model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Department> Get()
        {
            var data = db.Department.Select(a => a);
            return data;
        }

         public Department  GetByID(int ID)
        {
            var data = db.Department.Where(a => a.ID == ID).FirstOrDefault();
            return data;
        }
    }
}
