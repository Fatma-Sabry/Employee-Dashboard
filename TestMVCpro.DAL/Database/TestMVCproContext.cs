using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVCpro.DAL.Entity;

namespace TestMVCpro.DAL.Database
{
   public class TestMVCproContext : IdentityDbContext<IdentityUserEX>
    {
        public TestMVCproContext(DbContextOptions<TestMVCproContext> option) : base(option)
        {
                
        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<District>  District { get; set; }
        public DbSet<City>  City{ get; set; }
    }
}
