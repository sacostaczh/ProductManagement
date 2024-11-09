using Application.Commands.AddProduct;
using Application.Commands.AddProductReview;
using Application.Commands.DeleteProduct;
using Application.Commands.UpdateProduct;
using Application.Queries.GetAllProducts;
using Application.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
        }

        // GET api/product
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        // GET api/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return product != null ? Ok(product) : NotFound();
        }

        // PUT api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Product ID mismatch");
            }

            var result = await _mediator.Send(command);
            return result ? NoContent() : NotFound();
        }

        // DELETE api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return result ? NoContent() : NotFound();
        }

        // POST api/product/{id}/review
        [HttpPost("{id}/review")]
        public async Task<IActionResult> AddReview(Guid id, [FromBody] AddProductReviewCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest("Product ID mismatch");
            }

            var result = await _mediator.Send(command);
            //return result ? NoContent() : NotFound();
            if (!result)
                return NotFound("Producto no encontrado o no se pudo agregar la reseña");
            return Ok("Reseña agregada satisfactoriamente");
        }
    }
}
