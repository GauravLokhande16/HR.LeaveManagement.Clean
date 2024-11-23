
namespace HR.LeaveManagement.BlazorUI.Services.Base
{
    public partial class Client : IClient
    {
        private readonly HttpClient _httpClient;
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
