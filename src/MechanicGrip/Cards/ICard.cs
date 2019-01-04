using MechanicGrip.Ranks;
using MechanicGrip.Suits;

namespace MechanicGrip.Cards
{
    public interface ICard
    {
        IRank Rank { get; }
        ISuit Suit { get; }
    }
}
