using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Enitity;
using Core.Interface;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   
    public class ProductsController : BaseAPIController
    {
        private readonly IGenericRepostorty<ProductBrand> _productBrandRepo;
        private readonly IGenericRepostorty<ProductType> _productTypeRepo;
        private readonly IGenericRepostorty<Product> _productsRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepostorty<Product> productsRepo,
        IGenericRepostorty<ProductBrand> productBrandRepo,
        IGenericRepostorty<ProductType> productTypeRepo, IMapper mapper)
        {
            _mapper = mapper;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpec)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(productSpec);
           
            var countspec = new ProductWithFiltersCountSpecification(productSpec);

            var totalItem = await _productsRepo.CountAsync(countspec);

            var products = await _productsRepo.ListAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products);

            return Ok( new Pagination<ProductToReturnDto>(productSpec.PageIndex , productSpec.PageSize , totalItem ,data) );
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpace(spec);
            return _mapper.Map<Product,ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }

    }
}