using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator.Models
{
    public class MapPoint
    {
        public int _x = 0;
        public int _y = 0;

        public MapPoint(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public int positionx
        {
            get { return _x; } 
        }

        public int positiony
        {
            get { return _y; } 
        }
    }
}
