using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Sepecifications;

namespace Talabat.Repository
{
    internal class SpecificationEvaluator<T> : BaseSpecification<T> where T : EntityBase
    {
        public static IQueryable<T> BuildQuery(IQueryable<T> seq, ISpecification<T> spec)
        {
            var query = seq;

            if (spec.WhereCondition is not null)
                query = query.Where(spec.WhereCondition);

            query = spec.ObjsToInclude.Aggregate(query, (curQuery, nextInclude) => curQuery.Include(nextInclude));

            return query;
        }
    }
}
