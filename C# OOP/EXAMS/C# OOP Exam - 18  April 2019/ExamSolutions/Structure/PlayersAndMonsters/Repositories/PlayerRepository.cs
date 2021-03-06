using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    class PlayerRepository : IPlayerRepository
    {
        private List<IPlayer> playersCollection;

        public PlayerRepository()
        {
            this.playersCollection = new List<IPlayer>();
        }
        public int Count => this.playersCollection.Count;

        public IReadOnlyCollection<IPlayer> Players => this.playersCollection.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null");
            }
            var playerToCheck = this.playersCollection.FirstOrDefault(p => p.Username == player.Username);
            if (playerToCheck != null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.playersCollection.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.playersCollection.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException($"Player cannot be null");
            }

            return this.playersCollection.Remove(player);
        }
    }
}
