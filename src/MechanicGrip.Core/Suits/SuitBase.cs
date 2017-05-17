namespace MechanicGrip.Core.Suits
{
    public class SuitBase : ISuit
    {
        public string Name { get; }

        public SuitBase(string name)
        {
            Name = name;
        }
    }
}
