﻿namespace MechanicGrip.Core.Ranks
{
    public class Rank
    {
        private int _value;
        public int Value => _value;

        private string _symbol;
        public string Symbol => _symbol;

        private string _name;
        public string Name => _name;

        public static string Two = "Two";
        public static string Three = "Three";
        public static string Four = "Four";
        public static string Five = "Five";
        public static string Six = "Six";
        public static string Seven = "Seven";
        public static string Eight = "Eight";
        public static string Nine = "Nine";
        public static string Ten = "Ten";
        public static string Jack = "Jack";
        public static string Queen = "Queen";
        public static string King = "King";
        public static string Ace = "Ace";

        public static string TwoSymbol = "2";
        public static string ThreeSymbol = "3";
        public static string FourSymbol = "4";
        public static string FiveSymbol = "5";
        public static string SixSymbol = "6";
        public static string SevenSymbol = "7";
        public static string EightSymbol = "8";
        public static string NineSymbol = "9";
        public static string TenSymbol = "10";
        public static string JackSymbol = "J";
        public static string QueenSymbol = "Q";
        public static string KingSymbol = "K";
        public static string AceSymbol = "A";

        public Rank(int value, string symbol, string name)
        {
            _value = value;
            _symbol = symbol;
            _name = name;
        }
    }
}
