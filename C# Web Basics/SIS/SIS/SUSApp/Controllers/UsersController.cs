using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp.Controllers
{
    public class UsersController : Controller
    {
        // GET /users/login
        public HttpResponse Login()
        {
            return this.View();
        }

        // GET /users/register
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse DoLogin()
        {
            // TODO: read data
            // TODO: check user
            // TODO: log user
            return this.Redirect("/");
        }
    }
}
