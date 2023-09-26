using SWT.MVC.Web.Models;

namespace SWT.MVC.Web.Service.Contracts
{
    public class CouponService : ICouponContract
    {
        public Task<ResponseDto<CouponDto>> AddCouponAsync(CouponDto coupon)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CouponDto>> DeleteCouponAsync(int coupon)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<List<CouponDto>>> GetAllCouponsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CouponDto>> GetCouponByCodeAsync(string Code)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CouponDto>> GetCouponByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto<CouponDto>> UpdateCouponAsync(CouponDto coupon)
        {
            throw new NotImplementedException();
        }
    }
}
