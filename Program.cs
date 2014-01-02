using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvolutionSimulator.UI;
namespace EvolutionSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            Simulator start;
            if (menu.LoadedGame != "" && menu.LoadedGame != null)
            {
                MapMatrix map = save.load_map(menu.LoadedGame);
                map.IsCiclyFinish = true;             
                start = new Simulator(map);
               
            }
            else start = new Simulator();
            System.Threading.Thread newThread1;
            newThread1 = new System.Threading.Thread(start.Start);
            newThread1.Start();
            start.showGui();


            
            Console.Read();
        }



    }
}

