using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public class Plant:AbtractPlant
    {
        
        public Plant(DNA dna, Ground parent):base(dna, parent)
        {
            _status = kindstatus.Seed;
            //Get the generation from the DNA
            Generation = dna.Generation;
        }
        public Plant(Ground parent,string ID):base(parent)
            
        {
            Generation = dna.Generation;
        }

        /// <summary>
        /// Actions to execute when a plant born.
        /// </summary>
        /// <returns></returns>
        public override bool born()
        {
            //Change the status to indicate that the plant is growing up
            _status = kindstatus.Growup;
            
            return true;
        }

        public void SavetoDataBase()
        {
            Save.save_plant(this);
            dna.saveDNA();
        }
        public void LoadFromDataBase()
        {
            _dna = Save.load_dna(AliveID, Generation);
        }
    }

}
