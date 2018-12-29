using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerSimulator
{
    class GameUi
    {
        private ITechnologiesSimulator _simulator;

        public GameUi(ITechnologiesSimulator simulator)
        {
            _simulator = simulator;
        }

        public void Handle()
        {
            throw new NotImplementedException();
        }
    }
}
