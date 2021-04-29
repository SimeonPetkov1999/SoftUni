using SUS.HTTP;
using SUS.HTTP.Contracts;
using SUS.MvcFramework;
using SUSApp.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
           
            await Host.CreateHostAsync(new Startup(), 80);
        }
    }
}

