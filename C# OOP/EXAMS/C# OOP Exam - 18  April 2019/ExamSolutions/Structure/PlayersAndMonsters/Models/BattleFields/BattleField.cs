using System;
using System.Linq;

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.BattleFields.Contracts;
namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException($"Player is dead!");
            }

            IncreaseHealthAndDamageIfBeginner(attackPlayer, enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository
                     .Cards
                     .Select(c => c.HealthPoints)
                     .Sum();

            enemyPlayer.Health += enemyPlayer.CardRepository
                     .Cards
                     .Select(c => c.HealthPoints)
                     .Sum();

            while (true)
            {
                var attackPlayerPointsFromCards = attackPlayer
                                    .CardRepository
                                    .Cards
                                    .Select(c => c.DamagePoints)
                                    .Sum();

                enemyPlayer.TakeDamage(attackPlayerPointsFromCards);
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                var enemyPlayerPointsFromCards = enemyPlayer
                                    .CardRepository
                                    .Cards
                                    .Select(c => c.DamagePoints)
                                    .Sum();

                attackPlayer.TakeDamage(enemyPlayerPointsFromCards);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }          
        }

        private static void IncreaseHealthAndDamageIfBeginner(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;
                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
