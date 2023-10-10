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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly MVC01DbContext _dbContext;

        public DepartmentRepository(MVC01DbContext InjectedDbContext)
        {
            _dbContext = InjectedDbContext;
        }

        public int Create(Department d)
        {
            _dbContext.Add(d);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department d)
        {
            _dbContext.Remove(d);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Update(Department d)
        {
            _dbContext.Update(d);
            return _dbContext.SaveChanges();
        }

    }
}
