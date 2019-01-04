using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Decks;
using NUnit.Framework;

namespace MechanicGrip.Tests.UnitTests
{
    [TestFixture]
    public class StandardDeckTests
    {
        [Test]
        public void Deck_Has_52_Cards()
        {
            var sut = new StandardDeck();

            var cards = sut.Cards;
            
            Assert.AreEqual(52, cards.Count());
        }

        [Test]
        public void All_Cards_Are_Unique()
        {
            var sut = new StandardDeck();

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

            Assert.AreEqual(52, hashes.Count);
        }

        [Test]
        public void Can_Shuffle_Cards()
        {
            var sut = new StandardDeck();
           
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

            sut.Cut();

            All_Cards_Are_Unique();

            Deck_Has_52_Cards();
        }

        [Test]
        [Ignore]
        public void Utility()
        {
            var sut = new StandardDeck();

            var cards = sut.Cards;

            _dumpToConsole(cards);

            sut.Cut();

            _dumpToConsole(cards);
        }

        private void _dumpToConsole(Stack<ICard> cards)
        {
            Console.WriteLine($"====");

            foreach (var card in cards)
            {
                Console.WriteLine($"{card.Rank.Name} of {card.Suit.Name}");
            }
        }
    }
}
