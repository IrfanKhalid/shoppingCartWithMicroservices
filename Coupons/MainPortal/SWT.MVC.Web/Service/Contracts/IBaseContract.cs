using SWT.MVC.Web.Models;

namespace SWT.MVC.Web.Service.Contracts
{
    public interface IBaseContract<T,K>
    {
        Task<ResponseDto<T>> SendAsync(RequestDto<K> requestDto);
        Task<ResponseDto<T>> GetAsync(RequestDto<K> requestDto);
    }
}
