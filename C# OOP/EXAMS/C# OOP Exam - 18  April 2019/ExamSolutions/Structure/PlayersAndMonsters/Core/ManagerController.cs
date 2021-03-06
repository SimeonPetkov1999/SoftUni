namespace PlayersAndMonsters.Core
{
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Repositories;

    public class ManagerController : IManagerController
    {
        private PlayerRepository playerRepo;
        private CardRepository cardsRepo;
        private BattleField battleField;
        public ManagerController()
        {
            this.playerRepo = new PlayerRepository();
            this.cardsRepo = new CardRepository();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var factory = new PlayerFactory();
            var player = factory.CreatePlayer(type, username);
            this.playerRepo.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            var factory = new CardFactory();
            var card = factory.CreateCard(type, name);
            this.cardsRepo.Add(card);
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var card = cardsRepo.Find(cardName);
            var player = playerRepo.Find(username);
            player.CardRepository.Add(card);
            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = playerRepo.Find(attackUser);
            var enemyPlayer = playerRepo.Find(enemyUser);
            battleField.Fight(attackPlayer, enemyPlayer);
            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var player in playerRepo.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine($"###");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
