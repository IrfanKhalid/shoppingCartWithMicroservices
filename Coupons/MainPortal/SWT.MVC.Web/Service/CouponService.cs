using SWT.MVC.Web.Models;
using SWT.MVC.Web.Utility;

namespace SWT.MVC.Web.Service.Contracts
{
    public class CouponService : ICouponContract
    {
        private IBaseContract _baseContract;
        public CouponService(IBaseContract baseContract)
        {
            _baseContract = baseContract;
        }
        public async Task<ResponseDto> AddCouponAsync(CouponDto coupon)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.CouponApiUrl + "api/coupon/",
                ApiType = Utility.Enum.ApiType.POST,
                Data=coupon
            });
        }

        public async Task<ResponseDto> DeleteCouponAsync(int coupon)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.CouponApiUrl + "api/coupon/" + coupon,
                ApiType = Utility.Enum.ApiType.DELETE
            });
        }

        public async Task<ResponseDto> GetAllCouponsAsync()
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                 RequestUrl = Configuration.CouponApiUrl+"api/coupon",
                 ApiType=Utility.Enum.ApiType.GET
            });
        }

        public async Task<ResponseDto> GetCouponByCodeAsync(string Code)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.CouponApiUrl + "api/coupon/GetByCode/"+Code,
                ApiType = Utility.Enum.ApiType.GET
            });
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int Id)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.CouponApiUrl + "api/coupon/"+Id,
                ApiType = Utility.Enum.ApiType.GET
            });
        }

        public async Task<ResponseDto> UpdateCouponAsync(CouponDto coupon)
        {
            return await _baseContract.SendAsync(new RequestDto
            {
                RequestUrl = Configuration.CouponApiUrl + "api/coupon/",
                ApiType = Utility.Enum.ApiType.PUT,
                Data = coupon
            });
        }
    }
}
