using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Linq;




namespace Lab_2_First_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List<Ellipse>();
        static PointCollection pC = new PointCollection();
        List<int> points = new List<int>();
        static int[,] matrix; 
        static int counter = 0;

        static int PopulationSize = 20;
        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();

            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75 * MainWin.Width) - 3 * Radius);
                p.Y = rnd.Next(Radius, (int)(0.90 * MainWin.Height - 3 * Radius));
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            {
                if (i == 0)
                {
                    Ellipse elFirst = new Ellipse();

                    elFirst.StrokeThickness = 2;
                    elFirst.Height = elFirst.Width = Radius;
                    elFirst.Stroke = Brushes.Black;
                    elFirst.Fill = Brushes.Red;
                    EllipseArray.Add(elFirst);
                }
                else
                {
                    Ellipse el = new Ellipse();

                    el.StrokeThickness = 2;
                    el.Height = el.Width = Radius;
                    el.Stroke = Brushes.Black;
                    el.Fill = Brushes.LightBlue;
                    EllipseArray.Add(el);
                }
            }
        }

        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
        }

        private void PlotPoints()
        {
            for (int i = 0; i < PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius / 2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius / 2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }


        private void PlotWay(int[] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);
            
            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            dT.Interval = new TimeSpan(0, 0, 0, 0, Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {
                NumElemCB.IsEnabled = false;
                dT.Start();
                GenFirstPop(); // ініцілізація популяції за отриманими даними з вікна (за кількістю точок-вершин)
            }
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
        }

        private void OneStep(object sender, EventArgs e)
        {
            Crossing(); // схрещування
            Mutation(); // мутація           
            Sorting();  // сортування, а також відбір

            if (counter % 10 == 0)
            {
                MyCanvas.Children.Clear();
                //InitPoints();
                PlotPoints();
                PlotWay(GetBestWay());
                Label.Content = counter.ToString();
            }
            counter++;
        }

        static double FindDistance(Point a, Point b)
        {
            double distance = 0;
            distance = (Math.Abs(b.X) - Math.Abs(a.X)) * (Math.Abs(b.X) - Math.Abs(a.X)) + (Math.Abs(b.Y) - Math.Abs(a.Y)) * (Math.Abs(b.Y) - Math.Abs(a.Y));
            distance = Math.Sqrt(distance);
            return distance;
        }

        private int[] GetBestWay()
        {            
            int[] way = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
                way[i] = matrix[0, i];

            Length.Content = CountLengthOfRow(0);
            return way;
        }

        static void GenFirstPop()
        {
            Random rnd = new Random();

            matrix = new int[2*PopulationSize, PointCount];

            for (int i = 0; i < PopulationSize; i++)
                for (int j = 0; j < PointCount; j++)
                    matrix[i, j] = j;

            for (int i = 0; i < PopulationSize; i++)
                for (int j = 0; j < PointCount; j++)
                {
                    int j1 = rnd.Next(PointCount);
                    int j2 = rnd.Next(PointCount);

                    int tmp = matrix[i, j1];
                    matrix[i, j1] = matrix[i, j2];
                    matrix[i, j2] = tmp;
                }
        }

        static double CountLengthOfRow(int numOfRow)
        {
            double ret = 0;
            int[] row = new int[PointCount];
            Point a;
            Point b;

            for (int i = 0; i < row.Length; i++)
                row[i] = matrix[numOfRow, i];
            
            double sum = 0;
            for (int i = 0; i < row.Length; i++)
            {
                if (i == row.Length - 1)
                {
                    a = pC[0];
                    b = pC[row.Length - 1];
                }
                else
                {
                    a = pC[row[i]];
                    b = pC[row[i + 1]];
                }
                sum += FindDistance(a, b);
            }
            ret = sum;

            return ret;
        }

        static void Swap(int row)
        {
            int tmp;
            for (int j = 0; j < PointCount; j++)
            {
                tmp = matrix[row, j];
                matrix[row, j] = matrix[row + 1, j];
                matrix[row + 1, j] = tmp;
            }
        }

        static void Sorting()
        {
            double length1, length2;
            for (int i = 0; i < 2*PopulationSize - 1; i++)
            {
                for (int j = 0; j < 2*PopulationSize - i - 1; j++)
                {
                    length1 = CountLengthOfRow(j);
                    length2 = CountLengthOfRow(j+1);
                    if (length1 > length2)
                        Swap(j);
                }
            }

        }
        static void Crossing()
        {
            Random rnd = new Random();
            int i1, i2, CrossPosition;
            for (int i = PopulationSize; i < 2*PopulationSize; i++)
            {
                i1 = rnd.Next(PopulationSize);
                i2 = rnd.Next(PopulationSize);
                CrossPosition = rnd.Next(PointCount);
                FindChild(i1, i2, CrossPosition, i);
            }            
        }

        static void FindChild(int i1, int i2, int crosspos, int col)
        {
            Random rnd = new Random(); 

            List<int> tmp1 = new List<int>();
            List<int> tmp2 = new List<int>();
            tmp1.Clear(); tmp2.Clear();

            for (int i = 0; i < crosspos; i++)
                tmp1.Add(matrix[i1, i]);
            for (int i = crosspos; i < PointCount; i++)
                tmp1.Add(matrix[i2, i]);
            //
            for (int i = 0; i < crosspos; i++)
                tmp2.Add(matrix[i2, i]);
            for (int i = crosspos; i < PointCount; i++)
                tmp2.Add(matrix[i1, i]);

            if (rnd.Next(100) % 2 == 0)
                tmp1 = tmp1.Concat(tmp2).Distinct().ToList();            
            else
                tmp1 = tmp2.Concat(tmp1).Distinct().ToList();

            for (int i = 0; i < PointCount; i++)
                matrix[col, i] = tmp1[i];

        }
        static void Mutation()
        {
            Random rnd = new Random();
            for (int i = PopulationSize; i < 2 * PopulationSize; i++)
            {
                if (rnd.NextDouble() > 0.7)
                {
                    int j1 = rnd.Next(PointCount);
                    int j2 = rnd.Next(PointCount);
                    int tmp;
                    if (j1 > j2)
                    {
                        tmp = j1;
                        j1 = j2;
                        j2 = tmp;
                    }
                    for (int j = 0; j <= (j2-j1) / 2; j++)
                    {
                        tmp = matrix[i, j1 + j];
                        matrix[i, j1 + j] = matrix[i, j2 - j];
                        matrix[i, j2 - j] = tmp;
                    }
                }
            }
        }


        /*private int[] GetBestWay()
        {

            int[] way = new int[PointCount];
            for (int i = 0; i < way.Length; i++)
            {
                way[i] = 0;
            }

            //List <int> points = new List<int>();
            for (int i = 1; i < PointCount; i++)
            {
                points.Add(i);
            }
            for (int i = 0; i < way.Length; i++)
            {
                if (i == PointCount - 1) break;
                way[i + 1] = FindMin(points, way[i]);
               
            }
            return way;
        }*/
        /*private int FindMin(List<int> points, int check)
        {
            double distance = 0;
            double min = 9999;
            Point a = pC[check];
            Point b;
            int chis = 0;
            foreach (var item in points)
            {
                b = pC[item];
                if (a != b)
                {
                    distance = FindDistance(a, b);
                    if (distance < min)
                    {
                        min = distance;
                        chis = item;
                    }
                }
            }
            /*for (int i = 0; i < points.Count; i++)
            {
                if(chis == points[i])
                {
                    points.RemoveAt(i);
                    break;
                }
            }
            points.Remove(chis);
            return chis;
        }*/
        /*private int[] GetBestWay()
        {
            int[] way = new int[PointCount];
            for (int i = 0; i < PointCount; i++)
            {
                way[i] = i;
            }
            double min = 99999;
            double distance = 0;    
            double[] distanceArr = new double[PointCount];
            int index = 0;

            for (int i = 0; i < PointCount; i++)
            {
                for (int j = i+1; j < PointCount; j++)
                {
                    distance = FindDistance(pC[i], pC[j]);
                    if(distance < min)
                    {
                        min = distance;

                        index = j;
                    }
                }
                if (i == PointCount - 1) break;
                way = Swap(i+1, index, way);
                min = 999999;
            }
            return way;
        }*/
        /*private int[] Swap(int a, int b, int[] arr)
        {
            int tmp = arr[a];
            arr[a] = arr[b];
            arr[b] = tmp;   
            return arr;
        }*/
        /*private int[] GetBestWay()
        {
            Random rnd = new Random();
            int[] way = new int[PointCount];

            for (int i = 0; i < PointCount; i++)
                way[i] = i;

            for (int s = 0; s < 2 * PointCount; s++)
            {
                int i1, i2, tmp;

                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
            }

            return way;
        }*/
    }
}