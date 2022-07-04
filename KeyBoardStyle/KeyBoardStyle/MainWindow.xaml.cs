using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;


namespace KeyBoardStyle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Stopwatch stopWatch;
        TimeSpan ts;
        double t0, t1;
        int count = 0;
        int i = 0;
        const double student = 2.26;
        public MainWindow()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
            stopWatch.Start();
            t0 = 0;
        }

        
        private void Tb_KeyDown(object sender, KeyEventArgs e)
        {
            int n = 0;
            if (Cmb.SelectedIndex == 0)
            {
                n = 3;
            }
            if(Cmb.SelectedIndex == 1)
            {
                n = 5;
            }
            string text;
            text = Tb.Text;
            InputText.Content = text;
            NumberOfSymbols.Content = text.Length + 1;
            ts = stopWatch.Elapsed;
            StreamWriter sw = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\m.txt", true);
            if (count > 0)
            {
                t1 = ts.TotalSeconds;
                sw.Write(Math.Round(t1 - t0, 2) + " ");
                t0 = t1;
            }
            else
                t0 = ts.TotalSeconds;
            count++;
            if (count == 10)
            {
                if (i < n)
                {
                    i++;
                    if (Tb.Text != "sunstrike")
                    {
                        i--;
                        NumberOfSymbols.Content = "wrong";
                        //sw.Write("Wrong");
                        sw.Close();
                        StreamWriter del = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\m.txt", false);
                        del.Write("");
                        del.Close();
                    }
                    else
                    {
                        sw.Close();
                        StreamReader copy = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\m.txt");
                        string copiedString = copy.ReadLine();
                       
                        StreamWriter saveCopy = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\mRight.txt", true);
                        saveCopy.Write(copiedString + ".");
                        saveCopy.Close();
                        //MSpodivannya();
                        copy.Close();
                        StreamWriter del = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\m.txt", false);
                        del.Write("");
                        del.Close();
                        
                    }
                }
                if(n == i)
                {
                    Tb.IsEnabled = false;
                    CountStatistics();
                    CountStudent();
                    CountFinalStatistics();
                }
                Tb.Text = "";
                count = 0;
            }
            //sw.Close();
            sw.Close();
        }
        private void CountStatistics()
        {
            StreamReader sr = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\mRight.txt");
            
            string[] lines = sr.ReadLine().Split('.');
            double m = 0;
            double[] mArr = new double[lines.Length-1];
            int counter = 0;
            for (int i = 0; i < lines.Length-1; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length-1; j++)
                {
                    m += double.Parse(numbers[j]);
                    
                }
                m = Math.Round((m / (numbers.Length - 1)),8);
                mArr[counter] = m;
                counter++;
                StreamWriter sp = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\spodivannya.txt", true);
                sp.Write(m+" ");
                m = 0;
                sp.Close();
            }
            double m2 = 0;
            counter = 0;
            double[] m2Arr = new double[lines.Length-1];
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    m2 += (double.Parse(numbers[j])* double.Parse(numbers[j]));
                    
                }
                m2 = Math.Round((m2 / (numbers.Length - 1)), 8);
                m2Arr[counter] = m2;
                m2 = 0;
                counter++;
            }
            for (int i = 0; i < lines.Length - 1; i++)
            {
                StreamWriter sw = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\dispersiya.txt", true);
                sw.Write(m2Arr[i] - (mArr[i] * mArr[i])+" ");
                sw.Close();
            }
        }
        private void CountStudent()
        {
            StreamReader sr = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\mRight.txt");
            string[] lines = sr.ReadLine().Split('.');
            sr.Close();
            StreamReader m = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\spodivannya.txt");
            string[] sp = m.ReadLine().Split(' ');
            m.Close();
            StreamReader d = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\dispersiya.txt");
            string[] disp = d.ReadLine().Split(' ');
            d.Close();
            string  linesNew = "";
            double t = 0;
            int counter = 0;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    t = FindT(double.Parse(numbers[j]), double.Parse(sp[counter]), double.Parse(disp[counter]));
                    if (t < student)
                    {
                        linesNew += (numbers[j]+" ");
                    }
                }
                linesNew += ".";
                counter++;
                StreamWriter writeChecked = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\mChecked.txt", true);
                writeChecked.Write(linesNew);
                writeChecked.Close();
                linesNew = "";
            }
        }
        private double FindT(double y, double m, double s)
        {
            double t = 0;
            t = Math.Abs((y-m) / Math.Sqrt(s));
            return t;
        }

        private void ToMenu_Click(object sender, RoutedEventArgs e)
        {
            Menuxaml m;
            m = new Menuxaml();
            Hide();
            m.Show();
        }

        private void CountFinalStatistics()
        {
            StreamReader sr = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\mChecked.txt");

            string[] lines = sr.ReadLine().Split('.');
            double m = 0;
            double[] mArr = new double[lines.Length - 1];
            int counter = 0;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    m += double.Parse(numbers[j]);

                }
                m = Math.Round((m / (numbers.Length - 1)), 2);
                mArr[counter] = m;
                counter++;
                StreamWriter sp = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\spodivannyaFinal.txt", true);
                sp.Write(m + " ");
                m = 0;
                sp.Close();
            }
            double m2 = 0;
            counter = 0;
            double[] m2Arr = new double[lines.Length - 1];
            for (int i = 0; i < lines.Length - 1; i++)
            {
                string[] numbers = lines[i].Split(' ');
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    m2 += (double.Parse(numbers[j]) * double.Parse(numbers[j]));

                }
                m2 = Math.Round((m2 / (numbers.Length - 1)), 2);
                m2Arr[counter] = m2;
                m2 = 0;
                counter++;
            }
            for (int i = 0; i < lines.Length - 1; i++)
            {
                StreamWriter sw = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\dispersiyaFinal.txt", true);
                sw.Write(m2Arr[i] - (mArr[i] * mArr[i]) + " ");
                sw.Close();
            }
        }
        /*private void MSpodivannya()
        {
            StreamReader sr = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\m.txt");
            string[] numbers = sr.ReadLine().Split(' ');
            double m = 0;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                m += double.Parse(numbers[i]);
            }
            m = m / (numbers.Length - 1);
            sr.Close();
            StreamWriter mmm = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\mmm.txt", false);
            mmm.Write(m);
            mmm.Close();
            double m2 = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                m2 += (double.Parse(numbers[i])* double.Parse(numbers[i]));
            }
            double s = m2/ (numbers.Length - 1)-(m*m);
            StreamWriter sss = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\s.txt", false);
            sss.Write(s);
            sss.Close();
        }*/
    }
}
