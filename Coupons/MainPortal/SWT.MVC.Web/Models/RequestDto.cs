using static SWT.MVC.Web.Utility.Enum;

namespace SWT.MVC.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string RequestUrl { get; set; }
        public  Object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
