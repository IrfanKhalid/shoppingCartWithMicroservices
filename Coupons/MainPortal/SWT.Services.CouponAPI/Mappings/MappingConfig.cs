using AutoMapper;
using SWT.Services.CouponAPI.Models;
using SWT.Services.CouponAPI.Models.Dto;

namespace SWT.Services.CouponAPI.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            var mapperConfig = new MapperConfiguration(config  => {
                config.CreateMap<Coupon,CouponDto>().ReverseMap();
                        
            });

            return mapperConfig;
        }
    }
}
