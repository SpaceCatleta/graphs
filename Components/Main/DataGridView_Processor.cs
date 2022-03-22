using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace SoftwareConstructing.Main
{
    public static class DataGridView_Processor
    {
        /// <summary>
        /// Читает матрицу из DataGridView
        /// </summary>
        /// <param name="DGV"> Объект DataGridView </param>
        /// <returns> Возвращает матрицу из целых чисел </returns>
        public static int[,] ReadGraph(DataGridView DGV)
        {
            int w = DGV.Columns.Count;
            int h = DGV.Rows.Count;
            int[,] matrix = new int[w, h];

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    matrix[i, j] = Convert.ToInt32(DGV[i, j].Value);

            return matrix;
        }


        /// <summary>
        /// Создаёт необходимое кол-во строк и столбцов в DataGridView, при необходимости может подписать точки.
        /// </summary>
        /// <param name="PrintPoints"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="DGV"></param>
        /// <param name="cell_size"></param>
        /// <param name="cell_font"></param>
        public static void Build_Matrix(bool PrintPoints, int width, int height, DataGridView DGV, int cell_size = 35, Font cell_font = null)
        {
            cell_font = cell_font == null ? new Font("Microsoft Sans Serif", 12) : cell_font;

            DGV.Columns.Clear();
            DGV.Rows.Clear();
            DGV.Font = cell_font;

            for (int i = 0; i < width; i++)
            {
                DGV.Columns.Add("", PrintPoints ? ((char)(65 + i)).ToString(): "");
                DGV.Columns[i].Width = cell_size;
                DGV.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            DGV.Rows.Add(height);
            for (int i = 0; i < height; i++)
            {
                if(PrintPoints)
                    DGV.Rows[i].HeaderCell.Value = ((char)(65 + i)).ToString();
                DGV.Rows[i].Height = cell_size;
            }

            return;
        }
    }
}
