using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PensjonatApp.DS;
using PensjonatApp.Tools;
using System.Data;
using PensjonatApp.Helpers;

namespace PensjonatApp
{
    /// <summary>
    /// Interaction logic for Logowanie.xaml
    /// </summary>
    public partial class Logowanie : Window
    {
        public Logowanie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (LogowanieHelper.zalogujPracownika(textBox1.Text, passwordBox1.Password))
            {
                MainWindow oknoGlowne = new MainWindow(LogowanieHelper.ID, LogowanieHelper.Imie, LogowanieHelper.Nazwisko, LogowanieHelper.Stanowisko);
                this.Close();
                oknoGlowne.ShowDialog();
            }
            else
                System.Windows.MessageBox.Show("Wprowadzono błędne dane.", "Logowanie", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
