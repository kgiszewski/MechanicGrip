using System.Collections.Generic;
using MechanicGrip.Cards;
using MechanicGrip.Ranks;
using MechanicGrip.Suits;

namespace MechanicGrip.Decks
{
    public class EuchreDeck : DeckBase
    {
        public EuchreDeck()
        {
            Cards.Clear();

            var suits = new List<ISuit>
            {
                StandardSuit.Clubs,
                StandardSuit.Diamonds,
                StandardSuit.Spades,
                StandardSuit.Hearts
            };

            var ranks = new List<IRank>
            {
                new StandardRank(9, StandardRank.NineSymbol, StandardRank.Nine),
                new StandardRank(10, StandardRank.TenSymbol, StandardRank.Ten),
                new StandardRank(11, StandardRank.JackSymbol, StandardRank.Jack),
                new StandardRank(12, StandardRank.QueenSymbol, StandardRank.Queen),
                new StandardRank(13, StandardRank.KingSymbol, StandardRank.King),
                new StandardRank(14, StandardRank.AceSymbol, StandardRank.Ace)
            };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    Cards.Push(new StandardCard(suit, rank));
                }
            }
        }
    }
}
