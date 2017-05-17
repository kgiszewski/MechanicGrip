using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Cards
{
    public class CardBase : ICard
    {
        public IRank Rank { get; }
        public ISuit Suit { get; }

        public CardBase(ISuit suit, IRank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
