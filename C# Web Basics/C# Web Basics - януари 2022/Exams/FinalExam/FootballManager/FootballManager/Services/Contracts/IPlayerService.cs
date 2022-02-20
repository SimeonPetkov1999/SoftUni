using FootballManager.ViewModels.Player;

namespace FootballManager.Services.Contracts
{
    public interface IPlayerService
    {
        (bool created, string error) Create(AddPlayerInputModel model, string userId);

        IEnumerable<PlayerViewModel> GetAllPlayers();

        IEnumerable<PlayerViewModel> GetAllPlayersForUser(string userId);

        void RemovePlayerFromUserCollection(int playerId, string userId);

        void AddPlayerToUserCollection(int playerId, string userId);
    }
}
