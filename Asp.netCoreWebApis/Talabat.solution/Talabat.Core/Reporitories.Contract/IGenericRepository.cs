using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Reporitories.Contract
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(int id);

    }
}
