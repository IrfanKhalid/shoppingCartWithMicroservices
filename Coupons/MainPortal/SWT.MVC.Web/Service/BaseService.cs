using Newtonsoft.Json;
using SWT.MVC.Web.Models;
using SWT.MVC.Web.Service.Contracts;
using System.Net;
using System.Text;
using static SWT.MVC.Web.Utility.Enum;

namespace SWT.MVC.Web.Service
{
    public class BaseService:IBaseContract
    {       
        private readonly IHttpClientFactory _clientFactory;
        public BaseService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            HttpClient client = _clientFactory.CreateClient("Rest");
            HttpRequestMessage requestMessage = new();
            client.DefaultRequestHeaders.Accept.
                Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            requestMessage.RequestUri = new Uri( requestDto.RequestUrl);
            if(requestDto.Data != null)
            {
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage responseMessage = null;
            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    requestMessage.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    requestMessage.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    requestMessage.Method = HttpMethod.Delete;
                    break;

                default: 
                    requestMessage.Method = HttpMethod.Get;
                    break;
            }

            var response = await client.SendAsync(requestMessage);
            
            switch(response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ResponseDto() { IsSuccess=false,Message="Not Found" };
                case HttpStatusCode.Forbidden:
                    return new ResponseDto() { IsSuccess = false, Message = "Access Denied" };
                case HttpStatusCode.Unauthorized:
                    return new ResponseDto() { IsSuccess = false, Message = "Unauthorized access" };
                case HttpStatusCode.InternalServerError:
                    return new ResponseDto() { IsSuccess = false, Message = "Internal Server error" };
                default:
                    var resposeContent =await response.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<ResponseDto>(resposeContent);
                    return new ResponseDto() { IsSuccess = true, Result = responseData!=null?responseData.Result: default, Message = "Success" };
            }


 
        }

        public Task<ResponseDto> GetAsync(RequestDto requestDto)
        {
            throw new NotImplementedException();
        }
    }
}
