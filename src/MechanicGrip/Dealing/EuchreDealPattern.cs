using System.Collections.Generic;
using MechanicGrip.Cards;
using MechanicGrip.Decks;

namespace MechanicGrip.Dealing
{
    public class EuchreDealPattern : IDealPattern
    {
        public IEnumerable<IEnumerable<ICard>> Deal(IDeck deck, DealingOptions options)
        {
            //we will ignore the options
            var dealtCards = new List<List<ICard>>();

            var group1 = new List<ICard>();
            var group2 = new List<ICard>();
            var group3 = new List<ICard>();
            var group4 = new List<ICard>();

            dealtCards.Add(group1);
            dealtCards.Add(group2);
            dealtCards.Add(group3);
            dealtCards.Add(group4);

            var firstRound = true;

            //we need to go thru 8 times and we will create 4 groups of 5
            for (var i = 0; i < 2; i++)
            {
                if (firstRound)
                {
                    group1.Add(deck.Draw());
                    group1.Add(deck.Draw());
                    group1.Add(deck.Draw());

                    group2.Add(deck.Draw());
                    group2.Add(deck.Draw());

                    group3.Add(deck.Draw());
                    group3.Add(deck.Draw());
                    group3.Add(deck.Draw());

                    group4.Add(deck.Draw());
                    group4.Add(deck.Draw());
                }
                else
                {
                    group1.Add(deck.Draw());
                    group1.Add(deck.Draw());

                    group2.Add(deck.Draw());
                    group2.Add(deck.Draw());
                    group2.Add(deck.Draw());

                    group3.Add(deck.Draw());
                    group3.Add(deck.Draw());

                    group4.Add(deck.Draw());
                    group4.Add(deck.Draw());
                    group4.Add(deck.Draw());
                }

                firstRound = false;
            }

            return dealtCards;
        }
    }
}
