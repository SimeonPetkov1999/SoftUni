using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            if (type==nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            this.guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player;
            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type== nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            this.players.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);

        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var item in this.players.Models
                                             .OrderBy(x=>x.GetType().Name)
                                             .ThenByDescending(x=>x.Health)
                                             .ThenBy(x=>x.Username))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var alivePlayers = this.players.Models.Where(x => x.IsAlive).ToList();
            var result = this.map.Start(alivePlayers);
            return result;
        }
    }
}
