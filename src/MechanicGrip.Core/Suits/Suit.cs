using System;

namespace MechanicGrip.Core.Suits
{
    public class Suit : SuitBase
    {
        public static string Clubs = "Clubs";
        public static string Spades = "Spades";
        public static string Hearts = "Hearts";
        public static string Diamonds = "Diamonds";

        public static char HeartsSymbol = '\u2665';
        public static char DiamondsSymbol = '\u2666';
        public static char SpadesSymbol = '\u2660';
        public static char ClubsSymbol = '\u2663';

        public Suit(string name, char symbol) : base(name, symbol)
        {
        }
    }
}
