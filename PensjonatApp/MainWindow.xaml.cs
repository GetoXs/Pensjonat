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
        private List<Button> buttonPokojeDeafultList = new List<Button>();
        private List<Button> buttonPokojeBackOkList = new List<Button>();
        private List<Button> buttonWyposazenieDeafultList = new List<Button>();
        private List<Button> buttonWyposazenieBackOkList = new List<Button>();
        private List<Button> buttonRabatyDeafultList = new List<Button>();
        private List<Button> buttonRabatyBackOkList = new List<Button>();
        private List<Button> buttonPosilkiDeafultList = new List<Button>();
        private List<Button> buttonPosilkiBackOkList = new List<Button>();
        private List<Button> buttonUslugiDeafultList = new List<Button>();
        private List<Button> buttonUslugiBackOkList = new List<Button>();
        private List<Button> buttonStandPokoiDeafultList = new List<Button>();
        private List<Button> buttonStandPokoiBackOkList = new List<Button>();
        private List<Button> buttonPracownicyDeafultList = new List<Button>();
        private List<Button> buttonPracownicyBackOkList = new List<Button>();
        private List<Button> buttonPracownicyBackList = new List<Button>();
        private List<Button> buttonStanowiskaDeafultList = new List<Button>();
        private List<Button> buttonStanowiskaBackOkList = new List<Button>();
        private List<Button> buttonZadaniaDeafultList = new List<Button>();
        private List<Button> buttonZadaniaBackList = new List<Button>();
        private List<Button> buttonEmptyList = new List<Button>();
        private int id;
        private string imie;
        private string nazwisko;
        private string stanowisko;

        public static Grid currentGrid;
        public MainWindow(int id, string imie, string nazwisko, string stanowisko)
        {
            InitializeComponent();

            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.stanowisko = stanowisko;

            this.labelLoginImie.Content = this.imie;
            this.LabelLoginNazwisko.Content = this.nazwisko;
            this.labelLoginId.Content = this.id;

            tabNewsletter.Visibility = Visibility.Collapsed;
            switch (this.stanowisko)
            {
                case "Kierownik":
                    tabZadania.Visibility = Visibility.Collapsed;
                    break;

                case "Recepcjonista":
                    tabPokoje.Visibility = Visibility.Collapsed;
                    tabStandardyPokoi.Visibility = Visibility.Collapsed;
                    tabWyposazenie.Visibility = Visibility.Collapsed;
                    tabRabaty.Visibility = Visibility.Collapsed;
                    tabPosilki.Visibility = Visibility.Collapsed;
                    tabUslugi.Visibility = Visibility.Collapsed;
                    tabPrzydzialy.Visibility = Visibility.Collapsed;
                    tabStanowiska.Visibility = Visibility.Collapsed;
                    tabZadania.Visibility = Visibility.Collapsed;
                    break;

                case "Kucharz":
                    tabControl1.SelectedIndex = 13;
                    tabRezerwacje.Visibility = Visibility.Collapsed;
                    tabPobyty.Visibility = Visibility.Collapsed;
                    tabKlienci.Visibility = Visibility.Collapsed;
                    tabPokoje.Visibility = Visibility.Collapsed;
                    tabStandardyPokoi.Visibility = Visibility.Collapsed;
                    tabWyposazenie.Visibility = Visibility.Collapsed;
                    tabRabaty.Visibility = Visibility.Collapsed;
                    tabPosilki.Visibility = Visibility.Collapsed;
                    tabUslugi.Visibility = Visibility.Collapsed;
                    tabPrzydzialy.Visibility = Visibility.Collapsed;
                    tabStanowiska.Visibility = Visibility.Collapsed;
                    break;

                default:
                    tabControl1.SelectedIndex = 13;
                    tabRezerwacje.Visibility = Visibility.Collapsed;
                    tabPobyty.Visibility = Visibility.Collapsed;
                    tabKlienci.Visibility = Visibility.Collapsed;
                    tabPokoje.Visibility = Visibility.Collapsed;
                    tabStandardyPokoi.Visibility = Visibility.Collapsed;
                    tabWyposazenie.Visibility = Visibility.Collapsed;
                    tabRabaty.Visibility = Visibility.Collapsed;
                    tabPosilki.Visibility = Visibility.Collapsed;
                    tabUslugi.Visibility = Visibility.Collapsed;
                    tabPrzydzialy.Visibility = Visibility.Collapsed;
                    tabStanowiska.Visibility = Visibility.Collapsed;
                    break;
            }

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
            buttonPobytyDeafultList.Add(buttonPobytyNowy);
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

            buttonPokojeDeafultList.Add(buttonPokojeUsun);
            buttonPokojeDeafultList.Add(buttonPokojeEdytuj);
            buttonPokojeBackOkList.Add(buttonPokojeOk);
            buttonPokojeBackOkList.Add(buttonPokojePowrot);

            buttonWyposazenieDeafultList.Add(buttonWyposazenieUsun);
            buttonWyposazenieDeafultList.Add(buttonWyposazenieEdytuj);
            buttonWyposazenieBackOkList.Add(buttonWyposazenieOk);
            buttonWyposazenieBackOkList.Add(buttonWyposazeniePowrot);

            buttonRabatyDeafultList.Add(buttonRabatyUsun);
            buttonRabatyDeafultList.Add(buttonRabatyEdytuj);
            buttonRabatyBackOkList.Add(buttonRabatyOk);
            buttonRabatyBackOkList.Add(buttonRabatyPowrot);

            buttonPosilkiDeafultList.Add(buttonPosilkiUsun);
            buttonPosilkiDeafultList.Add(buttonPosilkiEdytuj);
            buttonPosilkiBackOkList.Add(buttonPosilkiOk);
            buttonPosilkiBackOkList.Add(buttonPosilkiPowrot);

            buttonUslugiDeafultList.Add(buttonUslugiUsun);
            buttonUslugiDeafultList.Add(buttonUslugiEdytuj);
            buttonUslugiBackOkList.Add(buttonUslugiOk);
            buttonUslugiBackOkList.Add(buttonUslugiPowrot);
            
            buttonStandPokoiDeafultList.Add(buttonStandPokoiDodaj);
            buttonStandPokoiDeafultList.Add(buttonStandPokoiUsun);
            buttonStandPokoiDeafultList.Add(buttonStandPokoiEdytuj);
            buttonStandPokoiBackOkList.Add(buttonStandPokoiOk);
            buttonStandPokoiBackOkList.Add(buttonStandPokoiPowrot);

            buttonPracownicyDeafultList.Add(buttonPracownicyZadania);
            buttonPracownicyDeafultList.Add(buttonPracownicyDodaj);
            buttonPracownicyDeafultList.Add(buttonPracownicyUsun);
            buttonPracownicyDeafultList.Add(buttonPracownicyEdytuj);
            buttonPracownicyBackOkList.Add(buttonPracownicyOk);
            buttonPracownicyBackOkList.Add(buttonPracownicyPowrot);
            buttonPracownicyBackList.Add(buttonPracownicyPowrot);

            buttonStanowiskaDeafultList.Add(buttonStanowiskaUsun);
            buttonStanowiskaDeafultList.Add(buttonStanowiskaEdytuj);
            buttonStanowiskaBackOkList.Add(buttonStanowiskaOk);
            buttonStanowiskaBackOkList.Add(buttonStanowiskaPowrot);

            buttonZadaniaDeafultList.Add(buttonZadaniaArchiwum);
            buttonZadaniaBackList.Add(buttonZadaniaPowrot);


            zwinRezerwacje();
            showWindow(gridRezerwacjeDeafult, buttonRezerwacjeDeafultList);
            zwinPobyty();
            showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
            zwinKlienci();
            showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
            zwinPokoje();
            showWindow(gridPokojeDeafult, buttonPokojeDeafultList);
            zwinWyposazenie();
            showWindow(gridWyposazenieDeafult, buttonWyposazenieDeafultList);
            zwinRabaty();
            showWindow(gridRabatyDeafult, buttonRabatyDeafultList);
            zwinPosilki();
            showWindow(gridPosilkiDeafult, buttonPosilkiDeafultList);
            zwinUslugi();
            showWindow(gridUslugiDeafult, buttonUslugiDeafultList);
            zwinStandPokoi();
            showWindow(gridStandPokoiDeafult, buttonStandPokoiDeafultList);
            zwinPracownicy();
            showWindow(gridPracownicyDeafult, buttonPracownicyDeafultList);
            zwinStanowiska();
            showWindow(gridStanowiskaDeafult, buttonStanowiskaDeafultList);
            zwinZadania();
            showWindow(gridZadaniaDeafult, buttonZadaniaDeafultList);

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
            grid.Visibility = Visibility.Visible;
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
            gridPobytyNowy.Height = 0;
            gridPobytyWybierzKlienta.Height = 0;
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
        private void zwinPokoje()
        {
            gridPokojeDeafult.Visibility = Visibility.Collapsed;
            gridPokojeEdycja.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonPokojeDeafultList);
            zwinButtonList(buttonPokojeBackOkList);
        }
        private void zwinWyposazenie()
        {
            gridWyposazenieDeafult.Visibility = Visibility.Collapsed;
            gridWyposazenieEdytuj.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonWyposazenieDeafultList);
            zwinButtonList(buttonWyposazenieBackOkList);
        }
        private void zwinRabaty()
        {
            gridRabatyDeafult.Visibility = Visibility.Collapsed;
            gridRabatyEdycja.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonRabatyDeafultList);
            zwinButtonList(buttonRabatyBackOkList);
        }
        private void zwinPosilki()
        {
            gridPosilkiDeafult.Visibility = Visibility.Collapsed;
            gridPosilkiEdycja.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonPosilkiDeafultList);
            zwinButtonList(buttonPosilkiBackOkList);
        }
        private void zwinUslugi()
        {
            gridUslugiDeafult.Visibility = Visibility.Collapsed;
            gridUslugiEdycja.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonUslugiDeafultList);
            zwinButtonList(buttonUslugiBackOkList);
        }
        private void zwinStandPokoi()
        {
            gridStandPokoiDeafult.Visibility = Visibility.Collapsed;
            gridStandPokoiDodaj.Visibility = Visibility.Collapsed;
            gridStandPokoiEdycja.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonStandPokoiDeafultList);
            zwinButtonList(buttonStandPokoiBackOkList);
        }
        private void zwinPracownicy()
        {
            gridPracownicyDeafult.Visibility = Visibility.Collapsed;
            gridPracownicyDodaj.Visibility = Visibility.Collapsed;
            gridPracownicyEdycja.Visibility = Visibility.Collapsed;
            gridPracownicyZadania.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonPracownicyDeafultList);
            zwinButtonList(buttonPracownicyBackOkList);
            zwinButtonList(buttonPracownicyBackList);
        }
        private void zwinStanowiska()
        {
            gridStanowiskaDeafult.Visibility = Visibility.Collapsed;
            gridStanowiskaEdycja.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonStanowiskaDeafultList);
            zwinButtonList(buttonStanowiskaBackOkList);
        }
        private void zwinZadania()
        {
            gridZadaniaDeafult.Visibility = Visibility.Collapsed;
            gridZadaniaArchiwum.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonZadaniaDeafultList);
            zwinButtonList(buttonZadaniaBackList);
            
        }

//----------------------------------------------REZERWACJE----------------------------------------------

        private void tabRezerwacje_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tabRezerwacje.IsFocused)
            {
                zwinRezerwacje();
                showWindow(gridRezerwacjeDeafult,buttonRezerwacjeDeafultList);
            }
        }
        //----------------------------------------------REZERWACJE->BELKA----------------------------------------------
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
                    labelRezerwacjeAdd2IlOsob.Content = textBoxRezerwacjeAddIlOsob.Text;
                    labelRezerwacjeAdd2Klient.Content = textBoxRezerwacjeAddKlient.Text;
                    datePickerRezeracjeAddTerminOd.SelectedDateFormat = DatePickerFormat.Long;
                    datePickerRezerwacjeAddTerminDo.SelectedDateFormat = DatePickerFormat.Long;
                    labelRezerwacjeAdd2Termin.Content = datePickerRezeracjeAddTerminOd.SelectedDate.ToString().Remove(11)
                         + " - " + datePickerRezerwacjeAddTerminDo.SelectedDate.ToString().Remove(11);
                    dataGridRezerawcjeAdd2Pokoje.ItemsSource = RezerwacjePokojeDodajList;
                }
                else
                    System.Windows.MessageBox.Show("Uzupełnij wszystkie pola.", "Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool walidacjaRezerwacjaAdd()
        {
            //if (labelRezerwacjeAddPozostaloOsob.Content.ToString() != "0")
            //{
                //System.Windows.MessageBox.Show("Nie przydzielono wszystkich pokoi.", "Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Warning);
               // return false;
           // }             
            if (textBoxRezerwacjeAddKlient.Text == "")
                return false;
            if (datePickerRezeracjeAddTerminOd.SelectedDate == null)
                return false;
            if (datePickerRezerwacjeAddTerminDo.SelectedDate == null)
                return false;
            if (textBoxRezerwacjeAddIlOsob.Text == "")
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
                    labelRezerwacjeAddId.Content = selectedRow.id_klienta;
                    zwinRezerwacje();
                    showWindow(gridRezerwacjeAdd, buttonRezerwacjeBackForwardList);
                }
                else
                {
                    System.Windows.MessageBox.Show("Nie wybrano klienta.\n", "Wybór klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (currentGrid == gridRezerwacjeAdd2)
            {
                int zaliczka;
                if(int.TryParse(textBoxRezerwacjeAdd2Zaliczka.Text,out zaliczka)){
                    List<int> idList = new List<int>();
                    foreach(var elem in RezerwacjePokojeDodajList)
                    {
                        idList.Add(elem.id_pokoju);
                    }
                RezerwacjeHelper.dodajRezerwacje((int)labelRezerwacjeAddId.Content, int.Parse(labelRezerwacjeAdd2IlOsob.Content.ToString()),zaliczka,
                    idList, (DateTime)datePickerRezeracjeAddTerminOd.SelectedDate, (DateTime)datePickerRezerwacjeAddTerminDo.SelectedDate);
                zwinRezerwacje();
                showWindow(gridRezerwacjeDeafult, buttonRezerwacjeDeafultList);
                }
                else{
                    System.Windows.MessageBox.Show("Pole zaliczka może zawierać tylko cyfry.","Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Information);
               
                }
            }
        }
        //----------------------------------------------REZERWACJE->DEAFULT----------------------------------------------
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
            rezerwacjeSearch();
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

        //----------------------------------------------REZERWACJE->DODAJ---------------------------------------------- 
        List<string> RezerwacjePokojeStringList = new List<string>();
        List<PokojeDS.PokojeRow> RezerwacjePokojeList = new List<PokojeDS.PokojeRow>();
        List<PokojeDS.PokojeRow> RezerwacjePokojeDodajList = new List<PokojeDS.PokojeRow>();
        List<PokojeDS.Pokoje_slownikRow> RezerwacjePokojeSlownikList = new List<PokojeDS.Pokoje_slownikRow>();
        int rezerwacjePokojeIloscOsob;
        private void dataGridRezerwacjeAddWybranePokoje_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridRezerwacjeAddWybranePokoje.ItemsSource = RezerwacjePokojeDodajList;
        }
        private void buttonRezerwacjeAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            showWindow(gridRezerwacjeAdd, buttonRezerwacjeBackForwardList);
            rezerwacjePokojeIloscOsob = 0;
            textBoxRezerwacjeAddIlOsob.Text = "";
          //  textBoxRezerwacjeAddKlient.Text == "";
            datePickerRezeracjeAddTerminOd.SelectedDate = null;
            datePickerRezerwacjeAddTerminDo.SelectedDate = null;
            
        }
        private void textBoxRezerwacjeAddIloscOsob_TextChanged(object sender, TextChangedEventArgs e)
        {

            labelRezerwacjeAddPozostaloOsob.Content = textBoxRezerwacjeAddIlOsob.Text;
        }
        
        private void buttonRezerwacjeAddDodajPokoj_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxRezerwacjeAddPokoje.SelectedItem != null && !RezerwacjePokojeDodajList.Contains(RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex]))
            {
                RezerwacjePokojeDodajList.Add(RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex]);
              //PokojeHel++
            }
            dataGridRezerwacjeAddWybranePokoje.ItemsSource = RezerwacjePokojeDodajList;
            dataGridRezerwacjeAddWybranePokoje.Items.Refresh();
        }

        private void buttonRezerwacjeAddUsunPokoj_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxRezerwacjeAddPokoje.SelectedItem != null)
            {
                foreach (var row in RezerwacjePokojeDodajList)
                {
                    if (row.id_pokoju == RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex].id_pokoju)
                    {
                        RezerwacjePokojeDodajList.Remove(row);
                        //POkeje --
                        break;
                    }
                }
            }
            dataGridRezerwacjeAddWybranePokoje.Items.Refresh();
        }
        private enum wolnePokoje
        {
            errTermin,errSelection,Ok
        }
        private wolnePokoje sprawdzPokoje(ref DatePicker terminOd,ref DatePicker terminDo)
        {

            if(terminOd.SelectedDate!=null && terminDo.SelectedDate!=null)
            {
                if (terminOd.SelectedDate > terminDo.SelectedDate)
                {
                    System.Windows.MessageBox.Show("Niepoprawny termin.\nTermin zakończenie nie może być poźniejszy od terminu rozpoczęcia.", "Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Error);
                    terminOd.SelectedDate = null;
                    terminDo.SelectedDate = null;

                }
                else
                {
                    return wolnePokoje.Ok;
                   
                }     
            }
            return wolnePokoje.errSelection;
        }
        private void DodajPokojdeDoComboBoxa()
        {
            sprawdzPokoje(ref datePickerRezeracjeAddTerminOd, ref datePickerRezerwacjeAddTerminDo);
            RezerwacjePokojeList.Clear();
            RezerwacjePokojeStringList.Clear();
            PokojeDS.PokojeDataTable pokojeTable = TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeByTermin(datePickerRezeracjeAddTerminOd.SelectedDate
                       , datePickerRezeracjeAddTerminOd.SelectedDate, datePickerRezerwacjeAddTerminDo.SelectedDate, datePickerRezerwacjeAddTerminDo.SelectedDate, 
                       datePickerRezeracjeAddTerminOd.SelectedDate, datePickerRezerwacjeAddTerminDo.SelectedDate);
            foreach (PokojeDS.PokojeRow row in pokojeTable)
            {
                RezerwacjePokojeList.Add(row);
                RezerwacjePokojeStringList.Add(row.nr_pokoju + " | ");
            }
            comboBoxRezerwacjeAddPokoje.ItemsSource = RezerwacjePokojeStringList;
        }
        private void datePickerRezeracjeAddTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DodajPokojdeDoComboBoxa();
        }

        private void datePickerRezerwacjeAddTerminDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DodajPokojdeDoComboBoxa();

        }
        private void dataGridRezerwacjeAddDostepnePokoje_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola

            }
        }
        //----------------------------------------------REZERWACJE->DODAJ->KLIENCI----------------------------------------------
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

        //----------------------------------------------REZERWACJE->DODAJ->DALEJ----------------------------------------------
        private void buttonRezerwacjeAddDalej_Click(object sender, RoutedEventArgs e)
        {
            
 

        }
        //----------------------------------------------REZERWACJE->ZALICZKA----------------------------------------------
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

        //----------------------------------------------REZERWACJE->USUN----------------------------------------------
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

//----------------------------------------------POBYTY----------------------------------------------
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
            if (currentGrid == gridPobytyWybierzKlienta)
            {
                if (dataGridPobytyNowyKlienci.SelectedItem != null)
                {
                    KlienciDS.KlienciRow selectedRow = (KlienciDS.KlienciRow)((DataRowView)dataGridPobytyNowyKlienci.SelectedItem).Row;
                    textBoxPobytyNowyKlient.Text = selectedRow.imie + ' ' + selectedRow.nazwisko;
                    labelPobytyNowyIdKlienta.Content = selectedRow.id_klienta;
                    zwinPobyty();
                    showWindow(gridPobytyNowy, buttonPobytyBackOkList);
                }
                else
                {
                    System.Windows.MessageBox.Show("Nie wybrano klienta.\n", "Wybór klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (currentGrid == gridPobytyNowy)
            {
                if (expander1.IsExpanded == true)
                {
                    if (textBoxPobytyNowyKlient.Text != null && textBoxPobytyNowyIlOsob != null && comboBoxPobytyNowyPokoj.SelectedItem != null
                        && datePickerPobytyNowyTerminDo.SelectedDate != null && datePickerPobytyNowyTerminOd.SelectedDate != null)
                    {
                        RezerwacjeHelper.dodajRezerwacjeIZakwaterowanieOdRazu((int)labelPobytyNowyIdKlienta.Content,
                            PobytyNowyIdPokoje[comboBoxPobytyNowyPokoj.SelectedIndex],(DateTime) datePickerPobytyNowyTerminOd.SelectedDate,
                            (DateTime)datePickerPobytyNowyTerminDo.SelectedDate);
                        zwinPobyty();
                        showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Wypełnij wszytkie pola", "Dodawanie pobytu", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    if (dataGridPobytyNowyRezerwacje.SelectedItem != null)
                    {
                        RezerwacjeDS.RezerwacjeRow selectedRow = (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridPobytyNowyRezerwacje.SelectedItem).Row;
               RezerwacjeHelper.dodajKlientaDoPobytuNaPodstawieRezerwacji(selectedRow.id_rezerwacji,selectedRow.id_klienta,(int)selectedRow["id_pokoju"]);
                        zwinPobyty();
                        showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
                    }
                    else
                        System.Windows.MessageBox.Show("Wybierz rezerwację", "Dodawanie pobytu", MessageBoxButton.OK, MessageBoxImage.Error);
                  
                }

            }
        }
        //----------------------------------------------POBYTY->DEAFULT----------------------------------------------
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


        //----------------------------------------------POBYTY->USŁUGI----------------------------------------------
        List<int> PobytyUslugiIdList = new List<int>();
        List<int> PobytyUslugiIdPracownikaList = new List<int>();
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
                    PobytyUslugiIdList.Add(row.id_slownikowe_uslugi);
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
            datePickerPobytyServicesTerminOd.IsEnabled = true;
        }

        private void datePickerPobytyServicesTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxPobytyPracownicy.IsEnabled = true;
            List<string> lst = new List<string>();
            PobytyUslugiIdPracownikaList.Clear();
            DateTime koniec = (DateTime)datePickerPobytyServicesTerminOd.SelectedDate;
            koniec = koniec.AddDays(1.0);
            PracownicyDS.PracownicyDataTable pracownicyTable = UslugiHelper.znajdzWolnegoPracownika(datePickerPobytyServicesTerminOd.SelectedDate, koniec, PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex]);//TablesManager.Manager.PracownicyTableAdapter.
               // GetDataPracownicyWykonujacyUslugeWPodanymTerminie(PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex], koniec, datePickerPobytyServicesTerminOd.SelectedDate);

            foreach (PracownicyDS.PracownicyRow row in pracownicyTable)
            {
                lst.Add(row.imie + " " + row.nazwisko);
                PobytyUslugiIdPracownikaList.Add(row.id_pracownika);
            }
            comboBoxPobytyPracownicy.ItemsSource = lst;

        }
        private void buttonPobytyServicesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPobytyUslugi.SelectedItem != null && datePickerPobytyServicesTerminOd.SelectedDate != null && comboBoxPobytyPracownicy.SelectedItem != null)
            {
                UslugiHelper.przydzielPracownika(PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex], PobytyUslugiIdPracownikaList[comboBoxPobytyPracownicy.SelectedIndex]);
                dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytyServicesId.Content);
            }
            else
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Dodawanie usługi", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        private void buttonPobytyUslugiUsun_Click(object sender, RoutedEventArgs e)
        {

            if (dataGridPobytyUslugi.SelectedItem != null)
            {
                UslugiDS.UslugiRow selectedRow = (UslugiDS.UslugiRow)((DataRowView)dataGridPobytyUslugi.SelectedItem).Row;
                UslugiHelper.usunUsluge(selectedRow.id_uslugi);
                dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytyServicesId.Content);
            }
        }

        //----------------------------------------------POBYTY->ROZLICZ----------------------------------------------
        List<RachunkiDS.RabatyRow> PobytyRabatyList = new List<RachunkiDS.RabatyRow>();
        List<RachunkiDS.RabatyRow> PobytyRabatyDodajList = new List<RachunkiDS.RabatyRow>();
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
                    PobytyRabatyList.Add(row);
                }
                comboBoxPobytySumRabat.ItemsSource = lst;

                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                labelPobytySumKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
                labelPobytySumPokoj.Content = (string)selectedRow["nr_pokoju"];
                labelPobytySumId.Content = selectedRow.id_pobytu;
                labelPobytySumTermin.Content = selectedRow.termin_start.ToLongDateString() + " - " + selectedRow.termin_koniec.ToLongDateString();
				//zerowanie listy rabatow
                PobytyRabatyDodajList = new List<RachunkiDS.RabatyRow>();
				dataGridPobytySumRabaty.ItemsSource = PobytyRabatyDodajList;

				labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCena(selectedRow.id_pobytu, PobytyRabatyDodajList).ToString(".00");
				labelPobytySumCena.Content = RozliczenieHelper.pobierzPodstawowaCenaLaczna(selectedRow.id_pobytu).ToString(".00");

               // dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(selectedRow.id_pobytu);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PobytySumRabatyDodaj_Click(object sender, RoutedEventArgs e)
        {
			if (comboBoxPobytySumRabat.SelectedItem != null && !PobytyRabatyDodajList.Contains(PobytyRabatyList[comboBoxPobytySumRabat.SelectedIndex]))
			{
				PobytyRabatyDodajList.Add(PobytyRabatyList[comboBoxPobytySumRabat.SelectedIndex]);

				labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCena((int)labelPobytySumId.Content, PobytyRabatyDodajList).ToString(".00");
			}
            dataGridPobytySumRabaty.Items.Refresh();

        }
        private void buttonPobytySumRabatyUsun_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPobytySumRabat.SelectedItem != null)
            {
                foreach (var row in PobytyRabatyDodajList)
                {
					if (row.id_rabatu == PobytyRabatyList[comboBoxPobytySumRabat.SelectedIndex].id_rabatu)
                    {
						PobytyRabatyDodajList.Remove(row);
						labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCena((int)labelPobytySumId.Content, PobytyRabatyDodajList).ToString(".00");
                        break;
                    }
                }
            }
            dataGridPobytySumRabaty.Items.Refresh();

        }

        //----------------------------------------------POBYTY->NOWY----------------------------------------------
        private void buttonPobytyNowy_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyNowy, buttonPobytyBackOkList);
        }

        private void expander2_Expanded(object sender, RoutedEventArgs e)
        {
            if (expander1 != null)
                expander1.IsExpanded = false;

        }
        private void expander2_Collapsed(object sender, RoutedEventArgs e)
        {
            if (expander1 != null)
                expander1.IsExpanded = true;
        }
        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {
            if (expander2 != null)
                expander2.IsExpanded = false;
        }

        private void expander1_Collapsed(object sender, RoutedEventArgs e)
        {
            if (expander2 != null)
                expander2.IsExpanded = true;
        }
        private void buttonPobytyNowyKlient_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyWybierzKlienta, buttonPobytyBackOkList);
        }

        private void dataGridPobytyNowyKlienci_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPobytyNowyKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
            }
        }
        private void dataGridPobytyNowyRezerwacje_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPobytyNowyRezerwacje.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeKlienciPokoje();
            }
        }
        List<int> PobytyNowyIdPokoje = new List<int>();
        List<string> PobytyNowyStringPokoje = new List<string>();
        private void PrzypiszWolnePokoje()
        {
            DateTime terminOd = (DateTime)datePickerPobytyNowyTerminOd.SelectedDate;
            DateTime terminDo = (DateTime)datePickerPobytyNowyTerminDo.SelectedDate;
            PobytyNowyIdPokoje.Clear();
            PobytyNowyStringPokoje.Clear();
            PokojeDS.PokojeDataTable pokojeTable = TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeByTermin(terminOd, terminOd, terminDo, terminDo, terminOd, terminDo);
            foreach (PokojeDS.PokojeRow row in pokojeTable)
            {
                PobytyNowyIdPokoje.Add(row.id_pokoju);
                PobytyNowyStringPokoje.Add(row.nr_pokoju + " | ");
            }
            comboBoxPobytyNowyPokoj.ItemsSource = PobytyNowyStringPokoje;
        }

        private void datePickerPobytyNowyTerminDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sprawdzPokoje(ref datePickerPobytyNowyTerminOd, ref datePickerPobytyNowyTerminDo) == wolnePokoje.Ok)
            {
                PrzypiszWolnePokoje();
            }
        }

        private void datePickerPobytyNowyTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sprawdzPokoje(ref datePickerPobytyNowyTerminOd, ref datePickerPobytyNowyTerminDo) == wolnePokoje.Ok)
            {
                PrzypiszWolnePokoje();
            }
        }
        //----------------------------------------------POBYTY->PODSUMOWANIE----------------------------------------------
        private void buttonPobytyDetails_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                zwinPobyty();
                showWindow(gridPobytyDetails, buttonPobytyBackPrintList);
                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                labelPobytyDetailsKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
                labelPobytyDetailsTelefon.Content = (string)selectedRow["nr_telefonu"].ToString();
                labelPobytyDetailsPesel.Content = (string)selectedRow["pesel"];
                labelPobytyDetailsPokoj.Content = (string)selectedRow["nr_pokoju"];
                labelPobytyDetailsId.Content = selectedRow.id_pobytu;
                //labelPobytyDetailsWymeldowano.Content = 
                labelPobytyDetailsTermin.Content = selectedRow.termin_start.ToLongDateString() + " - " + selectedRow.termin_koniec.ToLongDateString();

                // dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(selectedRow.id_pobytu);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


// ----------------------------------------------KLIENCI----------------------------------------------
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
        //----------------------------------------------KLIENCI->DEAFULT----------------------------------------------
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

        //----------------------------------------------KLIENCI->DODAJ----------------------------------------------
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

        //----------------------------------------------KLIENCI->EDYTUJ----------------------------------------------
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

//----------------------------------------------NEWSLETTER----------------------------------------------
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

//---------------------------------------------------------------------------------------
//----------KIEROWNIK----------
//---------------------------------------------------------------------------------------
//----------------------------------------------POKOJE----------------------------------------------
        private void dataGridPokojeDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
            }
        }
        List<int> PokojeIdLst = new List<int>();
        List<string> PokojeStringLst = new List<string>();

        private void comboBoxPokojeStandard_Loaded(object sender, RoutedEventArgs e)
        {
            PokojeIdLst.Clear();
            PokojeStringLst.Clear();
            PokojeDS.Pokoje_slownikDataTable standardyTable = TablesManager.Manager.Pokoje_slownikTableAdapter.GetData();
            foreach (PokojeDS.Pokoje_slownikRow row in standardyTable)
            {
                PokojeStringLst.Add(row.dodatkowy_opis);
                PokojeIdLst.Add(row.id_slownikowe_pokoju);
            }
            comboBoxPokojeStandard.ItemsSource = PokojeStringLst;
        }
        private void comboBoxPokojeEdycjaStandard_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxPokojeEdycjaStandard.ItemsSource = PokojeStringLst;    
        }

        private void buttonPokojePowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinPokoje();
            showWindow(gridPokojeDeafult, buttonPokojeDeafultList);
        }

        private void buttonPokojeOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPokojeEdycjaNrPokoju.Text != "" && comboBoxPokojeEdycjaStandard.SelectedItem != null)
            {
                PokojeHelper.edytujPokoj((int)labelPokojeEdycjaId.Content,PokojeIdLst[comboBoxPokojeEdycjaStandard.SelectedIndex], textBoxPokojeEdycjaNrPokoju.Text);
                dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
                zwinPokoje();
                showWindow(gridPokojeDeafult, buttonPokojeDeafultList);
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja pokoju", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonPokojeDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPokojeNrPokoju.Text != "" && comboBoxPokojeStandard.SelectedItem != null)
            {
                PokojeHelper.dodajPokoj(PokojeIdLst[comboBoxPokojeStandard.SelectedIndex], textBoxPokojeNrPokoju.Text);
                dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
                textBoxPokojeNrPokoju.Text = "";
                comboBoxPokojeStandard.SelectedItem = null;
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Dodawanie pokoju", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonPokojeEdytuj_Click(object sender, RoutedEventArgs e)
        {
            
            if (dataGridPokojeDeafult.SelectedItem != null)
            {
                zwinPokoje();
                showWindow(gridPokojeEdycja, buttonPokojeBackOkList);

                PokojeDS.PokojeRow selectedRow = ( PokojeDS.PokojeRow)((DataRowView)dataGridPokojeDeafult.SelectedItem).Row;
                textBoxPokojeEdycjaNrPokoju.Text = selectedRow.nr_pokoju;
                comboBoxPokojeEdycjaStandard.SelectedIndex = PokojeIdLst.IndexOf(selectedRow.id_slownikowe_pokoju);
                labelPokojeEdycjaId.Content = selectedRow.id_pokoju;
            }
            else  
                System.Windows.MessageBox.Show("Najpierw wybierz pokój.", "Edycja pokoju", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void buttonPokojeUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPokojeDeafult.SelectedItem != null)
            {
                PokojeDS.PokojeRow selectedRow = (PokojeDS.PokojeRow)
                    ((DataRowView)dataGridPokojeDeafult.SelectedItem).Row;

                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć pokój nr: " + (string)selectedRow["nr_pokoju"], "Usuwanie wyposażenia", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PokojeHelper.usunPokoj(selectedRow.id_pokoju);

                    dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
                }
            } 
        }

//----------------------------------------------STANDARDY POKOI----------------------------------------------

        private void dataGridStandPokoiDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridStandPokoiDeafult.ItemsSource = TablesManager.Manager.Pokoje_slownikTableAdapter.GetData();
            }
        }
        private void buttonStandPokoiPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinStandPokoi();
            showWindow(gridStandPokoiDeafult, buttonStandPokoiDeafultList);
        }

        List<WyposazeniaDS.Wyposazenia_slownikRow> StandPokoiDodajList = new List<WyposazeniaDS.Wyposazenia_slownikRow>();
        List<WyposazeniaDS.Wyposazenia_slownikRow> StandPokoiEdytujList = new List<WyposazeniaDS.Wyposazenia_slownikRow>();
        List<WyposazeniaDS.Wyposazenia_slownikRow> StandPokoiList = new List<WyposazeniaDS.Wyposazenia_slownikRow>();
        List<string> StandPokoiLabelLst = new List<string>();
        private void buttonStandPokoiDodaj_Click(object sender, RoutedEventArgs e)
        {
            zwinStandPokoi();
            showWindow(gridStandPokoiDodaj, buttonStandPokoiBackOkList);

            comboBoxStandPokoiDodajWyposazenie.ItemsSource = StandPokoiLabelLst;
            StandPokoiDodajList.Clear();
            dataGridStandPokoiDodajWyposazenie.ItemsSource = StandPokoiDodajList;
          
        }
        private void comboBoxStandPokoiDodajWyposazenie_Loaded(object sender, RoutedEventArgs e)
        {
            StandPokoiList.Clear();
            StandPokoiLabelLst.Clear();
            WyposazeniaDS.Wyposazenia_slownikDataTable standardyTable = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetData();
            foreach (WyposazeniaDS.Wyposazenia_slownikRow row in standardyTable)
            {
                StandPokoiList.Add(row);
                StandPokoiLabelLst.Add(row.opis);
            }
        }

        private void comboBoxStandPokoiEdycjaWyposazenie_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxStandPokoiEdycjaWyposazenie.ItemsSource = StandPokoiLabelLst;
        }

        private void buttonStandPokoiOk_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid == gridStandPokoiEdycja)
            {
                if (textBoxStandPokoiEdycjaCena.Text != "" && textBoxStandPokoiEdycjaIlOsob.Text!="" &&  textBoxStandPokoiEdycjaOpis.Text!="")
                {
                    int cena;
                    int ilOsob;
                    if (int.TryParse(textBoxStandPokoiEdycjaCena.Text, out cena) && int.TryParse(textBoxStandPokoiEdycjaIlOsob.Text, out ilOsob))
                    {
                    
                    List<int> idLst = new List<int>();
                    foreach (WyposazeniaDS.Wyposazenia_slownikRow row in StandPokoiDodajList)
                    {
                        idLst.Add(row.id_wyposazenia);
                    }
                    PokojeSlownikHelper.edytujKlasePokoi((int)labelStandPokoiEdycjaId.Content, cena, textBoxStandPokoiEdycjaOpis.Text, ilOsob, idLst.ToArray());

                    zwinStandPokoi();
                    showWindow(gridStandPokoiDeafult, buttonStandPokoiDeafultList);
                    }
                    else
                        System.Windows.MessageBox.Show("Pola cena i liczba osób może zawierać tylko cyfry.", "Edycja standardu pokoi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja standardu pokoi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (currentGrid == gridStandPokoiDodaj)
            {
                if (textBoxStandPokoiDodajCena.Text != "" && textBoxStandPokoiDodajIlOsob.Text != "" && textBoxStandPokoiDodajOpis.Text != "")
                {
                    int cena;
                    int ilOsob;
                    if (int.TryParse(textBoxStandPokoiDodajCena.Text, out cena) && int.TryParse(textBoxStandPokoiDodajIlOsob.Text, out ilOsob))
                    {

                        List<int> idLst = new List<int>();
                        foreach (WyposazeniaDS.Wyposazenia_slownikRow row in StandPokoiDodajList)
                        {
                            idLst.Add(row.id_wyposazenia);
                        }
                        PokojeSlownikHelper.dodajKlasePokoi(cena, textBoxStandPokoiDodajOpis.Text, ilOsob, idLst.ToArray());

                        zwinStandPokoi();
                        showWindow(gridStandPokoiDeafult, buttonStandPokoiDeafultList);
                    }
                    else
                        System.Windows.MessageBox.Show("Pola cena i liczba osób może zawierać tylko cyfry.", "Dodaj standard pokoi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Dodaj standard pokoi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
       
        private void buttonStandPokoiDodajWyposazenie_Click(object sender, RoutedEventArgs e)
        {
            if(comboBoxStandPokoiDodajWyposazenie.SelectedItem != null)
                StandPokoiDodajList.Add(StandPokoiList[comboBoxStandPokoiDodajWyposazenie.SelectedIndex]);
            dataGridStandPokoiDodajWyposazenie.Items.Refresh();
        }
        private void buttonStandPokoiDodajWyposazenieUsun_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxStandPokoiDodajWyposazenie.SelectedItem != null)
            {
                foreach (var row in StandPokoiDodajList)
                {
                    if (row.id_wyposazenia == StandPokoiList[comboBoxStandPokoiDodajWyposazenie.SelectedIndex].id_wyposazenia)
                    {
                        StandPokoiDodajList.Remove(row);
                        break;
                    }
                }
            }
            dataGridStandPokoiDodajWyposazenie.Items.Refresh();

        }

        private void buttonStandPokoEdytujWyposazenie_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxStandPokoiEdycjaWyposazenie.SelectedItem != null)
                StandPokoiEdytujList.Add(StandPokoiList[comboBoxStandPokoiEdycjaWyposazenie.SelectedIndex]);
            dataGridStandPokoiEdycjaWyposazenie.Items.Refresh();

        }

        private void buttonStandPokoiEdytujWyposazenieUsun_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxStandPokoiEdycjaWyposazenie.SelectedItem != null)
            {
                foreach(var row in StandPokoiEdytujList)
                {
                    if(row.id_wyposazenia ==  StandPokoiList[comboBoxStandPokoiEdycjaWyposazenie.SelectedIndex].id_wyposazenia)
                    {
                        StandPokoiEdytujList.Remove(row);
                        break;
                    }
                    
                }
            }
            dataGridStandPokoiEdycjaWyposazenie.Items.Refresh();

        } 


        private void buttonStandPokoiEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStandPokoiDeafult.SelectedItem != null)
            {
                zwinStandPokoi();
                showWindow(gridStandPokoiEdycja, buttonStandPokoiBackOkList);
                StandPokoiDodajList.Clear();

                PokojeDS.Pokoje_slownikRow selectedRow = (PokojeDS.Pokoje_slownikRow)((DataRowView)dataGridStandPokoiDeafult.SelectedItem).Row;
                textBoxStandPokoiEdycjaOpis.Text = selectedRow.dodatkowy_opis;
                textBoxStandPokoiEdycjaCena.Text = selectedRow.cena.ToString();
                textBoxStandPokoiEdycjaIlOsob.Text = selectedRow.ilosc_osob.ToString();
                labelStandPokoiEdycjaId.Content = selectedRow.id_slownikowe_pokoju;

                
                WyposazeniaDS.Wyposazenia_slownikDataTable standTable = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetDataListaWyposazenByID(selectedRow.id_slownikowe_pokoju);

                foreach (WyposazeniaDS.Wyposazenia_slownikRow row in standTable)
                {
                    StandPokoiEdytujList.Add(row);
                }
                dataGridStandPokoiEdycjaWyposazenie.ItemsSource = StandPokoiEdytujList;
               // dataGridStandPokoiEdycjaWyposazenie.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetDataListaWyposazenByID(selectedRow.id_slownikowe_pokoju);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pokój.", "Edycja pokoju", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        private void buttonStandPokoiUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStandPokoiDeafult.SelectedItem != null)
            {
                PokojeDS.Pokoje_slownikRow selectedRow = (PokojeDS.Pokoje_slownikRow)((DataRowView)dataGridStandPokoiDeafult.SelectedItem).Row;


                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: " + (string)selectedRow["dodatkowy_opis"], "Usuwanie standardu pokoi", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PokojeSlownikHelper.usunKlasePokoi(selectedRow.id_slownikowe_pokoju);
                    dataGridStandPokoiDeafult.ItemsSource = TablesManager.Manager.Pokoje_slownikTableAdapter.GetData();

                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz standard pokoi", "Usuwanie standardu pokoi", MessageBoxButton.OK, MessageBoxImage.Warning);
      
        }

//----------------------------------------------WYPOSAZENIE----------------------------------------------

        private void dataGridWyposazenieDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridWyposazenieDeafult.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetData();
            }
        }

        private void buttonWyposazenieDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxWyposazenieOpis.Text != "")
            {
                WyposazeniaSlownikHelper.dodajElementWyposazenia(textBoxWyposazenieOpis.Text.ToString());
                dataGridWyposazenieDeafult.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetData();
                textBoxWyposazenieOpis.Text = "";
            }
            else
            {
                System.Windows.MessageBox.Show("Opis nie może być pusty!", "Dodawanie wyposażenia", MessageBoxButton.OK, MessageBoxImage.Error);    
            }
            
        }
        private void buttonWyposazeniePowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinWyposazenie();
            showWindow(gridWyposazenieDeafult, buttonWyposazenieDeafultList);
        }

        private void buttonWyposazenieOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxWyposazenieEdycjaOpis.Text != "")
            {
                WyposazeniaSlownikHelper.edytujElementWyposazenia((int)labelWyposazenieId.Content, textBoxWyposazenieEdycjaOpis.Text);
                dataGridWyposazenieDeafult.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetData();
                zwinWyposazenie();
                showWindow(gridWyposazenieDeafult, buttonWyposazenieDeafultList);
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja wyposażenia", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           }

        private void buttonWyposazenieEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridWyposazenieDeafult.SelectedItem != null)
            {
                zwinWyposazenie();
                showWindow(gridWyposazenieEdytuj, buttonWyposazenieBackOkList);

                WyposazeniaDS.Wyposazenia_slownikRow selectedRow = (WyposazeniaDS.Wyposazenia_slownikRow)((DataRowView)dataGridWyposazenieDeafult.SelectedItem).Row;
                textBoxWyposazenieEdycjaOpis.Text = selectedRow.opis;
                labelWyposazenieId.Content = selectedRow.id_wyposazenia;
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz wyposażenie.", "Edycja wyposażenia", MessageBoxButton.OK, MessageBoxImage.Warning);
  

        }

        private void buttonWyposazenieUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridWyposazenieDeafult.SelectedItem != null)
            {
                WyposazeniaDS.Wyposazenia_slownikRow selectedRow = (WyposazeniaDS.Wyposazenia_slownikRow)
                    ((DataRowView)dataGridWyposazenieDeafult.SelectedItem).Row;

                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: " + (string)selectedRow["opis"], "Usuwanie wyposażenia", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    TablesManager.Manager.Wyposazenia_slownikTableAdapter.DeleteByID(selectedRow.id_wyposazenia);
                    dataGridWyposazenieDeafult.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetData();
                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz wyposażenie.", "Usuwanie wyposażenia", MessageBoxButton.OK, MessageBoxImage.Warning);
       
        }

//----------------------------------------------RABATY----------------------------------------------
        private void dataGridRabatyDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridRabatyDeafult.ItemsSource = TablesManager.Manager.RabatyTableAdapter.GetData();
            }
        }
        private void buttonRabatyPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinRabaty();
            showWindow(gridRabatyDeafult, buttonRabatyDeafultList);
        }

        private void buttonRabatyOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxRabatyEdycjaNazwa.Text != "" && textBoxRabatyEdycjaWartosc.Text != "" )
            {
                int wartosc;
                if (int.TryParse(textBoxRabatyEdycjaWartosc.Text, out wartosc))
                {
					//TODO: zmiana liczby argumentów
                    RabatyHelper.edytujRabat((int)labelRabatyEdycjaId.Content, textBoxRabatyEdycjaNazwa.Text,
                        (bool) checkBoxRabatyEdycjaProcentowy.IsChecked,wartosc, (bool)checkBoxRabatyEdycjaAktywny.IsChecked,
                        (bool)checkBoxRabatyEdycjaPobyty.IsChecked,(bool)checkBoxRabatyEdycjaUslugi.IsChecked,(bool)checkBoxRabatyEdycjaPosilki.IsChecked);
                    dataGridRabatyDeafult.ItemsSource = TablesManager.Manager.RabatyTableAdapter.GetData();
                    zwinRabaty();
                    showWindow(gridRabatyDeafult, buttonRabatyDeafultList);
                }
                else
                    System.Windows.MessageBox.Show("Pole wartość może zawierać tylko cyfry.", "Edycja rabatu", MessageBoxButton.OK, MessageBoxImage.Error);                        
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja rabatu", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonRabatyDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxRabatyNazwa.Text != "" && textBoxRabatyWartosc.Text != "")
            {
                int wartosc;
                if (int.TryParse(textBoxRabatyWartosc.Text, out wartosc))
                {
					//TODO: Zmiana liczby argumentow
                    RabatyHelper.dodajRabat(textBoxRabatyNazwa.Text, (bool)checkBoxRabatyProcentowy.IsChecked, wartosc, (bool)checkBoxRabatyAktywny.IsChecked,
                        (bool)checkBoxRabatyPobyty.IsChecked, (bool)checkBoxRabatyUslugi.IsChecked, (bool)checkBoxRabatyPosilki.IsChecked);
                    dataGridRabatyDeafult.ItemsSource = TablesManager.Manager.RabatyTableAdapter.GetData();
                    textBoxRabatyNazwa.Text = "";
                    textBoxRabatyWartosc.Text = "";
                }
                else
                    System.Windows.MessageBox.Show("Pole wartość może zawierać tylko cyfry.", "Dodawanie rabatu", MessageBoxButton.OK, MessageBoxImage.Error);               
            }
            else
            {
                System.Windows.MessageBox.Show("Uzupełnij wszytstkie pola.", "Dodawanie rabatu", MessageBoxButton.OK, MessageBoxImage.Warning);        
            }
        }  
      
        private void buttonRabatyEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRabatyDeafult.SelectedItem != null)
            {
                zwinRabaty();
                showWindow(gridRabatyEdycja, buttonRabatyBackOkList);

                RachunkiDS.RabatyRow selectedRow = (RachunkiDS.RabatyRow)((DataRowView)dataGridRabatyDeafult.SelectedItem).Row;
                textBoxRabatyEdycjaNazwa.Text = selectedRow.nazwa;
                textBoxRabatyEdycjaWartosc.Text = selectedRow.wartosc.ToString();
                checkBoxRabatyEdycjaAktywny.IsChecked = selectedRow.aktywny;
                checkBoxRabatyEdycjaProcentowy.IsChecked = selectedRow.procentowy;
                checkBoxRabatyEdycjaPobyty.IsChecked = selectedRow.na_pobyt;
                checkBoxRabatyEdycjaUslugi.IsChecked = selectedRow.na_uslugi;
                checkBoxRabatyEdycjaPobyty.IsChecked = selectedRow.na_posilki;
                labelRabatyEdycjaId.Content = selectedRow.id_rabatu;
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz rabat.", "Edycja rabatu", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        
        private void buttonRabatyUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridRabatyDeafult.SelectedItem != null)
            { DS.RachunkiDS.RabatyRow selectedRow = (RachunkiDS.RabatyRow)((DataRowView)dataGridRabatyDeafult.SelectedItem).Row;
               

                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: " + (string)selectedRow["nazwa"], "Usuwanie rabatu", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    RabatyHelper.kasujRabat((int)selectedRow["id_rabatu"]);
                    dataGridRabatyDeafult.ItemsSource = TablesManager.Manager.RabatyTableAdapter.GetData();
                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz rabat.", "Usuwanie rabatu", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

//----------------------------------------------POSIŁKI----------------------------------------------
        private void dataGridPosilkiDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPosilkiDeafult.ItemsSource = TablesManager.Manager.Posilki_slownikTableAdapter.GetData();
            }
        }

        private void buttonPosilkiPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinPosilki();
            showWindow(gridPosilkiDeafult, buttonPosilkiDeafultList);
        }
        private void buttonPosilkiOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPosilkiEdycjaNazwa.Text != "" && textBoxPosilkiEdycjaCena.Text != "")
            {
                int cena;
                if (int.TryParse(textBoxPosilkiEdycjaCena.Text, out cena))
                {
                    PosilkiSlownikHelper.edytujTypPosilku((int)labelPosilkiEdycjaID.Content, cena, textBoxPosilkiEdycjaNazwa.Text, (bool)checkBoxPosilkiEdycjaObiad.IsChecked,
                        (bool)checkBoxPosilkiEdycjaSniad.IsChecked, (bool)checkBoxPosilkiEdycjaKolacja.IsChecked, (bool)checkBoxPosilkiEdycjaDrSniad.IsChecked,
                        (bool)checkBoxPosilkiEdycjaLunch.IsChecked, (bool)checkBoxPosilkiEdycjaObiadkol.IsChecked, (bool)checkBoxPosilkiEdycjaPodwiecz.IsChecked);
                    dataGridPosilkiDeafult.ItemsSource = TablesManager.Manager.Posilki_slownikTableAdapter.GetData();
                    zwinPosilki();
                    showWindow(gridPosilkiDeafult, buttonPosilkiDeafultList);
                }
                else
                    System.Windows.MessageBox.Show("Pole cena może zawierać tylko cyfry.", "Dodawanie pakietu posiłku", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                System.Windows.MessageBox.Show("Uzupełnij wszytstkie pola.", "Dodawanie pakietu posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void buttonPosilkiEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPosilkiDeafult.SelectedItem != null)
            {
                zwinPosilki();
                showWindow(gridPosilkiEdycja, buttonPosilkiBackOkList);

                PosilkiDS.Posilki_slownikRow selectedRow = (PosilkiDS.Posilki_slownikRow)((DataRowView)dataGridPosilkiDeafult.SelectedItem).Row;
                textBoxPosilkiEdycjaNazwa.Text = selectedRow.nazwa_opcji;
                textBoxPosilkiEdycjaCena.Text = selectedRow.cena.ToString();
                checkBoxPosilkiEdycjaKolacja.IsChecked = selectedRow.sniadanie;
                checkBoxPosilkiEdycjaLunch.IsChecked = selectedRow.lunch;
                checkBoxPosilkiEdycjaObiad.IsChecked = selectedRow.obiad;
                checkBoxPosilkiEdycjaObiadkol.IsChecked = selectedRow.obiadokolacja;
                checkBoxPosilkiEdycjaPodwiecz.IsChecked = selectedRow.podwieczorek;
                checkBoxPosilkiEdycjaSniad.IsChecked = selectedRow.sniadanie;
                checkBoxPosilkiEdycjaDrSniad.IsChecked = selectedRow.drugie_sniadanie;
                labelPosilkiEdycjaID.Content = selectedRow.id_slownikowe_posilku;
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz posiłek.", "Edycja posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);
       
        }

        private void buttonPoslikiDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPosilkiNazwa.Text != "" && textBoxPosilkiCena.Text != "")
            {
                int cena;
                if (int.TryParse(textBoxPosilkiCena.Text, out cena))
                {
                    PosilkiSlownikHelper.dodajTypPosilku(cena, textBoxPosilkiNazwa.Text, (bool)checkBoxPosilkiObiad.IsChecked,
                        (bool)checkBoxPosilkiSniadanie.IsChecked, (bool)checkBoxPosilkiKolacja.IsChecked, (bool)checkBoxPosliki2Sniad.IsChecked,
                        (bool)checkBoxPosilkiLunch.IsChecked, (bool)checkBoxPosilkiObiadokolacja.IsChecked, (bool)checkBoxPosilkiPodwieczorek.IsChecked);
                    dataGridPosilkiDeafult.ItemsSource = TablesManager.Manager.Posilki_slownikTableAdapter.GetData();
                    textBoxPosilkiNazwa.Text = "";
                    textBoxPosilkiCena.Text = "";
                    checkBoxPosilkiKolacja.IsChecked = false;
                    checkBoxPosilkiLunch.IsChecked = false;
                    checkBoxPosilkiObiad.IsChecked = false;
                    checkBoxPosilkiObiadokolacja.IsChecked = false;
                    checkBoxPosilkiPodwieczorek.IsChecked = false;
                    checkBoxPosilkiSniadanie.IsChecked = false;
                    checkBoxPosliki2Sniad.IsChecked = false;
                }
                else
                    System.Windows.MessageBox.Show("Pole cena może zawierać tylko cyfry.", "Dodawanie pakietu posiłku", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                System.Windows.MessageBox.Show("Uzupełnij wszytstkie pola.", "Dodawanie pakietu posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonPosilkiUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPosilkiDeafult.SelectedItem != null)
            {
                PosilkiDS.Posilki_slownikRow selectedRow = (PosilkiDS.Posilki_slownikRow)
                    ((DataRowView)dataGridPosilkiDeafult.SelectedItem).Row;
                // + (string)selectedRow["nazwa_opcji"]
                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: ", "Usuwanie pakietu posiłku", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PosilkiHelper.usunPosilek((int)selectedRow["id_slownikowe_posilku"]);
                    dataGridPosilkiDeafult.ItemsSource = TablesManager.Manager.Posilki_slownikTableAdapter.GetData();
                   
                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz posiłek.", "Usuwanie pakietu posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);
       
        }

//----------------------------------------------USŁUGI----------------------------------------------
        private void dataGridUslugiDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridUslugiDeafult.ItemsSource = TablesManager.Manager.Uslugi_slownikTableAdapter.GetDataPlusSlownikPracownicy();
            }
        }
        List<int> uslugiStanowiskaIdLst = new List<int>();
        List<string> uslugiStanowiskaStringLst = new List<string>();
        private void comboBoxUslugiWykonawca_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            uslugiStanowiskaIdLst.Clear();
            uslugiStanowiskaStringLst.Clear();
            PracownicyDS.Pracownicy_slownikDataTable uslugiTable = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();
            foreach (PracownicyDS.Pracownicy_slownikRow row in uslugiTable)
            {
                uslugiStanowiskaStringLst.Add(row.nazwa + " (" + row.opis + ")");
                uslugiStanowiskaIdLst.Add(row.id_stanowiska);
            }
            comboBoxUslugiWykonawca.ItemsSource = uslugiStanowiskaStringLst;
        }

        private void comboBoxUslugiEdycjaWykonawca_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            comboBoxUslugiEdycjaWykonawca.ItemsSource = uslugiStanowiskaStringLst;
        }

        private void buttonUslugiPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinUslugi();
            showWindow(gridUslugiDeafult, buttonUslugiDeafultList);
        }

        private void buttonUslugiOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUslugiEdycjaNazwa.Text != "" && textBoxUslugiEdycjaOpis.Text != "" && textBoxUslugiEdycjaCena.Text != "" 
                && comboBoxUslugiEdycjaWykonawca.SelectedItem != null)
            {
                int cena;
                if (int.TryParse(textBoxUslugiEdycjaCena.Text, out cena))
                {
                    UslugiSlownikHelper.edytujTypUslugi((int)labelUslugiEdycjaId.Content, cena, textBoxUslugiEdycjaNazwa.Text, textBoxUslugiEdycjaOpis.Text,
                        uslugiStanowiskaIdLst[comboBoxUslugiEdycjaWykonawca.SelectedIndex]);
                    dataGridUslugiDeafult.ItemsSource = TablesManager.Manager.Uslugi_slownikTableAdapter.GetDataPlusSlownikPracownicy();
                    zwinUslugi();
                    showWindow(gridUslugiDeafult, buttonUslugiDeafultList);
                }
                else
                    System.Windows.MessageBox.Show("Pole wartość może zawierać tylko cyfry.", "Edycja usługi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja usługi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonUslugiEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUslugiDeafult.SelectedItem != null)
            {
                zwinUslugi();
                showWindow(gridUslugiEdycja, buttonUslugiBackOkList);

                UslugiDS.Uslugi_slownikRow selectedRow = (UslugiDS.Uslugi_slownikRow)((DataRowView)dataGridUslugiDeafult.SelectedItem).Row;
                textBoxUslugiEdycjaNazwa.Text = (string)selectedRow["nazwaUslugi"];
                textBoxUslugiEdycjaOpis.Text = (string)selectedRow["opisUslugi"]; 
                textBoxUslugiEdycjaCena.Text = selectedRow.cena.ToString();
                comboBoxUslugiEdycjaWykonawca.SelectedIndex = uslugiStanowiskaIdLst.IndexOf(selectedRow.id_stanowiska);
                labelUslugiEdycjaId.Content = selectedRow.id_slownikowe_uslugi;
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz usługę.", "Edycja usługi", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void buttonUslugiDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxUslugiNazwa.Text != "" && textBoxUslugiCena.Text != "" && textBoxUslugiOpis.Text != "" && comboBoxUslugiWykonawca.SelectedItem !=null)
            {
                int cena;
                if (int.TryParse(textBoxUslugiCena.Text, out cena))
                {
                    UslugiSlownikHelper.dodajTypUslugi(cena,textBoxUslugiNazwa.Text,textBoxUslugiOpis.Text,uslugiStanowiskaIdLst[comboBoxUslugiWykonawca.SelectedIndex]);
                    dataGridUslugiDeafult.ItemsSource = TablesManager.Manager.Uslugi_slownikTableAdapter.GetDataPlusSlownikPracownicy();
                    textBoxUslugiNazwa.Text = "";
                    textBoxUslugiCena.Text = "";
                    textBoxUslugiOpis.Text = "";
                    comboBoxUslugiWykonawca.SelectedItem = null;
                }
                else
                    System.Windows.MessageBox.Show("Pole wartość może zawierać tylko cyfry.", "Dodawanie rabatu", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                System.Windows.MessageBox.Show("Uzupełnij wszytstkie pola.", "Dodawanie rabatu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void buttonUslugiUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridUslugiDeafult.SelectedItem != null)
            {
                UslugiDS.Uslugi_slownikRow selectedRow = (UslugiDS.Uslugi_slownikRow)
                    ((DataRowView)dataGridUslugiDeafult.SelectedItem).Row;
                // + (string)selectedRow["nazwa_opcji"]
                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: "+ (string)selectedRow["nazwa"], "Usuwanie uslugi", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    UslugiHelper.usunUsluge((int)selectedRow.id_slownikowe_uslugi);
                    dataGridUslugiDeafult.ItemsSource = TablesManager.Manager.Uslugi_slownikTableAdapter.GetDataPlusSlownikPracownicy();

                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz usługę.", "Usuwanie usługi", MessageBoxButton.OK, MessageBoxImage.Warning);
       
        }

//----------------------------------------------PRACOWNICY----------------------------------------------
        private void dataGridPracownicyDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiska();
            }
        }
        List<int> stanowiskaIdList = new List<int>();
        List<string> stanowiskaStringList = new List<string>();
        private void comboBoxPracownicyDodajStanowisko_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            stanowiskaIdList.Clear();
            stanowiskaStringList.Clear();
            PracownicyDS.Pracownicy_slownikDataTable uslugiTable = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();
            foreach (PracownicyDS.Pracownicy_slownikRow row in uslugiTable)
            {
                stanowiskaStringList.Add(row.nazwa + " (" + row.opis +")");
                stanowiskaIdList.Add(row.id_stanowiska);
            }
            comboBoxPracownicyDodajStanowisko.ItemsSource = stanowiskaStringList;
            comboBoxPracownicyEdycjaStanowisko.ItemsSource = stanowiskaStringList;
        }

        private void comboBoxPracownicyEdycjaStanowisko_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

            comboBoxPracownicyEdycjaStanowisko.ItemsSource = stanowiskaStringList;
        }

        //----------------------------------------------PRACOWNICY->MENU
        private void buttonPracownicySzukaj_Click(object sender, RoutedEventArgs e)
        {
            SzukajPracownika();
        }
       

        private void buttonPracownicyDodaj_Click(object sender, RoutedEventArgs e)
        {
            zwinPracownicy();
            showWindow(gridPracownicyDodaj, buttonPracownicyBackOkList);
        }

        private void buttonPracownicyOk_Click(object sender, RoutedEventArgs e)
        {
            if (currentGrid == gridPracownicyDodaj)
            {
                if (textBoxPracownicyDodajImie.Text != "" && textBoxPracownicyDodajNazwisko.Text != "" && textBoxPracownicyDodajLogin.Text != ""
                    && comboBoxPracownicyDodajStanowisko.SelectedItem != null)
                {
                    PracownicyHelper.dodajPracownika(textBoxPracownicyDodajImie.Text, textBoxPracownicyDodajNazwisko.Text,
                        textBoxPracownicyDodajLogin.Text, textBoxPracownicyDodajLogin.Text, stanowiskaIdList[comboBoxPracownicyDodajStanowisko.SelectedIndex]);
                    dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiska(); 
                    textBoxPracownicyDodajImie.Text = "";
                    textBoxPracownicyDodajNazwisko.Text = "";
                    textBoxPracownicyDodajLogin.Text = "";
                    zwinPracownicy();
                    showWindow(gridPracownicyDeafult, buttonPracownicyDeafultList);
               
                }
                else
                {
                    System.Windows.MessageBox.Show("Uzupełnij wszytstkie pola.", "Dodawanie pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (currentGrid == gridPracownicyEdycja)
            {
                if (textBoxPracownicyEdycjaImie.Text != "" && textBoxPracownicyEdycjaNazwisko.Text != "" && textBoxPracownicyEdycjaLogin.Text != ""
                     && comboBoxPracownicyEdycjaStanowisko.SelectedItem != null)
                {

                PracownicyHelper.edytujPracownikaByIdPr(textBoxPracownicyEdycjaImie.Text,textBoxPracownicyEdycjaNazwisko.Text,
                    textBoxPracownicyEdycjaLogin.Text, textBoxPracownicyEdycjaLogin.Text, 1, stanowiskaIdList[comboBoxPracownicyEdycjaStanowisko.SelectedIndex]);    

                dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiska(); 
                   
                zwinPracownicy();
                showWindow(gridPracownicyDeafult, buttonPracownicyDeafultList);
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja usługi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            }
        }

        private void buttonPracownicyPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinPracownicy();
            showWindow(gridPracownicyDeafult, buttonPracownicyDeafultList);
        }

        private void buttonPracownicyEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPracownicyDeafult.SelectedItem != null)
            {
                zwinPracownicy();
                showWindow(gridPracownicyEdycja, buttonPracownicyBackOkList);
                PracownicyDS.PracownicyRow selectedRow = (PracownicyDS.PracownicyRow)((DataRowView)dataGridPracownicyDeafult.SelectedItem).Row;
                textBoxPracownicyEdycjaImie.Text = selectedRow.imie;
                textBoxPracownicyEdycjaNazwisko.Text = selectedRow.nazwisko;
                textBoxPracownicyEdycjaLogin.Text = selectedRow.login;
                /*
                textBoxPracownicyEdycjaPESEL.Text = selectedRow.Pesel;
                textBoxPracownicyEdycjaNIP.Text = selectedRow.Nip;
                textBoxPracownicyEdycjaAdres.Text = selectedRow.Adres;
                textBoxPracownicyEdycjaMiejscowosc.Text = selectedRow.Miejscowosc;
                textBoxPracownicyEdycjaKodPocztowy.Text = selectedRow.KodPocztowy;
                textBoxPracownicyEdycjaTelefon.Text = selectedRow.Telefon;
                */
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pracownika.", "Edycja pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);
       
            
        }

        private void buttonPracownicyUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPracownicyDeafult.SelectedItem != null)
            {
                PracownicyDS.PracownicyRow selectedRow = (PracownicyDS.PracownicyRow)((DataRowView)dataGridPracownicyDeafult.SelectedItem).Row;
                // + (string)selectedRow["nazwa_opcji"]
                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: " + (string)selectedRow["imie"] + " " 
                    + (string)selectedRow["nazwisko"], "Usuwanie pracownika", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PracownicyHelper.usunPracownika(selectedRow.id_pracownika);
                    dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiska();

                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pracownika.", "Usuwanie pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);
       
        }

        private void SzukajPracownika()
        {
            if (textBoxPracownicySzukaj.Text == "")
                dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiska();
            else
            {
                if ((bool)radioButtonPracownicyId.IsChecked)
                {
                    int id;
                    if (int.TryParse(textBoxPracownicySzukaj.Text, out id))
                        dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiskaById(id);
                    else
                        System.Windows.MessageBox.Show("Niepoprawne ID pracownika.\nNumer identyfikacyjny pracownika może zawierać tylko cyfry.", "Wyszukiwanie pracownika", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if ((bool)radioButtonPracownicyNazwisko.IsChecked)
                {
                    dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiskaByNazwisko(textBoxPracownicySzukaj.Text);
                }
            }
        }
        private void buttonPracownicyZadania_Click(object sender, RoutedEventArgs e)
        { 
            if (dataGridPracownicyDeafult.SelectedItem != null)
            {
                zwinPracownicy();
                showWindow(gridPracownicyZadania, buttonPracownicyBackList);
                PracownicyDS.PracownicyRow selectedRow = (PracownicyDS.PracownicyRow)((DataRowView)dataGridPracownicyDeafult.SelectedItem).Row;
                dataGridPracownicyZadania.ItemsSource = 
                TablesManager.Manager.UslugiTableAdapter.GetDataByIdPracownikaPrzedzialCzasu(selectedRow.id_pracownika, DateTime.Now, DateTime.Now);
               
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pracownika.", "Usuwanie pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);       
        }
       
//----------------------------------------------STANOWISKA----------------------------------------------
        private void dataGridStanowiskaDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridStanowiskaDeafult.ItemsSource = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();
            }
        }

        private void buttonStanowiskaEdytuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStanowiskaDeafult.SelectedItem != null)
            {
                zwinStanowiska();
                showWindow(gridStanowiskaEdycja, buttonStanowiskaBackOkList);

                PracownicyDS.Pracownicy_slownikRow selectedRow = (PracownicyDS.Pracownicy_slownikRow)
                    ((DataRowView)dataGridStanowiskaDeafult.SelectedItem).Row;
                textBoxStanowiskaEdycjaNazwa.Text = selectedRow.nazwa;
                textBoxStanowiskaEdycjaOpis.Text = selectedRow.opis;               
                labelStanowiskaEdycjaId.Content = selectedRow.id_stanowiska;
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz stanowisko.", "Edycja stanowiska", MessageBoxButton.OK, MessageBoxImage.Warning);


        }

        private void buttonStanowiskaPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinStanowiska();
            showWindow(gridStanowiskaDeafult, buttonStanowiskaDeafultList);
        }

        private void buttonStanowiskaOk_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxStanowiskaEdycjaNazwa.Text != "" && textBoxStanowiskaEdycjaOpis.Text != "" )
            {
                PracownicyHelper.edytujStanowisko(textBoxStanowiskaEdycjaNazwa.Text, textBoxStanowiskaEdycjaOpis.Text,int.Parse(labelStanowiskaEdycjaId.Content.ToString()));               
                dataGridStanowiskaDeafult.ItemsSource = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();
                zwinStanowiska();
                showWindow(gridStanowiskaDeafult, buttonStanowiskaDeafultList);
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja stanowiska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonStanowiskaDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxStanowiskaNazwa.Text != "" && textBoxStanowiskaOpis.Text != "" )
            {
                PracownicyHelper.dodajStanowisko(textBoxStanowiskaNazwa.Text, textBoxStanowiskaOpis.Text);
                dataGridStanowiskaDeafult.ItemsSource = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();
               
                textBoxStanowiskaNazwa.Text = "";
                textBoxStanowiskaOpis.Text = ""; 
            }
            else
            {
                System.Windows.MessageBox.Show("Uzupełnij wszytstkie pola.", "Dodawanie stanowiska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void buttonStanowiskaUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStanowiskaDeafult.SelectedItem != null)
            {
                PracownicyDS.Pracownicy_slownikRow selectedRow = (PracownicyDS.Pracownicy_slownikRow)
                    ((DataRowView)dataGridStanowiskaDeafult.SelectedItem).Row;
                // + (string)selectedRow["nazwa_opcji"]
                MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: " + (string)selectedRow["nazwa"], "Usuwanie stanowiska", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    PracownicyHelper.usunStanowisko(selectedRow.id_stanowiska);
                    dataGridStanowiskaDeafult.ItemsSource = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();

                }
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz stanowisko.", "Usuwanie stanowiska", MessageBoxButton.OK, MessageBoxImage.Warning);
       
        }

//----------------------------------------------ZADANIA----------------------------------------------
        private void dataGridZadaniaDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {
                DateTime czasObecny = DateTime.Now;
                int rok = czasObecny.Year;
                int miesiac = czasObecny.Month;
                int dzien = czasObecny.Day;
                DateTime czasStart = new DateTime(rok, miesiac, dzien, 0, 0, 0);
                DateTime czasStop = new DateTime(rok, miesiac, dzien, 23, 59, 59);
                dataGridZadaniaDeafult.ItemsSource = UslugiHelper.znajdzZadaniaDlaPracownikaWCzasie(this.id, czasStart, czasStop);
            }
        }

        private void dataGridArchiwumDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {
                DateTime czasObecny = DateTime.Now;
                int rok = czasObecny.Year;
                int miesiac = czasObecny.Month;
                int dzien = czasObecny.Day - 1;
                DateTime czasStop = new DateTime(rok, miesiac, dzien, 23, 59, 59);
                dataGridZadaniaDeafult.ItemsSource = UslugiHelper.znajdzZadaniaPracownikaDoCzasu(this.id, czasStop);
            }
        }

        private void buttonZadaniaPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinZadania();
            showWindow(gridZadaniaDeafult, buttonZadaniaDeafultList);
        }

        private void buttonZadaniaArchiwum_Click(object sender, RoutedEventArgs e)
        {
            zwinZadania();
            showWindow(gridZadaniaArchiwum, buttonZadaniaBackList);
        }

        private void buttonWyloguj_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Czy na pewno chcesz się wylogować?", "Wylogowanie", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Logowanie oknoLogowania = new Logowanie();
                this.Close();
                oknoLogowania.ShowDialog();
            }
        }



    }

}
