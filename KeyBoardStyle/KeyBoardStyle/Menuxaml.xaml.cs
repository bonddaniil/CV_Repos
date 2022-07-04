using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KeyBoardStyle
{
    /// <summary>
    /// Логика взаимодействия для Menuxaml.xaml
    /// </summary>
    public partial class Menuxaml : Window
    {
        public Menuxaml()
        {
            InitializeComponent();
        }

        private void Вихід_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ToStudy_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void CheckMode_Click(object sender, RoutedEventArgs e)
        {
            Perevirka per = new Perevirka();
            Hide();
            per.Show();
        }
    }
}
