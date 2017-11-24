using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EvolutionSimulator.UI
{
    public partial class LoadGame : Form
    {
        public string LoadedGame;
        public LoadGame(string LoadedGame)
        {
            InitializeComponent();
            listBox1.DataSource = MapRepositoyModelFirst.ListGames();
            this.LoadedGame = LoadedGame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                LoadedGame = listBox1.SelectedValue.ToString();
                this.Close();
            }
            else MessageBox.Show("Please select a saved game from the list");
        }
    }
}
