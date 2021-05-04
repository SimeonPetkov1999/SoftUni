using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        bool IsUserValid(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}
