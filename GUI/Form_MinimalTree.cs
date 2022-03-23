using ADS_Labs_4sem.Main;
using System;
using System.Windows.Forms;

namespace SoftwareConstructing_Forms
{
    public partial class Form_MinimalTree : Form
    {
        SoftwareConstructing.Alg2.Controller controller;

        public Form_MinimalTree()
        {
            InitializeComponent();
        }


        public void CreateController(object sender)
        {
            SubForms.Input_form_1_stroke form = (SubForms.Input_form_1_stroke)sender;

            int size = 0;

            try
            {
                size = Convert.ToInt32(form.answer);
            }
            catch
            {
                MessageBox.Show("error");
            }

            controller = new SoftwareConstructing.Alg2.Controller(size, DGV_Matrix, PB_GraphGraphics);
            controller.Set_SwichButton(B_Swich);

            return;
        }

        private void B_GetSize_Click(object sender, EventArgs e)
        {
            SubForms.Input_form_1_stroke sform = new SubForms.Input_form_1_stroke("Кол-во вершин");
            sform.DoTask += CreateController;
            sform.Show();
        }

        private void B_boot1_Click(object sender, EventArgs e)
        {
            controller.primAlgo();
        }


        private void bRead_Click(object sender, EventArgs e)
        {
            int[,] matr = Files.ReadFile("alg2in.txt", -1);
            int size = matr.GetLength(0);
            controller = new SoftwareConstructing.Alg2.Controller(size, DGV_Matrix, PB_GraphGraphics);
            Files.Fill_DGV(matr, controller);
        }
    }


}
