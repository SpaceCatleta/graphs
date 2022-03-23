using System.IO;
using SoftwareConstructing.GraphVisualization;
using System.Drawing;

namespace ADS_Labs_4sem.Main
{
    public static class Files
    {
        /// <summary>
        /// Заполняет матрицу смежности содержимым указанного файла
        /// </summary>
        /// <param name="FileName"> Имя файла </param>
        /// <param name="infinity"> Условное обозначение бесконечности </param>
        /// <returns> Возвращает матрицу смежности </returns>
        public static int[,] ReadFile(string FileName, int infinity)
        {
            string[] buffer;
            StreamReader file = new StreamReader(FileName);
            int order = int.Parse(file.ReadLine());
            int[,] graph = new int[order, order];


            for (int counter = 0; counter < order; counter++)
            {
                buffer = file.ReadLine().Split(' ');
                for (int step = 0; step < order; step++)
                {
                    graph[counter, step] = int.Parse(buffer[step]);
                }
            }

            file.Close();
            return graph;
        }


        public static void Fill_DGV(int[,] matr, Controller contr)
        {
            int size = matr.GetLength(0);
            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    if(matr[j, i] != -1)
                    {
                        contr.DGV_View[j, i] = matr[i, j];
                        contr.DGV_View_CellChanged(new object(), new Point(i, j), matr[j, i]);
                    }

                }
            }
        }
    }
}
