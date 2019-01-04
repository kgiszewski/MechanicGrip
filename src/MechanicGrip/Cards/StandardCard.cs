using MechanicGrip.Ranks;
using MechanicGrip.Suits;

namespace MechanicGrip.Cards
{
    public class StandardCard : CardBase
    {
        public StandardCard(ISuit suit, IRank rank) : base(suit, rank)
        {
        }
    }
}
