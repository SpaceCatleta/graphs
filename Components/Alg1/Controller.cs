using System;
using System.Windows.Forms;

namespace SoftwareConstructing.Alg1
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
        public void Matrix_DFS()
        {
            try
            {
                colorToStandard();

                int[] topsList = ((Alg1.Graph)graph_model).Matrix_DFS();

                drawWay(topsList);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            MessageBox.Show("calculated");
        }
    }
}
