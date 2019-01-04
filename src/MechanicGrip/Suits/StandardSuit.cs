namespace MechanicGrip.Suits
{
    public class StandardSuit
    {
        public static string ClubsName = "Clubs";
        public static string SpadesName = "Spades";
        public static string HeartsName = "Hearts";
        public static string DiamondsName = "Diamonds";

        public static char HeartsSymbol = '\u2665';
        public static char DiamondsSymbol = '\u2666';
        public static char SpadesSymbol = '\u2660';
        public static char ClubsSymbol = '\u2663';

        public static ISuit Clubs = new Suit(ClubsName, ClubsSymbol);
        public static ISuit Spades = new Suit(SpadesName, SpadesSymbol);
        public static ISuit Hearts = new Suit(HeartsName, HeartsSymbol);
        public static ISuit Diamonds = new Suit(DiamondsName, DiamondsSymbol);
    }
}
