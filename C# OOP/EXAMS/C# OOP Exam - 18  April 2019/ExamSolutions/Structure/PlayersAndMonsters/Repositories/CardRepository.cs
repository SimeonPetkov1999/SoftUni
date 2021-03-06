using System;
using System.Linq;
using System.Collections.Generic;

using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private List<ICard> cardsCollection;

        public CardRepository()
        {
            this.cardsCollection = new List<ICard>();
        }
        public int Count =>this.cardsCollection.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsCollection.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }

            var cardToCheck = cardsCollection.FirstOrDefault(c => c.Name == card.Name);
            if (cardToCheck != null)
            {
                throw new ArgumentException($"Card {cardToCheck.Name} already exists!");
            }

            this.cardsCollection.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cardsCollection.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }

            return this.cardsCollection.Remove(card);
        }
    }
}
