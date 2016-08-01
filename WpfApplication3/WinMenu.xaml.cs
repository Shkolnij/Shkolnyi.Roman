using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApplication3
{
    

    public partial class WinMenu : Window
    {
        public static string s;
        MainWindow MainWindow = new MainWindow();
        List<Money> Money = new List<Money>();
        double  Balans;
        public static double Balanse;
        public WinMenu()
        {
            InitializeComponent();
            ReadData();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (UAN.IsChecked == true || EUR.IsChecked == true|| USD.IsChecked == true)
            {
                if (UAN.IsChecked == true)
                {
                    s = "UAN";
                }
                else if (EUR.IsChecked == true)
                {
                    s = "EUR";
                }
                else if (USD.IsChecked == true)
                {
                    s = "USD";
                }
                Balanse = translation(MainWindow.Balans);
                WindowsOpen();
            }
            else MessageBox.Show("Виберіть валюту");
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("На вашому рахунку " + Convert.ToString(translation(MainWindow.Balans)));
        }
        private double pass(string Currency)
        {
            foreach (var money in Money)
            {
                if (money.Currency == Currency)
                {
                    return money.Exchange;
                }
            }
            return 0;
        }
        private double translation(double Balans)
        {
            if (UAN.IsChecked == true)
            {
                return Balans;
            }
            else if (EUR.IsChecked == true)
            {
                return Balans = Balans / pass("EUR");
            }
            else if (USD.IsChecked == true)
            {
                return Balans = Balans / pass("USD");
            }
            else
            {
                MessageBox.Show("Виберіть валюту");
                return Balans;
            }
        }
        private void ReadData()
        {
            String Cmd = "SELECT Currency, Exchange  FROM Money";
            using (IDbConnection conection = new SqlConnection(Properties.Settings.Default.Connection))
            {
                IDbCommand command = new SqlCommand(Cmd);
                command.Connection = conection;
                conection.Open();

                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Money money = new Money();
                    money.Currency = reader.GetString(0);
                    money.Exchange = reader.GetDouble(1); 
                    Money.Add(money);
                }
            }
        }
        private void WindowsOpen()
        {
            Window1 Window = new Window1();
            Window.Show();
        }
        private void UAN_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
