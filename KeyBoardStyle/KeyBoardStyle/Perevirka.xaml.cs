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
    /// Логика взаимодействия для Perevirka.xaml
    /// </summary>
    public partial class Perevirka : Window
    {
        Stopwatch stopWatch;
        TimeSpan ts;
        double t0, t1;
        int count = 0;
        int i = 0;
        const double student = 2.26;
        public Perevirka()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
            stopWatch.Start();
            t0 = 0;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Menuxaml m;
            m = new Menuxaml();
            Hide();
            m.Show();
        }
        private void Tb_KeyDown(object sender, KeyEventArgs e)
        {
            int n = 0;
            if (Cmb.SelectedIndex == 0)
            {
                n = 3;
            }
            if (Cmb.SelectedIndex == 1)
            {
                n = 5;
            }
            string text;
            text = Tb.Text;
            InputText.Content = text;
            NumberOfSymbols.Content = text.Length + 1;
            ts = stopWatch.Elapsed;
            StreamWriter sw = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!mPerevirka.txt", true);
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
                        StreamWriter del = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!mPerevirka.txt", false);
                        del.Write("");
                        del.Close();
                    }
                    else
                    {
                        sw.Close();
                        StreamReader copy = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\!mPerevirka.txt");
                        string copiedString = copy.ReadLine();

                        StreamWriter saveCopy = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!mRightPerevirka.txt", true);
                        saveCopy.Write(copiedString + ".");
                        saveCopy.Close();
                        //MSpodivannya();
                        copy.Close();
                        StreamWriter del = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!mPerevirka.txt", false);
                        del.Write("");
                        del.Close();

                    }
                }
                if (n == i)
                {
                    Tb.IsEnabled = false;
                    CountStatistics();
                    CountFisher();
                    FinalDispersion();
                    SudentAndP();
                    /*CountStudent();
                    CountFinalStatistics();*/
                }
                Tb.Text = "";
                count = 0;
            }
            
            sw.Close();
        }
        private void CountStatistics()
        {
            StreamReader sr = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\!mRightPerevirka.txt");

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
                m = Math.Round((m / (numbers.Length - 1)), 8);
                mArr[counter] = m;
                counter++;
                StreamWriter sp = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!spodivannyaPerevirka.txt", true);
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
                m2 = Math.Round((m2 / (numbers.Length - 1)), 8);
                m2Arr[counter] = m2;
                m2 = 0;
                counter++;
            }
            for (int i = 0; i < lines.Length - 1; i++)
            {
                StreamWriter sw = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!dispersiyaPerevirka.txt", true);
                sw.Write(m2Arr[i] - (mArr[i] * mArr[i]) + " ");
                sw.Close();
            }
        }
        private void CountFisher()
        {
            double fisher = 0;
            if (alpha.SelectedIndex == 0)
            {
                fisher = 4.85;
            }
            else
            {
                fisher = 2.97;
            }
            int n = 0;
            if (Cmb.SelectedIndex == 0)
            {
                n = 3;
            }
            if (Cmb.SelectedIndex == 1)
            {
                n = 5;
            }

            StreamReader sEt = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\dispersiyaFinal.txt");
            string dispEt = sEt.ReadLine();
            sEt.Close();

            StreamReader sPer = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\!dispersiyaPerevirka.txt");
            string dispPerev = sPer.ReadLine();
            sPer.Close();

            string[] dispEtArr = dispEt.Split(' ');
            string[] dispPerevArr = dispPerev.Split(' ');

            int counterWrong = 0, counterNorm =0;

            
            double sMax = 0, sMin = 0;
            for (int i = 0; i < dispEtArr.Length-1; i++)
            {
                sMax = Math.Max(double.Parse(dispEtArr[i]), double.Parse(dispPerevArr[i]));
                sMin = Math.Min(double.Parse(dispEtArr[i]), double.Parse(dispPerevArr[i]));
                if ((sMax / sMin) > fisher)
                {
                    counterWrong++;
                }
                else counterNorm++;
                
                sMax = 0;
                sMin = 0;
            }
            if (counterWrong > 0)
            {
                MessageBox.Show("Дисперсія неоднорідна");
                TypeOfDispersion.Content = "неоднорідні";
            }
            else
            {
                TypeOfDispersion.Content = "однорідні";
            }
            double p1 = 0, p2 = 0;
            if (counterNorm != 0 && counterWrong != 0)
            {
                p1 = (double)counterWrong / (double)n;
                p2 = (double)counterNorm / (double)n;
            }
            else if (counterNorm == 0) p2 = 0;
            else if(counterWrong == 0) p1 = 0;

            if (p1 > 1) p1 = 1;
            if (p2 > 1) p2 = 1;
            FirstType.Content = p1;
            Secondtype.Content = p2;
        }
        private void FinalDispersion()
        {
            StreamReader sEt = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\dispersiyaFinal.txt");
            string dispEt = sEt.ReadLine();
            sEt.Close();

            StreamReader sPer = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\!dispersiyaPerevirka.txt");
            string dispPerev = sPer.ReadLine();
            sPer.Close();

            string[] dispEtArr = dispEt.Split(' ');
            string[] dispPerevArr = dispPerev.Split(' ');
            double s = 0, a =0, b =0;
            for (int i = 0; i < dispEtArr.Length - 1; i++)
            {
                a = double.Parse(dispEtArr[i]) + double.Parse(dispPerevArr[i]);
                b = (a*(Tb.Text.Length - 1)) / (Tb.Text.Length + Tb.Text.Length - 1);
                s = Math.Sqrt(b);
                StreamWriter sF = new StreamWriter(@"D:\Учеба\прога\1 курс\2 семестр\!dispersiaPerevirkaFinal.txt", true);
                sF.Write(s+" ");
                sF.Close();
                a = 0;
                b = 0;
                s = 0;
            }

        }
        private void SudentAndP()
        {
            double student = 0;
            if (alpha.SelectedIndex == 0)
            {
                student = 2.26;
            }
            else
            {
                student = 1.83;
            }
            StreamReader mEt = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\spodivannyaFinal.txt");
            string spEt = mEt.ReadLine();
            mEt.Close();

            StreamReader mPer = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\!spodivannyaPerevirka.txt");
            string spPerev = mPer.ReadLine();
            mPer.Close();

            StreamReader s = new StreamReader(@"D:\Учеба\прога\1 курс\2 семестр\!dispersiaPerevirkaFinal.txt");
            string sFinal = s.ReadLine();
            s.Close();

            string[] mEtArr = spEt.Split(' ');
            string[] mPerevArr = spPerev.Split(' ');
            string[] sF = sFinal.Split(' ');

            int counter = 0;
            double a = 0, b = 0;
            for (int i = 0; i < mEtArr.Length-1; i++)
            {
                a = Math.Abs(double.Parse(mEtArr[i])- double.Parse(mPerevArr[i]));
                b = double.Parse(sF[i])*(double)(Math.Sqrt(2/ (double)(Tb.Text.Length-1)));
                if (a / b < student) counter++;
                a = 0;
                b = 0;
            }
            int n = 0;
            if (Cmb.SelectedIndex == 0)
            {
                n = 3;
            }
            if (Cmb.SelectedIndex == 1)
            {
                n = 5;
            }
            double p = (double)counter / (double)n;
            P.Content = p;
        }
    }
}
