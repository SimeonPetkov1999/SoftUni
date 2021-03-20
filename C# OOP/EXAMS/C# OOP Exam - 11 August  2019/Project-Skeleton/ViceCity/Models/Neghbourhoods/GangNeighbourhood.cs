using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            if (mainPlayer.GunRepository.Models.Count==0)
            {
                return;
            }
          
            while (mainPlayer.GunRepository.Models.Any() || civilPlayers.All(p => p.IsAlive == false))
            {
                var mainPlayerGun = mainPlayer.GunRepository.Models.First();
                var currentCivilPlayer = civilPlayers.First();
                if (mainPlayerGun.TotalBullets <= 0)
                 {
                    mainPlayer.GunRepository.Remove(mainPlayerGun);
                    if (mainPlayer.GunRepository.Models.Count==0)
                    {
                        continue;
                    }
                    mainPlayerGun = mainPlayer.GunRepository.Models.First();
                }

                currentCivilPlayer.TakeLifePoints(mainPlayerGun.Fire());                  
                
                if (currentCivilPlayer.IsAlive == false)                  
                {
                    if (civilPlayers.Count == 1)
                    {
                        civilPlayers.Remove(currentCivilPlayer);
                        return;
                    }
                    civilPlayers.Remove(currentCivilPlayer);              
                    currentCivilPlayer = civilPlayers.First();            
                }
            }

           
            while (civilPlayers.Any(p => p.GunRepository.Models.Count <= 0))
            {
                var currentCivilPlayer = civilPlayers.First();
                var currentCivilPlayerGun = currentCivilPlayer.GunRepository.Models.First();
                if (currentCivilPlayerGun.TotalBullets <= 0)
                {
                    currentCivilPlayer.GunRepository.Remove(currentCivilPlayerGun);
                    currentCivilPlayerGun = currentCivilPlayer.GunRepository.Models.First();
                }

                mainPlayer.TakeLifePoints(currentCivilPlayerGun.Fire());

                if (mainPlayer.IsAlive == false)
                {
                    return;
                }

                if (currentCivilPlayer.GunRepository.Models.Count == 0)
                {
                    civilPlayers.Remove(currentCivilPlayer);
                    currentCivilPlayer = civilPlayers.First();
                }
            }

        }

    }
}
