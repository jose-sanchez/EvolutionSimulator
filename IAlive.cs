using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public interface IAlive
    {
        
        DNA dna { get; }
         void metabolism();
         bool born();
    }
}
