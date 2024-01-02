
using E_commercebyifza.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ECommerceController : ControllerBase
{
    private readonly ECommerceDbContext _dbContext;

    public ECommerceController(ECommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _dbContext.Products.ToListAsync();
        return Ok(products);
    }

    
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.ProductId }, product);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
        if (id != product.ProductId)
        {
            return BadRequest();
        }

        _dbContext.Entry(product).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
