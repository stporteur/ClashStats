using System.Windows.Forms;

namespace ClashStats.Simulation
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        public void LoadHelp(string helpFile)
        {
            richTextBox1.LoadFile(helpFile);
        }
    }
}
