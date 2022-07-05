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
    /// Логика взаимодействия для Musicians.xaml
    /// </summary>
    public partial class Musicians : Window
    {

        string connectionString = "Data Source=DBOND;Initial Catalog=Music_Shop_DB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable logsTop;
        DataTable Table;
        string[] groups;
        string id;
        int index, LenTable;
        public Musicians()
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
            Table = new DataTable();
            adapter.Fill(Table);
            LenTable = Table.Rows.Count;
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
            SqlDataAdapter DataTop = new SqlDataAdapter($"SELECT Id_Group FROM Groups WHERE Groups.Group_Name = '{groups[ChooseGroup.SelectedIndex]}'", connection);
            logsTop = new DataTable("Logins");
            DataTop.Fill(logsTop);
            id = logsTop.Rows[0][0].ToString();
            index = -1;
            string sqlQ = $"SELECT Id_Record [№],  RecordName [Назва платівки],Group_Name[Назва гурту] FROM Records, Groups WHERE Groups.Id_Group = {Convert.ToInt32(id)} AND Records.Id_Group = Groups.Id_Group";
            try
            {
                GetAndShowData(sqlQ, MusiciansDg);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            MusiciansData();
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (index > 0)
            {
                index--;
                id = Table.Rows[index][0].ToString();
                image.Source = BitmapFrame.Create(new Uri(@"D:\Учеба\прога\1 курс\курсач\пикчи\платівки\" + id + ".jpg"));
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (index < LenTable - 1)
            {
                index++;
                id = Table.Rows[index][0].ToString();
                image.Source = BitmapFrame.Create(new Uri(@"D:\Учеба\прога\1 курс\курсач\пикчи\платівки\"+id+".jpg"));
            }
        }

        /* private void AddMusicians()
         {
             int ID = Int32.Parse(IdAdd.Text);
             string surname = SurnameAdd.Text;
             string name = NameAdd.Text;
             int IdGroup = Int32.Parse(IdGroupAdd.Text);
             string proffesion = ProffesionAdd.Text;

             if ((surname != null) && (name != null) && (proffesion != "") && (ID != null) && (IdGroup != null))
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
         }*/
    }
}
