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

        public async  Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto responseDto = await _couponService.AddCouponAsync(model);
                if (responseDto != null && responseDto.IsSuccess)
                    return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteCoupon(int couponid)
        {
            ResponseDto responseDto = await _couponService.GetCouponByIdAsync(couponid);
            if (responseDto != null && responseDto.IsSuccess)
            {
                CouponDto ? model=JsonConvert.DeserializeObject<CouponDto>(responseDto.Result?.ToString()) ?? null;
                return View(model);
            }
            return NotFound();
        }
    }
}
