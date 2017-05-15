using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Core.Cards;
using MechanicGrip.Core.Decks;
using NUnit.Framework;

namespace MechanicGrip.Core.Tests.UnitTests
{
    [TestFixture]
    public class StandardDeckTests
    {
        [Test]
        public void Deck_Has_52_Cards()
        {
            var sut = new StandardDeck();

            sut.Initialize();

            var cards = sut.GetDeck();

            Assert.AreEqual(52, cards.Count());
        }

        [Test]
        public void All_Cards_Are_Unique()
        {
            var sut = new StandardDeck();

            sut.Initialize();

            var cards = sut.GetDeck();

            var hashes = new Dictionary<int, Card>();

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

            Assert.AreEqual(52, hashes.Count);
        }

        [Test]
        public void Can_Shuffle_Cards()
        {
            var sut = new StandardDeck();
            
            sut.Initialize();

            for (var i = 0; i < 100; i++)
            {
                sut.Shuffle();
            }

            All_Cards_Are_Unique();

            Deck_Has_52_Cards();
        }

        [Test]
        public void Can_Cut_Cards()
        {
            var sut = new StandardDeck();

            sut.Initialize();

            sut.Cut();

            All_Cards_Are_Unique();

            Deck_Has_52_Cards();
        }

        [Test]
        [Ignore]
        public void Utility()
        {
            var sut = new StandardDeck();
            sut.Initialize();

            var cards = sut.GetDeck();

            _dumpToConsole(cards);

            sut.Cut();

            _dumpToConsole(cards);
        }

        private void _dumpToConsole(Stack<Card> cards)
        {
            Console.WriteLine($"====");

            foreach (var card in cards)
            {
                Console.WriteLine($"{card.Rank.Name} of {card.Suit.Name}");
            }
        }
    }
}
