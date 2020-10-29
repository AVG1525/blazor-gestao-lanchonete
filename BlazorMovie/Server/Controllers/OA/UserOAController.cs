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
    public class UserOAController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context)
        {
            return Ok(await _context.UserOA.ToListAsync());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            return Ok(await _context.UserOA.FirstOrDefaultAsync(x => x.Id.Equals(Convert.ToInt32(id))));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] UserOA userOA)
        {
            try
            {
                UserOA newUser = new UserOA()
                {
                    Name = userOA.Name,
                    Telephone = userOA.Telephone
                };

                _context.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] UserOA userOA)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(userOA).State = EntityState.Modified;

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
        public async Task<ActionResult<UserOA>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.UserOA.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserOA.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
