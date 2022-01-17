using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SIS
{
    public class Program
    {
        static void Main()
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var port = 8080;

            var serverListener = new TcpListener(ipAddress, port);

           
           
            
        }
    }
}