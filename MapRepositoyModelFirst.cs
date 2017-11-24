using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public static class MapRepositoyModelFirst
    {
        static private EvolutionEntities Context = new EvolutionEntities() ;

        /// <summary>
        /// Save a gen in the data base
        /// </summary>
        /// <param name="Gen">Contains the Gen to be saved</param>
        /// <param name="parent">ID of the Plant to be saved</param>
        public static void save_gen(gen Gen, string parent) {
            S_DNA dna = new S_DNA();
            dna.PARENT_ID=  parent;
            dna.GEN = Gen.name;
            dna.VALOR= Gen.valor;
            Context.DNA.AddObject(dna);
            Console.WriteLine(  Context.SaveChanges());         
        }
        public static DNA load_dna( string parent,int generation)
        {
            S_DNA dna = new S_DNA();
            DNAPlant result = new DNAPlant(parent,generation);
            result.Generation = generation;
            var query = Context.DNA.Where(S => S.PARENT_ID == parent);
            foreach (S_DNA item in query){
            
                gen newgen =  new gen(item.GEN,(double) item.VALOR);
                result.dnachain.Add(newgen);
            }
            return result;
        }
        public static void save_plant(Plant Plant)
        {
            DPLANT plant = new DPLANT();
            plant.PARENT_ID = Plant.Parent;
            plant.aliveID = Plant.AliveID;
            plant.CURRENTLIFECYCLE = Plant.CurrentLifeCycle;
            plant.GENERATION = Plant.Generation;
            plant.SIZE = (int) Plant.Size;
            plant.STATUS = Plant.Status.ToString();
            plant.WATERDEPOSIT = Plant.Waterdeposit;
            plant.NEXTREPRODUCTIONCYCLE = Plant.NextReproductionCycle;
            Context.AddToDPLANT(plant);
            Console.WriteLine(Context.SaveChanges());
        }
        public static List<IPlant> load_plants(Ground parent,kindstatus status)
        {
            DPLANT dna = new DPLANT();
            List<IPlant> List = new List<IPlant>();
            List<DPLANT> query;
            if(status == kindstatus.Growup || status ==kindstatus.Reproduction){
            query = Context.DPLANT.Where(S => S.PARENT_ID == parent.GroundID &&
                !S.STATUS.Contains( kindstatus.Seed.ToString()) ).ToList();
            }
            else{
             query = Context.DPLANT.Where(S => S.PARENT_ID == parent.GroundID &&
                S.STATUS.Contains( kindstatus.Seed.ToString()) ).ToList();
            }
            foreach (DPLANT item in query)
            {

                Plant newplant = new Plant(parent, item.aliveID);
                newplant.CurrentLifeCycle = (int)item.CURRENTLIFECYCLE;
                newplant.Generation = (int)item.GENERATION;
                newplant.NextReproductionCycle = (int)item.NEXTREPRODUCTIONCYCLE;
                newplant.Size = (int)item.SIZE;
                newplant.Waterdeposit = (int)item.WATERDEPOSIT;
                
                switch (item.STATUS)
                {
                    case "Seed":
                        newplant.Status = kindstatus.Seed;
                        break;
                    case "Growup":
                        newplant.Status = kindstatus.Growup;
                        break;
                    case "Reproduction":
                        newplant.Status = kindstatus.Reproduction;
                        break;
                }

                List.Add(newplant);
            }
            return List;
        }
        public static void save_ground(Ground Ground)
        {
            DGROUND ground = new DGROUND();
            ground.GROUND_ID = Ground.GroundID;
            ground.PARENT = Ground.Parent;
            ground.X = Ground.coordn.positionx;
            ground.Y = Ground.coordn.positiony;
            ground.GROUNDTYPE = Ground.groundtype;
            ground.DAMAGE = Ground.Damage;
            ground.ABSORTION = Ground.Absortion;
            Context.AddToDGROUND(ground);
            Console.WriteLine(Context.SaveChanges());

        }
        public static List<Ground> load_ground(MapMatrix parent)
        {
            var query = Context.DGROUND.Where(S => S.PARENT == parent.MapID);
            List<Ground> list = new List<Ground>();
            int index = 0;
            foreach (DGROUND item in query)
            {
                Ground newGround =
                    new Ground(parent, item.GROUNDTYPE, new Point((int)item.X, (int)item.Y));
                newGround.GroundID = item.GROUND_ID;
                newGround.Damage = (int) item.DAMAGE;
                newGround.Absortion = (double)item.ABSORTION;
                list.Add(newGround);
                index++;
            }
            return list; 

        }
        public static void save_map(MapMatrix MapMatrix)
        {
            DMAP map = new DMAP();
            map.MAP_ID = MapMatrix.MapID;
            map.MAPNAME = MapMatrix.Mapname;
            map.ROWS = MapMatrix.Y;
            map.COLUMNS = MapMatrix.X;
            map.SAVEGAME = MapMatrix.Savegame;
            Context.AddToDMAP(map);
            Console.WriteLine(Context.SaveChanges());         
        }
        public static MapMatrix load_map(string Gamename,Screen gui)
        {          
            DMAP map = Context.DMAP.Single(S => S.SAVEGAME == Gamename);
            MapMatrix MapMatrix = new MapMatrix(Gamename, map.MAP_ID, gui);
            MapMatrix.Mapname = map.MAPNAME;
            MapMatrix.X = (int)map.COLUMNS;
            MapMatrix.Y = (int)map.ROWS;
            MapMatrix.IsCiclyFinish = true;
            MapMatrix.LoadFromDataBase();
            MapMatrix.RePaint();
            return MapMatrix;
        }
        public static bool ExistMap(String MapName)
        {
            return (Context.DMAP.Where(S => S.SAVEGAME.Contains(MapName)).Count() > 0);
        }
        public static List<string> ListGames()
        {
            return Context.DMAP.Select(S => S.SAVEGAME).ToList();
        }
    }
}
