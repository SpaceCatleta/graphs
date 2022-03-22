using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstructing.Alg3
{
    internal class Graph : SoftwareConstructing.Alg1.Graph
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

        protected int waylen;
        public List<int> circleWay;
        protected List<int> way;


        public List<int> minimalCircle()
        {
            way = new List<int>();
            waylen = int.MaxValue;
            way.Add(StartPoint);
            cicleIter();
            return circleWay;
        }

        protected void cicleIter()
        {

            if (way[0] == way[way.Count - 1] && way.Count > 1)
            {
                int newLen = getLen(way);
                if (newLen < waylen)
                {
                    waylen = newLen;
                    circleWay = new List<int>();
                    foreach (int point in way)
                        circleWay.Add(point);
                    circleWay = new List<int>(way);
                }
            }

            int top = way[way.Count - 1];

            for(int i = 0; i < TopsCount; i++)
            {
                if (top == i || this[top, i] == -1)
                    continue;



                if(way.IndexOf(i) != -1)
                    if (way.Count != TopsCount && i != way[0])
                        continue;
                way.Add(i);
                cicleIter();
                way.Remove(i);
            }

        }

        protected int getLen(List<int> tops)
        {
            int len = 0;
            for (int i = 1; i < tops.Count; i++)
            {
                len += this[tops[i - 1], tops[i]];
            }
            return len;
        }
    }
}
