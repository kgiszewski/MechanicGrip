using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Decks;

namespace MechanicGrip.Dealing
{
    public class NormalDealPattern : IDealPattern
    {
        public IEnumerable<IEnumerable<ICard>> Deal(IDeck deck, DealingOptions options)
        {
            if (options.AsEvenPiles)
            {
                //make sure we have enough cards
                if (options.Groups * options.CardsPerGroup > deck.Cards.Count)
                {
                    throw new InvalidOperationException("There is not enough cards.");
                }
            }

            var dealtCards = new List<List<ICard>>();

            for (var i = 0; i < options.Groups; i++)
            {
                var cardsForGroup = new List<ICard>();

                dealtCards.Add(cardsForGroup);

                for (var j = 0; j < options.CardsPerGroup; j++)
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
