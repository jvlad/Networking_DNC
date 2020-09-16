using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace VladZamsCSTest
{

    class GoogleAPIClient: HttpClient {

        public GoogleAPIClient(): base(new GoogleAPIMessageHandler()) {}

        public async Task<string> GetMainPageHTML() {
            var result = await GetAsync("http://google.com");
            var res = $"Build {RequestApp.BUILD_NUMBER}: Status Code: {result.StatusCode.ToString()}";
            return res;
        }
    }

    class GoogleAPIMessageHandler : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Processing);
            return Task.FromResult(response);
        }
    }

}