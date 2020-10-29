using BlazorMovie.Server.Infra;
using BlazorMovie.Shared.Model.OA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BlazorMovie.Server.Controllers.OA
{
    [Route("v1/OA/[controller]")]
    [ApiController]
    public class ProductPurchaseStatusOAController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context)
        {
            return Ok(await _context.ProductPurchaseStatusOA.ToListAsync());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            return Ok(await _context.ProductPurchaseStatusOA.FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(id))));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] ProductPurchaseStatusOA productPurchaseStatusOA)
        {
            try
            {
                ProductPurchaseStatusOA newProductPurchaseStatusOA = new ProductPurchaseStatusOA()
                {
                    Description = productPurchaseStatusOA.Description
                };

                _context.Add(newProductPurchaseStatusOA);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] ProductPurchaseStatusOA productPurchaseStatusOA)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(productPurchaseStatusOA).State = EntityState.Modified;

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
        public async Task<ActionResult<ProductPurchaseStatusOA>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productPurchaseStatusOA = await _context.ProductPurchaseStatusOA.FindAsync(id);
            if (productPurchaseStatusOA == null)
            {
                return NotFound();
            }

            _context.ProductPurchaseStatusOA.Remove(productPurchaseStatusOA);
            await _context.SaveChangesAsync();
            return productPurchaseStatusOA;
        }
    }
}