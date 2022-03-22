﻿using SoftwareConstructing.GraphVisualization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftwareConstructing_Forms
{
    public partial class Form_Way : Form
    {
        SoftwareConstructing.Alg1.Controller controller;

        public Form_Way()
        {
            InitializeComponent();
        }

        private void B_GetSize_Click(object sender, EventArgs e)
        {
            SubForms.Input_form_1_stroke sform = new SubForms.Input_form_1_stroke("Кол-во вершин");
            sform.DoTask += CreateController;
            sform.Show();
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

            controller = new SoftwareConstructing.Alg1.Controller(size, DGV_Matrix, PB_GraphGraphics);
            controller.Set_SwichButton(B_Swich);

            return;
        }

        private void B_boot1_Click(object sender, EventArgs e)
        {
            controller.Matrix_DFS();
        }
    }
}
