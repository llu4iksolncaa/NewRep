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
    /// Логика взаимодействия для Sotrudnik.xaml
    /// </summary>
    public partial class Sotrudnik : Window
    {
        public Sotrudnik()
        {
            InitializeComponent();
            UpdateTable();

            DolznostTableAdapter t = new DolznostTableAdapter();
            for (int i = 0; i < t.GetData().Count(); i++)
            {
                ID.Items.Add(t.GetData().Rows[i][1]);
            }
            for (int i = 0; i < t.GetData().Count(); i++)
            {
                FakeId.Items.Add(t.GetData().Rows[i][0]);
            }

        }

        public int rabota;
        public List<string> Role = new List<string>();

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
            View_SotrudnikTableAdapter adapter = new View_SotrudnikTableAdapter();
            DataSet1.View_SotrudnikDataTable table = new DataSet1.View_SotrudnikDataTable();
            adapter.Fill(table);
            tablica.ItemsSource = table;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = ID.SelectedIndex;
                MessageBox.Show(FakeId.Items[a].ToString());
                if (name.Text!="" && surname.Text!="" && seria.Text.Length==4 && nomer.Text.Length==6 && data_rozd.SelectedDate!=null && phone.Text.Length==11 && login.Text!="" && pass.Text!="" && ID.SelectedItem!= null )
                {
                    new SotrudnikTableAdapter().InsertQuery(surname.Text, name.Text, patronymic.Text, seria.Text, nomer.Text, data_rozd.SelectedDate.ToString(), phone.Text, Convert.ToInt32(FakeId.Items[a]), login.Text, pass.Text);
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
                int a = ID.SelectedIndex;
                MessageBox.Show(FakeId.Items[a].ToString());
                if (name.Text != "" && surname.Text != "" && seria.Text.Length == 4 && nomer.Text.Length == 6 && data_rozd.SelectedDate != null && phone.Text.Length == 11 && login.Text != "" && pass.Text != "" && ID.SelectedItem != null)
                {
                    new SotrudnikTableAdapter().UpdateQuery(surname.Text, name.Text, patronymic.Text, seria.Text, nomer.Text, data_rozd.SelectedDate.ToString(), phone.Text, Convert.ToInt32(FakeId.Items[a]), login.Text, pass.Text, Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
                    new SotrudnikTableAdapter().DeleteQuery(Convert.ToInt32((tablica.SelectedItem as DataRowView).Row.ItemArray[0]));
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
