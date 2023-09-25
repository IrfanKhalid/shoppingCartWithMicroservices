using AutoMapper;
using SWT.Services.CouponAPI.Models;
using SWT.Services.CouponAPI.Models.Dto;

namespace SWT.Services.CouponAPI.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<Coupon, CouponDto>().ReverseMap();
            
            
            });
        }
    }
}
