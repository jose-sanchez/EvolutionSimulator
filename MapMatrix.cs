using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization.Formatters.Soap;

namespace EvolutionSimulator
{
    [Serializable()]
    public class MapMatrix
    {
        int _x;
        bool _IsCiclyFinish = true;

        public bool IsCiclyFinish
        {
            get { return _IsCiclyFinish; }
            set { _IsCiclyFinish = value; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        String mapID;

        public String MapID
        {
            get { return mapID; }

        }
        String _mapname;

        public String Mapname
        {
            get { return _mapname; }
            set { _mapname = value; }
        }
        String _savegame;

        public String Savegame
        {
            get { return _savegame; }
            set { _savegame = value; }
        }
        [field: NonSerialized()]
        private Screen screen;

        [field: NonSerialized()]
        List<Ground> _mapM = new List<Ground>();

        [System.Xml.Serialization.XmlIgnore]
        public List<Ground> mapM
        {
            get { return _mapM; }
        }

        public MapMatrix()
        //For testing purpose
        {
        }

        public MapMatrix(string savegame,string mapID, Screen instance)
        //Load from database. It will retrieve the information from the database 
        {
            screen = instance;
            _savegame = savegame;
            this.mapID = mapID;
        }
        public MapMatrix(int x, int y, string mapname, Screen instance)
        //Initialize the matrix reading the type of ground from the file mapname and creating the ground elements
        {
            _x = x;
            _y = y;
            Ramdom gui = new Ramdom();
            mapID = gui.RandomString(32);
            screen = instance;
            _mapname = mapname;
            try
            {
                string[] lines = System.IO.File.ReadAllLines(mapname.ToString());
                int Index_x;
                int Limit = x - 1;
                int Index_y;
                int Limit_Y = y - 1;
                for (Index_x = 0; Index_x <= Limit; Index_x++)
                {
                    for (Index_y = 0; Index_y <= Limit_Y; Index_y++)
                    {
                        Ground NewGround = new Ground(this, lines[Index_x].Substring(Index_y, 1), new Point(Index_x, Index_y));

                        _mapM.Add(NewGround);
                        screen.paint(NewGround.coordn, NewGround.groundtype, NewGround.ListPlant.Count);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write("Error in MapMatrix constructor");
                Console.Write(e.Message);
            }
        }
        public void addPlantToGround(int x, int y, DNA dna)
        {
            try
            {
                // Add a new plant to the ground place in the coordenates x, Y using de dna
                Ground targetGround = _mapM.Single(S => S.coordn.positionx == x && S.coordn.positiony == y);
                // No more thatn 21 seeds per ground
                if (targetGround.ListSeeds.Count < 21)
                {
                    IPlant plant = (IPlant)new BeingCreator().CreateLive("plant", dna, targetGround);

                    targetGround.ListSeeds.Add(plant);
                }

            }
            catch
            {
                Console.Write("out of map");
            }

        }

        public void Cycle()
        {
            // Run a cycle for the those grounds in the map that contains more than cero plants
            _IsCiclyFinish = false;
            foreach (Ground ground in _mapM.Where(S => S.ListPlant.Count >= 1))
            {
                ground.RunCycle();
            }

            foreach (Ground ground in _mapM.Where(S => S.ListSeeds.Count >= 1))
            {
                if (ground.RunCycleSeeds() > 0)
                {
                    screen.paint(ground.coordn, ground.groundtype, ground.ListPlant.Count);
                }
            }
            _IsCiclyFinish = true;

        }

        public void SavetoDataBase()
        {

            Save.save_map(this);
            foreach (Ground ground in _mapM)
            {

                ground.SaveToDataBase();
            }
        }
        public void LoadFromDataBase()
        {

            _mapM= Save.load_ground(this);
            foreach (Ground ground in _mapM)
            {
               
                ground.LoadFromDataBase();
            }
        }
        public void RePaint()
        {

            foreach (Ground ground in _mapM)
            {

                screen.paint(ground.coordn, ground.groundtype, ground.ListPlant.Count);

            }
        }
    }
}
