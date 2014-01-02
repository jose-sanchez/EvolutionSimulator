using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public abstract class FieldMap:IFieldMap
    {
        protected string groundID;

        public string GroundID
        {
            get { return groundID; }
            set { groundID = value; }
            
         
        }
        protected Point coordenate;
        public Point coordn
        {
            get { return coordenate; }
        }
        public abstract void RunCycle();
        void FielMap() {

        }
    }
}
