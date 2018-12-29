using System.Collections.Generic;

namespace ProgrammerSimulator
{
    public interface IWork : ITimeConverter
    {
        string Name { get; }
        IEnumerable<ITechnology> NeededTechnologies { get;}
    }
}