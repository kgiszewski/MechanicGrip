using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Decks;
using MechanicGrip.Extensions;
using MechanicGrip.Ranks;
using MechanicGrip.Suits;
using NUnit.Framework;

namespace MechanicGrip.Tests.UnitTests
{
    [TestFixture]
    public class StandardDeckTests
    {
        [TestCase(1, 52)]
        [TestCase(2, 104)]
        [TestCase(100, 5200)]
        public void Deck_Has_N_Cards(int deckCount, int expectedCardCount)
        {
            var sut = new StandardDeck(deckCount);

            var cards = sut.Cards;

            Assert.AreEqual(expectedCardCount, cards.Count);

            //we should have n-number of any particular card
            var queenOfHearts = cards.Where(x => x.Rank.Name == StandardRank.Queen && x.Suit == StandardSuit.Hearts);

            Assert.AreEqual(deckCount, queenOfHearts.Count());
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

            sut.Shuffle(100);

            All_Cards_Are_Unique();

            Assert.AreEqual(52, sut.Cards.Count);
        }

        [Test]
        public void Can_Cut_Cards()
        {
            var sut = new StandardDeck();

            sut.Cut(100);

            All_Cards_Are_Unique();

            Assert.AreEqual(52, sut.Cards.Count);
        }

        [Test]
        public void Can_Deal_Cards()
        {
            var sut = new StandardDeck();

            //throws if more than the cards in deck
            Assert.Throws<InvalidOperationException>(() =>
            {
                sut.Deal(1, 100);
            });

            sut = new StandardDeck();

            //does not throw if more than the cards in deck
            Assert.DoesNotThrow(() =>
            {
                sut.Deal(1, 100, false);
            });

            sut = new StandardDeck();

            var newSetOfCards = new StandardDeck();

            var result = sut.Deal(3, 5).ToList();

            var player1ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop()
            };

            var player2ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop()
            };

            var player3ExpectedCards = new List<ICard>
            {
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop(),
                newSetOfCards.Cards.Pop()
            };

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
        }

        [Test]
        public void Can_Draw_A_Card()
        {
            var sut = new StandardDeck();
            
            Assert.DoesNotThrow(() =>
            {
                var card = sut.Draw();

                Assert.IsNotNull(card);
            });

            var cardCount = sut.Cards.Count;

            for (var i = 0; i < cardCount; i++)
            {
                sut.Draw();
            }

            Assert.Throws<InvalidOperationException>(() => { sut.Draw(); });
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
