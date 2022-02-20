using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.Services.Contracts;
using FootballManager.ViewModels.Player;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Services
{
    internal class PlayerService : IPlayerService
    {
        private readonly IValidationService validationService;
        private readonly FootballManagerDbContext context;

        public PlayerService(IValidationService validationService,
            FootballManagerDbContext context)
        {
            this.validationService = validationService;
            this.context = context;
        }

        public void AddPlayerToUserCollection(int playerId, string userId)
        {
            var user = this.context.Users.Include(x=>x.UserPlayers).FirstOrDefault(x=>x.Id == userId);
            if (!user.UserPlayers.Any(x=>x.PlayerId == playerId)) 
            {
                user.UserPlayers.Add(new UserPlayer() { PlayerId = playerId });
                context.SaveChanges();
            }         
        }

        public (bool created, string error) Create(AddPlayerInputModel model, string userId)
        {
            string error = null;
            bool isAdded = true;
            var (isValid, validationError) = this.validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            var player = new Player()
            {
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = (byte)model.Speed,
                Endurance = (byte)model.Endurance,
                Description = model.Description,
            };

            var user = context.Users.FirstOrDefault(x => x.Id == userId);
            user.UserPlayers.Add(new UserPlayer() { Player = player });

            try
            {
                context.SaveChanges();
            }
            catch (Exception)
            {
                isAdded = false;
                error = "Could not add player to db";
            }

            return (isAdded, error);
        }

        public IEnumerable<PlayerViewModel> GetAllPlayers()
        {
            return this.context.Players.Select(x => new PlayerViewModel
            {
                Description = x.Description,
                Endurance = x.Endurance,
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                PlayerId = x.Id,
                Position = x.Position,
                Speed = x.Speed
            }).ToList();
        }

        public IEnumerable<PlayerViewModel> GetAllPlayersForUser(string userId)
        {
            var user = this.context
                .Users
                .Include(x => x.UserPlayers)
                .ThenInclude(x => x.Player)
                .FirstOrDefault(x => x.Id == userId);

            var players = user.UserPlayers.Select(x => new PlayerViewModel()
            {

                Description = x.Player.Description,
                Endurance = x.Player.Endurance,
                FullName = x.Player.FullName,
                ImageUrl = x.Player.ImageUrl,
                PlayerId = x.Player.Id,
                Position = x.Player.Position,
                Speed = x.Player.Speed
            }).ToList();

            return players;
        }

        public void RemovePlayerFromUserCollection(int playerId, string userId)
        {
            var user = this.context.Users.Find(userId);
            var userPlayer = this.context.UserPlayers.FirstOrDefault(x => x.UserId == userId && x.PlayerId == playerId);

            user.UserPlayers.Remove(userPlayer);
            this.context.SaveChanges();
        }
    }
}
