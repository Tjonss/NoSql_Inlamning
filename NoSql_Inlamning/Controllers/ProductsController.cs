using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoSql_Inlamning.Contexts;
using NoSql_Inlamning.Models.Entities;
using NoSql_Inlamning.Models.Requests;
using System.Diagnostics;

namespace NoSql_Inlamning.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {
            try
            {
                var product = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    Name = req.Name,
                    Description = req.Description,
                    Price = req.Price,
                    ArticleNumber = req.ArticleNumber,
                    PartitionKey = "Products"
                };
                _context.Add(product);
                await _context.SaveChangesAsync();
                return new OkObjectResult(product);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _context.Products.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductUpdateRequest req)
        {
           try
           {
                var product = await _context.Products.FindAsync(id);
                product.Name = req.Name;
                product.Description = req.Description;
                product.Price = req.Price;
                product.ArticleNumber = req.ArticleNumber;
                
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new OkObjectResult(product);
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new OkResult();
        }

    }
}
