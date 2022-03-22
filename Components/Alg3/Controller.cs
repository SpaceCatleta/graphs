using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SoftwareConstructing.Alg3
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



        public void minimalCircle()
        {
            try
            {
                colorToStandard();

                List<int> result = ((Alg3.Graph)graph_model).minimalCircle();

                drawWay(result.ToArray());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            MessageBox.Show("calculated");
        }





    }
}
