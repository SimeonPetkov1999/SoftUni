using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            var userId = this.usersService.GetUserId(username, password);
            if (userId == null)
            {
                return this.Error("Invlid email or password");
            }

            this.SignIn(userId);
            return this.Redirect("/Repositories/All");

        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword)
        {

            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                return this.Error("All fields are required");
            }
            if (username.Length < 5 || username.Length > 20)
            {
                return this.Error("Username must be between 5 and 20.");
            }
            if (password.Length < 6 || password.Length > 20)
            {
                return this.Error("Password must be between 5 and 20.");
            }
            if (this.usersService.IsUsernameAvailable(username) == false)
            {
                return this.Error("Username taken");
            }
            if (this.usersService.IsEmailAvailable(email) == false)
            {
                return this.Error("Email taken");
            }
            if (password != confirmPassword)
            {
                return this.Error("Passwords doesn't match");
            }

            this.usersService.CreateUser(username, email, password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
