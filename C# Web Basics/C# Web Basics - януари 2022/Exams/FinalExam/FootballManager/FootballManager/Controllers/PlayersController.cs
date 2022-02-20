using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Services.Contracts;
using FootballManager.ViewModels.Player;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(Request request,
            IPlayerService playerService) : base(request)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public Response All()
        {
            var players = this.playerService.GetAllPlayers();

            return View(new { IsAuthenticated = true, players });
        }

        [Authorize]
        public Response Add()
        {
            return View(new { IsAuthenticated = true });
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddPlayerInputModel model)
        {
            var (isAdded, error) = this.playerService.Create(model, this.User.Id);

            if (!isAdded)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public Response Collection()
        {
            var playersOfuser = this.playerService.GetAllPlayersForUser(this.User.Id);
            return View(new { IsAuthenticated = true, playersOfuser });
        }

        [Authorize]
        public Response RemoveFromCollection(int playerId) 
        {
            this.playerService.RemovePlayerFromUserCollection(playerId, this.User.Id);
            
            return Redirect("/Players/Collection");
        }

        public Response AddToCollection(int playerId)
        { 
            this.playerService.AddPlayerToUserCollection(playerId, this.User.Id);

            return Redirect("/Players/All");
        }
    }
}
