using EvolutionSimulator.DAL;
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
    public partial class SaveGame : Form
    {
        public bool mustsave;
        public string  savename;
        public SaveGame()
        {
            InitializeComponent();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "")
            {
                if (!MapRepositoyModelFirst.ExistMap(textBox1.Text))
                {
                    mustsave = true;
                    savename = textBox1.Text;
                    this.Close();
                }
                else MessageBox.Show("This name already exist please choose a different name");
            }
            else MessageBox.Show("The name cannot be empty");
        }
    }
}
