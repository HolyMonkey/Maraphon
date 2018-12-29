namespace ProgrammerSimulator
{
    public interface ITechnology : ITimeConverter
    {
        float Actual { get; }
        string Name { get; }
    }
}