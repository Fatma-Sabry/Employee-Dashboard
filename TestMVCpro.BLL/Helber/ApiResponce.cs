using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVCpro.BLL.Helber
{
   public class ApiResponce<T>
    {
        public string Code { get; set; }
        public string Statues { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

    }
}
