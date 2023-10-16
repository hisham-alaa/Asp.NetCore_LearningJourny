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

        public Employee GetEmployeeByAddress(string Address)
        {
            return _dbContext.Employees.Where(e => e.Address == Address).FirstOrDefault();
        }
    }
}
