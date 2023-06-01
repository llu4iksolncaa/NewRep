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
using Sistema.DataSet1TableAdapters;


namespace Sistema
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SotrudnikTableAdapter STA = new SotrudnikTableAdapter();
                List<string> listLog = new List<string>();
                List<string> Role = new List<string>();
                for (int i = 0; i < STA.GetData().Count(); i++) listLog.Add(STA.GetData().Rows[i][9].ToString() + STA.GetData().Rows[i][10].ToString());
                for (int i = 0; i < STA.GetData().Count(); i++) Role.Add(STA.GetData().Rows[i][8].ToString());
                for (int i = 0; i < listLog.Count; i++)
                {
                  
                        if (Password.Text + Login.Text == listLog[i])
                        {                          
                        int EnterRole = Convert.ToInt32(Role[i].ToString());
                        Menu m = new Menu();
                        m.PravaMoment(EnterRole);
                        this.Close();
                        break;
                        }                  
                
                }
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

   
    }
}
