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

namespace WpfApplication3
{
    
    public partial class MainWindow : Window
    {


        ATMDataSet ATMData = new ATMDataSet();
        int Balans;
        

        public MainWindow()
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //int account = Convert.ToInt32(textBox.Text);
           
                    if (password.Password=="1111")
                    {
                         WinMenu WinMenu = new WinMenu();
                        Window1 Window = new Window1();
                        WinMenu.Show();
                        //this.Hide();
                    }
                    else MessageBox.Show("Введіть пароль 1111");
                
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
