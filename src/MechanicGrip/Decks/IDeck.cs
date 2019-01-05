using System.Collections.Generic;
using MechanicGrip.Cards;

namespace MechanicGrip.Decks
{
    public interface IDeck
    { 
        void Shuffle(int iterations = 1);
        void Cut(int iterations = 1);
        Stack<ICard> Cards { get; }
        IEnumerable<IEnumerable<ICard>> Deal(int groups, int cardsPerGroup, bool asEvenPiles = true);
        ICard Draw();
    }
}
