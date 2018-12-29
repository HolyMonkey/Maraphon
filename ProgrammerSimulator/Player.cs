using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerSimulator
{
    interface IPlayer
    {
        int Money { get; }
        int FreeTime { get; }
        float Hungry { get; }
        float Boring { get; }
        float Loneliness { get; }
        float Sickliness { get; }

        void UpSkill(ITechnology technology, float delta);
        float GetCurrentLevel(ITechnology technology);
    }
}
