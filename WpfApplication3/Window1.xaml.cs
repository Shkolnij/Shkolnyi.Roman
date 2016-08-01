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
    
    public partial class Window1 : Window
    {
        int g = 0;
        public int sum, money;
        string[] s = new string[7];
        Infmoney Infmoney = new Infmoney();
        List<Infmoney> Money = new List<Infmoney>();
        List<Infmoney> IssuedMoney = new List<Infmoney>();
        List<Infmoney> temp = new List<Infmoney>();
        public Window1()
        {
            InitializeComponent();
            WinMenu WinMenu = new WinMenu();
            //MainWindow.Show();
            //this.Close();  
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (g == 0)
            {
                string currency = WinMenu.s;
                ReadInfMoney(currency);
                g++;
            }
            Clear();
            WriteInfMoney();
            sum = Convert.ToInt32(textBox.Text);
            money = 0;
            for (int i = 0; i < Money.Count; i++)
            {
                money = money + (Money[i].Nominal * Money[i].Kil);
                temp.Add(Money[i]);
            }

            if (sum <= WinMenu.Balanse)
            {
                if (sum <= money)
                {
                    for (int k = 0, i = 0; i < Money.Count; i++)
                    {
                        if (sum >= Money[i].Nominal)
                        {
                            Infmoney.Kil = Operation(Money[i], sum);
                            sum = sum - (Infmoney.Kil * Money[i].Nominal);
                            if (Infmoney.Kil != 0)
                            {
                                Infmoney.Nominal = Money[i].Nominal;
                                IssuedMoney.Add(Infmoney);
                                s[k++] = "Номіналом" + Convert.ToString(Money[i].Nominal) + " - " + Convert.ToString(Infmoney.Kil) + "шт";
                            }
                        }
                    }
                }
                else MessageBox.Show("В банкоматі не має коштів, максимальна сума " + money);
            }
            else MessageBox.Show("На вашому рахунку недостаньо коштів");

            if (sum != 0)
            {
                string s = "";
                for (int i = 0; i <Money.Count; i++)
                {
                    Money[i].Kil = temp[i].Kil;
                    if (sum < Money[i].Nominal) s = "Введіть суму кратну " + Convert.ToString(Money[i].Nominal);
                }
                MessageBox.Show(s);
            }
            else
            {
                for (int i = 0; i<IssuedMoney.Count; i++)
                {
                    WinMenu.Balanse = WinMenu.Balanse - (IssuedMoney[i].Nominal * IssuedMoney[i].Kil);
                }

                for (int i = 0; i < s.Length; i++)
                {
                    textBox1.Text += s[i] += "\r";
                    s[i] = "";
                }
            }
        }
        public int Operation(Infmoney y, int sum)
        {
            int kil = 0;
            while (sum >= y.Nominal & y.Kil > 0)
            {
                sum = sum - y.Nominal;
                kil++;
                y.Kil--;
            }
            return kil;

        }
        public void Clear()

        {
            for (int i = 0; i < 6; i++)
            {
                textBox1.Text = "" + "\r";
            }
        }
        public void ReadInfMoney(string s)
        {
            
            String Cmd = "SELECT * FROM "+s+ " ORDER BY Nominal DESC";
            using (IDbConnection conection = new SqlConnection(Properties.Settings.Default.Connection))
            {
                IDbCommand command = new SqlCommand(Cmd);
                command.Connection = conection;
                conection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Infmoney Inf = new Infmoney();
                    Inf.Nominal = reader.GetInt32(1);
                    Inf.Kil = reader.GetInt32(2);
                    Money.Add(Inf);
                }
            }             
        }
        public void WriteInfMoney()
        {
            string s = "У бакоматі наявні такі кутюри";
            for (int i = 0; i < Money.Count; i++)
            {
                if (Money[i].Kil > 0)
                {
                    s +=","+ Convert.ToString(Money[i].Nominal);
                }
            }
            textBox1.Text = s;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}   
