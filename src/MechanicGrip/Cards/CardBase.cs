using MechanicGrip.Ranks;
using MechanicGrip.Suits;

namespace MechanicGrip.Cards
{
    public abstract class CardBase : ICard
    {
        public IRank Rank { get; }
        public ISuit Suit { get; }

        protected CardBase(ISuit suit, IRank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
