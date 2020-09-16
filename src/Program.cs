using System;
using System.Net.Http;
using System.Threading.Tasks;
// using System.Threading;
// using System.Net;  
// using System.Net.Sockets;  
// using System.Text;

namespace VladZamsCSTest
{
    class Program
    {
        static readonly GoogleAPIClient GoogleAPIClient = new GoogleAPIClient();

        static void Main(string[] args)
        {
            var app = new RequestApp(GoogleAPIClient, 
                (stringToPrint) => {
                    System.Console.WriteLine(stringToPrint);
                });
            app.Launch();
        }
    }
}