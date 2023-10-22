using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Contexts;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MVC01DbContext dbContext;

        public IEmployeeRepository EmployeeRepo { get; set; }

        public IDepartmentRepository DepartmentRepo { get; set; }

        public UnitOfWork(MVC01DbContext dbContext)
        {
            EmployeeRepo = new EmployeeRepository(dbContext);
            DepartmentRepo = new DepartmentRepository(dbContext);
            this.dbContext = dbContext;
        }

        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }
    }
}
