using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvolutionSimulator
{
    public abstract class DNA
    {
        int _generation = 0;

        public int Generation
        {
            get { return _generation; }
            set { _generation = value; }
        }
       List <gen> _dnachain = new List <gen>();
       String _Parent_ID;
       public String Parent_ID
       {
           get
           {
               return _Parent_ID;
           }
       }
       public List<gen> dnachain
       {
           get
           {
               return _dnachain;
           }
       }

       public DNA()
       {

       }
       public DNA( string parent)
       {
           _Parent_ID = parent;
           _dnachain.Add(new gen("growRate",1));
           _dnachain.Add(new gen("absorbRate", 1));
           _dnachain.Add(new gen("lifeciclelimit", 30));
           _dnachain.Add(new gen("barrierPorcentage", 0.5));



           
       }
       public DNA(string parent,int generation)
       {
           _Parent_ID = parent;
           _generation = generation;

       }
       public DNA(DNA dna, string parent)
       {
           _Parent_ID = parent;
           _dnachain = dna._dnachain;
           Generation = dna.Generation;

       }
        /// <summary>
        /// Save the DNA information into the table S_DNA in the database
        /// </summary>
        public void saveDNA(){
          
            foreach (gen _gen in _dnachain){
                MapRepositoyModelFirst.Save_gen(_gen, Parent_ID);
            }
        }
        
       

    }

    public class gen {

        readonly string _name;
        readonly double _valor;
        public string name{
         get
         {
            return _name; 
          }
         }
        public double valor
        {
            get{return _valor; }
        }
    
        public gen(string name, double valor) {
            _name = name;
            _valor = valor;
        }


    }
}



