using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IDepartmentRepository
    {

        IEnumerable<Department> GetAll();

        Department GetById(int id);

        int Create(Department d);

        int Update(Department d);

        int Delete(Department d);

    }
}
