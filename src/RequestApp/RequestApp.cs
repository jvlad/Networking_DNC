
using System;

namespace VladZamsCSTest
{
    class RequestApp {
        public const int BUILD_NUMBER = 3;
        readonly GoogleAPIClient GoogleAPIClient;
        readonly Action<string> Printer;

        public RequestApp(GoogleAPIClient googleAPIClient, Action<string> printer) {
            this.GoogleAPIClient = googleAPIClient;
            this.Printer = printer;
        }

        public async void Launch() {
            var result = await GoogleAPIClient.GetMainPageHTML();
            Printer(result);
        }

    }
}
