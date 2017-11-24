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
    public partial class DNAProperties : Form
    {
        public DNAProperties(DNA dna)
        {
            InitializeComponent();
            dgDNAList.DataSource = dna.dnachain;
        }
    }
}
