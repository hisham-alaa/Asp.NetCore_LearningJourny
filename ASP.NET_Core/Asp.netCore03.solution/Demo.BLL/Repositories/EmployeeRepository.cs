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
        private readonly MVC01DbContext _dbContext;

        public EmployeeRepository(MVC01DbContext InjectedDbContext) : base(InjectedDbContext)
        {
            _dbContext = InjectedDbContext;
        }

        public Employee GetEmployeeByAddress(string Address)
        {
            return _dbContext.employees.Where(e => e.Address == Address).FirstOrDefault();
        }
    }
}
