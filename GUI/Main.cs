using System;
using System.Windows.Forms;


namespace SoftwareConstructing_Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form_Way().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form_MinimalTree().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form_circle().Show();
        }
    }
}
