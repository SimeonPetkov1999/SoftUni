using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players.Where(x => x.GetType().Name == nameof(Terrorist));
            var counterTerrorists = players.Where(x => x.GetType().Name == nameof(CounterTerrorist));

            while (true)
            {
                Attack(terrorists, counterTerrorists);
                if (counterTerrorists.All(x => x.IsAlive == false))
                {
                    return "Terrorist wins!";
                }
                Attack(counterTerrorists, terrorists);
                if (terrorists.All(x => x.IsAlive == false))
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private void Attack(IEnumerable<IPlayer> attackers, IEnumerable<IPlayer> deffenders)
        {
            foreach (var attacker in attackers.Where(x => x.IsAlive))
            {
                foreach (var counterTerrorist in deffenders.Where(x => x.IsAlive))
                {
                    counterTerrorist.TakeDamage(attacker.Gun.Fire());
                }
            }
        }
    }
}
