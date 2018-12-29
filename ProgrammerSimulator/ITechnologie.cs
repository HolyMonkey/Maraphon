namespace ProgrammerSimulator
{
    public interface ITechnologie : ITimeConverter
    {
        float Actual { get; }
        string Name { get; }
    }
}