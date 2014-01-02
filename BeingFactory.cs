using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public abstract class BeingFactory
    {

        public abstract  IAlive CreateLive(string AliveBeing, DNA dna , Ground parent);
    }
}
