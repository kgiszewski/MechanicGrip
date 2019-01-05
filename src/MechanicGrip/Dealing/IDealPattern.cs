using System.Collections.Generic;
using MechanicGrip.Cards;
using MechanicGrip.Decks;

namespace MechanicGrip.Dealing
{
    public interface IDealPattern
    {
        IEnumerable<IEnumerable<ICard>> Deal(IDeck deck, int groups, int cardsPerGroup, bool asEvenPiles = true);
    }
}
