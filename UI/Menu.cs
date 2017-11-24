using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EvolutionSimulator.Models;

namespace EvolutionSimulator.UI
{
    public partial class Menu : Form
    {

        public string LoadedGame;
        public Menu()
        {
            InitializeComponent();
            listView1.Items.Add("Ground");
            listView1.Items.Add("MapMatrix");
            listView1.Items.Add("Plant");
            listView1.View = View.List;

        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (listView1.SelectedItems[0].Text) {
                case "Ground":
                    testGround();
                    break;
                case "MapMatrix":
                    testMapMatrix();
                    break;
                case "Plant":
                    testMapMatrix();
                    break;
            
            }
            
        }
        //Test for the Class Ground
        public void testGround()
        {
            try
            {
                MapMatrix m = new MapMatrix();
                Ground g = new Ground(m, "W",new MapPoint(0,0));
              
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally {
                MessageBox.Show("testGround Completed");
            }
        }


        //Test for the Class Ground
        public void testMapMatrix()
        {
            try
            {
                MapMatrix m = new MapMatrix(4,4,"C:\\temp\\map.txt",null);
                Console.Write("Element in 0,0");
                Console.Write(m.mapM.Single(S => S.coordn.positionx == 0 & S.coordn.positiony == 0).groundtype);
                Console.Write("Element in 0,1");
                Console.Write(m.mapM.Single(S => S.coordn.positionx == 1 & S.coordn.positiony == 1).groundtype);
                

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MessageBox.Show("testMapMatrix Completed");
            }
        }

        //Test for the Class Ground
        public void testPlant()
        {
            try
            {
          
                //DNAPlant adn = new DNAPlant("12345678123456781234567812345678");
                //PlantCreator pc = new PlantCreator();
                //Alive al =pc.CreateLive(adn, );
                //Plant plant = (Plant)al;
                //plant.metabolism();
                //Console.Write(plant.status);



            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                MessageBox.Show("testPlant Completed");
            }
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            LoadGame newLoadGame = new LoadGame(LoadedGame);
            newLoadGame.ShowDialog();
            LoadedGame = newLoadGame.LoadedGame;
            this.Close();
        }
    }

}
