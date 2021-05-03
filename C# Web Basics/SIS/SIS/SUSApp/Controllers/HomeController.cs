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
        public HttpResponse Index(HttpRequest request)
        {
            var viewModel = new IndexViewModel();
            viewModel.CurrentYear = DateTime.UtcNow.Year;
            viewModel.Message = "Welcome to Battle Cards";
            return this.View(viewModel);
        }

        // GET /home/about
        public HttpResponse About(HttpRequest request)
        {
            return this.View();
        }
    }
}
