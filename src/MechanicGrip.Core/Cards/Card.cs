using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Cards
{
    public class StandardCard : CardBase
    {
        public StandardCard(ISuit suit, IRank rank) : base(suit, rank)
        {
        }
    }
}
