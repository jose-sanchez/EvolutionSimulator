using EvolutionSimulator.Models;
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
    public partial class GroundProperties : Form
    {
        Ground _ground;
        public GroundProperties(Ground gr)
        {
            InitializeComponent();
            _ground = gr;
            lbCoor.Text = gr.coordn._x + ", " + gr.coordn._y;
            lbGroundType.Text = gr.groundtype;
            lbNumberOfPlants.Text = gr.ListPlant.Count.ToString();
            dgPlantList.DataSource = gr.ListPlant;
            dgPlantList.Columns["dna"].Visible = false;
            cbGeneration.DataSource = gr.ListPlant.Select(S=>S.Generation).Distinct().ToList();
        }

        private void dgPlantList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgPlantList.SelectedRows.Count > 0)
            {
                Plant pl = (Plant)dgPlantList.SelectedRows[0].DataBoundItem;

                DNAProperties newDNAProperties = new DNAProperties(pl.dna);
                newDNAProperties.ShowDialog();
            }
        }

        private void cbGeneration_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgPlantList.DataSource = _ground.ListPlant.Where(S=> S.Generation.ToString() ==  cbGeneration.SelectedValue.ToString()).ToList();
        }
    }
}
