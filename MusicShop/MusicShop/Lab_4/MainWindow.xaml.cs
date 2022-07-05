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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Lab_4
{
    
    public partial class MainWindow : Window
    {
        string connectionString = null;
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        public MainWindow()
        {
           
           // backGround.Source = BitmapFrame.Create(@"D:\Учеба\прога\1 курс\курсач\пикчи\фон.png");
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //OpenDB();
        }
        private void GetAndShowData(string SQLQuery, DataGrid dataGrid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            command = new SqlCommand(SQLQuery, connection);
            adapter = new SqlDataAdapter(command);
            DataTable Table = new DataTable();
            adapter.Fill(Table);
            dataGrid.ItemsSource = Table.DefaultView;

            connection.Close();
        }
        
        /*private void OpenDB()
        {
            GetGroupsData();
            MusiciansData();
            RecordsData();
            TracksData();
        }

        private void GetGroupsData()
        {
            string sqlQ = "SELECT Id_Group as [№], " +
                "Type as [Тип гурту], " +
                "Genre as [Жанр], " +
                "Group_Name as [Назва гурту] " +
                "FROM Groups";

            try
            {
                GetAndShowData(sqlQ, GroupsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void MusiciansData()
        {
            string sqlQ = "SELECT Id_Musician as [№], " +
                "Surname as [Прізвище], " +
                "Name as [Ім'я], " +
                "Id_Group as [№ Гурту], " +
                "Proffesion as [Професія] " +
                "FROM Musicians";

            try
            {
                GetAndShowData(sqlQ, MusiciansDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void RecordsData()
        {
            string sqlQ = "SELECT Id_Record as [№], " +
                "Id_Group as [Номер групи], " +
                "RecordName as [Назва платівки], " +
                "CompanyName as [Назва компанії звукозапису], " +
                "Id_Buy as [Назва магазину, де придбати товар], " +
                "WholesalePrice as [Оптова ціна], " +
                "RetailPrice as [Роздрібна ціна], " +
                "Date as [Дата випуску], " +
                "LastYear as [Продано за минулий рік], " +
                "ThisYear as [Продано за цей рік], " +
                "RecordsLeft as [Залишилось на складі] " +
                "FROM Records";

            try
            {
                GetAndShowData(sqlQ, RecordsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void TracksData()
        {
            string sqlQ = "SELECT Id_Track as [№], " +
                "Id_Record as [Номер платівки], " +
                "TrackName as [Назва треку], " +
                "Id_Group as [№ Гурту], " +
                "Circumstance as [Обставини виконання] " +
                "FROM Tracks";

            try
            {
                GetAndShowData(sqlQ, TracksDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        */

        private void GroupsButton_Click(object sender, RoutedEventArgs e)
        {
            Groups  gr = new Groups();
            Hide();
            gr.Show();
        }

        private void Musicians_Click(object sender, RoutedEventArgs e)
        {
            Musicians ms = new Musicians();
            Hide();
            ms.Show();
        }

        private void RecordsButton_Click(object sender, RoutedEventArgs e)
        {
            Records rd = new Records(); 
            Hide();
            rd.Show();
        }

        private void TracksAdd_Click(object sender, RoutedEventArgs e)
        {
            Tracks tr = new Tracks();
            Hide();
            tr.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void RedactMusicians_Click(object sender, RoutedEventArgs e)
        {
            RedactMusicians ms = new RedactMusicians();
            Hide();
            ms.Show();
        }

        private void TracksRed_Click(object sender, RoutedEventArgs e)
        {
            TracksRed tr = new TracksRed();
            Hide();
            tr.Show();
        }
    }
}
