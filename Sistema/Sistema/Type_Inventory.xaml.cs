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
    /// Логика взаимодействия для Type_Inventory.xaml
    /// </summary>
    public partial class Type_Inventory : Window
    {
        public Type_Inventory()
        {
            InitializeComponent();
            UpdateTable();
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

        private void UpdateTable()
        {
            View_Type_InventoryTableAdapter adapter = new View_Type_InventoryTableAdapter();
            DataSet1.View_Type_InventoryDataTable table = new DataSet1.View_Type_InventoryDataTable();
            adapter.Fill(table);
            tablica.ItemsSource = table;       
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && opisanie.Text != "")
                {
                    new Type_InventoryTableAdapter().InsertQuery(name.Text, opisanie.Text);
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
                if (name.Text != "" && opisanie.Text !="" && tablica.SelectedItem != null)
                {
                    new Type_InventoryTableAdapter().UpdateQuery(name.Text, opisanie.Text , Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
                    new Type_InventoryTableAdapter().DeleteQuery(Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
