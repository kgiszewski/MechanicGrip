﻿using System.Collections.Generic;
using MechanicGrip.Core.Cards;
using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Decks
{
    public class EuchreDeck : StandardDeck
    {
        public override void Initialize()
        {
            Cards.Clear();

            var suits = new List<ISuit>
            {
                new Suit(Suit.Clubs, Suit.ClubsSymbol),
                new Suit(Suit.Spades, Suit.SpadesSymbol),
                new Suit(Suit.Hearts, Suit.HeartsSymbol),
                new Suit(Suit.Diamonds, Suit.DiamondsSymbol)
            };

            var ranks = new List<IRank>
            {
                new Rank(9, Rank.NineSymbol, Rank.Nine),
                new Rank(10, Rank.TenSymbol, Rank.Ten),
                new Rank(11, Rank.JackSymbol, Rank.Jack),
                new Rank(12, Rank.QueenSymbol, Rank.Queen),
                new Rank(13, Rank.KingSymbol, Rank.King),
                new Rank(14, Rank.AceSymbol, Rank.Ace)
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
