using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Contexts
{
    public class MVC01DbContext : DbContext
    {
        public MVC01DbContext(DbContextOptions<MVC01DbContext> options) : base(options)
        {
        }

        //I have used the parameter constructor that will take the option of the DbContext as a constructor parameter so no need for this
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlServer("Server = .; Database = MVC01; Trusted_Connection = true;"); //MultipleLineResultSets = true

        public DbSet<Department> Departments { get; set; }
    }
}
