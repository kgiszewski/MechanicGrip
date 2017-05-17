using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Cards
{
    public interface ICard
    {
        IRank Rank { get; }
        ISuit Suit { get; }
    }
}
