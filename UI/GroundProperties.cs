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
            lbGroundType.Text = GroundInformationToString(gr);
            lbNumberOfPlants.Text = gr.ListPlant.Count.ToString();
            dgPlantList.DataSource = gr.ListPlant;

            cbGeneration.DataSource = gr.ListPlant.Select(S=>S.Generation).Distinct().ToList();
        }

        private string GroundInformationToString(Ground gr)
        {
            string result = string.Empty;

            switch (gr.groundtype)
            {
                case "W":
                    result = String.Format("{0}     Damage:{1}     Water Absortion: {2}", "Cold", 10, 0.3);
                    break;
                case "D":
                    result = String.Format("{0}     Damage:{1}     Water Absortion: {2}", "Desert", 30, 0.1);
                    break;
                case "S":
                    result = String.Format("{0}     Damage:{1}     Water Absortion: {2}", "Dry", 15, 0.7);
                    break;
                case "P":
                    result = String.Format("{0}     Damage:{1}     Water Absortion: {2}", "Tropical", 2, 1);
                    break;
            }
            return result;
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
