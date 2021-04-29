using SUS.HTTP;
using SUS.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            // TODO: {controller}/{action}/{id}
            List<Route> routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);

            IHttpServer server = new HttpServer(routeTable);  
            await server.StartAsync(port);
        }
    }
}
