using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Core.Sepecifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : EntityBase
    {
        public Expression<Func<T, bool>> WhereCondition { get; set; }
        public List<Expression<Func<T, EntityBase>>> ObjsToInclude { get; set; } = new List<Expression<Func<T, EntityBase>>>();

        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> InWherCondition)
        {
            WhereCondition = InWherCondition;
        }
    }
}
