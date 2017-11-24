using EvolutionSimulator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator.Models
{
    public enum kindstatus { Seed, Growup, Reproduction, Dead };
    public abstract class AbtractPlant:IPlant
    {
        // Store a reference to the Ground where the plant stands
        private Ground _parent;

        public String Parent
        {
            get { return _parent.GroundID; }
      
        }
        //Unique ID that identify the specific instance
        private String aliveID;

        public String AliveID
        {
            get { return aliveID; }
        
        }
        //Reference to the plant DNA
        protected DNA _dna;
        //Current Cycle of life
        int _currentLifeCycle = 0;
        //Plant generation
        int _generation = 0;
        //Plant size
        double _size = 0;
        //Store number of Cycles needed to reach the next reproduction stage from the last reproduction stage(should be DNA)
        int nextReproductionCycle = 1;

        public int NextReproductionCycle
        {
            get { return nextReproductionCycle; }
            set { nextReproductionCycle = value; }
        }

        // State variable 
        //amount of water stored
        double waterdeposit = 1;
        // Current porcentage of life
        double life = 100.0;

        public int Generation
        {
            get { return _generation; }
            set { _generation = value; }
        }
        public int CurrentLifeCycle
        {
            get { return _currentLifeCycle; }
            set { _currentLifeCycle = value; }
        }

        public double Size
        {
            get { return _size; }
            set { _size = value; }
        }


        public double Waterdeposit
        {
            get { return waterdeposit; }
            set { waterdeposit = value; }
        }


        public double Life
        {
            get { return life; }
            set { life = value; }
        }
        

 //Environment variable
        double damage = 2;
        
        protected kindstatus _status;

        public kindstatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public DNA dna
        {
            get { return _dna; }
            set { _dna = value; }
        }
        public AbtractPlant(DNA dna, Ground parent) {
            
            Ramdom gui = new Ramdom();
            aliveID = gui.RandomString(32);
            _dna = new DNAPlant(dna, aliveID);
            _parent = parent;
        }
        public AbtractPlant(Ground parent, string ID)
            
        {
            _parent = parent;
            aliveID = ID;
        }
       
        /// <summary>
        /// Run one life cicyle of the plant
        /// </summary>
        public virtual void metabolism()
        {
            feed();
            if ( _status == kindstatus.Growup)  growup();
            reproduccion();
            environmentDamage();
            Died();
            _currentLifeCycle += 1;

        }

        protected virtual void reproduccion()
        {
            if (_currentLifeCycle >= 25 + nextReproductionCycle) 
            { _status = kindstatus.Reproduction;
            nextReproductionCycle += 10;
            } 
            
        }
        /// <summary>
        /// Change the status of the plant to Died if any of the condition to die are met
        /// </summary>
        protected virtual void Died()
        {

            if (_currentLifeCycle == _dna.dnachain.Single(s => s.name == "lifeciclelimit").valor) {
                _status = kindstatus.Dead;
                
            }
            if (life<= 0)
            {
                _status = kindstatus.Dead;
            }
        }
        /// <summary>
        /// Execute the actions neccesary to grow up one life cycle
        /// </summary>
        protected virtual void growup()
        {
            if (waterdeposit > 0.5 && life <=95)
            {
                life = life + 5;
                waterdeposit = waterdeposit - 0.5;
            }
            if (waterdeposit > 2)
            {
                _size += _dna.dnachain.Single(s => s.name == "growRate").valor;
                waterdeposit -= 2;
            }
        }
        /// <summary>
        /// Execute the actions neccesary to feed .
        /// </summary>
        protected virtual void feed()
        {
            waterdeposit += _size * _dna.dnachain.Single(s => s.name == "barrierPorcentage").valor * _dna.dnachain.Single(s => s.name == "absorbRate").valor *_parent.Absortion;
            
        }
        /// <summary>
        /// Apply the Damage environment to the plant
        /// </summary>
        protected virtual void environmentDamage()
        {

            life = life - ((1-_dna.dnachain.Single(s => s.name == "barrierPorcentage").valor) * _parent.Damage);
        
        }
        public abstract bool born();
    }
}
