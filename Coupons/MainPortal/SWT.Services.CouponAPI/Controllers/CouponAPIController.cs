using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWT.Services.CouponAPI.Data;
using SWT.Services.CouponAPI.Models;
using SWT.Services.CouponAPI.Models.Dto;

namespace SWT.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _appDbContext;
        public CouponAPIController(AppDbContext dbContext,IMapper mapper)
        {
            _appDbContext = dbContext;
            _mapper = mapper;   
        }

        [HttpGet]
        public ResponseDto<List< CouponDto>> Get()
        {
            ResponseDto<List< CouponDto>> coupon = new ResponseDto<List< CouponDto>>();

            try
            {
                var data= _appDbContext.Coupons.ToList();
                coupon.Result =data.Select(x=> _mapper.Map<CouponDto>(x)).ToList();
                coupon.IsSuccess = true;
            }
            catch (Exception ex)
            {
                coupon.IsSuccess = false;
                coupon.Message = ex.Message;
            }
            return coupon;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto<CouponDto> Get(int id)
        {
            ResponseDto<CouponDto> coupon =new ResponseDto<CouponDto>();
            try
            {
                coupon.Result = _mapper.Map<CouponDto>(_appDbContext.Coupons.First(x=> x.CouponId == id ));
                coupon.IsSuccess = true;
            }
            catch (Exception ex)
            {
                coupon.IsSuccess = false;
                coupon.Message = ex.Message;
            }
            return coupon;
        }
    }
}
