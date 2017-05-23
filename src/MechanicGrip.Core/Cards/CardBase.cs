using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Cards
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
