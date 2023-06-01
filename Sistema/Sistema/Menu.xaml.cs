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

namespace Sistema
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();

        }
        public int rabota;

        public void PravaMoment(int Role)
        {
           
            if (Role == 1)
            {
                Menu m = new Menu();
                m.rabota = Role;
                m.Show();              
                this.Close();
            }
            else if (Role == 2)
            {
                Menu m = new Menu();
                m.Type_Inventory.Visibility = Visibility.Hidden;
                m.Inventory.Visibility = Visibility.Hidden;
                m.Role.Visibility = Visibility.Hidden;
                m.Sotrudniki.Visibility = Visibility.Hidden;
                m.Backup.Visibility= Visibility.Hidden;
                m.rabota = Role;
                m.Show();
                this.Close();
            }
            else if (Role == 3)
            {
                Menu m = new Menu();
                m.Type_Inventory.Visibility = Visibility.Hidden;
                m.Inventory.Visibility = Visibility.Hidden;
                m.Auditory.Visibility = Visibility.Hidden;
                m.Backup.Visibility = Visibility.Hidden;
                m.ex.Visibility= Visibility.Hidden;
                m.rabota = Role;
                m.Show();
                this.Close();
            }
            else if (Role == 4)
            {
                Menu m = new Menu();
                m.Auditory.Visibility = Visibility.Hidden;
                m.Role.Visibility = Visibility.Hidden;
                m.Sotrudniki.Visibility = Visibility.Hidden;
                m.Backup.Visibility = Visibility.Hidden;
                m.ex.Visibility = Visibility.Hidden;
                m.rabota = Role;
                m.Show();
                this.Close();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void Role_Click(object sender, RoutedEventArgs e)
        {
            Role r = new Role();            
            r.Show();
            r.WhichRole(rabota);
            this.Close();
        }

        private void Type_Inventory_Click(object sender, RoutedEventArgs e)
        {
            Type_Inventory t = new Type_Inventory();
            t.Show();
            t.WhichRole(rabota);
            this.Close();
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            Inventory i = new Inventory();
            i.Show();
            i.WhichRole(rabota);
            this.Close();
        }

        private void Sotrudniki_Click(object sender, RoutedEventArgs e)
        {
            Sotrudnik s = new Sotrudnik();
            s.Show();
            s.WhichRole(rabota);
            this.Close();
        }

        private void Auditory_Click(object sender, RoutedEventArgs e)
        {
            Auditory a = new Auditory();
            a.Show();
            a.WhichRole(rabota);
            this.Close();
        }

        private void ex_Click(object sender, RoutedEventArgs e)
        {
            Documents d = new Documents();
            d.Show();
            d.WhichRole(rabota);
            this.Close();
        }

        private void Backup_Click(object sender, RoutedEventArgs e)
        {
            Backup b = new Backup();
            b.Show();
            b.WhichRole(rabota);
            this.Close();
        }
    }
}
