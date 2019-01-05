using System.Collections.Generic;
using MechanicGrip.Cards;
using MechanicGrip.Dealing;
using MechanicGrip.Ranks;
using MechanicGrip.Suits;

namespace MechanicGrip.Decks
{
    public class EuchreDeck : DeckBase
    {
        public EuchreDeck(int deckCount = 1)
            :this(new EuchreDealPattern(), deckCount)
        {
            
        }

        public EuchreDeck(IDealPattern dealPattern, int deckCount = 1)
            :base(dealPattern)
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

            for (var i = 0; i < deckCount; i++)
            {
                foreach (var suit in suits)
                {
                    foreach (var rank in ranks)
                    {
                        CardStack.Push(new StandardCard(suit, rank));
                    }
                }
            }
        }
    }
}
