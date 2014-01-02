﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EvolutionSimulator.UI;

namespace EvolutionSimulator
{
    public partial class Screen : Form
    {
        GMap _gmap;
        Graphics g;
        Graphics _surface;
        Bitmap mapimage ;
        bool _IsCycleStop = true;
        int X;
        int Y;
        public bool IsCycleStop
        {
            get { return _IsCycleStop; }
            set { _IsCycleStop = value; }
        }
        public bool mustSaveGame { get; set; }
        public string SaveGameName { get; set; }
        private static Screen InstanceScreen;
        delegate void PaintCallback(Point point, string groundtype, int nplants);
        delegate void RefreshCallback();
        static readonly object locker = new object();
        public static Screen Instance

        {
            get
            {
                if (InstanceScreen == null)
                {
                    InstanceScreen = new Screen();
                }
                return InstanceScreen;
            }
        }
        public static event EventHandler<DoubleClick_Arg> EventTriggered; 
        public Screen()
        {
            InitializeComponent();
     
            
            _gmap = new GMap(30, 30,"C:\\evolution\\map1.txt", this.Location.X, this.Location.Y,20,20);
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

        public void paint( Point point,string groundtype, int nplants)
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


    }

    public class DoubleClick_Arg : EventArgs
    {
        public int x{get;set;}
        public int y{get;set;}
    }
}
