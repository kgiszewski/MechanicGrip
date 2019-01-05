using System;
using System.Collections.Generic;
using System.Linq;
using MechanicGrip.Cards;
using MechanicGrip.Dealing;

namespace MechanicGrip.Decks
{
    public abstract class DeckBase : IDeck
    {
        private readonly IDealPattern _dealPattern;

        protected DeckBase(IDealPattern dealPattern)
        {
            _dealPattern = dealPattern;
        }

        protected Stack<ICard> CardStack { get; } = new Stack<ICard>();
        public List<ICard> Cards => CardStack.ToList();

        public IEnumerable<IEnumerable<ICard>> Deal(DealingOptions options = null)
        {
            return _dealPattern.Deal(this, options);
        }

        public ICard Draw()
        {
            if (!CardStack.Any())
            {
                throw new InvalidOperationException("There are no cards left!");
            }

            return CardStack.Pop();
        }

        private readonly Random _rand = new Random();

        public virtual void Cut(int iterations = 1)
        {
            for (var i = 0; i < iterations; i++)
            {
                var startingNumberOfCards = CardStack.Count;

                var splitDeck = _splitCardsIntoTwoHalves();
                var leftHandCards = splitDeck.Item1;
                var rightHandCards = splitDeck.Item2;

                _moveCards(leftHandCards, CardStack, leftHandCards.Count);
                _moveCards(rightHandCards, CardStack, rightHandCards.Count);

                if (CardStack.Count != startingNumberOfCards)
                {
                    throw new Exception($"You have a different number of cards in your deck! {CardStack.Count} != {startingNumberOfCards}");
                }
            }
        }

        public virtual void Shuffle(int iterations = 1)
        {
            for (var i = 0; i < iterations; i++)
            {
                var startingNumberOfCards = CardStack.Count;

                var splitDeck = _splitCardsIntoTwoHalves();
                var leftHandCards = splitDeck.Item1;
                var rightHandCards = splitDeck.Item2;

                //interleave cards either 1-3 cards at a time
                while (leftHandCards.Count > 0)
                {
                    _moveCards(leftHandCards, CardStack, _getNumberOfCardsToMove());
                    _moveCards(rightHandCards, CardStack, _getNumberOfCardsToMove());
                }

                //if any cards are leftover in the right hand deck, move them
                if (rightHandCards.Any())
                {
                    _moveCards(rightHandCards, CardStack, rightHandCards.Count);
                }

                if (CardStack.Count != startingNumberOfCards)
                {
                    throw new Exception($"You have a different number of cards in your deck! {CardStack.Count} != {startingNumberOfCards}");
                }
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
            var totalNumberOfCards = CardStack.Count;

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
            _moveCards(CardStack, leftHandCards, leftHandCardsCount);

            var rightHandCards = new Stack<ICard>();
            _moveCards(CardStack, rightHandCards, rightHandCardsCount);

            if (CardStack.Any())
            {
                throw new Exception("You shouldn't have any cards left in the pile!");
            }

            return new Tuple<Stack<ICard>, Stack<ICard>>(leftHandCards, rightHandCards);
        }
    }
}
