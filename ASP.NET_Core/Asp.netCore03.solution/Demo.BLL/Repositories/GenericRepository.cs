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
        private protected readonly MVC01DbContext _dbContext;

        public GenericRepository(MVC01DbContext InjectedDbContext)
        {
            _dbContext = InjectedDbContext;
        }

        public void Create(Item d)
        {
            _dbContext.Set<Item>().Add(d);

        }

        public void Delete(Item d)
        {
            _dbContext.Set<Item>().Remove(d);
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            if ((typeof(Item) == typeof(Employee)))
            {
                return (IEnumerable<Item>)await _dbContext.Employees.Include(e => e.Department).AsNoTracking().ToListAsync();
            }
            return await _dbContext.Set<Item>().AsNoTracking().ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Item>().FindAsync(id);
        }

        public void Update(Item d)
        {
            _dbContext.Update(d);
        }

    }
}
