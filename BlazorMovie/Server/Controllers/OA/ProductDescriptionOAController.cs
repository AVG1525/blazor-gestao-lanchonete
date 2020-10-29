using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorMovie.Server.Infra;
using BlazorMovie.Shared.Model.OA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorMovie.Server.Controllers.OA
{
    [Route("v1/OA/[controller]")]
    [ApiController]
    public class ProductDescriptionOAController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context)
        {
            return Ok(await _context.ProductDescriptionOA.ToListAsync());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            return Ok(await _context.ProductDescriptionOA.FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(id))));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] ProductDescriptionOA productDescriptionOA)
        {
            try
            {
                ProductDescriptionOA newProductDescriptionOA1 = new ProductDescriptionOA()
                {
                    Description = productDescriptionOA.Description
                };

                _context.Add(newProductDescriptionOA1);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] ProductDescriptionOA productDescriptionOA)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(productDescriptionOA).State = EntityState.Modified;

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
        public async Task<ActionResult<ProductDescriptionOA>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDescription = await _context.ProductDescriptionOA.FindAsync(id);
            if (productDescription == null)
            {
                return NotFound();
            }

            _context.ProductDescriptionOA.Remove(productDescription);
            await _context.SaveChangesAsync();
            return productDescription;
        }
    }
}