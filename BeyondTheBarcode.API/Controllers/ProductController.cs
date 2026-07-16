using BeyondTheBarcode.Application.DTOs.ProductDtos;
using BeyondTheBarcode.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BeyondTheBarcode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #region Get All Products

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        #endregion

        #region Get Product By Id

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound($"Product with Id {id} not found.");

            return Ok(product);
        }

        #endregion

        #region Get Product By Code

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var product = await _productService.GetByCodeAsync(code);

            if (product == null)
                return NotFound($"Product with code '{code}' not found.");

            return Ok(product);
        }

        #endregion

        #region Get Products By Brand

        [HttpGet("brand/{brand}")]
        public async Task<IActionResult> GetByBrand(string brand)
        {
            var products = await _productService.GetByBrandAsync(brand);

            if (!products.Any())
                return NotFound("No Products found.");

            return Ok(products);
        }

        #endregion

        #region Get Products By Category

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var products = await _productService.GetByCategoryAsync(category);

            if (!products.Any())
                return NotFound("No Products found.");

            return Ok(products);
        }

        #endregion

        #region Search Products

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            var products = await _productService.SearchAsync(keyword);

            if (!products.Any())
                return NotFound("No matching Products found.");

            return Ok(products);
        }

        #endregion

        #region Get Active Products

        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var products = await _productService.GetActiveAsync();

            if (!products.Any())
                return NotFound("No active Products found.");

            return Ok(products);
        }

        #endregion

        #region Get Inactive Products

        [HttpGet("inactive")]
        public async Task<IActionResult> GetInactive()
        {
            var products = await _productService.GetInactiveAsync();

            if (!products.Any())
                return NotFound("No inactive Products found.");

            return Ok(products);
        }

        #endregion

        #region Get Products By Date Range

        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange(
            [FromQuery] DateTime fromDate,
            [FromQuery] DateTime toDate)
        {
            var products = await _productService.GetByDateRangeAsync(fromDate, toDate);

            if (!products.Any())
                return NotFound("No Products found for the given date range.");

            return Ok(products);
        }

        #endregion
        #region Get Export Products

        [HttpGet("export")]
        public async Task<IActionResult> GetExportProducts()
        {
            var products = await _productService.GetExportProductsAsync();

            if (!products.Any())
                return NotFound("No export products found.");

            return Ok(products);
        }

        #endregion

        #region Get Health Warning Products

        [HttpGet("health-warning")]
        public async Task<IActionResult> GetHealthWarningProducts()
        {
            var products = await _productService.GetHealthWarningProductsAsync();

            if (!products.Any())
                return NotFound("No products requiring health warning found.");

            return Ok(products);
        }

        #endregion

        #region Get Discontinued Products

        [HttpGet("discontinued")]
        public async Task<IActionResult> GetDiscontinuedProducts()
        {
            var products = await _productService.GetDiscontinuedProductsAsync();

            if (!products.Any())
                return NotFound("No discontinued products found.");

            return Ok(products);
        }

        #endregion

        #region Check Product Code Exists

        [HttpGet("exists/{productCode}")]
        public async Task<IActionResult> IsProductCodeExists(string productCode)
        {
            var exists = await _productService.IsProductCodeExistsAsync(productCode);

            return Ok(exists);
        }

        #endregion

        #region Create Product

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _productService.IsProductCodeExistsAsync(dto.ProductCode);

            if (exists)
                return BadRequest("Product Code already exists.");

            await _productService.CreateAsync(dto);

            return Ok("Product created successfully.");
        }

        #endregion

        #region Update Product

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = await _productService.GetByIdAsync(dto.ProductId);

            if (existingProduct == null)
                return NotFound($"Product with Id {dto.ProductId} not found.");

            await _productService.UpdateAsync(dto);

            return Ok("Product updated successfully.");
        }

        #endregion

        #region Delete Product

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);

            if (existingProduct == null)
                return NotFound($"Product with Id {id} not found.");

            await _productService.DeleteAsync(id);

            return Ok("Product deleted successfully.");
        }

        #endregion
    }
}

