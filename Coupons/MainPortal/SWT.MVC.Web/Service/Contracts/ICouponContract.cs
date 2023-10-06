using SWT.MVC.Web.Models;

namespace SWT.MVC.Web.Service.Contracts
{
    public interface ICouponContract
    {
        Task<ResponseDto> GetCouponByCodeAsync(string Code);
        Task<ResponseDto> GetAllCouponsAsync();
        Task<ResponseDto> GetCouponByIdAsync(int Id);
        Task<ResponseDto> AddCouponAsync(CouponDto coupon);
        Task<ResponseDto> UpdateCouponAsync(CouponDto coupon);
        Task<ResponseDto> DeleteCouponAsync(int coupon);
    }
}
