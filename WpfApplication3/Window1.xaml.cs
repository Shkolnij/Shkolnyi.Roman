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
using System.Windows.Shapes;

namespace WpfApplication3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int sum, money;
        int[] kil = new int[6];
        string[] s = new string[6];
        //Client Client;

        Infmoney y500 = new Infmoney();
        Infmoney y200 = new Infmoney();
        Infmoney y100 = new Infmoney();
        Infmoney y50 = new Infmoney();
        Infmoney y20 = new Infmoney();
        Infmoney y10 = new Infmoney();
        Infmoney[] nomi = new Infmoney[] { };
        public Window1()
        {
            InitializeComponent();
            ReadInfMoney();
            
            //WriteInfMoney();
            MainWindow MainWindow = new MainWindow();
            //MainWindow.Show();
            
            //this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Infmoney[] nomi = new Infmoney[] { y500, y200, y100, y50, y20, y10 };
            
            Clear();
            //WriteInfMoney();
            int[] temp = new int[6];

            sum = Convert.ToInt32(textBox.Text);
            money = 0;
            for (int i = 0; i < nomi.Length; i++)
            {
                money = money + (nomi[i].Nominal * nomi[i].Kil);
                temp[i] = nomi[i].Kil;

            }

            if (sum <= money)
            {
                for (int k = 0, i = 0; i < nomi.Length; i++)
                {
                    if (sum >= nomi[i].Nominal)
                    {
                        kil[i] = Operation(nomi[i], sum);
                        sum = sum - (kil[i] * nomi[i].Nominal);
                        if (kil[i] != 0)
                        {
                            s[k++] = "Номіналом" + Convert.ToString(nomi[i].Nominal) + " - " + Convert.ToString(kil[i]) + "шт";
                        }
                    }
                }
                if (sum != 0)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        nomi[i].Kil = temp[i];
                    }
                    if (sum < 10)
                        MessageBox.Show("Введіть суму кратну 10");
                    else if (sum < 20) MessageBox.Show("Введіть суму кратну 20");
                    else if (sum < 50) MessageBox.Show("Введіть суму кратну 50");
                    else if (sum < 100) MessageBox.Show("Введіть суму кратну 100");
                    else if (sum < 200) MessageBox.Show("Введіть суму кратну 200");
                    else if (sum < 500) MessageBox.Show("Введіть суму кратну 500");
                }
                else
                    for (int i = 0; i < s.Length; i++)
                    {
                        textBox1.Text += s[i] += "\r";
                        s[i] = "";
                    }
            }
            else MessageBox.Show("В банкоматі не має коштів, максимальна сума " + money);

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
        public void ReadInfMoney()
        {
            y500.Nominal = 500;
            y500.Kil = 20;
            y200.Nominal = 200;
            y200.Kil = 5;
            y100.Nominal = 100;
            y100.Kil = 5;
            y50.Nominal = 50;
            y50.Kil = 5;
            y20.Nominal = 20;
            y20.Kil = 5;
            y10.Nominal = 10;
            y10.Kil = 5;
            
        }
        public void WriteInfMoney()
        {
            string s = "У бакоматі наявні такі кутюри";
            for (int i = 0; i < nomi.Length; i++)
            {
                if (nomi[i].Kil > 0)
                {
                    s +=","+ Convert.ToString(nomi[i].nominal);
                }
            }
            textBox1.Text = s;
        }

    }
}   
