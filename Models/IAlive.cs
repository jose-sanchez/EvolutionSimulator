using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator.Models
{
    public interface IAlive
    {
        
        DNA dna { get; }
         void metabolism();
         bool born();
    }
}
