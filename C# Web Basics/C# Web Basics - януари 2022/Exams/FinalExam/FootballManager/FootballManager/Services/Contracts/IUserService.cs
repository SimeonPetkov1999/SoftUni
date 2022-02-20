using FootballManager.ViewModels.User;

namespace FootballManager.Services.Contracts
{
    public interface IUserService
    {
        (bool registered, string error) Register(RegisterUserInputModel model);

        string Login(LoginInputModel model);
    }
}
