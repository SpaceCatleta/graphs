using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareConstructing.Alg2
{
    internal class Graph : SoftwareConstructing.Main.MatrixGraph
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="topscount"> Кол-во вершин </param>
        public Graph(int topscount) : base(topscount) { }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="matrix"> Матрица смежности </param>
        public Graph(int[,] matrix) : base(matrix) { }


        public List<int[]> primAlgo()
        {
            SetAllStringFlags("");
            SetAllUntFlags(0);

            List<int[]> tree = new List<int[]>();
            List<int> visitedPoints = new List<int>();
            visitedPoints.Add(StartPoint);

            int[] currWay = null;

            bool run = true;
            while (run)
            {
                run = false;
                currWay = null;
                foreach (int point in visitedPoints)
                {
                    for (int i = 0; i < TopsCount; i++)
                    {
                        if (visitedPoints.IndexOf(i) != -1)
                            continue;
                        if (this[point, i] > 0)
                        {
                            run = true;
                            if (currWay == null)
                                currWay = new int[] { point, i };
                            else
                                currWay = this[currWay[0], currWay[1]] <= this[point, i] ? currWay : new int[] { point, i };
                        }
                    }
                }
                if (run)
                {
                    //MessageBox.Show($"{currWay[0]} : {currWay[1]}");
                    tree.Add(currWay);
                    visitedPoints.Add(currWay[1]);
                }
            }

            return tree;
        }
    }
}
