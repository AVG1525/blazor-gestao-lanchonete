using BlazorMovie.Server.Infra;
using BlazorMovie.Shared.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorMovie.Server.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context)
        {
            return Ok(await _context.Product.ToListAsync());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            return Ok(await _context.Product.FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(id))));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] Product product)
        {
            try
            {
                Product newProduct = new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                _context.Add(newProduct);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw (e);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Product>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
