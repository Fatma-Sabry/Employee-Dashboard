using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.BLL.Models;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.BLL.Mapper
{
  public  class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();

            CreateMap<Country, CountryVM>();
            CreateMap<CountryVM, Country>();

            CreateMap<City, CityVM>();
            CreateMap<CityVM, City>();

            CreateMap<District, DistrictVM>();
            CreateMap<DistrictVM, District>();

         
        }
    }
}
