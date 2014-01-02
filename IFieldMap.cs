using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    //Interface that represents all kind of maps
    interface IFieldMap
    {
         Point coordn{
            get;}
        //Will run a cycle in the fieldmap
        void RunCycle();
    }
}
