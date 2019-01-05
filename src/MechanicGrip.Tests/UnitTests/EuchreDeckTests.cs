using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Decks;
using MechanicGrip.Ranks;
using MechanicGrip.Suits;
using NUnit.Framework;

namespace MechanicGrip.Tests.UnitTests
{
    [TestFixture]
    public class EuchreDeckTests
    {
        [Test]
        [TestCase(1, 24)]
        [TestCase(2, 48)]
        public void Deck_Has_N_Cards(int deckCount, int expectedCardCount)
        {
            var sut = new EuchreDeck(deckCount);

            var cards = sut.Cards;

            Assert.AreEqual(expectedCardCount, cards.Count);

            //we should have n-number of any particular card
            var queenOfHearts = cards.Where(x => x.Rank.Name == StandardRank.Queen && x.Suit == StandardSuit.Hearts);

            Assert.AreEqual(deckCount, queenOfHearts.Count());
        }

        [Test]
        public void All_Cards_Are_Unique()
        {
            var sut = new EuchreDeck();

            var cards = sut.Cards;

            var hashes = new Dictionary<int, ICard>();

            foreach (var card in cards)
            {
                var hash = card.GetHashCode();

                if (hashes.ContainsKey(hash))
                {
                    throw new Exception($"{card.Rank} {card.Suit} has already been added to this list!");
                }
                else
                {
                    hashes.Add(hash, card);
                } 
            }

            Assert.AreEqual(24, hashes.Count);
        }

        [Test]
        public void Can_Shuffle_Cards()
        {
            var sut = new EuchreDeck();
           
            for (var i = 0; i < 100; i++)
            {
                sut.Shuffle();
            }

            All_Cards_Are_Unique();

            Assert.AreEqual(24, sut.Cards.Count);
        }

        [Test]
        public void Can_Cut_Cards()
        {
            var sut = new EuchreDeck();

            sut.Cut();

            All_Cards_Are_Unique();

            Assert.AreEqual(24, sut.Cards.Count);
        }
    }
}
