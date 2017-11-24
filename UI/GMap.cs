using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using EvolutionSimulator.Models;

namespace EvolutionSimulator
{
    public class GMap:Imap
    {
        // In which pixel the map start
        int _pixelX;
        int _pixelY;
        //size in pixelof the element from the map , also image
        int _imagesizeX;
        int _imagesizeY;
        int _wide;
        int _height;
        public Graphics _e;
        Bitmap mapimage;
        string _mapname;
        string imagepath;
       
        public GMap(int Wide,int Height,String mapname, int pixelX, int pixelY, int imagesizeX, int imagesizeY)
        {
            _pixelX = pixelX;
            _pixelY = pixelY;
            _imagesizeX = imagesizeX;
            _imagesizeY = imagesizeY;
    
            _wide = Wide;
            _height = Height;
            _mapname = mapname;
            RegistryKey rk_imagepath = Registry.LocalMachine;
            rk_imagepath = rk_imagepath.OpenSubKey("SOFTWARE", false);
            rk_imagepath = rk_imagepath.OpenSubKey("EvolutionSimulator", false);
            if (rk_imagepath != null)
            {
                imagepath = rk_imagepath.GetValue("imagePath").ToString();
            }
            else {
                imagepath = Path.Combine(Environment.CurrentDirectory, @"UI\Images\ground");

            }
        }

        public Bitmap PaintMap(Form f1, Graphics grap)
        {
            try
            {
                mapimage = new Bitmap(f1.Width, f1.Height);
                Rectangle frame = new Rectangle(new System.Drawing.Point(f1.Width, f1.Height), f1.Size);
                f1.DrawToBitmap(mapimage, frame);
                grap = Graphics.FromImage(mapimage);
                string[] lines = System.IO.File.ReadAllLines(_mapname.ToString());
                int Index_x;
                int Limit = _wide - 1;
                int Index_y;
                int Limit_Y = _height - 1;
                for (Index_x = 0; Index_x < Limit; Index_x++)
                {
                    for (Index_y = 0; Index_y < Limit_Y; Index_y++)
                    {
                        //paint(grap, new Point(Index_x, Index_y), 0);
                    }
                }

                



            }
            catch (Exception p)
            {
                Console.Write(p.Message);
               
            }
            return mapimage;
        }
        public void paint(Graphics grap, MapPoint point,string groundtype, int nplants)
        {
            Image MyImage;
            int plants = (nplants / 5) + 1;
            MyImage = Image.FromFile(imagepath + "\\" + groundtype + "\\" + plants.ToString() + ".png");

            grap.DrawImage(MyImage, _pixelX + (point.positionx * _imagesizeX), _pixelY + (point.positiony * _imagesizeY));
            
        }
        public Bitmap paint(Bitmap mapImage, MapPoint point,string groundtype, int nplants)
        {
            Graphics grap;
            Image MyImage;
            int plants = (nplants / 2) + 1;
            try
            {
                MyImage = Image.FromFile(imagepath + "\\" + groundtype + "\\" + plants.ToString() + ".png");
                grap = Graphics.FromImage(mapImage);
                grap.DrawImage(MyImage, _pixelX + (point.positionx * _imagesizeX), _pixelY + (point.positiony * _imagesizeY));
                return mapImage;
            }
            catch
            {
                return mapImage;
            }
      
           

        }


        public void showmap() {
            
            _e.DrawImage(mapimage,100, 100);
        
        }

        
    }
}
