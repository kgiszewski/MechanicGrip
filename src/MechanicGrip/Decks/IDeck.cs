using System.Collections.Generic;
using MechanicGrip.Cards;

namespace MechanicGrip.Decks
{
    public interface IDeck
    { 
        void Shuffle();
        void Cut();
        Stack<ICard> Cards { get; }
    }
}
