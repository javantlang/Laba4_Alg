using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4_Alg
{
    public partial class Form1 : Form
    {
        //Список всех точек на поле
        private Dictionary<PointF, int> listpoints;
        //Список точек, которые нужно соединить
        private Dictionary<PointF, int> ConnectPoints;
        //Список путей из поданного ключа
        private List<int> [] Trail;
        //Очередь для обхода в ширину
        private Queue<int> widthQueue;
        //Результат обхода в ширину
        List<int> processed;
        //Результат Эйлерова цикла
        Stack<int> ELcycle;
        //Матрица смежности
        private int[,] matrix;
        //Радиус кругов
        private int Rad = 16;
        private Bitmap bitmap;
        private Graphics g;
        private StringFormat sf = new StringFormat();
        private Font font = new Font("Times New Roman", 12);
        private SolidBrush CircleBrush = new SolidBrush(Color.DarkGreen);

        public Form1()
        {
            InitializeComponent();

            listpoints = new Dictionary<PointF, int>();
            ConnectPoints = new Dictionary<PointF, int>();
            widthQueue = new Queue<int>();
            processed = new List<int>();
            ELcycle = new Stack<int>();
            matrix = new int[0, 0];

            bitmap = new Bitmap(graphBox.Width, graphBox.Height);
            g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.BurlyWood);
            graphBox.Image = bitmap;

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            txtAttention.TextAlign = HorizontalAlignment.Center;
            txtAttention.Text = "Кликните на рабочую область, чтобы добавить вершину";
        }

        //Функция проверки попадания курсора в круг при нажатии
        private bool InShape(MouseEventArgs e)
        {
            foreach (var it in listpoints)
            {
                if (Math.Pow((it.Key.X - e.X), 2) +
                    Math.Pow((it.Key.Y - e.Y), 2) <= Math.Pow(Rad, 2))
                {
                    /*Проверка, есть ли уже добавленная точка
                     * Если нет, то добавляет для соединения,
                     * иначе проверяет, не равняется ли следующая точка первой добавленной,
                     * если не является, то добавляет её в список для соединения
                    */
                    if (ConnectPoints.Count == 0)
                        ConnectPoints.Add(it.Key, it.Value);
                    else if (!ConnectPoints.First().Equals(it))
                        ConnectPoints.Add(it.Key, it.Value);

                    return true;
                }
            }

            return false;
        }

        //Функция рисования на поле
        private void Draw()
        {
            g.Clear(Color.BurlyWood);

            //Сначала рисуются соединительные линии по матрице смежности
            for (int i = 0; i < listpoints.Count; ++i)
                for (int j = 0; j < listpoints.Count; ++j)
                {
                    if (matrix[i, j] == 1)
                    {
                        g.DrawLine(new Pen(Color.DarkRed, 3),
                        listpoints.ElementAt(i).Key, listpoints.ElementAt(j).Key);
                    }
                }

            //Рисуются все круги и текст
            foreach (var it in listpoints)
            {
                //Прямоугольник, в который вписываем текст и круг
                Rectangle rect = new Rectangle((int)it.Key.X - Rad,
                    (int)it.Key.Y - Rad, Rad * 2, Rad * 2);
                //Если есть выделенный круг для соединения, то его цвет станет синим
                if (ConnectPoints.Count != 0)
                {
                    if (it.Equals(ConnectPoints.First()))
                    {
                        CircleBrush.Color = Color.DarkBlue;
                    }
                    else
                        CircleBrush.Color = Color.DarkGreen;
                }
                else
                    CircleBrush.Color = Color.DarkGreen;

                //Круг
                g.FillEllipse(CircleBrush, rect);
                //Текст на круге
                g.DrawString((it.Value + 1).ToString(), font,
                    new SolidBrush(Color.White), rect, sf);
            }

            graphBox.Image = bitmap;
        }

        //Добавление нового узла
        private void AddNode(MouseEventArgs e)
        {
            int i = listpoints.Count;
            listpoints.Add(new PointF(e.X, e.Y), i);

            int[,] matrixCopy = matrix;

            matrix = new int[i + 1, i + 1];

            for (int k = 0; k < i; ++k)
                for (int j = 0; j < i; ++j)
                {
                    matrix[k, j] = matrixCopy[k, j];
                }
        }

        private void graphBox_MouseClick(object sender, MouseEventArgs e)
        {
            bool inFigure = InShape(e);
            if (btnAdd.Checked)
            {
                if (!inFigure)
                {
                    //Если точки будут находиться друг от друга меньше, чем на радиус,
                    //Они не построятся. Сделано для удобства восприятия.
                    foreach (var it in listpoints)
                    {
                        if (Math.Pow((it.Key.X - e.X), 2) +
                            Math.Pow((it.Key.Y - e.Y), 2) <= Math.Pow(Rad * 3, 2))
                        {
                            return;
                        }
                    }

                    //Добавление узла
                    AddNode(e);
                    Draw();
                }
                else
                    ConnectPoints.Clear();
            }
            else if (btnConnect.Checked)
            {
                if (inFigure)
                {
                    if (ConnectPoints.Count < 2)
                    {
                        Draw();
                        txtAttention.Text = "Выделите вторую вершину для создания дуги";
                        return;
                    }

                    int[] con = new int[2];
                    int i = 0;
                    foreach (var it in ConnectPoints)
                    {
                        con[i++] = it.Value;
                    }

                    matrix[con[0], con[1]] = 1;
                    matrix[con[1], con[0]] = 1;

                    ConnectPoints.Clear();
                    Draw();
                    txtAttention.Text = "Выделите первую вершину для создания дуги";
                }
                else
                {
                    ConnectPoints.Clear();
                    txtAttention.Text = "Выделите первую вершину для создания дуги";
                    Draw();
                }
            }
            else if (btnWidth.Checked)
            {
                if (inFigure)
                {
                    Draw();
                    processed.Clear();

                    //Начальная позиция Поиска в ширину
                    int startPos = ConnectPoints.First().Value;
                    txtAttention.Text = "Порядок обхода: " + (startPos + 1);

                    //Функция Поиска в ширину
                    WidthSearch(startPos);

                    if (processed.Count < listpoints.Count)
                    {
                        txtAttention.Text = "Несвязный граф";
                        ConnectPoints.Clear();
                        return;
                    }

                    foreach (var it in processed)
                    {
                        if (it != startPos)
                            txtAttention.Text += "->" + (it + 1);
                    }

                    processed.Clear();
                    ConnectPoints.Clear();
                }
            }
        }

        private void WidthSearch(int start)
        {
            //В очередь помещается начальная позиция
            widthQueue.Enqueue(start);

            while (widthQueue.Count() != 0)
            {
                //Удаляем вершину из очереди и помещаем её в переменную
                int index = widthQueue.Dequeue();

                //Проверяем, есть ли полученная вершина в списке выполненных
                bool flag = false;
                foreach (var it in processed)
                {
                    if (it == index)
                    {
                        flag = true;
                        break;
                    }
                }
                //Если нет, то помещаем в этот список
                if (!flag)
                {
                    processed.Add(index);
                }

                //Получаем все смежные с index вершины
                for (int i = 0; i < listpoints.Count; ++i)
                {
                    //Проверяем, смежная ли вершина с index
                    if (matrix[index, i] == 1)
                    {
                        //Вставляем в очередь те вершины, которые не были выполнены
                        flag = false;
                        foreach (var it in processed)
                            if (it == i)
                            {
                                flag = true;
                                break;
                            }
                        if (!flag)
                        {
                            widthQueue.Enqueue(i);
                        }
                    }
                }
            }
        }

        private void ChangeStateRadioButton(object sender, EventArgs e)
        {
            ConnectPoints.Clear();
            Draw();
            if (btnAdd.Checked)
            {
                txtAttention.Text = "Кликните на рабочую область, чтобы добавить вершину";
            }
            else if (btnConnect.Checked)
            {
                txtAttention.Text = "Выделите первую вершину для создания дуги";
            }
            else if (btnWidth.Checked)
            {
                txtAttention.Text = "Выберите начальную вершину обхода";
            }
            else if (btnEiler.Checked)
            {
                txtAttention.Text = "";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.BurlyWood);
            graphBox.Image = bitmap;
            listpoints.Clear();
            ConnectPoints.Clear();
            matrix = new int[0, 0];

            btnAdd.Checked = true;
        }

        private void btnEiler_CheckedChanged(object sender, EventArgs e)
        {
            if (btnEiler.Checked)
            {
                WidthSearch(0);

                if (processed.Count < listpoints.Count)
                {
                    txtAttention.Text = "Граф не содержит Эйлеров цикл," +
                        "так как граф несвязный";
                    ConnectPoints.Clear();
                    return;
                }

                //Массив список связных точек с данной
                Trail = new List<int>[listpoints.Count];

                for (int i = 0; i < listpoints.Count; ++i)
                {
                    Trail[i] = new List<int>();

                    int degree = 0;
                    for (int j = 0; j < listpoints.Count; ++j)
                    {
                        if (matrix[i, j] == 1)
                        {
                            ++degree;
                            Trail[i].Add(j);
                        }
                    }
                    if (degree % 2 == 1)
                    {
                        txtAttention.Text = "Граф не содержит Эйлеров цикл," +
                            " так как не все вершины имеют четную степень";
                        ConnectPoints.Clear();
                        return;
                    }
                }

                //Вызов Эйлерова цикла
                EilerCycle(listpoints.Values.First());

                txtAttention.Text += "Граф содержит Эйлеров цикл: ";
                while (ELcycle.Count != 0)
                {
                    int it = ELcycle.Pop();
                    if (ELcycle.Count != 0)
                        txtAttention.Text += (it + 1) + "⇒";
                    else
                        txtAttention.Text += (it + 1);
                }
            }
        }

        //Эйлеров цикл
        private void EilerCycle(int start)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(start);
            while (stack.Count() != 0)
            {
                int index = stack.Peek();
                //Проверяем, можно ли удлинить путь
                if (Trail[index].Count() != 0)
                {
                    int vertex = Trail[index].First();
                    stack.Push(vertex);
                    Trail[index].Remove(vertex);
                    Trail[vertex].Remove(index);
                }
                //Помещаем отработавшую вершину в результирующий стек
                else
                {
                    ELcycle.Push(stack.Pop());
                }
            }
        }
    }
}