using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    class DNAPlant:DNA{
    
         public DNAPlant():base()
        {
        
        }
        public DNAPlant(string parent):base(parent)
        {
        
        }
        public DNAPlant(DNA dna,string parent)
            : base(dna,parent)
        {

        }
        public DNAPlant( string parent,int generation)
            : base(parent,generation)
        {

        }
    }
}
