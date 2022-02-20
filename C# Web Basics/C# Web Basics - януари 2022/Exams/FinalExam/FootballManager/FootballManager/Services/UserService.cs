using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services.Contracts;
using FootballManager.ViewModels.User;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IValidationService validationService;
        private readonly FootballManagerDbContext context;

        public UserService(IValidationService validationService,
            FootballManagerDbContext context)
        {
            this.validationService = validationService;
            this.context = context;
        }

        public string Login(LoginInputModel model)
        {
            var user = context.Users
               .Where(u => u.Username == model.Username)
               .Where(u => u.Password == CalculateHash(model.Password))
               .FirstOrDefault();

            return user?.Id;
        }

        public (bool registered, string error) Register(RegisterUserInputModel model)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            if (this.context.Users.Any(x => x.Username == model.Username))
            {
                return (false,  "Username already taken!" );
            }

            User user = new User()
            {
                Email = model.Email,
                Password = CalculateHash(model.Password),
                Username = model.Username,
            };

            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error ="Could not save user in DB";
            }

            return (registered, error);
        }

        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
