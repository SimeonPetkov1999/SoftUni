using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private MainPlayer mainPlayer;
        private List<IPlayer> civilPlayers;
        private GunRepository gunRepo;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.gunRepo = new GunRepository();
        }
        public string AddGun(string type, string name)
        {
            if (type == "Rifle" || type =="Pistol")
            {
                IGun gun;
                if (type=="Rifle")
                {
                    gun = new Rifle(name);
                }
                else
                {
                    gun = new Pistol(name);
                }
                this.gunRepo.Add(gun);
                return $"Successfully added {name} of type: {type}";
            }
            else
            {
                return "Invalid gun type!";
            }
        }

        public string AddGunToPlayer(string name)
        {
            if (this.gunRepo.Models.Count <= 0)
            {
                return "There are no guns in the queue!";
            }
            else if (name == "Vercetti")
            {
                var gun = this.gunRepo.Models.First();
                this.mainPlayer.GunRepository.Add(gun);
                this.gunRepo.Remove(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            else if (this.civilPlayers.Any(p => p.Name == name)==false)
            {
                return "Civil player with that name doesn't exists!";
            }

            var civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            var civilPlayerGun = this.gunRepo.Models.First();
            civilPlayer.GunRepository.Add(civilPlayerGun);
            this.gunRepo.Remove(civilPlayerGun);
            return $"Successfully added {civilPlayerGun.Name} to the Civil Player: {civilPlayer.Name}";

        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            this.civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var neighbourhood = new GangNeighbourhood();
            var mainPlayerPoints = this.mainPlayer.LifePoints;
            var civilPlayerPoints = this.civilPlayers.Sum(p => p.LifePoints);
            var civilPlayersCount = this.civilPlayers.Count;
            neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            if (this.mainPlayer.LifePoints == mainPlayerPoints && this.civilPlayers.Sum(p => p.LifePoints) == civilPlayerPoints)
            {
                return $"Everything is okay!";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"A fight happened:");
            sb.AppendLine($"Tommy live points: {this.mainPlayer.LifePoints}!");
            sb.AppendLine($"Tommy has killed: {civilPlayersCount - this.civilPlayers.Count} players!");
            sb.AppendLine($"Left Civil Players: {this.civilPlayers.Count}!");

            return sb.ToString().TrimEnd();

        }
    }
}
