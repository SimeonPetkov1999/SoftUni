using SIS.Server.Controllers;
using SIS.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Demo.Controllers
{
    public class UserController : Controller
    {
        private const string Username = "user";
        public const string Password = "user123";


        private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";
        public UserController(Request request)
            : base(request)
        {
        }

        public Response Login() => View();

        public Response LogInUser()
        {
            this.Request.Session.Clear();

            var usenameMatches = this.Request.Form["Username"] == UserController.Username;
            var passwordMatches = this.Request.Form["Password"] == UserController.Password;

            if (usenameMatches && passwordMatches)
            {
                if (!this.Request.Session.ContaisKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

                    return Html("<h3> Logged successfully!</h3>", cookies);
                }

                return Html("<h3> Logged successfully!</h3>");
            }

            return Redirect("/Login");

        }

        public Response Logout()
        {
            this.Request.Session.Clear();
            return Html("<h3> Logged out successfully</h3>");
        }

        public Response GetUserData() 
        {
            if (this.Request.Session.ContaisKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is with username '{Username}'</h3>");
            }

            return Redirect("/Login");
        }
    }
}
