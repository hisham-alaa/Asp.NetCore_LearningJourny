using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entites;
using Talabat.Core.Reporitories.Contract;

namespace Talabat.APIs.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> productsRepo;

        public ProductsController(IGenericRepository<Product> productRepo)
        {
            productsRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
        {
            var products = await productsRepo.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await productsRepo.GetAsync(id);
            return Ok(product);
        }
    }

}
