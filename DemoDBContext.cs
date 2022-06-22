using EmployeeData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    public class DemoDBContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organisation> Organizations { get; set; }
        public DemoDBContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-3AOH9UNJ\SQLEXPRESS;Database=EntityFrameworkDB;Trusted_Connection=True;");
        }
    }
}
