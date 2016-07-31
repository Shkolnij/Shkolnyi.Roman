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
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public int sum, money;
        int[] kil = new int[6];
        string[] s = new string[6];  
        Infmoney Infmoney = new Infmoney();
        List<Infmoney> Money = new List<Infmoney>();
        List<Infmoney> temp = new List<Infmoney>();
        List<Infmoney>   m= new List<Infmoney>();

   
        public Window1()
        {
            InitializeComponent();
            string s = "UAN";
            ReadInfMoney(s);
            
            //WriteInfMoney();
            MainWindow MainWindow = new MainWindow();
            //MainWindow.Show();
            
            //this.Close();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            //WriteInfMoney();
            sum = Convert.ToInt32(textBox.Text);
            money = 0;
     
            foreach (var infmoney in Money)
            {
                money = money + (infmoney.Nominal * infmoney.Kil);
            }

            int k = 0;
            if (sum <= money)
            {
                foreach (var infmoney in Money)
                {
                    if (sum >= infmoney.Nominal)
                    {
                        Infmoney.Kil = Operation(infmoney, sum);
                        sum = sum - (Infmoney.Kil * infmoney.Nominal);
                        if (Infmoney.Kil != 0)
                        {

                            Infmoney.Nominal = infmoney.Nominal;
                            temp.Add(Infmoney);
                            s[k++] = "Номіналом" + Convert.ToString(infmoney.Nominal) + " - " + Convert.ToString(Infmoney.Kil) + "шт";
                        }
                    }

                }
                for (int i = 0; i < s.Length; i++)
                {
                    textBox1.Text += s[i] += "\r";
                    s[i] = "";
                }
            }
            else MessageBox.Show("В банкоматі не має коштів, максимальна сума " + money);
        }

            


                //               if (sum != 0)
                //                {
                //                    for (int i = 0; i < temp.Length; i++)
                //                    {
                //                        nomi[i].Kil = temp[i];
                //                    }
                //                    if (sum < 10)
                //                        MessageBox.Show("Введіть суму кратну 10");
                //                    else if (sum < 20) MessageBox.Show("Введіть суму кратну 20");
                //                    else if (sum < 50) MessageBox.Show("Введіть суму кратну 50");
                //                    else if (sum < 100) MessageBox.Show("Введіть суму кратну 100");
                //                    else if (sum < 200) MessageBox.Show("Введіть суму кратну 200");
                //                    else if (sum < 500) MessageBox.Show("Введіть суму кратну 500");
                //                }
                //                else
                //                    for (int i = 0; i < s.Length; i++)
                //                    {
                //                        textBox1.Text += s[i] += "\r";
                //                        s[i] = "";
                //                    }
                //            }

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
            
            String Cmd = "SELECT * FROM "+s+"";
            using (IDbConnection conection = new SqlConnection(Properties.Settings.Default.Connection))
            {
                IDbCommand command = new SqlCommand(Cmd);
                command.Connection = conection;
                conection.Open();

                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Infmoney.Nominal = reader.GetInt32(1);
                    Infmoney.Kil = reader.GetInt32(2);
                    Money.Add(Infmoney);
                }
            }           
        }
      //  public void WriteInfMoney()
       // {
      //      string s = "У бакоматі наявні такі кутюри";
      ////      for (int i = 0; i < nomi.Length; i++)
     //       {
       //         if (nomi[i].Kil > 0)
         //       {
           //         s +=","+ Convert.ToString(nomi[i].nominal);
             //   }
 //           }
   //         textBox1.Text = s;
     //   }
        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}   
