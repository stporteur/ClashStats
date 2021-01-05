using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashStats.Simulation
{
    public partial class SimulationHelp : Form
    {
        public SimulationHelp()
        {
            InitializeComponent();
        }

        private void SimulationHelp_Load(object sender, EventArgs e)
        {
            richTextBox1.LoadFile("Simulation/SimulationHelp.rtf");
        }
    }
}
