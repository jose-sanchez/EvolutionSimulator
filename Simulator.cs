using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using EvolutionSimulator.UI;
using System.Windows.Forms;
using System.IO;

namespace EvolutionSimulator
{
    public class Simulator:IDisposable
    {
        private Screen gui;
        private MapMatrix mMatrix;
        private System.Timers.Timer aTimer;
        private int CX = 13;
        private int CY = 13;
         static readonly string Key = "";
        public Simulator(Screen gui)
        {

            this.gui = gui;
            Screen.EventTriggered += Screen_MouseDoubleClick;
            string mapname = Path.Combine(Environment.CurrentDirectory, @"UI\Maps\map1.txt");           
            mMatrix = new MapMatrix(13, 13, mapname, gui);
            mMatrix.addPlantToGround(10, 10, new DNAPlant("12345678123456781234567812345678"));
            mMatrix.Mapname = mapname;

           
        }
        public Simulator(MapMatrix MapMatrix)
        {

            Screen.EventTriggered += Screen_MouseDoubleClick;
            mMatrix = MapMatrix;
        }

        public void Start()
        {
            aTimer = new System.Timers.Timer();
            // Hook up the Elapsed event for the timer.
            aTimer.Elapsed += new ElapsedEventHandler(Cycle);

            // Set the Interval to 2 seconds (2000 milliseconds).
            aTimer.Interval = 500;
            aTimer.Enabled = true;
            GC.KeepAlive(aTimer);
            //bool bucle = true;
            //while (bucle == true) {
            
            //    mMatrix.Cycle();
                
            //}
        }

        private void Cycle(object source, ElapsedEventArgs e)
        {
            if(mMatrix.IsCiclyFinish && !gui.IsCycleStop) mMatrix.Cycle();
            if (!mMatrix.IsCiclyFinish) aTimer.Interval += 250;
            lock (Key)
            {
                if (mMatrix.IsCiclyFinish && gui.IsCycleStop && gui.mustSaveGame)
                {
                    mMatrix.Savegame = gui.SaveGameName;

                    mMatrix.SavetoDataBase();
                    MessageBox.Show("The game was saved correctly");
                    gui.mustSaveGame = false;
                }
            }
           

        }
        public void showGui()
        {
            gui.ShowDialog();
        }
        private void Screen_MouseDoubleClick(object sender, DoubleClick_Arg e)
        {                      
                int x = ((e.x - (gui.mapStartXCoordinate)) / 20) ;
                int y = ((e.y - (gui.mapStartYCoordinate)) / 20) ;
                if (x <= CX-1 && y <= CY-1)
                {
                    Ground gr = mMatrix.mapM.FirstOrDefault(S => S.coordn.positionx == x
                                                    && S.coordn.positiony == y);
                if(gr!=null)
                {
                    GroundProperties newGroundProperties = new GroundProperties(gr);
                    newGroundProperties.ShowDialog();
                }


            }
                
            

        }



        public void Dispose()
        {
            aTimer.Dispose();
        }
    }
}

