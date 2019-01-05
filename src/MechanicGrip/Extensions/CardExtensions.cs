using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;

namespace MechanicGrip.Extensions
{
    public static class CardExtensions
    {
        public static bool ContainsCard(this IEnumerable<ICard> cards, ICard card)
        {
            return cards.Any(x => x.Rank.Symbol == card.Rank.Symbol && x.Suit == card.Suit);
        }
    }
}
