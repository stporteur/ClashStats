using System;
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
