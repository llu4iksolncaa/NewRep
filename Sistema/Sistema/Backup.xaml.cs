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
using System.Globalization;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace Sistema
{
    /// <summary>
    /// Логика взаимодействия для Backup.xaml
    /// </summary>
    public partial class Backup : Window
    {
        public Backup()
        {
            InitializeComponent();
            ListUpdater();
        }

        public string path = @"C:\Users\lu4ik\Desktop\Курсач\Прога\Sistema\Sistema\NewFolder1";


        private void ListUpdater()
        {
           
                    
            for(int i = 0; i < Directory.GetFiles(path).Count(); i++)
            {
                Scripts.Items.Add(Directory.GetFiles(path)[i].Split('\\')[9]);
            }

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

        private void Load_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Push_Click(object sender, RoutedEventArgs e)
        {
            if (Scripts.SelectedItem!=null)
            {
                MessageBox.Show("Выбранный скрипт загружен");
                Scripts.SelectedItem = null;
            }
            else
            {
                MessageBox.Show("Выберите скрипт");
            }
        }
    }
}
