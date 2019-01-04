using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Decks;
using NUnit.Framework;

namespace MechanicGrip.Tests.UnitTests
{
    [TestFixture]
    public class EuchreDeckTests
    {
        [Test]
        public void Deck_Has_24_Cards()
        {
            var sut = new EuchreDeck();

            var cards = sut.Cards;
            
            Assert.AreEqual(24, cards.Count());
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

            Deck_Has_24_Cards();
        }

        [Test]
        public void Can_Cut_Cards()
        {
            var sut = new EuchreDeck();

            sut.Cut();

            All_Cards_Are_Unique();

            Deck_Has_24_Cards();
        }
    }
}
