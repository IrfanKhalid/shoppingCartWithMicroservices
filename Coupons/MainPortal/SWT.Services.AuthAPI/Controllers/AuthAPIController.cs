using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SWT.Services.AuthAPI.Models.Dto;
using SWT.Services.AuthAPI.Service.IService;
using SWT.Services.CouponAPI.Models.Dto;

namespace SWT.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new ();
        }

     
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage =await _authService.Register(model);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequest)
        {
            var loginResponse =await _authService.Login(loginRequest);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or Message is incorrect";
                return BadRequest(_response);
            }
            _response.Result = true;
            return Ok(_response);
        }
        
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto loginRequest)
        {
            var assignRoleSuccessful = await _authService.AssignRole(loginRequest.Email,loginRequest.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                _response.IsSuccess = false;
                _response.Message = "Error occured while assiging.";
                return BadRequest(_response);
            }
            _response.Result = true;
            return Ok(_response);
        }
    }
}
