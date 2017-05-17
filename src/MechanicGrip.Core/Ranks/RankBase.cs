namespace MechanicGrip.Core.Ranks
{
    public class RankBase : IRank
    {
        public int Value { get; }
        public string Symbol { get; }
        public string Name { get; }

        public RankBase(int value, string symbol, string name)
        {
            Value = value;
            Symbol = symbol;
            Name = name;
        }
    }
}
