using System.Collections.Generic;
using System.Diagnostics;


namespace SoftwareConstructing.Alg1
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


        /// <summary>
        /// Выполняет обход в глубину
        /// </summary>
        /// <param name="startPoint"> Стартовая вершина </param>
        /// <returns> Возвращает древо поиска с индексами вершин </returns>
        public int[] Matrix_DFS()
        {
            int startPoint = StartPoint;
            int endPoint = EndPoint;
            SetAllStringFlags("");
            SetAllUntFlags(0);

            List<int> visit = new List<int>();
            int[] waysLen = new int[TopsCount];
            for (int i = 0; i < TopsCount; i++)
                waysLen[i] = int.MaxValue;

            int[] wayPoints = new int[0];

            waysLen[startpoint] = 0;
            visit.Add(startPoint);
            SetStringFlag(startPoint, "visit");

            while (visit.Count > 0)
            {
                Debug.Print($"{visit.Count} -visit count");
                int current_top = visit[visit.Count - 1];

                //Поиск следующей вершины
                bool breaked = false;
                for (int i = 0; i < TopsCount; i++)
                {
                    //if (this[current_top, i] > 0 && VisitFlags[i] == "")
                    if (this[current_top, i] > 0 && waysLen[current_top] + this[current_top, i] < waysLen[i])
                    {
                        waysLen[i] = waysLen[current_top] + this[current_top, i];
                        visit.Add(i);
                        SetStringFlag(i, "visit");

                        if (i == endPoint)
                        {
                            wayPoints = new int[visit.Count];
                            visit.CopyTo(wayPoints);
                        }

                        breaked = true;
                        break;
                    }
                }

                //Выход из вершины
                if (!breaked)
                {
                    Debug.Print($"{current_top} - drop");
                    SetStringFlag(current_top, "visited");
                    visit.Remove(current_top);
                }
            }

            Debug.Print("end matrix");

            return wayPoints;
        }

    }
}
