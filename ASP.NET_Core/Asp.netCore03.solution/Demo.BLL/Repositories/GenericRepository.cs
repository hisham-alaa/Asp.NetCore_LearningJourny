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
    public class GenericRepository<Item> : IGenericRepository<Item> where Item : ModelBase
    {
        public readonly MVC01DbContext _dbContext;

        public GenericRepository(MVC01DbContext InjectedDbContext)
        {
            _dbContext = InjectedDbContext;
        }

        public int Create(Item d)
        {
            _dbContext.Set<Item>().Add(d);
            return _dbContext.SaveChanges();
        }

        public int Delete(Item d)
        {
            _dbContext.Set<Item>().Remove(d);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            if ((typeof(Item) == typeof(Employee)))
            {
                return (IEnumerable<Item>)_dbContext.Employees.Include(e => e.Department).AsNoTracking().ToList();
            }
            return _dbContext.Set<Item>().AsNoTracking().ToList();
        }

        public Item GetById(int id)
        {
            return _dbContext.Set<Item>().Find(id);
        }

        public int Update(Item d)
        {
            _dbContext.Update(d);
            return _dbContext.SaveChanges();
        }

    }
}
