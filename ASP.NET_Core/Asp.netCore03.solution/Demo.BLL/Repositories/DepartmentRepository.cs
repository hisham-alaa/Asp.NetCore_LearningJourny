using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MVC01DbContext InjectedDbContext) : base(InjectedDbContext)
        {
        }

        public IQueryable<Department> SearchByName(string Name)
        {
            return _dbContext.Departments.Where(d => d.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
