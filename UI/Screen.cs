using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EvolutionSimulator.UI;
using System.IO;
using EvolutionSimulator.Models;

namespace EvolutionSimulator
{
    public partial class Screen : Form
    {
        GMap _gmap;
        Graphics g;
        Graphics _surface;
        Bitmap mapimage ;
        bool _IsCycleStop = true;
        public int mapStartXCoordinate { get; set;}
        public int mapStartYCoordinate { get; set; }
        public bool IsCycleStop
        {
            get { return _IsCycleStop; }
            set { _IsCycleStop = value; }
        }
        public bool mustSaveGame { get; set; }
        public bool mustResetGame { get; set; }
        public string SaveGameName { get; set; }
        delegate void PaintCallback( MapPoint  point, string groundtype, int nplants);
        delegate void RefreshCallback();
        static readonly object locker = new object();

        public static event EventHandler<DoubleClick_Arg> EventTriggered; 
        public Screen(int mapStartXCoordinate, int mapStartYCoordinate)
        {
            InitializeComponent();

            this.mapStartXCoordinate = mapStartXCoordinate;
            this.mapStartYCoordinate = mapStartYCoordinate;
            _gmap = new GMap(30, 30, Path.Combine(Environment.CurrentDirectory, @"UI\Maps\map1.txt"), mapStartXCoordinate, mapStartYCoordinate, 20,20);
            mapimage= _gmap.PaintMap(this,_surface);
            g = this.CreateGraphics();
            g = Graphics.FromImage(mapimage);
         
        }

       



        protected override void  OnDoubleClick(EventArgs e)
            {
 	        base.OnDoubleClick(e);
            g.DrawImage(mapimage, 0, 0);

            }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (mapimage != null)
            {
                e.Graphics.DrawImage(mapimage, 0, 0);
            }
        }

        public void paint( MapPoint point,string groundtype, int nplants)
        {

            if (this.InvokeRequired)
            {
                PaintCallback d = new PaintCallback(paint);
                this.Invoke(d, new object[] { point, groundtype, nplants });
            }
            else
            {
                lock (locker)
                {
                    mapimage= _gmap.paint(mapimage, point, groundtype, nplants);
                    this.Refresh();
                }
                
            }
            

        }
        public void RefreshMap()
        {
            if (this.InvokeRequired)
            {
                RefreshCallback d = new RefreshCallback(RefreshMap);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _IsCycleStop = true;
            btStop.Visible = false;
            btStart.Visible = true;
            btSave.Enabled = true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            _IsCycleStop = false;
            btStop.Visible = true;
            btStart.Visible = false;
            btSave.Enabled = false;
            
        }

        private void Screen_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs ev = e as MouseEventArgs;
            if (EventTriggered != null)
            {
                EventTriggered(null, new DoubleClick_Arg { x = ev.X, y = ev.Y });
            } 
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var savegame = new SaveGame();
            savegame.ShowDialog();
            if (savegame.mustsave) 
            {
                SaveGameName = savegame.savename;
                mustSaveGame = true;
            }
        }

        private void btReset_Click_(object sender, EventArgs e)
        {
            mustResetGame = true;
        }
    }

    public class DoubleClick_Arg : EventArgs
    {
        public int x{get;set;}
        public int y{get;set;}
    }
}
