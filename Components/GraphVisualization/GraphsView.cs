using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareConstructing.GraphVisualization
{
    /// <summary>
    /// Описывает класс для графического отображения графа в PictureBox
    /// </summary>
    public class GraphsView
    {
        /// <summary>
        /// Для обработки клика мышкой по полотну 
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="PosOnCanvas"> Позиция на полотне </param>
        /// <param name="LeftOrRight"> лКМ(true) или ПКМ(false) </param>
        public delegate void for_Click(object sender, Point PosOnCanvas, bool LeftOrRight);

        /// <summary>
        /// Обработка клика по полотну
        /// </summary>
        public event for_Click Click;

        /// <summary>
        /// PictureBox в котором будет содержаться графика
        /// </summary>
        public PictureBox PB;
        /// <summary>
        /// Холст
        /// </summary>
        public Bitmap Canvas;
        /// <summary>
        /// Ширина холста
        /// </summary>
        public int Width { get { return PB.Width; } }
        /// <summary>
        /// Высота холста
        /// </summary>
        public int Height { get { return PB.Height; } }
        /// <summary>
        /// Список отрисованных вершин
        /// </summary>
        public List<Graphs_Top> Tops;
        /// <summary>
        /// Список путей
        /// </summary>
        public List<Graphs_Way> Ways;

        #region параметры вершин
        /// <summary>
        /// Дистанция между центрами вершин
        /// </summary>
        public int Distance = 130;
        /// <summary>
        /// Радиус вершины (круга)
        /// </summary>
        public int TopRadius = 20;
        /// <summary>
        /// Толщина линии
        /// </summary>
        public int LineWidth = 6;
        /// <summary>
        /// Стандартный цвет вершины
        /// </summary>
        public Color StandartColor = Color.Green;
        /// <summary>
        /// Цвет для посещаемой вершины
        /// </summary>
        public Color VisitCol0r = Color.Orange;
        /// <summary>
        /// Цвет для посещённой вершины
        /// </summary>
        public Color VisitedColor = Color.Red;
        /// <summary>
        /// Цвет для пометки маргрута
        /// </summary>
        public Color WayColor = Color.Blue;
        /// <summary>
        /// Цвет для начальной вершины
        /// </summary>
        public Color StartColor = Color.LightBlue;
        /// <summary>
        /// Цвет для конечной вершины
        /// </summary>
        public Color EndColor = Color.DarkBlue;
        /// <summary>
        /// Использыемый для подписей шрифт
        /// </summary>
        public Font Font = new Font("Microsoft Sans Serif", 14);
        /// <summary>
        /// Цвет шрифта
        /// </summary>
        public Color FontColor = Color.Black;
        #endregion


        /// <summary>
        /// Конструктор, поумалчанию высота и ширина беруться у PictureBox
        /// </summary>
        /// <param name="window"> PictureBox в котором будет содержаться графика </param>
        /// <param name="height"> высота </param>
        /// <param name="width"> ширина </param>
        public GraphsView(PictureBox window, int height = 0, int width = 0)
        {
            PB = window;
            height = height == 0 ? PB.Height : height;
            width = width == 0 ? PB.Width : width;
            Canvas = new Bitmap(width, height);
            PB.Image = Canvas;
            using (var g = Graphics.FromImage(Canvas))
                g.Clear(Color.White);

            Tops = new List<Graphs_Top>();
            Ways = new List<Graphs_Way>();

            PB.Click += PB_Click;
        }


        /// <summary>
        /// Обработка клика по оплотну
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PB_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            Point location = args.Location;

            if (args.Button == MouseButtons.Left)
                Click?.Invoke(this, location, true);
            else if (args.Button == MouseButtons.Right)
                Click?.Invoke(this, location, false);
        }


        /// <summary>
        /// Отрисовывает все вершины на холсте
        /// </summary>
        /// <param name="topscount"></param>
        public void DrawTops(int topscount)
        {
            int rowsize = (int)Math.Sqrt(topscount);

            for (int i = 0, distan_from_top_border = TopRadius + 10 + Font.Height; i < topscount;)
            {
                for (int row_count = 0, distan_from_left_border = TopRadius + 10; row_count < rowsize && i < topscount; row_count++)
                {
                    Point center = new Point(distan_from_left_border, distan_from_top_border);
                    Tops.Add(new Graphs_Top(this, center, StandartColor, ((char)(65 + i)).ToString()));
                    distan_from_left_border += Distance;

                    Tops[i].Draw();
                    i++;
                }
                distan_from_top_border += Distance;
            }
        }


        /// <summary>
        /// Переотрисовывает вершины графа
        /// </summary>
        /// <param name="color"> Цвет вершин </param>
        public void ReDrawTops()
        {
            foreach (Graphs_Top top in Tops)
                top.ReDraw();
        }


        /// <summary>
        /// Меняет цвет всех вершин на указанный
        /// </summary>
        /// <param name="color"> Новый цвет </param>
        public void ReColorTops(Color color)
        {
            foreach (Graphs_Top top in Tops)
            {
                top.CurrentColor = color;
                top.ReDraw();
            }
        }


        /// <summary>
        /// Меняет цвет всех путей на указанный
        /// </summary>
        /// <param name="color"> Новый цвет </param>
        public void ReColorWays(Color color)
        {
            foreach (Graphs_Way way in Ways)
            {
                way.CurrentColor = color;
                way.ReDraw();
            }
        }


        /// <summary>
        /// переотрисовывает пути в графе
        /// </summary>
        /// <param name="color"> Цвет путей </param>
        public void ReDrawWays()
        {
            foreach (Graphs_Way way in Ways)
                way.ReDraw();
        }


        /// <summary>
        /// Находит индекс пути по началу и концу
        /// </summary>
        /// <param name="from"> Индекс начальной вершины </param>
        /// <param name="to"> Индекс конечной вершины </param>
        /// <returns></returns>
        public int GetWayIndex(int from, int to)
        {
            for (int i = 0; i < Ways.Count; i++)
                if (from == Ways[i].From && to == Ways[i].To)
                    return i;

            return -1;
        }
    }
}
