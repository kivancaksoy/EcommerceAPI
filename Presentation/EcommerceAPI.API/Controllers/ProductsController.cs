using EcommerceAPI.Application.Repositories;
using EcommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() {Id = Guid.NewGuid(), Name = "Product1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10},
            //    new() {Id = Guid.NewGuid(), Name = "Product2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20},
            //    new() {Id = Guid.NewGuid(), Name = "Product3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30},
            //});
            //await _productWriteRepository.SaveAsync();

            Product product = await _productReadRepository.GetByIdAsync("533112a7-68e9-493f-8ae4-188513215f55",false);
            product.Name = "Mehmet";
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product =  await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
