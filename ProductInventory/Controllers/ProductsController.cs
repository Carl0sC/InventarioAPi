using Microsoft.AspNetCore.Mvc;
using ProductInventory.Models;
using ProductInventory.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // Obtener todos los productos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();
            return Ok(products);
        }

        // Obtener un producto por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Agregar un nuevo producto
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            await _repository.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Agregar productos de manera masiva
        [HttpPost("bulk")]
        public async Task<IActionResult> AddProductsBulk([FromBody] IEnumerable<Product> products)
        {
            await _repository.AddProductsBulkAsync(products);
            return Ok();
        }

        // Actualizar un producto existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateProductAsync(product);
            return NoContent();
        }

        // Eliminar un producto
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteProductAsync(id);
            return NoContent();
        }

        // Obtener productos por estado
        [HttpGet("state/{state}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByState(ProductState state)
        {
            var products = await _repository.GetProductsByStateAsync(state);
            return Ok(products);
        }

        // Marcar producto como fuera de stock
        [HttpPatch("exit/{id}")]
        public async Task<IActionResult> ExitProduct(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.State = ProductState.OutOfStock; // Marcar como fuera de stock
            await _repository.UpdateProductAsync(product);

            return NoContent();
        }

        // Marcar producto como defectuoso
        [HttpPatch("defective/{id}")]
        public async Task<IActionResult> MarkProductAsDefective(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.State = ProductState.Defective;
            await _repository.UpdateProductAsync(product);

            return NoContent();
        }
    }
}
