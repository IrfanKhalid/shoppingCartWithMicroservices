using SWT.MVC.Web.Models;

namespace SWT.MVC.Web.Service.Contracts
{
    public interface ICouponContract
    {
        Task<ResponseDto<CouponDto>> GetCouponByCodeAsync(string Code);
        Task<ResponseDto<List<CouponDto>>> GetAllCouponsAsync();
        Task<ResponseDto<CouponDto>> GetCouponByIdAsync(int Id);
        Task<ResponseDto<CouponDto>> AddCouponAsync(CouponDto coupon);
        Task<ResponseDto<CouponDto>> UpdateCouponAsync(CouponDto coupon);
        Task<ResponseDto<CouponDto>> DeleteCouponAsync(int coupon);
    }
}
