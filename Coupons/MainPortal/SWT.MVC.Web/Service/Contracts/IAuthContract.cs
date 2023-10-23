using SWT.MVC.Web.Models;
using SWT.Services.AuthAPI.Models.Dto;

namespace SWT.MVC.Web.Service.Contracts
{
    public interface IAuthContract
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto login);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto register);
        Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto deregister);

    }
}
