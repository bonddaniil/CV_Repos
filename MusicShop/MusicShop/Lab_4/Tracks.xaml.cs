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
    /// <summary>
    /// Логика взаимодействия для Tracks.xaml
    /// </summary>
    public partial class Tracks : Window
    {
        string connectionString = "Data Source=DBOND;Initial Catalog=Music_Shop_DB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable logsTop;
        DataTable Table;

        string[] groups;
        string id;

        public Tracks()
        {
            InitializeComponent();
            groups = GetComboData("Group_Name", "Groups");
            ChooseGroup.ItemsSource = groups;
            
        }
        private String[] GetComboData(string typeOfData, string tableName)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            String[] Items = { "" };
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter DataLogins = new SqlDataAdapter($"SELECT {typeOfData} FROM {tableName}", connection);
                DataTable logs = new DataTable("Logins");
                DataLogins.Fill(logs);
                Items = new String[logs.Rows.Count];
                for (int i = 0; i < logs.Rows.Count; i++)
                {
                    Items[i] = logs.Rows[i][0].ToString();
                }
            }
            connection.Close();
            return Items;
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

        private void TracksData()
        {
            SqlDataAdapter DataTop = new SqlDataAdapter($"SELECT Id_Group FROM Groups WHERE Groups.Group_Name = '{groups[ChooseGroup.SelectedIndex]}'", connection);
            logsTop = new DataTable("Logins");
            DataTop.Fill(logsTop);
            id = logsTop.Rows[0][0].ToString();
            string sqlQ = $"SELECT TrackName [Назва треку], RecordName[Назва платівки], Group_Name[Назва гурту] FROM Tracks, Records, Groups WHERE Tracks.Id_Group = '{id}' AND Records.Id_Group = Tracks.Id_Group AND Groups.Id_Group = '{id}'";
            image.Source = BitmapFrame.Create(new Uri(@"D:\Учеба\прога\1 курс\курсач\пикчи\гурти\" + id + ".jpg"));
            try
            {
                GetAndShowData(sqlQ, TracksDg);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /*
        private void AddRecords()
        {
            int IdTrack = Int32.Parse(IdTrackAdd.Text);
            int IdRecord = Int32.Parse(IdRecordAdd.Text);
            string TrackName = TrackNameAdd.Text;
            int IdGroup = Int32.Parse(IdGroupAdd.Text);
            int Circum = Int32.Parse(СircumstanceAdd.Text);
            
            if((IdTrack  != null) && (IdRecord != null) &&(TrackName != null) &&(IdGroup != null) &&(Circum != null))
            {
                string sqlQ = $"INSERT INTO Tracks (Id_Track, Id_Record, TrackName, Id_Group, Circumstance) VALUES('{IdTrack}', '{IdRecord}', '{TrackName}', '{IdGroup}', '{Circum}')";
                try
                {
                    GetAndShowData(sqlQ, TracksDg);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Недостатньо данних");
            }
        }

        private void DeleteTrack()
        {
            string recordName = DeleteTrackName.Text;
            if (recordName != null)
            {
                string sqlQ = $"DELETE FROM Tracks WHERE TrackName = '{recordName}'";
                try
                {
                    GetAndShowData(sqlQ, TracksDg);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
            {
                MessageBox.Show("Недостатньо данних");
            }
        }

        private void TrackAddBt_Click(object sender, RoutedEventArgs e)
        {
            AddRecords();
            TracksData();
        }

        private void DeleteTrackBt_Click(object sender, RoutedEventArgs e)
        {
            DeleteTrack();
            TracksData();
        }
       */
        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            TracksData();
        }
    }
}
