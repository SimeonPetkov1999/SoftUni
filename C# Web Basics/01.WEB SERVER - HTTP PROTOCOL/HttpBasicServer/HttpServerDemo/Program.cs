using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace HttpServerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string NewLine = "\r\n";

            var list = new List<Tweet>();
            var tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            while (true)
            {
                var client = tcpListener.AcceptTcpClient();
                using var stream = client.GetStream();

                byte[] buffer = new byte[1000000];

                var lenght = stream.Read(buffer, 0, buffer.Length);

                var requestString =
                    Encoding.UTF8.GetString(buffer, 0, lenght).Split("\r\n");
                var route = requestString[0].Split();
                string html = string.Empty;

                Console.WriteLine(route[1]);
                if (route[0] == "POST")
                {

                    var info = requestString.Last().Split('&');
                    var username = info[0].Split('=').Last();
                    var tweeet = info[1].Split('=').Last();

                    html = $"<h1>{username} succesfuly tweeted at {DateTime.Now}</h1>";
                    list.Add(new Tweet() { Username = username, TweetInput = tweeet, Date = DateTime.Now.ToString() });

                }
                else if (route[0] == "GET")
                {

                    if (route[1] == "/tweets")
                    {
                        html += @"<style>table, th, td { border: 1px solid ;} </style>
                                  <table style=""width:50%"">
                                  <tr>
                                  <th> Username </th>
                                  <th> Tweet </th>
                                  <th> Date </th>
                                  </tr>";
                        foreach (var item in list)
                        {
                            html += @$"<tr>
                                     <td> {item.Username} </td>
                                     <td> {item.TweetInput} </td>
                                     <td> {item.Date} </td>
                                     </tr>";
                        }
                        html += "</table>";
                    }
                    else
                    {
                        html = "<h1>Tweet:</h1>" +
                               "<form action=/tweet method=post>" +
                               "<label>Username</label></br><input name=username /> </br></br>" +
                               "<label>Tweet</label> </br> <input name=tweet />" +
                               "</br></br><input type=submit /> </form>";
                    }
                }

                string response = "HTTP/1.1 200 OK" + NewLine +
                    "Server: SimoServerSimpleDemo" + NewLine +
                    "Content-Type: text/html; charset=utf-8" + NewLine +
                    "Content-Lenght: " + html.Length + NewLine +
                    NewLine +
                    html + NewLine;



                byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                stream.Write(responseBytes);

                Console.WriteLine(new string('=', 70));

            }
        }

        public class Tweet
        {
            public string Username { get; set; }
            public string TweetInput { get; set; }
            public string Date { get; set; }

        }
    }
}
