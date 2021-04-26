using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HttpAsyncDemo
{
    class Program
    {
        const string NewLine = "\r\n";
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
         
            TcpListener tcpListener = new TcpListener(
                IPAddress.Loopback, 80);
            tcpListener.Start();
            while (true)
            {
                var client = await tcpListener.AcceptTcpClientAsync();
                await ProcessClinetAsync(client);
            }
        }

        private static async Task ProcessClinetAsync(TcpClient client)
        {
            var stream = client.GetStream();
            byte[] buffer = new byte[1000000];
            var lenght = await stream.ReadAsync(buffer, 0, buffer.Length);

            string requestString =
                Encoding.UTF8.GetString(buffer, 0, lenght);
            Console.WriteLine(requestString);

            string html = $"<h1>Hello from SimoServer {DateTime.Now}</h1>";


            string response = "HTTP/1.1 200 OK" + NewLine +
                "Server: DemoServer" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                "Content-Lenght: " + html.Length + NewLine +
                NewLine +
                html + NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes);

            Console.WriteLine(new string('=', 70));
        }
    }
}
