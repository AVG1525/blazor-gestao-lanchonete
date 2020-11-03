using BlazorMovie.Server.Infra;
using BlazorMovie.Shared.Model.OA;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovie.Server.Controllers.OA
{
    [Route("v1/OA/[controller]")]
    [ApiController]
    public class SaleOAController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context)
        {
            var query = (from sle in _context.SaleOA
                         join usr in _context.UserOA on sle.UserOAId equals usr.Id
                         join prd in _context.ProductOA on sle.ProductOAId equals prd.Id
                         join prc in _context.ProductPurchaseStatusOA on sle.ProductPurchaseStatusOAId equals prc.Id
                         where sle.ProductPurchaseStatusOAId > 1
                         select new SaleOA
                         {
                             Id = sle.Id,
                             UserOAId = sle.UserOAId,
                             UserOA = usr,
                             ProductOAId = sle.ProductOAId,
                             ProductOA = prd,
                             ProductPurchaseStatusOAId = sle.ProductPurchaseStatusOAId,
                             ProductPurchaseStatusOA = prc
                         }).ToListAsync();
            return Ok(await query);
        }

        [HttpGet]
        [Route("ToApprove")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            var query = (from sle in _context.SaleOA
                         join usr in _context.UserOA on sle.UserOAId equals usr.Id
                         join prd in _context.ProductOA on sle.ProductOAId equals prd.Id
                         join prc in _context.ProductPurchaseStatusOA on sle.ProductPurchaseStatusOAId equals prc.Id
                         where sle.ProductPurchaseStatusOAId == 1
                         select new SaleOA
                         {
                             Id = sle.Id,
                             UserOAId = sle.UserOAId,
                             UserOA = usr,
                             ProductOAId = sle.ProductOAId,
                             ProductOA = prd,
                             ProductPurchaseStatusOAId = sle.ProductPurchaseStatusOAId,
                             ProductPurchaseStatusOA = prc
                         }).ToListAsync();
            return Ok(await query);
        }

        //[HttpGet]
        //[Route("ById")]
        //public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        //{
        //    return Ok(await _context.SaleOA.FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(id))));
        //}

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] SaleOA saleOA)
        {
            try
            {
                SaleOA newSale = new SaleOA()
                {
                    UserOAId = saleOA.UserOAId,
                    ProductOAId = saleOA.ProductOAId,
                    ProductPurchaseStatusOAId = saleOA.ProductPurchaseStatusOAId
                };

                _context.Add(newSale);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] SaleOA saleOA)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(saleOA).State = EntityState.Modified;

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
        public async Task<ActionResult<SaleOA>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _context.SaleOA.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.SaleOA.Remove(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
    }
}