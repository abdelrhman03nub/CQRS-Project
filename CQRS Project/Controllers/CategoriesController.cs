
using CQRS_Project.Application.Categories.Commands.CreateCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRS_Project.Application.Categories.Queries.GetCategories;



namespace CQRS_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }




        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            CreateCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);

            return Ok(new { Id = categoryId });
        }





        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _mediator.Send(
                new GetCategoriesQuery());

            return Ok(categories);
        }
    }
}
