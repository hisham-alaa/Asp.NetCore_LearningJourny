using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MVC01DbContext InjectedDbContext) : base(InjectedDbContext)
        {
        }

        public IQueryable<Employee> GetEmployeesByAddress(string Address)
        {
            return _dbContext.Employees.Where(e => e.Address == Address);
        }

        public IQueryable<Employee> SearchByName(string Name)
        {
            return _dbContext.Employees.Where(e => e.Name.ToLower().Contains(Name.ToLower()));
        }
    }
}
