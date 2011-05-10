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
        private List<Button> buttonRezerwacjeDeafultList = new List<Button>();
        private List<Button> buttonRezerwacjeBackForwardList = new List<Button>();
        private List<Button> buttonRezerwacjeBackOkList = new List<Button>();
        private List<Button> buttonPobytyDeafultList = new List<Button>();
        private List<Button> buttonPobytyBackOkList = new List<Button>();
        private List<Button> buttonPobytyBackPrintList = new List<Button>();
        private List<Button> buttonPobytyBackOkPrintList = new List<Button>();
        private List<Button> buttonKlienciDeafultList = new List<Button>();
        private List<Button> buttonKlienciBackOkList = new List<Button>();
        public static Grid currentGrid;
        public MainWindow()
        {
            InitializeComponent();
            buttonRezerwacjeDeafultList.Add(buttonRezerwacjeZaliczka);
            buttonRezerwacjeDeafultList.Add(buttonRezerwacjeDel);
            buttonRezerwacjeDeafultList.Add(buttonRezerwacjeAdd);
            buttonRezerwacjeBackForwardList.Add(buttonRezerwacjePowrot);
            buttonRezerwacjeBackForwardList.Add(buttonRezerwacjeDalej);
            buttonRezerwacjeBackOkList.Add(buttonRezerwacjePowrot);
            buttonRezerwacjeBackOkList.Add(buttonRezerwacjeOk);

            buttonPobytyDeafultList.Add(buttonPobytyServices);
            buttonPobytyDeafultList.Add(buttonPobytySum);
            buttonPobytyDeafultList.Add(buttonPobytyDetails);
            buttonPobytyBackOkList.Add(buttonPobytyPowrot);
            buttonPobytyBackOkList.Add(buttonPobytyOk);
            buttonPobytyBackOkPrintList.Add(buttonPobytyPowrot);
            buttonPobytyBackOkPrintList.Add(buttonPobytyOk);
            buttonPobytyBackOkPrintList.Add(buttonPobytyDrukuj);
            buttonPobytyBackPrintList.Add(buttonPobytyPowrot);
            buttonPobytyBackPrintList.Add(buttonPobytyDrukuj);

            buttonKlienciDeafultList.Add(buttonKlienciAdd);
            buttonKlienciDeafultList.Add(buttonKlienciEdit);
            buttonKlienciBackOkList.Add(buttonKlienciPowrot);
            buttonKlienciBackOkList.Add(buttonKlienciOk);

            zwinRezerwacje();
            showWindow(gridRezerwacjeDeafult, buttonRezerwacjeDeafultList);
            zwinPobyty();
            showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
            zwinKlienci();
            showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
        }

// Główne metody
        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void zwinButtonList(List<Button> buttonList)
        {
            foreach (Button b in buttonList)
                b.Visibility = Visibility.Collapsed;   
        }
        private void pokazButtonList(List<Button> buttonList)
        {
            foreach (Button b in buttonList)
                b.Visibility = Visibility.Visible;  
        }
       
        private void showWindow(Grid grid,List<Button> buttonList)
        {
            grid.Height = 580;
            pokazButtonList(buttonList);
            currentGrid = grid;
            if (grid == gridRezerwacjeDeafult)
                dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeKlienci();
      
        }
        private void zwinRezerwacje()
        {
            gridRezerwacjeDeafult.Height = 0;
            gridRezerwacjeAdd.Height = 0;
            gridRezerwacjeAdd2.Height = 0;
            gridRezerwacjeDel.Height = 0;
            gridRezerwacjeCheck.Height = 0;
            gridRezerwacjeAddKlient.Height = 0;
            zwinButtonList(buttonRezerwacjeBackForwardList);
            zwinButtonList(buttonRezerwacjeDeafultList);
            zwinButtonList(buttonRezerwacjeBackOkList); 
        }

       
        private void zwinPobyty()
        {
            gridPobytyDeafult.Height = 0;
            gridPobytyServices.Height = 0;
            gridPobytySum.Height = 0;
            gridPobytyDetails.Height = 0;
            zwinButtonList(buttonPobytyBackOkList);
            zwinButtonList(buttonPobytyBackOkPrintList);
            zwinButtonList(buttonPobytyBackPrintList);
            zwinButtonList(buttonPobytyDeafultList);

        }

        private void zwinKlienci()
        {
            gridKlienciDeafult.Height = 0;
            gridKlienciAdd.Height = 0;
            gridKlienciEdit.Height = 0;
            zwinButtonList(buttonKlienciBackOkList);
            zwinButtonList(buttonKlienciDeafultList);
        }

//REZERWACJE

        private void tabRezerwacje_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabRezerwacje.IsFocused)
            {
                zwinRezerwacje();
                showWindow(gridRezerwacjeDeafult,buttonRezerwacjeDeafultList);
            }
        }
//REZERWACJE->BELKA
        private void buttonRezerwacjePowrot_Click(object sender, RoutedEventArgs e)
        {
         if (currentGrid == gridRezerwacjeAdd2)
            {
                zwinRezerwacje();
                showWindow(gridRezerwacjeAdd, buttonRezerwacjeBackForwardList);
            }
            else
            {
                zwinRezerwacje();
                showWindow(gridRezerwacjeDeafult, buttonRezerwacjeDeafultList);
            }
        }
        private void buttonRezerwacjeDalej_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid == gridRezerwacjeAdd)
            {
                if (walidacjaRezerwacjaAdd())
                {
                    zwinRezerwacje();
                    showWindow(gridRezerwacjeAdd2, buttonRezerwacjeBackOkList);
                }
            }
        }
        private bool walidacjaRezerwacjaAdd()
        {
            if (labelRezerwacjeAddPozostaloOsob.Content.ToString() != "0")
            {
                System.Windows.MessageBox.Show("Nie przydzielono wszystkich pokoi.", "Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }             
            if (textBoxRezerwacjeAddKlient.Text == "")
                return false;
            if (datePickerRezeracjeAddTerminOd.SelectedDate == null)
                return false;
            if (datePickerRezerwacjeAddTerminDo.SelectedDate == null)
                return false;
            return true;

        }
        private void buttonRezerwacjeOk_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid == gridRezerwacjeCheck)
            {
                RezerwacjeHelper.potwierdzZaliczke(int.Parse(labelRezerwacjeCheckId.Content.ToString()));
                System.Windows.MessageBox.Show("Potwierdzono wpłatę zaliczki.\nKlient: "+labelRezerwacjeCheckKlient.Content+"\nWysokość zaliczki: "+labelRezerwacjeCheckWysokosc.Content, 
                    "Potwierdzenie wpłaty zaliczki", MessageBoxButton.OK, MessageBoxImage.Information);
                zwinRezerwacje();
                showWindow(gridRezerwacjeDeafult, buttonRezerwacjeDeafultList);
            }
            else if (currentGrid == gridRezerwacjeDel)
            {
                RezerwacjeHelper.usunRezerwacje(int.Parse(labelRezerwacjeDelId.Content.ToString()));
                System.Windows.MessageBox.Show("Usunięto rezerwację.\nKlient: " + labelRezerwacjeDelKlient.Content + "\nTermin: " + labelRezerwacjeDelTermin.Content, 
                    "Usuwanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Information);
                zwinRezerwacje();
                showWindow(gridRezerwacjeDeafult, buttonRezerwacjeDeafultList);
            }
            else if (currentGrid == gridRezerwacjeAddKlient)
            {
                if (dataGridRezerwacjeAddKlienci.SelectedItem != null)
                {
                    KlienciDS.KlienciRow selectedRow = (KlienciDS.KlienciRow)((DataRowView)dataGridRezerwacjeAddKlienci.SelectedItem).Row;
                    textBoxRezerwacjeAddKlient.Text = selectedRow.imie + ' ' + selectedRow.nazwisko;
                    zwinRezerwacje();
                    showWindow(gridRezerwacjeAdd, buttonRezerwacjeBackForwardList);
                }
                else
                {
                    System.Windows.MessageBox.Show("Nie wybrano klienta.\n", "Wybór klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
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
        private void rezerwacjeSearch()
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
                        System.Windows.MessageBox.Show("Niepoprawne ID rezerwacji.\nNumer identyfikacyjny rezerwacji może zawierać tylko cyfry.", "Wyszukiwanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if ((bool)rbRezerwacjeName.IsChecked)
                {
                    if (textBoxRezerwacjeSzukaj.Text.Contains(' '))
                    {
                        string[] szukaj = textBoxRezerwacjeSzukaj.Text.Split(' ');
                        //dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataByRezerwacjeMiejscowosciByImieNazwiskoKlienta(szukaj[0], szukaj[1]);
                    }
                    else
                        dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjaKlienciByNazwiskoRejestrujacego(textBoxRezerwacjeSzukaj.Text);
                }
            }
        }

//REZERWACJE->DODAJ
        private void buttonRezerwacjeAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            showWindow(gridRezerwacjeAdd, buttonRezerwacjeBackForwardList);
        }
        private void textBoxRezerwacjeAddIloscOsob_TextChanged(object sender, TextChangedEventArgs e)
        {
            labelRezerwacjeAddPozostaloOsob.Content = textBoxRezerwacjeAddIlOsob.Text;
        }
        private void sprawdzPokoje()
        {
            DateTime? terminOd = datePickerRezeracjeAddTerminOd.SelectedDate;
            DateTime? terminDo = datePickerRezerwacjeAddTerminDo.SelectedDate;
            if(terminOd!=null && terminDo!=null)
            {
                if (terminOd > terminDo)
                {
                    System.Windows.MessageBox.Show("Niepoprawny termin.\nTermin zakończenie nie może być poźniejszy od terminu rozpoczęcia.", "Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePickerRezeracjeAddTerminOd.SelectedDate = null; 
                    datePickerRezerwacjeAddTerminDo.SelectedDate = null;

                }
                else
                    dataGridRezerwacjeAddDostepnePokoje.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeByTermin(terminOd, terminOd, terminDo, terminDo, terminOd, terminDo);      
          
            }
        }
        private void datePickerRezeracjeAddTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzPokoje();
        }

        private void datePickerRezerwacjeAddTerminDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzPokoje();
        }
        private void dataGridRezerwacjeAddDostepnePokoje_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola

            }
        }
        private void dataGridRezerwacjeAddDostepnePokoje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridRezerwacjeAddDostepnePokoje.SelectedItem != null)
            {
                PokojeDS.PokojeRow pok = (PokojeDS.PokojeRow)((DataRowView)dataGridRezerwacjeAddDostepnePokoje.SelectedItem).Row;
            }
        }
//REZERWACJE->DODAJ->KLIENCI
        private void buttonRezerwacjeAddKlient_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            showWindow(gridRezerwacjeAddKlient, buttonRezerwacjeBackOkList);
       
        }
        private void dataGridRezerwacjeAddKlienci_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridRezerwacjeAddKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
            }
        }

//REZERWACJE->DODAJ->DALEJ
        private void buttonRezerwacjeAddDalej_Click(object sender, RoutedEventArgs e)
        {
            
 

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
                    showWindow(gridRezerwacjeCheck, buttonRezerwacjeBackOkList);
                    labelRezerwacjeCheckKlient.Content = (string)selectedRow["imie"] + " " + (string)selectedRow["nazwisko"];
                    labelRezerwacjeCheckPesel.Content = (string)selectedRow["pesel"];
                    //labelRezerwacjeCheckTermin = selectedRow.termin;
                    labelRezerwacjeCheckId.Content = selectedRow.id_rezerwacji;
                    labelRezerwacjeCheckIlOsob.Content = selectedRow.ilosc_osob;
                    labelRezerwacjeCheckWysokosc.Content = selectedRow.zaliczka + " zł";
                }
                else
                    System.Windows.MessageBox.Show("Wybrana rezerwacja ma już potwierdzoną wpłatę zaliczki", "Potwierdzenie wpłaty zaliczki", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz rezerwacje.", "Potwierdzenie wpłaty zaliczki", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

//REZERWACJE->USUN
        private void buttonRezerwacjeDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRezerwacjeSzukaj.SelectedItem != null)
            {
                RezerwacjeDS.RezerwacjeRow selectedRow = (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridRezerwacjeSzukaj.SelectedItem).Row;
                zwinRezerwacje();
                showWindow(gridRezerwacjeDel, buttonRezerwacjeBackOkList);
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

//POBYTY
        private void tabPobyty_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabPobyty.IsFocused)
            {
                zwinPobyty();
                showWindow(gridPobytyDeafult, buttonPobytyDeafultList);

            }
        }
        private void buttonPobytyPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
        }
        private void buttonPobytyOk_Click(object sender, RoutedEventArgs e)
        {

        }
//POBYTY->DEAFULT
        private void dataGridPobytySzukaj_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokoje();
            }
        }
        private void dataGridPobytySzukaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                PobytyDS.PobytyRow t = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
            }
        }
        private void pobytySearch()
        {
            if (textBoxPobytySzukaj.Text == "")
				if ((bool)checkBoxPobytyAktualne.IsChecked)
					dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeAktualne();
				else
                dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokoje();
            else
            {
                if ((bool)rbPobytyId.IsChecked)
                {
                    int id;
                    if (int.TryParse(textBoxPobytySzukaj.Text, out id))
                        if ((bool)checkBoxPobytyAktualne.IsChecked)
                           dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeAktualneByIDKlienta(id);
                        else
                            dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeByIDKlienta(id);
                    else
                        System.Windows.MessageBox.Show("Niepoprawne ID pobytu.\nNumer identyfikacyjny pobytu może zawierać tylko cyfry.", "Wyszukiwanie pobytu", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if ((bool)rbPobytyKlient.IsChecked)
                {
                    if (textBoxPobytySzukaj.Text.Contains(' '))
                    {

                        string[] szukaj = textBoxPobytySzukaj.Text.Split(' ');
                        //dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeAktualneByNazwiskoKlienta(szukaj[0], szukaj[1]);
                    }
                    else
                    {
                        if ((bool)checkBoxPobytyAktualne.IsChecked)
							dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeAktualneByNazwiskoKlienta(textBoxPobytySzukaj.Text);
                        else
                            dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeByNazwisko(textBoxPobytySzukaj.Text);                  
                    }
                }           
            }
        }
        private void buttonPobytySzukaj_Click(object sender, RoutedEventArgs e)
        {
            pobytySearch();
        }


//POBYTY->USŁUGI
        private void buttonPobytyServices_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                zwinPobyty();
                showWindow(gridPobytyServices, buttonPobytyBackOkList);
                List<string> lst = new List<string>();
                DS.UslugiDS.Uslugi_slownikDataTable rabatyTable = TablesManager.Manager.Uslugi_slownikTableAdapter.GetData();
                foreach (DS.UslugiDS.Uslugi_slownikRow row in rabatyTable)
                {
                    lst.Add(row.nazwa + " -" + row.cena + "zł");
                }
                comboBoxPobytyUslugi.ItemsSource = lst;

                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                labelPobytyServicesKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
                labelPobytyServicesPokoj.Content = (string)selectedRow["nr_pokoju"];
                labelPobytyServicesId.Content = selectedRow.id_pobytu;
                dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(selectedRow.id_pobytu);
           }
            else  
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Dodawanie usługi.", MessageBoxButton.OK, MessageBoxImage.Warning);
 

        }

        private void comboBoxPobytyUslugi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxPobytyPracownicy.IsEnabled = true;
        }


//POBYTY->ROZLICZ
        private void buttonPobytySum_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                zwinPobyty();
                showWindow(gridPobytySum, buttonPobytyBackOkPrintList);
                List<string> lst = new List<string>();
                DS.RachunkiDS.RabatyDataTable rabatyTable = TablesManager.Manager.RabatyTableAdapter.GetDataByAktywne();
                foreach (DS.RachunkiDS.RabatyRow row in rabatyTable)
                {
                    lst.Add(row.nazwa + " -" + row.wartosc + ((row.procentowy == true) ? "%" : "zł"));
                }

                comboBoxPobytySumRabat.ItemsSource = lst;
                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                labelPobytySumKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
                labelPobytySumPokoj.Content = (string)selectedRow["nr_pokoju"];
                labelPobytySumId.Content = selectedRow.id_pobytu;
                labelPobytySumTermin.Content = selectedRow.termin_start.ToLongDateString() + " - " + selectedRow.termin_koniec.ToLongDateString();
                
               // dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(selectedRow.id_pobytu);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


//POBYTY->PODSUMOWANIE
        private void buttonPobytyDetails_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                zwinPobyty();
                showWindow(gridPobytyDetails, buttonPobytyBackPrintList);
                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                labelPobytyDetailsKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
                labelPobytyDetailsPokoj.Content = (string)selectedRow["nr_pokoju"];
                labelPobytyDetailsId.Content = selectedRow.id_pobytu;
                labelPobytyDetailsTermin.Content = selectedRow.termin_start.ToLongDateString() + " - " + selectedRow.termin_koniec.ToLongDateString();

                // dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(selectedRow.id_pobytu);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


// KLIENCI
        private void tabKlienci_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabKlienci.IsFocused)
            {
                zwinKlienci();
                showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
            }
        }
        private void buttonKlienciPowrot_Click(object sender, RoutedEventArgs e)
        {
                zwinKlienci();
                showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
        }
        private void buttonKlienciOk_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid == gridKlienciEdit)
            {
                KlienciHelper.edytujKlienta(int.Parse(labelKlienciEdytujId.Content.ToString()), textBoxKlienciEdycjaImie.Text, textBoxKlienciEdycjaNazwisko.Text, textBoxKlienciEdycjaFirma.Text,
                    textBoxKlienciEdycjaMiejscowosc.Text, textBoxKlienciEdycjaAdres.Text, textBoxKlienciEdycjaKodPocztowy.Text, int.Parse(textBoxKlienciEdycjaNIP.Text),
                       textBoxKlienciEdycjaPESEL.Text, int.Parse(textBoxKlienciEdycjaTelefon.Text), textBoxKlienciEdycjaMail.Text);
                dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
                System.Windows.MessageBox.Show("Wyedytowano pomyślnie.", "Edycja klienta", MessageBoxButton.OK, MessageBoxImage.Information);

                zwinKlienci();
                showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
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
        private void klienciSearch()
        {
            if (textBoxKlienciSzukaj.Text == "")
                dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
            else
            {
                if ((bool)rbKlienciId.IsChecked)
                {
                    int id;
                    if (int.TryParse(textBoxKlienciSzukaj.Text, out id))
                        dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciMiejsconowsciByIdKlienta(id);
                    else
                        System.Windows.MessageBox.Show("Niepoprawne ID klienta.\nNumer identyfikacyjny klienta może zawierać tylko cyfry.", "Wyszukiwanie klienta", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if ((bool)rbKlienciKlient.IsChecked)
                {
                    if (textBoxKlienciSzukaj.Text.Contains(' '))
                    {
                        string[] szukaj = textBoxKlienciSzukaj.Text.Split(' ');
                        dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataByKlienciMiejscowosciByImieNazwiskoKlienta(szukaj[0],szukaj[1]);
                    }
                    else
                        dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataByKlienciMiejscowosciByNazwiskoKlienta(textBoxKlienciSzukaj.Text);                 
                }
            }
        }
        private void buttonKlienciSearch_Click(object sender, RoutedEventArgs e)
        {
            klienciSearch();
        }
       
//KLIENCI->DODAJ
        private void buttonKlienciAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinKlienci();
            showWindow(gridKlienciAdd, buttonKlienciBackOkList);
     
            buttonKlienciAddDodaj.IsEnabled = false;
        }

		private void buttonKlienciAddDodaj_Click(object sender, RoutedEventArgs e)
		{
			//dodawanie klienta
			/*if (KlienciHelper.addKlient(
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
            */
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
                showWindow(gridKlienciEdit, buttonKlienciBackOkList);
     
                KlienciDS.KlienciRow selectedRow = (KlienciDS.KlienciRow)((DataRowView)dataGridKlienci.SelectedItem).Row;
                //dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciMiejsconowsciByIdKlienta(selectedRow.id_klienta);
                textBoxKlienciEdycjaImie.Text = selectedRow.imie;
                textBoxKlienciEdycjaNazwisko.Text = selectedRow.nazwisko;
                textBoxKlienciEdycjaPESEL.Text = selectedRow.pesel;
                textBoxKlienciEdycjaNIP.Text = selectedRow.nip.ToString();
                textBoxKlienciEdycjaTelefon.Text = selectedRow.nr_telefonu.ToString();
                textBoxKlienciEdycjaMail.Text = selectedRow.email;
                textBoxKlienciEdycjaMiejscowosc.Text = (string)selectedRow["miejscowosc"];
                textBoxKlienciEdycjaKodPocztowy.Text = selectedRow.kod_pocztowy;
                textBoxKlienciEdycjaAdres.Text = selectedRow.ulica;
                textBoxKlienciEdycjaFirma.Text = selectedRow.IsnazwaNull() ? "" : selectedRow.nazwa;
                labelKlienciEdytujId.Content = selectedRow.id_klienta;
            }
            else  
                System.Windows.MessageBox.Show("Najpierw wybierz klienta.", "Edycja klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

//NEWSLETTER
        private void buttonNewsletterNew_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Czy jesteś pewny?", "Nowy newsletter", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Czy jesteś pewny?", "Nowy newsletter", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
                richTextBoxNewsletter.Text = @"{\rtf1\ansi\ansicpg1252\uc1\htmautsp\deff2{\fonttbl{\f0\fcharset0 Times New Roman;}{\f2\fcharset0 Segoe UI;}}{\colortbl\red0\green0\blue0;\red255\green255\blue255;}\loch\hich\dbch\pard\plain\ltrpar\itap0{\lang1033\fs18\f2\cf0 \cf0\ql{\f2 {\ltrch }\li0\ri0\sa0\sb0\fi0\ql\par}}}";
        }

        private void buttonRezerwacjeAddWybierz_Click(object sender, RoutedEventArgs e)
        {
            //dataGridRezerwacjeAddKlienci.Items.RemoveAt(3);


        }

        private void buttonPobytySumRabatAdd_Click(object sender, RoutedEventArgs e)
        {
            //do skasowania demonstracja działania zapisywania do comboBoxów
            List<string> lst = new List<string>();
            DS.RachunkiDS.RabatyDataTable rabatyTable = TablesManager.Manager.RabatyTableAdapter.GetDataByAktywne();
            foreach (DS.RachunkiDS.RabatyRow row in rabatyTable)
            {
                lst.Add(row.nazwa + " -" + row.wartosc + ((row.procentowy == true) ? "%" : "zł"));
            }
            comboBoxPobytySumRabat.ItemsSource = lst;
        }











    }

}
