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
    /// Логика взаимодействия для TracksRed.xaml
    /// </summary>
    public partial class TracksRed : Window
    {
        string connectionString = "Data Source=DBOND;Initial Catalog=Music_Shop_DB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable logsTop;
        string[] groups, circums, records;
        public TracksRed()
        {
            InitializeComponent();
            groups = GetComboData("Group_Name", "Groups");
            circums = GetComboData("NameCircumstance", "TrackCircumstance");
            records = GetComboData("RecordName", "Records");
            ChooseGroup.ItemsSource = groups;
            CircumsChoose.ItemsSource = circums;
            RecordsChoose.ItemsSource = records;
            TracksData();
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
            string sqlQ = "SELECT dbo.Tracks.Id_Track as [№], " +
                "dbo.Records.RecordName as [Назва платівки], " +
                "dbo.Tracks.TrackName as [Назва пісні], " +
                "dbo.Groups.Group_Name as [Назва гурту], " +
                "dbo.TrackCircumstance.NameCircumstance as [Обставини виконання] " +
                "FROM Tracks " +
                "INNER JOIN dbo.Records ON dbo.Records.Id_Record = dbo.Tracks.Id_Record " +
                "INNER JOIN dbo.Groups ON dbo.Groups.Id_Group = dbo.Tracks.Id_Group " +
                "INNER JOIN dbo.TrackCircumstance ON dbo.TrackCircumstance.Id_Circumstance = dbo.Tracks.Circumstance ";

            try
            {
                GetAndShowData(sqlQ, TracksDg);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddRecords()
        {
            int IdTrack = Int32.Parse(IdTrackAdd.Text);
            
            string TrackName = TrackNameAdd.Text;
            
            int Circum = CircumsChoose.SelectedIndex+1;

            SqlDataAdapter DataTop = new SqlDataAdapter($"SELECT Id_Group FROM Groups WHERE Groups.Group_Name = '{groups[ChooseGroup.SelectedIndex]}'", connection);
            logsTop = new DataTable("Logins");
            DataTop.Fill(logsTop);
            string IdGroup = logsTop.Rows[0][0].ToString();

            DataTop = new SqlDataAdapter($"SELECT Id_Record FROM Records WHERE Records.RecordName = '{records[RecordsChoose.SelectedIndex]}'", connection);
            logsTop = new DataTable("Logins");
            DataTop.Fill(logsTop);
            string IdRecord = logsTop.Rows[0][0].ToString();

            if ((IdTrack != null) && (IdRecord != null) && (TrackName != null) && (IdGroup != null) && (Circum != null))
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

        private void ExitBt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
