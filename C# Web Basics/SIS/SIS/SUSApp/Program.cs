using SUS.HTTP;
using SUS.HTTP.Contracts;
using SUSApp.Controllers;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            //server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);
            server.AddRoute("/", new HomeController().Index);
            server.AddRoute("/about", new HomeController().About);
            server.AddRoute("/users/login", new UsersController().Login);
            server.AddRoute("/users/register", new UsersController().Register);
           
            await server.StartAsync(80);
        }
    }
}

