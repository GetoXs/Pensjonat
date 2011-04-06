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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using Microsoft.Windows.Controls;
namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
            zwinRezerwacje();
            gridRezerwacjeDeafult.Height = 580;
            zwinPobyty();
            gridPobytyDeafult.Height = 580;
            zwinKlienci();
            gridKlienciDeafult.Height = 580;
        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void zwinRezerwacje()
        {
            gridRezerwacjeDeafult.Height = 0;
            gridRezerwacjeAdd.Height = 0;
            gridRezerwacjeAdd2.Height = 0;
            gridRezerwacjeDel.Height = 0;
            gridRezerwacjeCheck.Height = 0;
        }

        private void zwinPobyty()
        {
            gridPobytyDeafult.Height = 0;
            gridPobytyServices.Height = 0;
            gridPobytySum.Height = 0;
            gridPobytyDetails.Height = 0;
        }

        private void zwinKlienci()
        {
            gridKlienciDeafult.Height = 0;
            gridKlienciAdd.Height = 0;
            gridKlienciEdit.Height = 0;
        }


        private void buttonRezerwacjeAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeAdd.Height = 580;
        }


        private void buttonRezerwacjeZaliczka_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeCheck.Height = 580;
        }

        private void buttonRezerwacjeDel_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeDel.Height = 580;
        }

        private void tabRezerwacje_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabRezerwacje.IsFocused)
            {
                zwinRezerwacje();
                gridRezerwacjeDeafult.Height = 580;
            }
        }

        private void textBoxRezerwacjeAddIloscOsob_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelPozostaloOsob.Content = textBoxRezerwacjeAddIlOsob.Text;
        }

        private void buttonRezerwacjeAddDalej_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeAdd2.Height = 580;
        }

        private void dataGrid9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonPobytyServices_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            gridPobytyServices.Height = 580;
        }

        private void tabPobyty_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabPobyty.IsFocused)
            {
                zwinPobyty();
                gridPobytyDeafult.Height = 580;
            }
        }

        private void comboBoxPobytyUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxPobytyPracownicy.IsEnabled = true;
        }

        private void tabControl1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonPobytySum_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            gridPobytySum.Height = 580;
        }

        private void buttonPobytyDetails_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            gridPobytyDetails.Height = 580;
        }

        private void buttonKlienciAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinKlienci();
            gridKlienciAdd.Height = 580;
        }

        private void buttonKlienciEdit_Click(object sender, RoutedEventArgs e)
        {
            zwinKlienci();
            gridKlienciEdit.Height = 580;
        }

        private void tabKlienci_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabKlienci.IsFocused)
            {
                zwinKlienci();
                gridKlienciDeafult.Height = 580;
            }
        }

        private void textBoxValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextBoxTextAllowed(e.Text);
        }

        private bool TextBoxTextAllowed(string p)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(p);
        }



    }
}
