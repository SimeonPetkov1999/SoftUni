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
        public static async Task CreateHostAsync(List<Route> routeTable, int port = 80)
        {
            // TODO: {controller}/{action}/{id}
            IHttpServer server = new HttpServer(routeTable);       
            await server.StartAsync(port);
        }
    }
}
