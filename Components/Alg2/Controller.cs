using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SoftwareConstructing.Alg2
{

    public class Controller : SoftwareConstructing.GraphVisualization.Controller
    {

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="topscount"> Кол-во вершин в графе </param>
        /// <param name="field"> DGV для матрицы смежности </param>
        /// <param name="Canvas"> PB для визуализации </param>
        public Controller(int topscount, DataGridView field, PictureBox Canvas) : base(topscount, field, Canvas)
        {
            graph_model = new Graph(topscount);

            LinkEvents();
        }

        /// <summary>
        /// Находит Гамильтоновы циклы
        /// </summary>
        public void primAlgo()
        {
            try
            {
                colorToStandard();

                List<int[]> result = ((Alg2.Graph)graph_model).primAlgo();

                drawResult(result, false, true);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            MessageBox.Show("calculated");
        }
    }
}
