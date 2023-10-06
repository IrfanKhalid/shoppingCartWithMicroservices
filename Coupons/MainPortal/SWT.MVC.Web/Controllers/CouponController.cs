using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SWT.MVC.Web.Models;
using SWT.MVC.Web.Service.Contracts;

namespace SWT.MVC.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponContract _couponService;
        public CouponController(ICouponContract couponService)
        {
            _couponService = couponService;
        }
        public async Task<IActionResult> Index()
        {
            List<CouponDto> model = new();
            ResponseDto responseDto=await _couponService.GetAllCouponsAsync();
            if(responseDto != null && responseDto.IsSuccess)
                model = JsonConvert.DeserializeObject<List<CouponDto>>(responseDto.Result?.ToString());
            return View(model); 
        }
    }
}
