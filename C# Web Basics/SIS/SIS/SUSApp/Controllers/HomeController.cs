using SUS.HTTP;
using SUS.MvcFramework;
using SUSApp.VIewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp.Controllers
{

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }

        // GET /home/about
        public HttpResponse About()
        {
            this.SignIn("niki");
            return this.View();
        }
    }

}
