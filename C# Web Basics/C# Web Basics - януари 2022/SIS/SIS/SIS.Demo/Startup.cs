using SIS.Demo.Controllers;
using SIS.Server;
using SIS.Server.Controllers;
using SIS.Server.HTTP;
using SIS.Server.Responses;
using System.Text;
using System.Web;

namespace SIS.Demo
{
    public class Startup
    {      
        public static async Task Main()
        {

            var server = new HttpServer(routes => routes
            .MapGet<HomeController>("/", c => c.Index())
            .MapGet<HomeController>("/Redirect", c => c.Redirect())
            .MapGet<HomeController>("/HTML",c=>c.Html())
            .MapPost<HomeController>("/HTML",c=>c.HtmlFormPost())
            .MapGet<HomeController>("/Content", c=>c.Content())
            .MapPost<HomeController>("/Content",c=>c.DownloadContent())
            .MapGet<HomeController>("/Cookies",c=>c.Cookies())
            .MapGet<HomeController>("/Session",c=>c.Session())
            .MapGet<UserController>("/Login",c=>c.Login())
            .MapPost<UserController>("/Login", c=>c.LogInUser())
            .MapGet<UserController>("/Logout", c=>c.Logout())
            .MapGet<UserController>("/UserProfile",c=>c.GetUserData()));

            await server.Start();
        }     
    }
}