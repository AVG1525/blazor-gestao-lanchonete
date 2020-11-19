using BlazorMovie.Shared.Model.PO;
using BlazorMovie.Shared.Response;
using System.Threading.Tasks;

namespace BlazorMovie.Shared.Interface
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginPO loginModel);
        Task<object> Register(LoginPO registerModel);
        Task Logout();
    }
}
