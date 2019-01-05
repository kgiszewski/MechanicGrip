using System.Collections.Generic;
using MechanicGrip.Cards;
using MechanicGrip.Dealing;

namespace MechanicGrip.Decks
{
    public interface IDeck
    { 
        void Shuffle(int iterations = 1);
        void Cut(int iterations = 1);
        Stack<ICard> Cards { get; }
        IEnumerable<IEnumerable<ICard>> Deal(DealingOptions options = null);
        ICard Draw();
    }
}
