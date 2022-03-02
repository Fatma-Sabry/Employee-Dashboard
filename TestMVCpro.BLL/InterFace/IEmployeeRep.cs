using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.InterFace
{
   public interface IEmployeeRep
    {
        public IEnumerable<Employee> Get();
        public IEnumerable<Employee> SearchByName(string Name);
        public Employee GetByID(int ID);
        public void Create(Employee model);
        public void Update(Employee model);
        public void Delete(Employee model);
    }
}
