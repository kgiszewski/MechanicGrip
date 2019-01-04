using System.Collections.Generic;
using MechanicGrip.Core.Cards;

namespace MechanicGrip.Core.Decks
{
    public interface IDeck
    { 
        void Shuffle();
        void Cut();
        Stack<ICard> Cards { get; }
    }
}
