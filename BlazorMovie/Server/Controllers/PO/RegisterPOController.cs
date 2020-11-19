using BlazorMovie.Shared.Model.PO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovie.Server.Controllers.PO
{
    [Route("v1/PO/[controller]")]
    [ApiController]
    public class RegisterPOController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterPOController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginPO model)
        {
            var newUser = new IdentityUser { UserName = model.Username };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(errors);

            }

            return Ok(result);
        }
    }
}
