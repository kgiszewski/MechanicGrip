using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Dealing;
using MechanicGrip.Decks;
using MechanicGrip.Extensions;
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

        [Test]
        public void Can_Deal_Cards()
        {
            var sut = new EuchreDeck();

            var newSetOfCards = new EuchreDeck();

            var result = sut.Deal().ToList();

            var player1ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop()
            };

            var player2ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop()
            };

            var player3ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
            };
            
            var player4ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
            };

            player1ExpectedCards.Add(newSetOfCards.Draw());
            player1ExpectedCards.Add(newSetOfCards.Draw());

            player2ExpectedCards.Add(newSetOfCards.Draw());
            player2ExpectedCards.Add(newSetOfCards.Draw());
            player2ExpectedCards.Add(newSetOfCards.Draw());

            player3ExpectedCards.Add(newSetOfCards.Draw());
            player3ExpectedCards.Add(newSetOfCards.Draw());

            player4ExpectedCards.Add(newSetOfCards.Draw());
            player4ExpectedCards.Add(newSetOfCards.Draw());
            player4ExpectedCards.Add(newSetOfCards.Draw());

            var dealtPile1 = result.ElementAt(0).ToList();

            Assert.AreEqual(player1ExpectedCards.Count, dealtPile1.Count);

            foreach (var card in player1ExpectedCards)
            {
                Assert.IsTrue(dealtPile1.ContainsCard(card));
            }

            var dealtPile2 = result.ElementAt(1).ToList();

            Assert.AreEqual(player2ExpectedCards.Count, dealtPile2.Count);

            foreach (var card in player2ExpectedCards)
            {
                Assert.IsTrue(dealtPile2.ContainsCard(card));
            }

            var dealtPile3 = result.ElementAt(2).ToList();

            Assert.AreEqual(player3ExpectedCards.Count, dealtPile3.Count);

            foreach (var card in player3ExpectedCards)
            {
                Assert.IsTrue(dealtPile3.ContainsCard(card));
            }

            var dealtPile4 = result.ElementAt(3).ToList();

            Assert.AreEqual(player4ExpectedCards.Count, dealtPile4.Count);

            foreach (var card in player4ExpectedCards)
            {
                Assert.IsTrue(dealtPile4.ContainsCard(card));
            }
        }
    }
}
