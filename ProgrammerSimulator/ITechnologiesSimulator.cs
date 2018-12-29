using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerSimulator
{
    interface ITechnologiesSimulator
    {
        IEnumerable<ITechnologie> Technologies { get; }
        void SimulateStep();
    }
}
