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
using PensjonatApp.DS;
using PensjonatApp.Tools;
using System.Data;
using PensjonatApp.Helpers;


namespace PensjonatApp
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
// Główne metody
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

//REZERWACJE

        private void tabRezerwacje_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabRezerwacje.IsFocused)
            {
                zwinRezerwacje();
                gridRezerwacjeDeafult.Height = 580;
            }
        }
//REZERWACJE->DEAFULT
        private void gridRezerwacjeDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeKlienci();
            }
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridRezerwacjeSzukaj.SelectedItem != null)
            {
                RezerwacjeDS.RezerwacjeRow t = (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridRezerwacjeSzukaj.SelectedItem).Row;
            }
        }

        private void buttonRezerwacjeSearch_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxRezerwacjeSzukaj.Text == "")
                dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeKlienci();
            else
            {
                if ((bool)rbRezerwacjeId.IsChecked)
                {
                    int id;
                    if (int.TryParse(textBoxRezerwacjeSzukaj.Text, out id))
                        dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeByID(id);
                    else
                        System.Windows.MessageBox.Show("Niepoprawne ID rezerwacje.\nNumer identyfikacyjny rezerwacji może zawierać tylko cyfry.", "Wyszukiwanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

//REZERWACJE->DODAJ
        private void buttonRezerwacjeAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeAdd.Height = 580;
        }
        private void textBoxRezerwacjeAddIloscOsob_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelPozostaloOsob.Content = textBoxRezerwacjeAddIlOsob.Text;
        }
//REZERWACKE->DODAJ->DALEJ
        private void buttonRezerwacjeAddDalej_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeAdd2.Height = 580;
        }
//REZERWACJE->ZALICZKA
        private void buttonRezerwacjeZaliczka_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRezerwacjeSzukaj.SelectedItem != null)
            {
                RezerwacjeDS.RezerwacjeRow selectedRow= (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridRezerwacjeSzukaj.SelectedItem).Row;
                if (selectedRow.zaplacono_zaliczke == false)
                {
                    zwinRezerwacje();
                    gridRezerwacjeCheck.Height = 580;
                    labelRezerwacjeCheckKlient.Content = (string)selectedRow["imie"] + (string)selectedRow["nazwisko"];
                    labelRezerwacjeCheckPesel.Content = (string)selectedRow["pesel"];
                    //labelRezerwacjeCheckTermin = selectedRow.termin;
                    labelRezerwacjeCheckId.Content = selectedRow.id_rezerwacji;
                    labelRezerwacjeCheckIlOsob.Content = selectedRow.ilosc_osob;
                }
                else
                    System.Windows.MessageBox.Show("Wybrana rezerwacja ma już potwierdzoną wpłatę zaliczki", "Potwierdzenie wpłaty zaliczki", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz rezerwacje.", "Potwierdzenie wpłaty zaliczki", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void buttonRezerwacjeCheckCancel_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeDeafult.Height = 580;
        }
//REZERWACJE->USUN
        private void buttonRezerwacjeDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRezerwacjeSzukaj.SelectedItem != null)
            {
                RezerwacjeDS.RezerwacjeRow selectedRow = (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridRezerwacjeSzukaj.SelectedItem).Row;
                zwinRezerwacje();
                gridRezerwacjeDel.Height = 580;
                labelRezerwacjeDelKlient.Content = (string)selectedRow["imie"] + (string)selectedRow["nazwisko"];
                labelRezerwacjeDelPesel.Content = (string)selectedRow["pesel"];
                //labelRezerwacjeDelTermin = selectedRow.termin;
                labelRezerwacjeDelId.Content = selectedRow.id_rezerwacji;
                labelRezerwacjeDelIlOsob.Content = selectedRow.ilosc_osob;
                checkBoxRezerwacjeDelZaliczka.IsChecked = selectedRow.zaplacono_zaliczke;
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz rezerwacje.", "Usuwanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void buttonRezerwacjeDelCancel_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            gridRezerwacjeDeafult.Height = 580;
        }


//POBYTY
        private void tabPobyty_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabPobyty.IsFocused)
            {
                zwinPobyty();
                gridPobytyDeafult.Height = 580;
            }
        }

        private void buttonPobytyServices_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            gridPobytyServices.Height = 580;
        }

        private void comboBoxPobytyUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxPobytyPracownicy.IsEnabled = true;
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


// KLIENCI
        private void tabKlienci_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabKlienci.IsFocused)
            {
                zwinKlienci();
                gridKlienciDeafult.Height = 580;
            }
        }

//KLIENCI->DEAFULT
        private void dataGridKlienci_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
            }
        }
        private void dataGridKlienci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridKlienci.SelectedItem != null)
            {
                KlienciDS.KlienciRow t = (KlienciDS.KlienciRow)((DataRowView)dataGridKlienci.SelectedItem).Row;
            }
        }
        private void buttonKlienciSearch_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxKlienciSzukaj.Text == "")
                dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
            else
            {
                if ((bool)rbKlienciId.IsChecked)
                {
                    int id;
                    if(int.TryParse(textBoxKlienciSzukaj.Text,out id))
                        dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciMiejsconowsciByIdKlienta(id);
                    else
                        System.Windows.MessageBox.Show("Niepoprawne ID klienta.\nNumer identyfikacyjny klienta może zawierać tylko cyfry.", "Wyszukiwanie klienta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
       
//KLIENCI->DODAJ
        private void buttonKlienciAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinKlienci();
            gridKlienciAdd.Height = 580;
            buttonKlienciAddDodaj.IsEnabled = false;
        }

		private void buttonKlienciAddDodaj_Click(object sender, RoutedEventArgs e)
		{
			//dodawanie klienta
			if (KlienciHelper.addKlient(
				textBoxKlienciAddMail.Text,
				textBoxKlienciAddImie.Text,
				textBoxKlienciAddNazwisko.Text,
				textBoxKlienciAddMiejscowosc.Text,
				textBoxKlienciAddAdres.Text,
				textBoxKlienciAddNIP.Text,
				textBoxKlienciAddPESEL.Text,
				textBoxKlienciAddTelefon.Text,
				textBoxKlienciAddKodPocztowy.Text) == true)
			{
				MessageBox.Show("Pomyślnie dodano klienta do bazy", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			else
				MessageBox.Show("Błąd: " + KlienciHelper.lastMsg, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);

		}

		/// <summary>
		/// Sprawdzanie na bieżąco czy 
		/// </summary>
		private void textBoxKlienciAdd_TextChanged(object sender, TextChangedEventArgs e)
		{
			int nip;
			int tel;
			bool sprawdzic=true;

			buttonKlienciAddDodaj.IsEnabled = false;
			this.labelKlienciAddStatus.Content = "";

			if (!int.TryParse(textBoxKlienciAddNIP.Text, out nip))
			{
				if (textBoxKlienciAddNIP.Text != "")
				{
					this.labelKlienciAddStatus.Content = "W polu NIP może być tylko liczba";
					sprawdzic = false;
				}
			}
			if (!int.TryParse(textBoxKlienciAddTelefon.Text, out tel))
			{
				if (textBoxKlienciAddTelefon.Text != "")
				{
					this.labelKlienciAddStatus.Content = "W polu telefon może być tylko liczba";
					sprawdzic = false;
				}
			}
			if (sprawdzic == true)
			{
				buttonKlienciAddDodaj.IsEnabled = true;
			}
			
		}

//KLIENCI->EDYTUJ
        private void buttonKlienciEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridKlienci.SelectedItem != null)
            {
                zwinKlienci();
                gridKlienciEdit.Height = 580;
                KlienciDS.KlienciRow selectedRow = (KlienciDS.KlienciRow)((DataRowView)dataGridKlienci.SelectedItem).Row;
                //dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciMiejsconowsciByIdKlienta(selectedRow.id_klienta);
                textBoxKlienciEdycjaImie.Text = selectedRow.imie;
                textBoxKlienciEdycjaNazwisko.Text = selectedRow.nazwisko;
                textBoxKlienciEdycjaPESEL.Text = selectedRow.pesel;
                textBoxKlienciEdycjaNIP.Text = selectedRow.nip.ToString();
                textBoxKlienciEdycjaTelefon.Text = selectedRow.nr_telefonu.ToString();
                textBoxKlienciEdycjaMail.Text = selectedRow.email;
                textBoxKlienciEdycjaMiejscowosc.Text = (string)selectedRow["miejscowosc"];
                textBoxKlienciEdycjaAdres.Text = selectedRow.ulica;
                textBoxKlienciEdycjaFirma.Text = selectedRow.IsnazwaNull() ? "" : selectedRow.nazwa;
            }
            else  
                System.Windows.MessageBox.Show("Najpierw wybierz klienta.", "Edycja klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void buttonKlienciEdycjaPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinKlienci();
            gridKlienciDeafult.Height = 580;

        }
//NEWSLETTER
        private void buttonNewsletterNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Czy jesteś pewny?", "Nowy newsletter", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Czy jesteś pewny?", "Nowy newsletter", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                richTextBoxNewsletter.Text = @"{\rtf1\ansi\ansicpg1252\uc1\htmautsp\deff2{\fonttbl{\f0\fcharset0 Times New Roman;}{\f2\fcharset0 Segoe UI;}}{\colortbl\red0\green0\blue0;\red255\green255\blue255;}\loch\hich\dbch\pard\plain\ltrpar\itap0{\lang1033\fs18\f2\cf0 \cf0\ql{\f2 {\ltrch }\li0\ri0\sa0\sb0\fi0\ql\par}}}";
        }





  


    }

}
