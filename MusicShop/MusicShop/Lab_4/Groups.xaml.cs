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
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : Window
    {
        string connectionString = "Data Source=DBOND;Initial Catalog=Music_Shop_DB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string[] typeArr;
        string[] genreArr;


        public Groups()
        {
            InitializeComponent();
            typeArr = GetComboData("Type_Name", "TypeOfGroup" );
            genreArr = GetComboData("GenreName", "GenreOfGroup");
            TypeOfGroup.ItemsSource = typeArr;
            GenreOfGroup.ItemsSource = genreArr;    


            GetGroupsData();
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
        private void ExitToMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
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

        private void GetGroupsData()
        {
            string sqlQ = "SELECT Groups.Id_Group as [№], " +
                "TypeOfGroup.Type_Name as [Тип гурту], " +
                "GenreOfGroup.GenreName as [Жанр], " +
                "Groups.Group_Name as [Назва гурту] " +
                "FROM Groups " +
                "INNER JOIN dbo.TypeOfGroup ON dbo.TypeOfGroup.Id_Type = dbo.Groups.Type " +
                "INNER Join dbo.GenreOfGroup ON dbo.GenreOfGroup.Id_Genre = dbo.Groups.Genre ";

            try
            {
                GetAndShowData(sqlQ, GroupsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddGroup()
        {
            int ID = Int32.Parse(IdGroupCh.Text);
            int type = TypeOfGroup.SelectedIndex+1;
            int genre = GenreOfGroup.SelectedIndex+1;
            //int type = Int32.Parse(GroupTypeCh.Text);
            //int genre = Int32.Parse(GroupJCh.Text);
            string name = GroupNameCh.Text;
            if ((type != null) && (genre != null) && (name !="") && (ID != null))
            {
                string sqlQ = $"INSERT INTO Groups (Id_Group, Type, Genre, Group_Name) VALUES('{ID}', '{type}', '{genre}', '{name}')";
                try
                {
                    GetAndShowData(sqlQ, GroupsDG);
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddGroup();
            GetGroupsData();
        }

        private void DeleteGroup()
        {
            string name = GroupNameDel.Text;
            if(name != null)
            {
                string sqlQ = $"DELETE FROM Groups WHERE Group_Name = '{name}'";
                try
                {
                    GetAndShowData(sqlQ, GroupsDG);
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
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteGroup();
            GetGroupsData();
        }
    }
}
