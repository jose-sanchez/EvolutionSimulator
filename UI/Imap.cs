using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using EvolutionSimulator.Models;

namespace EvolutionSimulator
{
    interface Imap
    {
        void paint(Graphics gra, MapPoint  point ,String groundType, int nplants);


    }
}
