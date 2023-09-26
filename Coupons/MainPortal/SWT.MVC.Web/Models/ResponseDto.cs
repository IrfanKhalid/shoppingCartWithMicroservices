namespace SWT.MVC.Web.Models
{
    public class ResponseDto<T>
    {
        public T Result { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
