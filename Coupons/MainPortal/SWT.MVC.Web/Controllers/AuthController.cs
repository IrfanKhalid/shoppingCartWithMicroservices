using Microsoft.AspNetCore.Mvc;
using SWT.MVC.Web.Service.Contracts;

namespace SWT.MVC.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthContract _authContract;
        public AuthController(IAuthContract authContract)
        {
            _authContract = authContract;
        }
        public IActionResult Index()
        {
            return View();
        }





    }
}
