using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Cards
{
    public class Card
    {
        private Rank _rank;
        public Rank Rank => _rank;

        private Suit _suit;
        public Suit Suit => _suit;

        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }
    }
}
