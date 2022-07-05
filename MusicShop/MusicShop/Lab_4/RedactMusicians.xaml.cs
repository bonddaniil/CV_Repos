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
    /// Логика взаимодействия для RedactMusicians.xaml
    /// </summary>
    public partial class RedactMusicians : Window
    {
        string connectionString = "Data Source=DBOND;Initial Catalog=Music_Shop_DB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable logsTop;
        DataTable Table;
        string[] groups, proffecions;
        public RedactMusicians()
        {
            InitializeComponent();
            groups = GetComboData("Group_Name", "Groups");
            ChooseGroup.ItemsSource = groups;
            proffecions = GetComboData("ProfessionName", "MusiciansProffecions");
            ProffecionChoose.ItemsSource = proffecions;
            MusiciansData();
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
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void MusiciansData()
        {
            string sqlQ = "SELECT dbo.Musicians.Id_Musician as [№], " +
                "dbo.Musicians.Surname as [Прізвище], " +
                "dbo.Musicians.Name as [Ім'я], " +
                "dbo.Groups.Group_Name as [Назва гурту], " +
                "dbo.MusiciansProffecions.ProfessionName as [Професія] " +
                "FROM   dbo.Musicians " +
                "INNER JOIN dbo.Groups ON dbo.Groups.Id_Group = dbo.Musicians.Id_Group " +
                "INNER JOIN dbo.MusiciansProffecions  ON dbo.MusiciansProffecions.Id_Profession = dbo.Musicians.Proffesion ";

            try
            {
                GetAndShowData(sqlQ, MusiciansDg);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddMusicians()
        {
            int ID = Int32.Parse(IdAdd.Text);
            string surname = SurnameAdd.Text;
            string name = NameAdd.Text;
            int proffesion = ProffecionChoose.SelectedIndex+1;
            //string proffesion = ProffesionAdd.Text;

            SqlDataAdapter DataTop = new SqlDataAdapter($"SELECT Id_Group FROM Groups WHERE Groups.Group_Name = '{groups[ChooseGroup.SelectedIndex]}'", connection);
            logsTop = new DataTable("Logins");
            DataTop.Fill(logsTop);
            string IdGroup = logsTop.Rows[0][0].ToString();
            
           

            if ((surname != null) && (name != null) && (proffesion != null) && (ID != null) && (IdGroup != null))
            {
                string sqlQ = $"INSERT INTO Musicians (Id_Musician, Surname, Name, Id_Group, Proffesion) VALUES('{ID}', '{surname}', '{name}', '{IdGroup}', '{proffesion}')";
                try
                {
                    GetAndShowData(sqlQ, MusiciansDg);
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
            MusiciansData();
        }
        private void DeleteMusician()
        {
            string surname = SurnameDelete.Text;
            if (surname != null)
            {
                string sqlQ = $"DELETE FROM Musicians WHERE Surname = '{surname}'";
                try
                {
                    GetAndShowData(sqlQ, MusiciansDg);
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

        private void AddMButt_Click(object sender, RoutedEventArgs e)
        {
            MusiciansData();
            AddMusicians();
        }

        private void DeleteMusicianButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteMusician();
            MusiciansData();
        }
    }
}
