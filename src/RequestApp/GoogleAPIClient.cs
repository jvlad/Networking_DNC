using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VladZamsCSTest
{

    class GoogleAPIClient: HttpClient {

        /// <summary>
        /// Supplying custom HttpMessageHandler to the base constructor
        /// </summary>
        public GoogleAPIClient(): base(new GoogleAPIMessageHandler()) {}

        public async Task<string> GetMainPageHTML() {
            var result = await GetAsync("http://google.com");
            var res = $"Build {RequestApp.BUILD_NUMBER}: Status Code: {result.StatusCode.ToString()}";
            return res;
        }
    }

    class GoogleAPIMessageHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // TODO 1: Set breakpoint here to see this method called implicitly
            
            // TODO 2: Add code to intercept the request here  

            
            // Substitute response with hard-coded HttpStatusCode  
            // var response = new HttpResponseMessage(HttpStatusCode.Processing);
            var response = await base.SendAsync(request, cancellationToken);
            
            // TODO 3: Add Response Content  
            
            return response;
        }
    }

}