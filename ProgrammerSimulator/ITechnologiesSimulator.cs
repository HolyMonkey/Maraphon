using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerSimulator
{
    interface ITechnologiesSimulator
    {
        IEnumerable<ITechnology> Technologies { get; }
        IEnumerable<IWork> Works { get; }
        void SimulateStep();
    }
}
