using Microsoft.EntityFrameworkCore;
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
   public class EmployeeRep : IEmployeeRep
    {
        private readonly TestMVCproContext db;
        public EmployeeRep(TestMVCproContext db)
        {
            this.db = db;      
        }
        public void Create(Employee model)
        {
            db.Employee.Add(model);
            db.SaveChanges();
        }

        public void Delete(Employee model)
        {
            db.Employee.Remove(model);
            db.SaveChanges();

        }

        public IEnumerable<Employee> Get()
        {
            var data = db.Employee.Include("Department").Select(a => a);
            return data;
        }

        public Employee GetByID(int ID)
        {
            var data = db.Employee.Where(a => a.ID == ID).FirstOrDefault();
            return data;
        }

        public IEnumerable<Employee> SearchByName(string Name)
        {
            var data = db.Employee.Where(a=> a.Name.Contains(Name));
            return data;
        }

        public void Update(Employee model)
        {
            db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
          //  return db.Employee.Find(model.ID);
        }
    }
}
