using System.Linq.Expressions;
using Talabat.Core.Entites;

namespace Talabat.Core.Sepecifications.ProductSpecifications
{
    public class ProductAllSpecification : BaseSpecification<Product>
    {
        public ProductAllSpecification()
        {
            setIncludes();
        }

        public ProductAllSpecification(Expression<Func<Product, bool>> productExpression) : base(productExpression)
        {
            setIncludes();
        }

        private void setIncludes()
        {
            ObjsToInclude.Add(p => p.Brand);
            ObjsToInclude.Add(p => p.Category);
        }
    }
}