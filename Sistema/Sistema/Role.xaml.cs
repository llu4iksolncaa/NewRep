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
using System.Data;
using Sistema.DataSet1TableAdapters;

namespace Sistema
{
    /// <summary>
    /// Логика взаимодействия для Role.xaml
    /// </summary>
    public partial class Role : Window
    {
        public Role()
        {
            InitializeComponent();
            UpdateTable();
        }

        private void UpdateTable()
        {

            //Отрисовка таблиц в DataGrid
            View_DolznostTableAdapter adapter = new View_DolznostTableAdapter();
            DataSet1.View_DolznostDataTable table = new DataSet1.View_DolznostDataTable();
            adapter.Fill(table);
            tablica.ItemsSource = table;
        }

        public int rabota;

        public void WhichRole(int role)
        {
            rabota = role;
        }      
            
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.PravaMoment(rabota);
            this.Close();
        }

     

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text!="" && Convert.ToDecimal(oklad.Text)*0==0)
                {
                    new DolznostTableAdapter().InsertQuery(name.Text, Convert.ToDecimal(oklad.Text));
                    UpdateTable();                    
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                }
          
            }
            catch            
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void Chg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && Convert.ToDecimal(oklad.Text) * 0 == 0 && tablica.SelectedItem!=null)
                {
                    new DolznostTableAdapter().UpdateQuery(name.Text, Convert.ToDecimal(oklad.Text), Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateTable();
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                }

            }
            catch
            {
                MessageBox.Show("Введите корректные данные");
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tablica.SelectedItem != null)
                {
                    new DolznostTableAdapter().DeleteQuery(Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
                    UpdateTable();
                }
                else
                {
                    MessageBox.Show("Выберите строку");
                }

            }
            catch
            {
                MessageBox.Show("Выберите строку");
            }
        }
    }
}

