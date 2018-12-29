using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerSimulator
{
    class GameStateMachine
    {
        public void Run()
        {
            ITechnologiesSimulator technologiesSimulator;
            GameUi ui;
            int currentStep = 0;

            while(currentStep < GetEndStep())
            {
                ui.Handle();
                technologiesSimulator.SimulateStep();
                currentStep++;
            }
        }

        private int GetEndStep()
        {
            return 4 * 12 * 40;
        }
    }
}
