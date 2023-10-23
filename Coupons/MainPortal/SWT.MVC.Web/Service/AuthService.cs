using SWT.MVC.Web.Models;
using SWT.MVC.Web.Service.Contracts;
using SWT.MVC.Web.Utility;
using SWT.Services.AuthAPI.Models.Dto;

namespace SWT.MVC.Web.Service
{
    public class AuthService : IAuthContract
    {
        private IBaseContract _baseContract;
        public AuthService(IBaseContract baseContract)
        {
            _baseContract = baseContract;
        }
        public async Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto register)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.AuthApiUrl+ "api/auth/AssignRole/",
                ApiType = Utility.Enum.ApiType.POST,
                Data = register
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto login)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.AuthApiUrl + "api/auth/login/",
                ApiType = Utility.Enum.ApiType.POST,
                Data = login
            });
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto register)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.AuthApiUrl + "api/auth/register/",
                ApiType = Utility.Enum.ApiType.POST,
                Data = register
            });
        }
    }
}
