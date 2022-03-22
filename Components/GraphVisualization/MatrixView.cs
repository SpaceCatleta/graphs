using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SoftwareConstructing.GraphVisualization
{
    /// <summary>
    /// Описывает матрицу смежности (DataGridView) для ввода графа
    /// </summary>
    public class MatrixView
    {
        const string INPUT_ERROR = "Данные введены неверно";

        /// <summary>
        /// Для обработки изменения значения в клетке
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="location"> Позиция клетки </param>
        /// <param name="value"> Значение </param>
        public delegate void for_CellChanged(object sender, Point location, int value);
        
        /// <summary>
        /// Событие при изменении значения в клетке
        /// </summary>
        public event for_CellChanged CellChanged;

        /// <summary>
        /// Указывает, является ли вводимые пути ориентированными
        /// </summary>
        public bool IsOriented = true;
        /// <summary>
        /// Поле, с которым взаимодействует пользователь
        /// </summary>
        public DataGridView Field;
        /// <summary>
        /// Ширина поля
        /// </summary>
        public int Width { get { return Field.Columns.Count; } }
        /// <summary>
        /// Высота поля
        /// </summary>
        public int Height { get { return Field.Rows.Count; } }


        /// <summary>
        /// Предоставляет доступ к полям DataGridView
        /// </summary>
        /// <param name="row"> Строка </param>
        /// <param name="col"> Столбец </param>
        /// <returns></returns>
        public int this[int row, int col]
        {
            get { return int.Parse(Field[row, col].Value.ToString()); }
            set { Field[row, col].Value = value; }
        }


        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="field"> Поле для взаимодействия </param>
        /// <param name="width"> Ширина </param>
        /// <param name="height"> Высота</param>
        public MatrixView(DataGridView field, int height, int width)
        {
            Field = field;
            Field.CellValueChanged += DGV_ValueChanged;
            SoftwareConstructing.Main.DataGridView_Processor.Build_Matrix(true, width, height, Field);
        }


        /// <summary>
        /// Оработка события изменения значения в ячейке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_ValueChanged( object sender, EventArgs e)
        {
            if(CellChanged != null)
            {
                Point cell = Field.CurrentCellAddress;
                try
                {
                    int value = int.Parse(Field[cell.X, cell.Y].Value.ToString());
                    CellChanged(this, cell, value);
                    if (!IsOriented)
                    {
                        Field[cell.Y, cell.X].Value = Field[cell.X, cell.Y].Value;
                        CellChanged(this, new Point(cell.Y, cell.X), value);
                    }
                       
                }
                catch
                {
                    MessageBox.Show(INPUT_ERROR + " (" + Field[cell.X, cell.Y].Value.ToString() + ")");
                    Field[cell.X, cell.Y].Value = 0;
                }
            }  
        }
    }
}
