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
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get ([FromServices]AppDbContext _context)
        {
            return Ok(await _context.User.ToListAsync());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> Get([FromServices]AppDbContext _context, [FromQuery] string id)
        {
            return Ok(await _context.User.FirstOrDefaultAsync(x => x.Key.Equals(Convert.ToInt32(id))));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromServices]AppDbContext _context, [FromBody] RegisterModel user)
        {
            try
            {
                RegisterModel newUser = new RegisterModel()
                {
                    Title = user.Title,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateBirth = user.DateBirth,
                    Email = user.Email,
                    Password = user.Password,
                    ConfirmPassword = user.ConfirmPassword,
                    AcceptTerms = user.AcceptTerms
                };

                _context.User.Add(newUser);
                await _context.SaveChangesAsync();
                return Ok();
            } catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromServices]AppDbContext _context, [FromBody] RegisterModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            } catch (Exception e)
            {
                throw (e);
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<RegisterModel>> Delete([FromServices]AppDbContext _context, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}