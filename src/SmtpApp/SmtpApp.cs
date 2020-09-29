using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;


namespace VladZamsCSTest
{
    public class SmtpApp {
        static bool mailSent = false;
        public void Launch() {
            // Command-line argument must be the SMTP host.
            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(Credentials.Username, Credentials.Pwd),
                EnableSsl = true,
            };

            MailAddress from = new MailAddress("jane@contoso.com",
               "Jane " + (char)0xD8 + " Clayton",
            System.Text.Encoding.UTF8);
            
            MailAddress to = new MailAddress("vzamskoi@gmail.com");
            MailMessage message = new MailMessage(from, to);
            message.Body = "This is a test email message sent by an application. ";
            
            string someArrows = new string(new char[] {'\u2190', '\u2191', '\u2192', '\u2193'});
            // message.Body += Environment.NewLine + someArrows;
            message.Body += Environment.NewLine + "Hello from Vlad";
            message.BodyEncoding =  System.Text.Encoding.UTF8;
            // message.Subject = "test message 1" + someArrows;
            message.Subject = "test message 1" + someArrows;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            
            // The userState can be any object that allows your callback
            // method to identify this send operation.
            // For this example, the userToken is a string constant.
            string userState = "test message1";
            client.SendAsync(message, userState);


            Console.WriteLine("Sending message... press c to cancel mail. Press any other key to exit.");            
            string answer = Console.ReadLine();
            
            if (answer.StartsWith("c") && mailSent == false)
            {
                client.SendAsyncCancel();
            }
            // Clean up.
            message.Dispose();
            Console.WriteLine("Goodbye.");
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
                String token = (string) e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            } else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
    }
}