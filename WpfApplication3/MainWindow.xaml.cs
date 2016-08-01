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
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;

namespace WpfApplication3
{
    
    public partial class MainWindow : Window
    {
        public static double Balans;
        Bankaccount bancaccount = new Bankaccount();
        public Stack<float> Stack = new Stack<float>();

        public MainWindow()
        {
            InitializeComponent();
        }



        public void button_Click(object sender, RoutedEventArgs e)
        {
            int account;
            string String_account = "";
            try
            {
                account = Convert.ToInt32(textBox.Text);
                String_account = textBox.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Введіть № рахунка");
            }

            String Cmd = "SELECT * FROM Bankaccount WHERE Account='" + String_account + "'";
            using (IDbConnection conection = new SqlConnection(Properties.Settings.Default.Connection))
            {
                IDbCommand command = new SqlCommand(Cmd);
                command.Connection = conection;
                conection.Open();

                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bancaccount.Account = reader.GetInt32(1);
                    bancaccount.Password = reader.GetInt32(2);
                    bancaccount.Balans = reader.GetInt32(3);
                    Balans = bancaccount.Balans;
                }
            }
            if (password.Password == Convert.ToString(bancaccount.Password))
            {
                WinMenu WinMenu = new WinMenu();
                Window1 Window = new Window1();
                WinMenu.Show();
            }
            else MessageBox.Show("Неправильно введений пароль");
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
