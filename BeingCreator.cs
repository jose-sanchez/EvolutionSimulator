using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public class BeingCreator:BeingFactory
    {
        //Main factory where all the beings will be created
        public override IAlive CreateLive(string AliveBeing,DNA dna, Ground parent)
        {
            switch (AliveBeing) { 
                case "plant":
                    Plant newplant = new Plant(dna, parent);
                    return newplant;
                default:
                    throw new ApplicationException(string.Format("Being '{0}' cannot be created", AliveBeing));

            }
        }
    }
}
