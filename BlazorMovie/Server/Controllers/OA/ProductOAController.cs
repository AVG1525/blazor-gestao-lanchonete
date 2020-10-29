using BlazorMovie.Server.Infra;
using BlazorMovie.Shared.Model.OA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovie.Server.Controllers.OA
{
    [Route("v1/OA/[controller]")]
    [ApiController]
    public class ProductOAController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context)
        {
            var query = (from prd in _context.ProductOA
                         join desc in _context.ProductDescriptionOA on prd.ProductDescriptionOAId equals desc.Id
                         select new ProductOA { 
                             Id = prd.Id, 
                             Name = prd.Name, 
                             Price = prd.Price, 
                             ProductDescriptionOAId = prd.ProductDescriptionOAId,
                             ProductDescriptionOA = desc
                         }).ToListAsync();
            return Ok(await query);
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            return Ok(await _context.ProductOA.FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(id))));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] ProductOA productOA)
        {
            try
            {
                ProductOA newProduct = new ProductOA()
                {
                    Name = productOA.Name,
                    Price = productOA.Price,
                    ProductDescriptionOAId = productOA.ProductDescriptionOAId
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
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] ProductOA productOA)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(productOA).State = EntityState.Modified;

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
        public async Task<ActionResult<ProductOA>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.ProductOA.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.ProductOA.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}