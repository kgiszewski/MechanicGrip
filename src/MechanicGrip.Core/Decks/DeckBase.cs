using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Core.Cards;
using MechanicGrip.Core.Ranks;
using MechanicGrip.Core.Suits;

namespace MechanicGrip.Core.Decks
{
    public abstract class DeckBase : IDeck
    {
        public Stack<ICard> Cards { get; } = new Stack<ICard>();
        private readonly Random _rand = new Random();

        public virtual void Cut()
        {
            var startingNumberOfCards = Cards.Count();

            var splitDeck = _splitCardsIntoTwoHalves();
            var leftHandCards = splitDeck.Item1;
            var rightHandCards = splitDeck.Item2;

            _moveCards(leftHandCards, Cards, leftHandCards.Count);
            _moveCards(rightHandCards, Cards, rightHandCards.Count);

            if (Cards.Count() != startingNumberOfCards)
            {
                throw new Exception($"You have a different number of cards in your deck! {Cards.Count} != {startingNumberOfCards}");
            }
        }

        public virtual void Initialize()
        {
            var suits = new List<ISuit>
            {
                new Suit(Suit.Clubs, Suit.ClubsSymbol),
                new Suit(Suit.Spades, Suit.SpadesSymbol),
                new Suit(Suit.Hearts, Suit.HeartsSymbol),
                new Suit(Suit.Diamonds, Suit.DiamondsSymbol)
            };

            var ranks = new List<IRank>
            {
                new Rank(2, Rank.TwoSymbol, Rank.Two),
                new Rank(3, Rank.ThreeSymbol, Rank.Three),
                new Rank(4, Rank.FourSymbol, Rank.Four),
                new Rank(5, Rank.FiveSymbol, Rank.Five),
                new Rank(6, Rank.SixSymbol, Rank.Six),
                new Rank(7, Rank.SevenSymbol, Rank.Seven),
                new Rank(8, Rank.EightSymbol, Rank.Eight),
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

        public virtual void Shuffle()
        {
            var startingNumberOfCards = Cards.Count();

            var splitDeck = _splitCardsIntoTwoHalves();
            var leftHandCards = splitDeck.Item1;
            var rightHandCards = splitDeck.Item2;

            //interleave cards either 1-3 cards at a time
            while (leftHandCards.Count > 0)
            {
                _moveCards(leftHandCards, Cards, _getNumberOfCardsToMove());
                _moveCards(rightHandCards, Cards, _getNumberOfCardsToMove());
            }

            //if any cards are leftover in the right hand deck, move them

            if (rightHandCards.Any())
            {
                _moveCards(rightHandCards, Cards, rightHandCards.Count());
            }

            if (Cards.Count() != startingNumberOfCards)
            {
                throw new Exception($"You have a different number of cards in your deck! {Cards.Count} != {startingNumberOfCards}");
            }
        }

        private static void _moveCards(Stack<ICard> fromStack, Stack<ICard> toStack, int numberOfCards)
        {
            var tempList = new List<ICard>();

            var iterations = (fromStack.Count < numberOfCards) ? fromStack.Count : numberOfCards;

            for (var i = 0; i < iterations; i++)
            {
                tempList.Add(fromStack.Pop());
            }

            tempList.Reverse();

            foreach (var card in tempList)
            {
                toStack.Push(card);
            }
        }

        private int _getNumberOfCardsToMove()
        {
            //grab some cards from the left
            var cardsToMove = _rand.Next(3);

            //make sure we get at least 1
            if (cardsToMove == 0)
            {
                cardsToMove = 1;
            }

            return cardsToMove;
        }

        private Tuple<Stack<ICard>, Stack<ICard>> _splitCardsIntoTwoHalves()
        {
            //split deck into two similar halves
            var totalNumberOfCards = Cards.Count();

            var leftHandCardsCount = (totalNumberOfCards / 2);
            var rightHandCardsCount = totalNumberOfCards - leftHandCardsCount;

            //up to 3 cards difference
            var randomVariance = _rand.Next(3);
            var addOrRemove = _rand.Next(1);

            if (addOrRemove == 0)
            {
                leftHandCardsCount += randomVariance;
                rightHandCardsCount -= randomVariance;
            }
            else
            {
                leftHandCardsCount -= randomVariance;
                rightHandCardsCount += randomVariance;
            }

            var leftHandCards = new Stack<ICard>();
            _moveCards(Cards, leftHandCards, leftHandCardsCount);

            var rightHandCards = new Stack<ICard>();
            _moveCards(Cards, rightHandCards, rightHandCardsCount);

            if (Cards.Any())
            {
                throw new Exception("You shouldn't have any cards left in the pile!");
            }

            return new Tuple<Stack<ICard>, Stack<ICard>>(leftHandCards, rightHandCards);
        }
    }
}
