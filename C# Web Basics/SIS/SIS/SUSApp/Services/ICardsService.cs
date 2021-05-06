using SUSApp.VIewModels.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUSApp.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardInputModel input);

        IEnumerable<CardViewModel> GetAll();

        IEnumerable<CardViewModel> GetByUserId(string userId);

        void AddCardToUserCollection(string userId, int cardId);

        void RemoveCardFromUserCollection(string userId, int cardId);
    }
}
