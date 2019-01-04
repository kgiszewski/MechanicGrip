namespace MechanicGrip.Ranks
{
    public abstract class RankBase : IRank
    {
        public int Value { get; }
        public string Symbol { get; }
        public string Name { get; }

        protected RankBase(int value, string symbol, string name)
        {
            Value = value;
            Symbol = symbol;
            Name = name;
        }
    }
}
