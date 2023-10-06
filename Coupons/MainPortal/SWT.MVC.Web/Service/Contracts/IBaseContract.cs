using SWT.MVC.Web.Models;

namespace SWT.MVC.Web.Service.Contracts
{
    public interface IBaseContract
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
        Task<ResponseDto> GetAsync(RequestDto requestDto);
    }
}
