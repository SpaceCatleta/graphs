using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareConstructing.GraphVisualization
{
    /// <summary>
    /// Описывает контроллер для взаимодействия модели графа, DGV для ввода и его графического представления в PB
    /// </summary>
    public class Controller
    {
        const string SWICH_oriented = "ввод ориентированного пути";
        const string SWICH_not_oriented = "ввод не ориентированного пути";

        /// <summary>
        /// Поле ввода
        /// </summary>
        public MatrixView DGV_View;
        /// <summary>
        /// Графическое представление
        /// </summary>
        public GraphsView Graphics_View;
        /// <summary>
        /// Модель графа
        /// </summary>
        public Main.MatrixGraph graph_model;
        /// <summary>
        /// Кнопка переключения режимов ввода
        /// </summary>
        public Button SwichButton;
        

        /// <summary>
        /// Конструткор
        /// </summary>
        /// <param name="topscount"> Кол-во вершин</param>
        /// <param name="field"> поле DGV </param>
        /// <param name="Canvas"> PB для визуализации </param>
        public Controller(int topscount, DataGridView field, PictureBox Canvas)
        {
            graph_model = new Main.MatrixGraph(topscount);
            DGV_View = new GraphVisualization.MatrixView(field, topscount, topscount);
            Graphics_View = new SoftwareConstructing.GraphVisualization.GraphsView(Canvas);
            Graphics_View.DrawTops(topscount);

            LinkEvents();
        }


        /// <summary>
        /// привязывает события
        /// </summary>
        public void LinkEvents()
        {
            //Привязка событий
            DGV_View.CellChanged += DGV_View_CellChanged;

            graph_model.AlgorythmStarted += Graph_model_AlgorythmStarted;
            graph_model.AlgorythmFinished += Graph_model_AlgorythmFinished;

            graph_model.CellChanged += Graph_model_CellChanged;
            graph_model.FlagChanged += Graph_model_FlagChanged;
            graph_model.StringFlagChanged += Graph_model_StringFlagChanged;
            graph_model.StartOrEndChanged += Graph_model_StartOrEndChanged;
            graph_model.WayPassed += Graph_model_WayPassed;

            Graphics_View.Click += Graphics_View_Click;

            graph_model.StartPoint = 0;
            graph_model.EndPoint = 1;
        }

        /// <summary>
        /// Устанавливает кнопку как переключатель режима ввода
        /// </summary>
        /// <param name="button"> Кнопка </param>
        public void Set_SwichButton(Button button)
        {
            SwichButton = button;
            button.Click += Button_Click;
            SwichButton.Text = DGV_View.IsOriented ? SWICH_oriented : SWICH_not_oriented;
        }


        /// <summary> 
        /// Обраотка клика переключателя ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, System.EventArgs e)
        {
            DGV_View.IsOriented = !DGV_View.IsOriented;
            SwichButton.Text = DGV_View.IsOriented ? SWICH_oriented : SWICH_not_oriented;
        }


        /// <summary>
        /// Обработка прохода по пути(ребру)
        /// </summary>
        /// <param name="sender"> отправиитель </param>
        /// <param name="from"> откуда </param>
        /// <param name="to"> куда </param>
        protected void Graph_model_WayPassed(object sender, int from, int to)
        {
            int way = Graphics_View.GetWayIndex(from, to);
            Graphics_View.Ways[way].CurrentColor = Graphics_View.WayColor;

            Graphics_View.Ways[way].ReDraw();
            Graphics_View.Tops[from].ReDraw();
            Graphics_View.Tops[to].ReDraw();
        }


        /// <summary>
        /// Обработка зваершения работы алгоритма
        /// </summary>
        /// <param name="sender"></param>
        private void Graph_model_AlgorythmFinished(object sender, bool ReDrewEnd)
        {
            if (ReDrewEnd)
            {
                Graphics_View.Tops[graph_model.EndPoint].CurrentColor = Graphics_View.EndColor;
                Graphics_View.Tops[graph_model.EndPoint].ReDraw();
            }

            Graphics_View.Tops[graph_model.StartPoint].CurrentColor = Graphics_View.StartColor;
            Graphics_View.Tops[graph_model.StartPoint].ReDraw();  

            foreach (Graphs_Way way in Graphics_View.Ways)
                if (way.From == graph_model.StartPoint || graph_model.VisitFlags[way.From] == "WayPoint")
                    if (graph_model.VisitFlags[way.To] == "WayPoint" || way.To == graph_model.EndPoint)
                    {
                        way.CurrentColor = Graphics_View.WayColor;
                        way.ReDraw();
                    }

            Graphics_View.ReDrawTops();
        }


        /// <summary>
        /// Обработка смены стартовой\конечной точки
        /// </summary>
        /// <param name="sender"> отправитель </param>
        /// <param name="Oldpoint"> Старое значение </param>
        /// <param name="NewPoint"> Новое значение </param>
        /// <param name="StartOrEnd"> Стартовое или конечное значение изменилось </param>
        private void Graph_model_StartOrEndChanged(object sender, int Oldpoint, int NewPoint, bool StartOrEnd)
        {
            Graphics_View.Tops[Oldpoint].CurrentColor = Graphics_View.StandartColor;
            Graphics_View.Tops[Oldpoint].ReDraw();

            if (StartOrEnd)
                Graphics_View.Tops[NewPoint].CurrentColor = Graphics_View.StartColor;
            else
                Graphics_View.Tops[NewPoint].CurrentColor = Graphics_View.EndColor;

            Graphics_View.Tops[NewPoint].ReDraw();
        }


        /// <summary>
        /// Обработка клика по граф. представлению графа
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="PosOnCanvas"> Позиция на полотне </param>
        /// <param name="LeftOrRight"> ЛКМ или ПКМ </param>
        private void Graphics_View_Click(object sender, Point PosOnCanvas, bool LeftOrRight)
        {
            for (int i = 0; i < graph_model.TopsCount; i++)
                if (Graphics_View.Tops[i].IsPointOnObject(PosOnCanvas))
                {
                    if (LeftOrRight)
                        graph_model.StartPoint = i;
                    else
                        graph_model.EndPoint = i;
                    Graphics_View.Tops[i].ReDraw();
                    return;
                }
            return;
        }


        /// <summary>
        /// Обработка события старта алгоритма
        /// </summary>
        /// <param name="sender"></param>
        private void Graph_model_AlgorythmStarted(object sender)
        {
            graph_model.SetAllStringFlags("");
            graph_model.SetAllUntFlags(0);
            Graphics_View.ReColorWays(Graphics_View.StandartColor);
        }


        /// <summary>
        /// Обработка смены числового флага 
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="topindex"> Индекс вершины </param>
        /// <param name="value"> Флаг </param>
        /// <param name="IsSetOrdeleted"> Установлен(true) или удалён(false)</param>
        private void Graph_model_FlagChanged(object sender, int topindex, int value, bool IsSetOrdeleted = true)
        {
            Graphics_View.Tops[topindex].Flag = IsSetOrdeleted ? value.ToString() : "";
            Graphics_View.Tops[topindex].ReDraw();
        }


        /// <summary>
        /// Обработка смены текстового флага (посещения)
        /// </summary>
        /// <param name="topindex"> Индекс вершины </param>
        /// <param name="value"> Флаг </param>
        public void Graph_model_StringFlagChanged(int topindex, string value)
        {
            if (value == "")
                Graphics_View.Tops[topindex].CurrentColor = Graphics_View.StandartColor;
            else if (value == "visit")
                Graphics_View.Tops[topindex].CurrentColor = Graphics_View.VisitCol0r;
            else if (value == "visited")
                Graphics_View.Tops[topindex].CurrentColor = Graphics_View.VisitedColor;
            else if (value == "WayPoint")
                Graphics_View.Tops[topindex].CurrentColor = Graphics_View.WayColor;

            Graphics_View.Tops[topindex].ReDraw();
        }

        
        /// <summary>
        /// Обработка события изменения значения в матрице смежности графа
        /// </summary>
        /// <param name="sender"> отправитель </param>
        /// <param name="cell"> ячейка </param>
        /// <param name="newvalue"> новое значение </param>
        private void Graph_model_CellChanged(object sender, System.Drawing.Point cell, int newvalue)
        {
            int from = cell.X;
            int to = cell.Y;

            //Прокладывается или удаляется путь
            if(newvalue != graph_model.INF)
            {
                //проверка, существует ли уже путь
                int index = Graphics_View.GetWayIndex(from, to);
                if (index == -1)
                {
                    Graphics_View.Ways.Add(new GraphVisualization.Graphs_Way(Graphics_View, Graphics_View.StandartColor, from, to, newvalue));
                    Graphics_View.Ways[Graphics_View.Ways.Count - 1].Draw();
                }                  
                else
                {
                    Graphics_View.Ways[index].Erase();
                    Graphics_View.Ways[index].Length = newvalue;
                    Graphics_View.Ways[index].Draw();
                }  
            }
            else
            {
                int index = Graphics_View.GetWayIndex(from, to);
                if(index != -1)
                {
                    Graphics_View.Ways[index].Erase();
                    Graphics_View.Ways.Remove(Graphics_View.Ways[index]);
                }
            }

            Graphics_View.Tops[from].ReDraw();
            Graphics_View.Tops[to].ReDraw();
        }


        /// <summary>
        /// Обработка события смены значения в матрице UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="location"></param>
        /// <param name="value"></param>
        public void DGV_View_CellChanged(object sender, System.Drawing.Point location, int value)
        {          
            graph_model[location.Y, location.X] = value == 0 ? graph_model.INF : value;

            //Проверка обратного пути
            int index = Graphics_View.GetWayIndex(location.X, location.Y);
            if (index != -1)
            {
                if (graph_model[location.Y, location.X] != graph_model[location.X, location.Y] && value > 0)
                    DGV_View[location.Y, location.X] = value;
                
            }
        }


        protected void drawWay(int[] wayPoints)
        {
            for (int i = 1; i < wayPoints.Length; i++)
            {
                Graph_model_WayPassed(this, wayPoints[i - 1], wayPoints[i]);
            }

            foreach (int val in wayPoints)
            {
                if (val == graph_model.StartPoint || val == graph_model.EndPoint)
                    continue;
                Graphics_View.Tops[val].CurrentColor = Graphics_View.WayColor;
                Graphics_View.Tops[val].ReDraw();
            }

            Graphics_View.Tops[graph_model.StartPoint].CurrentColor = Graphics_View.StartColor;
            Graphics_View.Tops[graph_model.StartPoint].ReDraw();

            Graphics_View.Tops[graph_model.EndPoint].CurrentColor = Graphics_View.EndColor;
            Graphics_View.Tops[graph_model.EndPoint].ReDraw();
        }


        protected void drawResult(List<int[]> ways, bool nonOriented = false, bool colorStart = false, bool colorEnd = false)
        {
            foreach (int[] way in ways)
            {
                Graph_model_WayPassed(this, way[0], way[1]);
                if (nonOriented)
                    Graph_model_WayPassed(this, way[1], way[0]);
                Graphics_View.Tops[way[0]].CurrentColor = Graphics_View.WayColor;
                Graphics_View.Tops[way[0]].ReDraw();
                Graphics_View.Tops[way[1]].CurrentColor = Graphics_View.WayColor;
                Graphics_View.Tops[way[1]].ReDraw();
            }

            if (colorStart)
            {
                Graphics_View.Tops[graph_model.StartPoint].CurrentColor = Graphics_View.StartColor;
                Graphics_View.Tops[graph_model.StartPoint].ReDraw();
            }

            if (colorEnd)
            {
                Graphics_View.Tops[graph_model.EndPoint].CurrentColor = Graphics_View.EndColor;
                Graphics_View.Tops[graph_model.EndPoint].ReDraw();
            }
        }


        protected void colorToStandard()
        {
            foreach (Graphs_Way way in Graphics_View.Ways)
            {
                way.CurrentColor = Graphics_View.StandartColor;
                way.ReDraw();
            }

            foreach(Graphs_Top top in Graphics_View.Tops)
            {
                top.CurrentColor = Graphics_View.StandartColor;
                top.ReDraw();
            }
        }
    }
}
