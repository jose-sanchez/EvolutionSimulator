using EvolutionSimulator.DAL;
using EvolutionSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator.Models
{
    public class Ground:FieldMap
    {
        private MapMatrix _parent;

        public string Parent
        {
            get { return _parent.MapID; }
          
        }
        List<IPlant> _ListPlant = new List<IPlant>();
        List<IPlant> _ListSeeds = new List<IPlant>();
        List<IPlant> _ListDeads = new List<IPlant>();
        private string _groundtype;
        private int _plantsNumber = 0;
        private int _damage;
        private double _absortion;
        
        public double Absortion
        {
            get { return _absortion; }
            set { _absortion = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public string groundtype
        {
            get { return _groundtype; }
        }
        public int plantsNumber
        {
            get { return _plantsNumber; }
        }

        public Ground(MapMatrix parent,string groundtype, MapPoint coord):base()
        {
            Ramdom gui = new Ramdom();
            groundID = gui.RandomString(32);
            _parent = parent;
            _groundtype = groundtype;
            switch (groundtype) {
                case "W":

                    _damage=10;
                    _absortion= 0.3;
                    break;
                case "D":
                     _damage=30;
                    _absortion= 0.1;
                    break;
                case "S":
                     _damage=15;
                    _absortion= 0.7;
                    break;
                case "P":
                     _damage=2;
                    _absortion= 1;
                    break;
            }
            coordenate = coord;
        }

        public List<IPlant> ListPlant
        {
            get { return _ListPlant; }
        }
        public List<IPlant> ListSeeds
        {
            get { return _ListSeeds; }
        }

        /// <summary>
        /// Iterate through the collection of plants to activate the metabolism
        /// </summary>
        public override void RunCycle()  
        {
            foreach (IPlant plant in _ListPlant.Where(S=> S.Status.ToString() != kindstatus.Dead.ToString())){
                plant.metabolism();
            }
            Reproduction();
            Deads();
        }
        /// <summary>
        /// Iterate over the list of plants and pass it to the dead plant list
        /// </summary>
        public void Deads()
        {
            foreach (IPlant plant in _ListPlant.Where(S => S.Status.ToString() == kindstatus.Dead.ToString()))
            {
                _ListDeads.Add(plant);

            }
            _ListPlant.RemoveAll(S => S.Status.ToString() == kindstatus.Dead.ToString());
        }
        /// <summary>
        /// Check the plants in reproduction status and spread new seeds. The reproduccion is sexual
        /// for more than one plant and axesual for one plant
        /// </summary>
        public void Reproduction()
        {

            while (_ListPlant.Where(S => S.Status == kindstatus.Reproduction).Count() > 1)
            {
               IPlant Plant1 =  _ListPlant.Where(S => S.Status == kindstatus.Reproduction).First();
               IPlant Plant2 =  _ListPlant.Where(S => S.Status == kindstatus.Reproduction).Last();
               spreadSeed(mixDNA(Plant1.dna, Plant2.dna));
               Plant1.Status = kindstatus.Growup;
               Plant2.Status = kindstatus.Growup;
                
            }
            //Codigo para reproduction axesual ,I must add a if to check the key in the web config and see with reproduction is
            //foreach (Plant plant in _ListPlant.Where(S => S.status == kindstatus.Reproduction)) {
            //    spreadSeed( plant.dna);

            //}

            if (_ListPlant.Where(S => S.Status == kindstatus.Reproduction).Count() == 1) {
                IPlant Plant1 = _ListPlant.Where(S => S.Status == kindstatus.Reproduction).First();
                spreadSeed(mixDNA(Plant1.dna,Plant1.dna));
            
            }
        }

        private void spreadSeed( DNA[] Ldna)
        {
            Random numer = new Random();
            foreach (DNA p_dna in Ldna)
            {
               
                int randomnumer = numer.Next(1, 9);
                switch (randomnumer)
                {
                    //down left
                    case 1:
                        _parent.addPlantToGround(coordenate.positionx - 1, coordenate.positiony - 1, p_dna);
                        break;
                    case 2:
                        // down
                        _parent.addPlantToGround(coordenate.positionx, coordenate.positiony - 1, p_dna);
                        break;
                    case 3:
                        //down right
                        _parent.addPlantToGround(coordenate.positionx + 1, coordenate.positiony - 1, p_dna);
                        break;
                    case 4://right
                        _parent.addPlantToGround(coordenate.positionx + 1, coordenate.positiony, p_dna);
                        break;
                    case 5://right up
                        _parent.addPlantToGround(coordenate.positionx + 1, coordenate.positiony + 1, p_dna);
                        break;
                    case 6://up
                        _parent.addPlantToGround(coordenate.positionx, coordenate.positiony + 1, p_dna);
                        break;
                    case 7://left up

                            _parent.addPlantToGround(coordenate.positionx - 1, coordenate.positiony + 1, p_dna);
                        break;
 
                    case 8://left
                        _parent.addPlantToGround(coordenate.positionx - 1, coordenate.positiony, p_dna);
                        break;
                    case 9://center
                        _parent.addPlantToGround(coordenate.positionx, coordenate.positiony, p_dna);
                        break;

                }
            }
        }

        private DNA[] mixDNA(DNA plant, DNA plant_2)
        {
            int generation = plant.Generation > plant_2.Generation ? plant.Generation : plant_2.Generation;
            generation += 1;
            DNA[] LDNA = new DNA[2];
            Random numer = new Random();
            int numberOfGens = plant.dnachain.Count;
            int randomnumer = numer.Next(1, numberOfGens);
            DNA DNA1= new DNAPlant();
            DNA DNA2 = new DNAPlant();
            DNA1.Generation = generation;
            DNA2.Generation = generation;
            foreach(gen g in plant.dnachain.GetRange(0,randomnumer)){
                gen g1 = new gen(g.name, mutation(g.valor));
                DNA1.dnachain.Add(g1);
            }
            foreach (gen g in plant_2.dnachain.GetRange(randomnumer, numberOfGens-randomnumer))
            {
                gen g1 = new gen(g.name, mutation(g.valor));
                DNA1.dnachain.Add(g1);
            }
            foreach (gen g in plant_2.dnachain.GetRange(0, randomnumer))
            {
                gen g1 = new gen(g.name, mutation(g.valor));
                DNA2.dnachain.Add(g1);
            }
            foreach (gen g in plant.dnachain.GetRange(randomnumer, numberOfGens - randomnumer))
            {
                gen g1 = new gen(g.name, mutation(g.valor));
                DNA2.dnachain.Add(g1);
            }

            LDNA[0] = DNA1;
            LDNA[1] = DNA2;

            return LDNA;

        }

        private double mutation(double p)
        {
            Random numer = new Random();
            int ra = numer.Next(1, 9);
            if (ra == 1)
            {
                ra = numer.Next(1, 4)/2;
                if (ra==1)
                return p + p * 0.1;
                else return p - p * 0.1;
            }
            else return p;

        }


        /// <summary>
        /// Run The metabolism for the seeds in this ground and add to the _ListPlant when it born
        /// </summary>
        /// <returns>Increment in the amount of plants</returns>
        public int RunCycleSeeds()
        {
            
                int previous_amount = this._ListPlant.Count;
                int seedholes = 21 - previous_amount;
                if (_ListPlant.Count() < 21)
                {
                    foreach (IPlant plant in _ListSeeds.Where(S => S.Status == kindstatus.Seed))
                    {
                        if (plant.born())
                        {
                            _ListPlant.Add(plant);
                        }
                        seedholes-= 1;
                        if (seedholes == 0) break;
                    }
                    //Delete from the List of seeds the one that are not seeds
                     _ListSeeds.RemoveAll(S => S.Status != kindstatus.Seed);
                }
                else{
                    //Delete from the List of seeds the one that are not seeds
                    _ListSeeds.RemoveAll(S => S.Status != kindstatus.Seed);
                     }
                return this._ListPlant.Count - previous_amount;
            }
        public void SaveToDataBase()
        {
            MapRepositoyModelFirst.Save_ground(this);
            foreach (Plant plant in ListPlant)
            {
                plant.SavetoDataBase();
            }
            foreach (Plant plant in ListSeeds)
            {
                plant.SavetoDataBase();
            }
        }
        public void LoadFromDataBase()
        {

            _ListPlant = MapRepositoyModelFirst.Load_plants(this, kindstatus.Growup);
            _ListSeeds = MapRepositoyModelFirst.Load_plants(this, kindstatus.Seed);
            foreach (Plant plant in _ListPlant)
            {

                plant.LoadFromDataBase();
            }
            foreach (Plant plant in _ListSeeds)
            {

                plant.LoadFromDataBase();
            }
        }
        }


}


