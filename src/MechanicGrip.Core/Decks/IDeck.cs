using System.Collections.Generic;
using MechanicGrip.Core.Cards;

namespace MechanicGrip.Core.Decks
{
    public interface IDeck
    {
        void Initialize();
        void Shuffle();
        void Cut();
        Stack<Card> GetDeck();
    }
}
