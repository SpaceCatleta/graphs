using System.Drawing;
using System.Collections.Generic;

namespace SoftwareConstructing.Main
{
    /// <summary>
    /// Описывает граф, заданный матрицей смежности
    /// </summary>
    public class MatrixGraph
    {
        #region события и их делегаты
        /// <summary>
        /// Для события изменения значения в ячейке матрицы смежности
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="cell"> Позиция ячейки </param>
        /// <param name="newvalue"> Новое значение в чейке </param>
        public delegate void for_CellChanged(object sender, Point cell, int newvalue);
        /// <summary>
        /// Для событи изменения значения в массиве меток
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="topindex"> Индекс вершины </param>
        /// <param name="value"> установленное значение </param>
        /// <param name="IsSetOrdeleted"> Значение установлено(true) или удалено(false) </param>
        public delegate void for_IntFlagChanged(object sender, int topindex, int value, bool IsSetOrdeleted = true);
        /// <summary>
        /// Для событи изменения значения в массиве меток посещения
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        /// <param name="topindex"> Индекс вершины </param>
        /// <param name="value"> установленное значение </param>
        /// <param name="IsSetOrdeleted"> Значение установлено(true) или удалено(false) </param>
        public delegate void for_StringFlagChanged(int topindex, string value);
        /// <summary>
        /// Для обработкы события старта алгоритма
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        public delegate void for_AlgorythmStart(object sender);
        /// <summary>
        /// Для события завершения работы алгоритма
        /// </summary>
        /// <param name="sender"></param>
        public delegate void for_AlgorythmFinish(object sender, bool ReDrawEnd);
        /// <summary>
        /// Для обработки смены стартовой/конечной точки
        /// </summary>
        /// <param name="sender"> отправитель </param>
        /// <param name="Oldpoint"> Старая очка </param>
        /// <param name="NewPoint"> Новая точка </param>
        /// <param name="StartOrEnd"> Изменилось начало или конец </param>
        public delegate void for_Start_or_EndPointChanged(object sender, int Oldpoint, int NewPoint, bool StartOrEnd);
        /// <summary>
        /// Для обработки прохода по пути
        /// </summary>
        /// <param name="sender"> Отпавитель </param>
        /// <param name="from"> Откуда </param>
        /// <param name="to"> Куда </param>
        public delegate void for_WayPassed(object sender, int from, int to);
        
        /// <summary>
        /// Значениние в матрице смежности изменилось
        /// </summary>
        public event for_CellChanged CellChanged;
        /// <summary>
        /// Значение в массиве меток изменилось
        /// </summary>
        public event for_IntFlagChanged FlagChanged;
        /// <summary>
        /// Значение в массиве строковых меток изменилось
        /// </summary>
        public event for_StringFlagChanged StringFlagChanged;
        /// <summary>
        /// Запущен алгоритм обхода графа
        /// </summary>
        public event for_AlgorythmStart AlgorythmStarted;
        /// <summary>
        /// Алгоритм обхода графа завершён
        /// </summary>
        public event for_AlgorythmFinish AlgorythmFinished;
        /// <summary>
        /// Стартовая или конечная точки изменились
        /// </summary>
        public event for_Start_or_EndPointChanged StartOrEndChanged;
        /// <summary>
        /// Пройден путь между точками(финальная обработка алгоритма)
        /// </summary>
        public event for_WayPassed WayPassed;
        #endregion


        #region поля
        /// <summary>
        /// Обозначает бесконечность в матрице смежности или отсутствие меток массиве меток
        /// </summary>
        public int INF = -1;
        /// <summary>
        /// Матрица смежности
        /// </summary>
        public int[,] Matrix;
        /// <summary>
        /// массив меток вершин (используется в алгоритмах обхода графа)
        /// </summary>
        public int[] Flags;
        /// <summary>
        /// Массив меток посещения (используется в алгоритмах обхода графа)
        /// </summary>
        public string[] VisitFlags;
        /// <summary>
        /// Начальная точка
        /// </summary>
        protected int startpoint;
        /// <summary>
        /// Конечноая точка
        /// </summary>
        protected int endpoint;
        #endregion


        #region методы-свойства
        /// <summary>
        /// Предоставляет доступ к матрице смежности
        /// </summary>
        /// <param name="x"> X (Откуда) </param>
        /// <param name="y"> Y (куда)</param>
        /// <returns></returns>
        public int this[int x, int y]
        {
            get { return Matrix[x, y]; }
            set
            {
                Matrix[x, y] = value;
                CellChanged?.Invoke(this, new Point(x, y), value);
            }
        }     
        /// <summary>
        /// Кол-во вершин в графе
        /// </summary>
        public int TopsCount { get; protected set; }
        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        public int StartPoint
        {
            get { return startpoint; }
            set
            {
                int oldVal = startpoint;
                startpoint = value;
                StartOrEndChanged?.Invoke(this, oldVal, value, true);
            }
        }
        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        public int EndPoint
        {
            get { return endpoint; }
            set
            {
                int oldVal = endpoint;
                endpoint = value;
                StartOrEndChanged?.Invoke(this, oldVal, value, false);
            }
        }
        #endregion


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="topscount"> Кол-во вершин </param>
        public MatrixGraph(int topscount)
        {
            TopsCount = topscount;
            VisitFlags = new string[topscount]; 
            Matrix = new int[topscount, topscount];
            Flags = new int[topscount];
            for (int i = 0; i < topscount; i++)
            {
                Flags[i] = INF;
                VisitFlags[i] = "";
                for (int j = 0; j < topscount; j++)
                    Matrix[i, j] = INF;
            }
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="matrix"> матрица смежности </param>
        public MatrixGraph(int[,] matrix)
        {
            TopsCount = matrix.GetLength(0);
            VisitFlags = new string[TopsCount];
            Matrix = new int[TopsCount, TopsCount];
            Flags = new int[TopsCount];
            for (int i = 0; i < TopsCount; i++)
            {
                Flags[i] = INF;
                VisitFlags[i] = "";
                for (int j = 0; j < TopsCount; j++)
                    Matrix[i, j] = matrix[i, j];
            }
        }


        #region вызов событий

        /// <summary>
        /// Сигнализирует о старте алгоритма
        /// </summary>
        /// <param name="sender"> Отправитель </param>
        public void StartAlgorythm(object sender)
        {
            AlgorythmStarted?.Invoke(sender);
        }


        /// <summary>
        /// Сигнализирует о завершении работы алгоритма
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="bool"> Пересовка конца пути </param>
        public void FinishAlgorythm(object sender, bool redrawend)
        {
            AlgorythmFinished?.Invoke(this, redrawend);
        }


        /// <summary>
        /// Сгнализирует оп прохождении по указанному пути(ребру)
        /// </summary>
        /// <param name="sender"> отправитель </param>
        /// <param name="from"> откуда </param>
        /// <param name="to"> куда </param>
        public void WayPass(int from, int to)
        {
            WayPassed(this, from, to);
        } 

        #endregion


        #region преобразование модели

        /// <summary>
        /// Создаёёт список смежности по матрице [0] - куда, [1] - длина пути
        /// </summary>
        /// <returns></returns>
        protected List<int[]>[] CreateList()
        {
            List<int[]>[] list = new List<int[]>[TopsCount];
            for (int i = 0; i < TopsCount; i++)
            {
                list[i] = new List<int[]>();
                for (int j = 0; j < TopsCount; j++)
                    if (this[i, j] > 0)
                        list[i].Add(new int[2] { j, this[i, j] });
            }

            return list;
        }


        /// <summary>
        /// проводит поиск обратного пути в списке смежности
        /// </summary>
        /// <param name="list"> список смежности </param>
        /// <param name="from"> откуда </param>
        /// <param name="to"> куда </param>
        /// <returns> озвращает индекс обратного пути в списке смежности, либо -1 </returns>
        protected int ListSearch(List<int[]>[] list, int from, int to)
        {
            for (int i = 0; i < list[from].Count; i++)
                if (list[from][i][0] == to)
                    return i;

            return -1;
        }


        /// <summary>
        /// Создаёт список посещения для списка смежности
        /// </summary>
        /// <param name="list"> список смежности </param>
        /// <returns></returns>
        protected List<bool>[] CreateVisitList(List<int[]>[] list)
        {
            List<bool>[] answer = new List<bool>[TopsCount];
            for (int i = 0; i < TopsCount; i++)
            {
                answer[i] = new List<bool>();
                for (int j = 0; j < list[i].Count; j++)
                    answer[i].Add(false);
            }

            return answer;
        }


        /// <summary>
        /// Возвращает копию матрицы смежности
        /// </summary>
        /// <returns></returns>
        public int[,] GetMatrixCopy()
        {
            int[,] matrix = new int[TopsCount, TopsCount];

            for (int i = 0; i < TopsCount; i++)
                for (int j = 0; j < TopsCount; j++)
                    matrix[i, j] = Matrix[i, j];

            return matrix;
        }


        /// <summary>
        /// Транспонирует граф
        /// </summary>
        public void Transposition()
        {
            int[,] matrix = new int[TopsCount, TopsCount];

            for (int i = 0; i < TopsCount; i++)
                for (int j = 0; j < TopsCount; j++)
                    matrix[i, j] = Matrix[j, i];

            Matrix = matrix;
        }

        #endregion


        #region работа с метками

        /// <summary>
        /// Устанавливает метку на вершину (если метка равна INF, то метка удаляется)
        /// </summary>
        /// <param name="topindex"> Индекс вершины </param>
        /// <param name="value" Значение </param>
        public void SetFlag(int topindex, int value)
        {
            Flags[topindex] = value;
            FlagChanged?.Invoke(this, topindex, value, value != INF ? true : false);
        }


        /// <summary>
        /// Удаляет метку с вершины
        /// </summary>
        /// <param name="topindex"> Индекс вершины </param>
        public void ClearFlag(int topindex)
        {
            Flags[topindex] = INF;
            FlagChanged?.Invoke(this, topindex, INF, false);
        }


        /// <summary>
        /// Позволяет изменить строковую метку вершины
        /// </summary>
        /// <param name="topindex"> Индекс вершины </param>
        /// <param name="flag"> Метка </param>
        public void SetStringFlag(int topindex, string flag)
        {
            VisitFlags[topindex] = flag;
            StringFlagChanged?.Invoke(topindex, flag);
        }

        public string GetStringFlag(int topindex)
        {
            return VisitFlags[topindex];
        }


        /// <summary>
        /// Устанавливает всем вершинам указанную метку
        /// </summary>
        /// <param name="flag"></param>
        public void SetAllStringFlags(string flag)
        {
            for (int i = 0; i < TopsCount; i++)
            {
                VisitFlags[i] = flag;
                StringFlagChanged?.Invoke(i, flag);
            }
        }


        /// <summary>
        /// Устанавливет всем вершинам указанную числовую метку
        /// </summary>
        /// <param name="flag"> Метка </param>
        public void SetAllUntFlags(int flag)
        {
            for (int i = 0; i < TopsCount; i++)
            {
               Flags[i] = flag;
                FlagChanged?.Invoke(this, i, flag, flag != 0 ? true : false);
            }
        }

        #endregion


        /// <summary>
        /// Возврращает индекс вершины по её имени (считается что имена вершин идут по порядку: A, B, C...)
        /// </summary>
        /// <param name="Name"> Имя вершины </param>
        /// <returns></returns>
        public int IndexByName(string Name)
        {
            return (int)Name.ToCharArray()[0] - 65;
        }


        /// <summary>
        /// Возврращает имя вершины по её индексу (считается что имена вершин идут по порядку: A, B, C...)
        /// </summary>
        /// <param name="index"> Индекс </param>
        /// <returns></returns>
        public string NameByIndex(int index)
        {
            return ((char)65 + index).ToString();
        }
    }
}
