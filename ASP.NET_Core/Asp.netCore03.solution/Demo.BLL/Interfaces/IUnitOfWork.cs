using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {

        public IEmployeeRepository EmployeeRepo { get; set; }

        public IDepartmentRepository DepartmentRepo { get; set; }

        public Task<int> CompleteAsync();

    }
}
