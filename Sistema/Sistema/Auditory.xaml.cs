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
    /// Логика взаимодействия для Auditory.xaml
    /// </summary>
    public partial class Auditory : Window
    {
        public Auditory()
        {
            InitializeComponent();
            UpdateTable();
            Status.Items.Add("Принята");
            Status.Items.Add("Сдана");
            UpdateBox();
            UpdateOneMoreBox();
        }

        private void UpdateBox()
        {
            SotrudnikTableAdapter t = new SotrudnikTableAdapter();
            for (int i = 0; i < t.GetData().Count(); i++)
            {
                if (t.GetData().Rows[i][8].ToString() == "1" || t.GetData().Rows[i][8].ToString() == "2")
                {
                 Sotrudnik.Items.Add(t.GetData().Rows[i][1].ToString() + " " + t.GetData().Rows[i][2].ToString() + " " + t.GetData().Rows[i][3].ToString());
                }
            }
            for (int i = 0; i < t.GetData().Count(); i++)
            {
                if (t.GetData().Rows[i][8].ToString() == "1" || t.GetData().Rows[i][8].ToString() == "2")
                {
                    FakeSotr.Items.Add(t.GetData().Rows[i][0]);                 
                }

            }
        }
        private void UpdateOneMoreBox()
        {
            InventoryTableAdapter t = new InventoryTableAdapter();
            for (int i = 0; i < t.GetData().Count(); i++)
            {                
                FakeInvent.Items.Add(t.GetData().Rows[i][0]);             
            }
            for (int i = 0; i < t.GetData().Count(); i++)
            {
                Secret.Items.Add(t.GetData().Rows[i][2].ToString());
            }
            Type_InventoryTableAdapter r = new Type_InventoryTableAdapter();
            for (int i = 0; i < r.GetData().Count(); i++)
            {
                Inventory.Items.Add(r.GetData().Rows[i][1]);
            }
        }

        public void WhichRole(int role)
        {
            rabota = role;
        }

        public int rabota;
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.PravaMoment(rabota);
            this.Close();
        }

        private void UpdateTable()
        {
            View_AuditoryTableAdapter adapter = new View_AuditoryTableAdapter();
            DataSet1.View_AuditoryDataTable table = new DataSet1.View_AuditoryDataTable();
            adapter.Fill(table);
            tablica.ItemsSource = table;
            
        }

        private void Pri_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tablica.SelectedItem != null)
                {
                    new AuditoryTableAdapter().UpdateStatus("Принята",DateTime.Now,Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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

        private void Sda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tablica.SelectedItem != null)
                {
                    new AuditoryTableAdapter().UpdateStatus("Сдана", DateTime.Now, Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int so = Sotrudnik.SelectedIndex;
                int inv = Inventory.SelectedIndex;
                if(Nomer.Text != "" && kolvo.Text!="" && data.SelectedDate!=null && Inventory.SelectedItem != null  && Sotrudnik.SelectedItem!= null)
                {
                    new AuditoryTableAdapter().InsertQuery(Nomer.Text, "Новая",Convert.ToDateTime(data.SelectedDate), Convert.ToInt32(kolvo.Text), Convert.ToInt32(FakeInvent.Items[inv]), Convert.ToInt32(FakeSotr.Items[so]));
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
                int so = Sotrudnik.SelectedIndex;
                int inv = Inventory.SelectedIndex;
                if (Nomer.Text != "" && kolvo.Text != "" && Status.SelectedItem!=null && data.SelectedDate != null && Inventory.SelectedItem != null && Sotrudnik.SelectedItem != null)
                {
                    new AuditoryTableAdapter().UpdateQuery(Nomer.Text, Status.SelectedItem.ToString() , Convert.ToDateTime(data.SelectedDate), Convert.ToInt32(kolvo.Text), Convert.ToInt32(FakeInvent.Items[inv]), Convert.ToInt32(FakeSotr.Items[so]), Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
                    new AuditoryTableAdapter().DeleteQuery(Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
