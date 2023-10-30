using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.Core.Entites;
using Talabat.Core.Reporitories.Contract;
using Talabat.Core.Sepecifications;
using Talabat.Core.Sepecifications.ProductSpecifications;

namespace Talabat.APIs.Controllers
{
    public class ProductsController : ApiBaseController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IMapper mapper)
        {
            productsRepo = productRepo;
            _mapper = mapper;
        }


        [ProducesResponseType(typeof(IEnumerable<ProductToReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProductsAsync()
        {
            var spec = new ProductAllSpecification();
            var products = await productsRepo.GetAllAsyncWithSpec(spec);
            return Ok(_mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products));
        }

        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductByIdAsync(int id)
        {
            var spec = new ProductAllSpecification(p => p.Id == id);
            var product = await productsRepo.GetAsyncWithSpec(spec);
            if (product is null)
                return NotFound(new ApiResponse(400));
            return Ok(_mapper.Map<Product, ProductToReturnDto>(product));
        }
    }

}
