using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SWT.MVC.Web.Models;
using SWT.MVC.Web.Service.Contracts;
using SWT.Services.AuthAPI.Models.Dto;
using static SWT.MVC.Web.Utility.Enum;

namespace SWT.MVC.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthContract _authContract;
        public AuthController(IAuthContract authContract)
        {
            _authContract = authContract;
        }
        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>
            {
                new SelectListItem{ Text =Role.Admin.ToString(), Value=Role.Admin.ToString() },
                new SelectListItem{ Text =Role.Customer.ToString(), Value=Role.Customer.ToString() }
            };
            ViewBag.roleList = roleList;
            return  View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto requestDto)
        {
            ResponseDto response =await _authContract.RegisterAsync(requestDto);
            ResponseDto assignRole;

            if(response != null && response.IsSuccess)
            {
                if (string.IsNullOrEmpty(requestDto.Role))
                {
                    requestDto.Role = Role.Customer.ToString();
                }
            }
            assignRole=await _authContract.AssignRoleAsync(requestDto);
            if(assignRole != null && assignRole.IsSuccess)
            {
                TempData["success"] = "Registration successful";
                return RedirectToAction(nameof(Login));
            }
            var roleList = new List<SelectListItem>
            {
                new SelectListItem{ Text =Role.Admin.ToString(), Value=Role.Admin.ToString() },
                new SelectListItem{ Text =Role.Customer.ToString(), Value=Role.Customer.ToString() }
            };
            ViewBag.roleList = roleList;
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }



    }
}
