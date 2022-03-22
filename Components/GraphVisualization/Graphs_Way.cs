using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstructing.GraphVisualization
{
    /// <summary>
    /// Описывает ребро в графе
    /// </summary>
    public class Graphs_Way
    {
        /// <summary>
        /// Родитель
        /// </summary>
        public GraphsView Parent;
        /// <summary>
        /// Индекс начальной вершины
        /// </summary>
        public int From;
        /// <summary>
        /// Индекс конечной вершины
        /// </summary>
        public int To;
        /// <summary>
        /// Длина пти
        /// </summary>
        public int Length;
        /// <summary>
        /// Цвет ребра
        /// </summary>
        public Color CurrentColor;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="from"> Индекс начальной вершины </param>
        /// <param name="to"> Индекс конечной вершины </param>
        /// <param name="length"> Длна </param>
        public Graphs_Way(GraphsView parent, Color color, int from, int to, int length = 1)
        {
            Parent = parent;
            From = from;
            To = to;
            Length = length;
            CurrentColor = color;
        }


        /// <summary>
        /// Отрисовывает путь на холсте
        /// </summary>
        /// <param name="color"> Цвет пути </param>
        public void Draw()
        {
            Graphics graphics = Graphics.FromImage(Parent.Canvas);

            //Отрисовка линии
            graphics.DrawLine(new Pen(CurrentColor, Parent.LineWidth), Parent.Tops[From].Center, Parent.Tops[To].Center);
            Parent.PB.Image = Parent.Canvas;

            //Отрисовка длины пути
            Point LenLocation = new Point((Parent.Tops[To].Center.X + Parent.Tops[From].Center.X) / 2, (Parent.Tops[To].Center.Y + Parent.Tops[From].Center.Y) / 2);
            graphics.DrawString(Length.ToString(), Parent.Font, new SolidBrush(Parent.FontColor), LenLocation);

            //Отрисовка направления
            DrawDirectionPoint(graphics, CurrentColor);

            Parent.PB.Image = Parent.Canvas;
        }


        /// <summary>
        /// Удаляет путь с холста
        /// </summary>
        public void Erase()
        {
            Graphics graphics = Graphics.FromImage(Parent.Canvas);
            graphics.DrawLine(new Pen(Color.White, Parent.LineWidth), Parent.Tops[From].Center, Parent.Tops[To].Center);

            Point LenLocation = new Point((Parent.Tops[To].Center.X + Parent.Tops[From].Center.X) / 2, (Parent.Tops[To].Center.Y + Parent.Tops[From].Center.Y) / 2);
            graphics.FillRectangle(new SolidBrush(Color.White), LenLocation.X, LenLocation.Y, 20, 20);

            //Отрисовка направления
            DrawDirectionPoint(graphics, Color.White);

            Parent.PB.Image = Parent.Canvas;
        }


        /// <summary>
        /// Удаляет и отрисовывает путь на холсте заново
        /// </summary>
        /// <param name="color"> Цвет пути </param>
        public void ReDraw()
        {
            Erase();
            Draw();
        }


        /// <summary>
        /// Отрисовывает точку-направление (вместо стрелки)
        /// </summary>
        /// <param name="graphics"> Graphics </param>
        /// <param name="FillColor"> Цвет точки </param>
        private void DrawDirectionPoint(Graphics graphics, Color FillColor)
        {
            float LenX = Math.Abs(Parent.Tops[To].Center.X - Parent.Tops[From].Center.X);
            float LenY = Math.Abs(Parent.Tops[To].Center.Y - Parent.Tops[From].Center.Y);
            float LenLine = (float)Math.Sqrt(LenX * LenX + LenY * LenY);
            float ratio = (LenLine - Parent.TopRadius) / LenLine;
            int Xdiff = (int)((Parent.Tops[To].Center.X - Parent.Tops[From].Center.X) * (1 - ratio));
            int Ydiff = (int)((Parent.Tops[To].Center.Y - Parent.Tops[From].Center.Y) * (1 - ratio));

            Point LenLocation = new Point(Parent.Tops[To].Center.X - Xdiff, Parent.Tops[To].Center.Y - Ydiff);
            graphics.FillEllipse(new SolidBrush(FillColor), LenLocation.X - 10, LenLocation.Y - 10, 20, 20);
        }
    }
}
