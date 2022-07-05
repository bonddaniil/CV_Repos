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
    /// Логика взаимодействия для Records.xaml
    /// </summary>
    public partial class Records : Window
    {
        string connectionString = "Data Source=DBOND;Initial Catalog=Music_Shop_DB;Integrated Security=True";
        SqlConnection connection = null;
        SqlCommand command;
        SqlDataAdapter adapter;
        string[] idBuy;
        public Records()
        {
            InitializeComponent();
            idBuy = GetComboData("Shop_Name", "BuyRecord");
            ShopBuy.ItemsSource = idBuy;
            FindBest();
            RecordsData();
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
        private void ExitButton_Click(object sender, RoutedEventArgs e)
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
        private void FindBest()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            string[] thisYear;
            string id;
            string thisyearNew;
            int thisyearMax = 0;
            if (connection.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter DataLogins = new SqlDataAdapter($"SELECT ThisYear FROM Records", connection);
                DataTable logs = new DataTable("Logins");
                DataLogins.Fill(logs);
                thisYear = new string[logs.Rows.Count];

                for (int i = 0; i < logs.Rows.Count; i++)
                {
                    thisyearNew = logs.Rows[i][0].ToString();
                    if (Convert.ToInt32(thisyearNew) >= thisyearMax)
                    {
                        thisyearMax= Convert.ToInt32(thisyearNew);
                    }
                }

                ///////////////////////
                SqlDataAdapter DataTop = new SqlDataAdapter($"SELECT Id_Record FROM Records WHERE ThisYear = {thisyearMax}", connection);
                DataTable logsTop = new DataTable("Logins");
                DataTop.Fill(logsTop);
                id = logsTop.Rows[0][0].ToString();
                Image.Source = BitmapFrame.Create(new Uri(@"D:\Учеба\прога\1 курс\курсач\пикчи\платівки\"+id+".jpg"));
            }

            connection.Close();
        }
        private void RecordsData()
        {
            string sqlQ = "SELECT dbo.Records.Id_Record as [№]," +
                "dbo.Groups.Group_Name as [Назва гурту], " +
                "dbo.Records.RecordName as [Назва платівки], " +
                "dbo.Records.CompanyName as [Назва компанії звукозапису], " +
                "dbo.BuyRecord.Shop_Name as [Назва магазину де придбати платівку], " +
                "dbo.Records.WholesalePrice as [Оптова ціна], " +
                "dbo.Records.RetailPrice as [Роздрібна ціна], " +
                "dbo.Records.Date as [Дата], " +
                "dbo.Records.LastYear as [Продано минулого року], " +
                "dbo.Records.ThisYear as [Продано цього року], " +
                "dbo.Records.RecordsLeft as [Залишилось на складі] " +
                "FROM   dbo.Records " +
                "INNER JOIN dbo.BuyRecord ON dbo.BuyRecord.Id_Shop = dbo.Records.Id_Buy " +
                "INNER JOIN dbo.Groups ON dbo.Groups.Id_Group = dbo.Records.Id_Group ";

            try
            {
                GetAndShowData(sqlQ, RecordsDG);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void AddRecords()
        {
            int ID = Int32.Parse(IDAdd.Text);
            int IdGroup = Int32.Parse(AddIdGroup.Text);
            string RecordName = RecordNameAdd.Text;
            string CompanyName = CompanyNameAdd.Text;
            int IdBuy = ShopBuy.SelectedIndex + 1;
            //int IdBuy = Int32.Parse(IdBuyAdd.Text);
            int Wholesale = Int32.Parse(WholesaleAdd.Text); 
            int Retail = Int32.Parse(RetailAdd.Text);
            string Date = DateAdd.Text;
            int LastYear = Int32.Parse(LastAdd.Text);
            int ThisYear = Int32.Parse(ThisAdd.Text);
            int RecordsLeft = Int32.Parse(LeftAdd.Text);

            if ((ID != null) && (IdGroup != null) && (RecordName != null) && (CompanyName != null) && (IdBuy != null) && (Wholesale != null) && 
                (Retail != null) && (Date != null) && (LastYear != null) && (ThisYear != null) && (RecordsLeft != null))
            {
                string sqlQ = $"INSERT INTO Records (Id_Record, Id_Group, RecordName, CompanyName, Id_Buy, WholesalePrice, RetailPrice," +
                    $"Date, LastYear, ThisYear, RecordsLeft) VALUES('{ID}', '{IdGroup}', '{RecordName}', '{CompanyName}', '{IdBuy}', '{Wholesale}', " +
                    $"'{Retail}', '{Date}', '{LastYear}', '{ThisYear}', '{RecordsLeft}')";
                try
                {
                    GetAndShowData(sqlQ, RecordsDG);
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddRecords();
            RecordsData();

        }
        private void DeleteRecord()
        {
            string recordName = DeleteName.Text;
            if (recordName != null)
            {
                string sqlQ = $"DELETE FROM Records WHERE RecordName = '{recordName}'";
                try
                {
                    GetAndShowData(sqlQ, RecordsDG);
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

        

        private void DeleteRecordButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteRecord();
            RecordsData();
        }
    }
}
