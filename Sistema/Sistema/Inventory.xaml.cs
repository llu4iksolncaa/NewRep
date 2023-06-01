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
    /// Логика взаимодействия для Inventory.xaml
    /// </summary>
    public partial class Inventory : Window
    {
        public Inventory()
        {
            InitializeComponent();
            UpdateTable();
            Update();
            OneMoreUpdate();
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

        private void Update()
        {
            View_Type_InventoryTableAdapter adapter = new View_Type_InventoryTableAdapter();
            DataSet1.View_Type_InventoryDataTable table = new DataSet1.View_Type_InventoryDataTable();
            adapter.Fill(table);
            Second.ItemsSource = table;
        }


        private void UpdateTable()
        {
            View_InventoryTableAdapter adapter = new View_InventoryTableAdapter();
            DataSet1.View_InventoryDataTable table = new DataSet1.View_InventoryDataTable();
            adapter.Fill(table);
            tablica.ItemsSource = table;
        }

        private void OneMoreUpdate()
        {
            Type_InventoryTableAdapter t = new Type_InventoryTableAdapter();
            for (int i = 0; i < t.GetData().Count(); i++)
            {
                ID.Items.Add(t.GetData().Rows[i][0]);
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (kolvo.Text != "" && ID.SelectedItem!=null)
                {
                    new InventoryTableAdapter().InsertQuery(Convert.ToInt32(kolvo.Text), Convert.ToInt32(ID.SelectedItem));
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
                if (kolvo.Text != "" && ID.SelectedItem != null && tablica.SelectedItem != null)
                {
                    new InventoryTableAdapter().UpdateQuery(Convert.ToInt32(kolvo.Text), Convert.ToInt32(ID.SelectedItem), Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
                    new InventoryTableAdapter().DeleteQuery(Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
