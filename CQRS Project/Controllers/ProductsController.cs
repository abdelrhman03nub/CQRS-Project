
using CQRS_Project.Application.DTOs;
using CQRS_Project.Application.Products.Commands.CreateProduct;
using CQRS_Project.Application.Products.Commands.DeleteProduct;
using CQRS_Project.Application.Products.Commands.UpdateProduct;
using CQRS_Project.Application.Products.Queries.GetProducts;
using CQRS_Project.Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Project.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }





        [HttpGet]
        public async Task<IActionResult> GetProducts(
            string? search,
            string? sortBy,
            bool descending = false,
            int page = 1,
            int pageSize = 10)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 10;
            }

            if (pageSize > 100)
            {
                pageSize = 100;
            }

            var products = await _mediator.Send(
                new GetProductsQuery
                {
                    Search = search,
                    SortBy = sortBy,
                    Descending = descending,
                    Page = page,
                    PageSize = pageSize
                });

            return Ok(products);
        }





        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(
                new GetProductByIdQuery { Id = id });

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }




        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            var command = new CreateProductCommand
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                CategoryId = dto.CategoryId
            };

            var productId = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = productId },
                new { id = productId });
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(
            int id,
            UpdateProductDto dto)
        {
            var command = new UpdateProductCommand
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
