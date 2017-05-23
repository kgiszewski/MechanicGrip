namespace MechanicGrip.Core.Suits
{
    public class SuitBase : ISuit
    {
        public string Name { get; }
        public char Symbol { get; }

        public SuitBase(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
