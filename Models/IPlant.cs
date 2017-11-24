using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator.Models
{
    public interface IPlant : IAlive
    {
        kindstatus Status
        {
            get;
            set;
        }
        DNA dna { get; }
        int Generation { get; }
        int CurrentLifeCycle { get; }

        double Size { get; }


        double Waterdeposit { get; }

        double Life { get; }
    }
}
