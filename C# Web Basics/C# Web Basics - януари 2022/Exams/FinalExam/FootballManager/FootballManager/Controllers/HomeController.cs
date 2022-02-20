namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Services.Contracts;

    public class HomeController : Controller
    {
        private readonly IPlayerService playerService;

        public HomeController(Request request,
            IPlayerService playerService)
            : base(request)
        {
            this.playerService = playerService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                var players = this.playerService.GetAllPlayers();
                return View(new { IsAuthenticated = true, players }, "/Players/All");
            }

            return this.View(new { IsAuthenticated = false });
        }
    }
}
