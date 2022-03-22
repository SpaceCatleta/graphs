using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConstructing_Forms.SubForms
{
    public partial class Input_form_1_stroke : Form
    {
        public delegate void Task(object sender);
        public event Task DoTask;
        public String answer;

        public Input_form_1_stroke(string label)

        {
            InitializeComponent();
            L_Stroke1.Text = label;
        }


        private void B_Finish_Click(object sender, EventArgs e)
        {
            answer = TB_PointCount.Text;

            DoTask(this);

            this.Close();
        }
    }
}
