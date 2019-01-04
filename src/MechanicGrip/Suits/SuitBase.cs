namespace MechanicGrip.Suits
{
    public abstract class SuitBase : ISuit
    {
        public string Name { get; }
        public char Symbol { get; }

        protected SuitBase(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
