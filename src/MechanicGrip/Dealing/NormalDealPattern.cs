using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Decks;

namespace MechanicGrip.Dealing
{
    public class NormalDealPattern : IDealPattern
    {
        public IEnumerable<IEnumerable<ICard>> Deal(IDeck deck, int groups, int cardsPerGroup, bool asEvenPiles = true)
        {
            if (asEvenPiles)
            {
                //make sure we have enough cards
                if (groups * cardsPerGroup > deck.Cards.Count)
                {
                    throw new InvalidOperationException("There is not enough cards.");
                }
            }

            var dealtCards = new List<List<ICard>>();

            for (var i = 0; i < groups; i++)
            {
                var cardsForGroup = new List<ICard>();

                dealtCards.Add(cardsForGroup);

                for (var j = 0; j < cardsPerGroup; j++)
                {
                    if (!deck.Cards.Any())
                    {
                        break;
                    }

                    cardsForGroup.Add(deck.Draw());
                }
            }

            return dealtCards;
        }
    }
}
