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
        Client Client;

        Infmoney y500 = new Infmoney();
        Infmoney y200 = new Infmoney();
        Infmoney y100 = new Infmoney();
        Infmoney y50 = new Infmoney();
        Infmoney y20 = new Infmoney();
        Infmoney y10 = new Infmoney();

        public Window1()
        {
            InitializeComponent();
            MainWindow MainWindow = new MainWindow();
            //MainWindow.Show();
            y500.nominal = 500;
            y500.kil = 5;
            y200.nominal = 200;
            y200.kil = 5;
            y100.nominal = 100;
            y100.kil = 5;
            y50.nominal = 50;
            y50.kil = 5;
            y20.nominal = 20;
            y20.kil = 5;
            y10.nominal = 10;
            y10.kil = 5;
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
            Clear();
            Infmoney[] nomi = new Infmoney[] { y500, y200, y100, y50, y20, y10 };
            int[] temp = new int[6];

            sum = Convert.ToInt16(textBox.Text);
            money = 0;
            for (int i = 0; i < nomi.Length; i++)
            {
                money = money + (nomi[i].nominal * nomi[i].kil);
                temp[i] = nomi[i].kil;

            }

            if (sum <= money)
            {
                for (int k = 0, i = 0; i < nomi.Length; i++)
                {
                    if (sum >= nomi[i].nominal)
                    {
                        kil[i] = Operation(nomi[i], sum);
                        sum = sum - (kil[i] * nomi[i].nominal);
                        if (kil[i] != 0)
                        {
                            s[k++] = "Номіналом" + Convert.ToString(nomi[i].nominal) + " - " + Convert.ToString(kil[i]) + "шт";
                        }
                    }
                }
                if (sum != 0)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        nomi[i].kil = temp[i];
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
            while (sum >= y.nominal & y.kil > 0)
            {
                sum = sum - y.nominal;
                kil++;
                y.kil--;
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
        
        
    }
}   
