using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSBackend.Services;
using POSShared.DTOs;
using POSShared.Entities;

namespace POSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductos()
        {
            var productos = await _productoService.ObtenerProductosAsync();

            var productDtos = productos.Select(p => new ProductDTO
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CurrentStock = p.CurrentStock,
                StockMininum = p.StockMininum,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.Name : string.Empty,
                IsActive = p.IsActive,
                ImagenUrl = p.ImagenUrl
            });

            return Ok(productDtos);
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDTO>> GetProducto(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
                return NotFound();

            var dto = new ProductDTO
            {
                Id = producto.Id,
                Code = producto.Code,
                Name = producto.Name,
                Description = producto.Description,
                Price = producto.Price,
                CurrentStock = producto.CurrentStock,
                StockMininum = producto.StockMininum,
                CategoryId = producto.CategoryId,
                CategoryName = producto.Category != null ? producto.Category.Name : string.Empty,
                IsActive = producto.IsActive,
                ImagenUrl = producto.ImagenUrl
            };

            return Ok(dto);
        }


        [HttpGet("categoria/{categoria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetPorCategoria(string categoria)
        {
            var productos = await _productoService.ObtenerPorCategoriaAsync(categoria);

            var productDtos = productos.Select(p => new ProductDTO
            {
                Id = p.Id,
                Code = p.Code,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                CurrentStock = p.CurrentStock,
                StockMininum = p.StockMininum,
                CategoryId = p.CategoryId,
                CategoryName = p.Category != null ? p.Category.Name : string.Empty,
                IsActive = p.IsActive,
                ImagenUrl = p.ImagenUrl
            });

            return Ok(productDtos);
        }


        [HttpGet("{id}/stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> GetStock(int id)
        {
            var stock = await _productoService.ObtenerStockAsync(id);
            return Ok(stock);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CrearProducto([FromBody] Product producto)
        {
            await _productoService.CrearProductoAsync(producto);
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ActualizarProducto(int id, [FromBody] Product producto)
        {
            if (id != producto.Id)
                return BadRequest("El Id del producto no coincide.");

            await _productoService.ActualizarProductoAsync(producto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            await _productoService.EliminarProductoAsync(id);
            return NoContent();
        }


        [HttpPut("{id}/stock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ActualizarStock(int id, [FromQuery] int cantidadVendida)
        {
            var resultado = await _productoService.ActualizarStockAsync(id, cantidadVendida);

            if (!resultado)
                return NotFound("Producto no encontrado.");

            return Ok("Stock actualizado correctamente.");
        }
    }
}

