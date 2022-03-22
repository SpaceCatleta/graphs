using System.Drawing;

namespace SoftwareConstructing.GraphVisualization
{
    /// <summary>
    /// Описывает графическое представление вершины графа
    /// </summary>
    public class Graphs_Top
    {
        /// <summary>
        /// Родитель
        /// </summary>
        public GraphsView Parent;
        /// <summary>
        /// координаты центра
        /// </summary>
        public Point Center;
        /// <summary>
        /// Имя, отрисовывается над вершиной
        /// </summary>
        public string Name;
        /// <summary>
        /// Метка, отрисовывается на вершине
        /// </summary>
        public string Flag = "";
        /// <summary>
        /// Цвет вершины
        /// </summary>
        public Color CurrentColor;


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parent"> Родитель </param>
        /// <param name="center"> Положение центра </param>
        /// <param name="name"> Имя </param>
        public Graphs_Top(GraphsView parent, Point center, Color color, string name)
        {
            Center = center;
            Name = name;
            Parent = parent;
            CurrentColor = color;
        }


        /// <summary>
        /// Отрисовывает вершину
        /// </summary>
        /// <param name="color"> Цвет вершины </param>
        public void Draw()
        {
            Graphics graphics = Graphics.FromImage(Parent.Canvas);
            //Отрисовка круга
            int radius = Parent.TopRadius;
            graphics.DrawEllipse(new Pen(CurrentColor, Parent.LineWidth), Center.X - radius, Center.Y - radius, radius * 2, radius * 2);

            //Отрисовка метки
            Point corner = new Point(Center.X - radius / 2, Center.Y - radius / 2);
            RectangleF rec = new RectangleF(Center.X - radius, Center.Y - radius, radius * 2, radius * 2);
            int remaining = radius - Parent.Font.Height;
            Point loc = new Point(Center.X - Parent.Font.Height/2, Center.Y - Parent.Font.Height/2);
            graphics.DrawString(Flag, Parent.Font, new SolidBrush(Parent.FontColor), loc);

            //Отрисовка названия
            Point corner2 = new Point(Center.X - radius/2, (int)(Center.Y - radius*2.3));
            graphics.DrawString(Name, Parent.Font, new SolidBrush(Parent.FontColor), corner2);

            Parent.PB.Image = Parent.Canvas;
        }


        /// <summary>
        /// Удаляет вершину с графа
        /// </summary>
        public void Erase()
        {
            Graphics graphics = Graphics.FromImage(Parent.Canvas);
            int radius = Parent.TopRadius;
            graphics.FillEllipse(new SolidBrush(Color.White), Center.X - radius, Center.Y - radius, radius * 2, radius * 2);
        }


        /// <summary>
        /// Стирает и отисовывает вершину заново
        /// </summary>
        /// <param name="color"></param>
        public void ReDraw()
        {
            Erase();
            Draw();
        }


        /// <summary>
        /// Проверяет попадает ли указанная точка на объект
        /// </summary>
        /// <param name="point"> Точка </param>
        /// <returns></returns>
        public bool IsPointOnObject(Point point)
        {
            int x = Center.X - Parent.TopRadius;
            int y = Center.Y - Parent.TopRadius;

            bool HitX = x < point.X && x + Parent.TopRadius * 2 > point.X;
            bool HitY = y < point.Y && y + Parent.TopRadius * 2 > point.Y;
            return HitX && HitY ? true : false;
        }
    }
}
