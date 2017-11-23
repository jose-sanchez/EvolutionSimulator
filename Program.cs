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
            int mapStartXCoordinate = 300;
            int mapStartYCoordinate = 100;
            Screen gui = new Screen(mapStartXCoordinate, mapStartYCoordinate);
            if (menu.LoadedGame != "" && menu.LoadedGame != null)
            {
                MapMatrix map = Save.load_map(menu.LoadedGame,gui);
                map.IsCiclyFinish = true;             
                start = new Simulator(map);
               
            }
            else start = new Simulator(gui);
            System.Threading.Thread newThread1;
            newThread1 = new System.Threading.Thread(start.Start);
            newThread1.Start();
            start.showGui();


            
            Console.Read();
        }



    }
}

