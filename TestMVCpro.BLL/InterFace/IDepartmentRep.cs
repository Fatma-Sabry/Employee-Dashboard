using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.InterFace
{
  public interface IDepartmentRep
    {
        public IEnumerable<Department> Get();
        public Department GetByID( int ID);
        public void Create(Department model);
        public void Update(Department model);
        public void Delete(Department model);

    }
}
