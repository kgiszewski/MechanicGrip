namespace MechanicGrip.Core.Suits
{
    public class Suit
    {
        private string _name;
        public string Name => _name;

        public static string Clubs = "Clubs";
        public static string Spades = "Spades";
        public static string Hearts = "Hearts";
        public static string Diamonds = "Diamonds";

        public Suit(string name)
        {
            _name = name;
        }
    }
}
