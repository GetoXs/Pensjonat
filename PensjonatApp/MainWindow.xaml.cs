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
        private List<Button> buttonPobytyZarzadzajList = new List<Button>();
        private List<Button> buttonPobytyBackOkList = new List<Button>();
        private List<Button> buttonPobytyOkList = new List<Button>();
        private List<Button> buttonPobytyBackPrintList = new List<Button>();
        private List<Button> buttonKlienciDeafultList = new List<Button>();
        private List<Button> buttonKlienciBackOkList = new List<Button>();
        private List<Button> buttonKlienciBackList = new List<Button>();
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
            this.stanowisko = stanowisko;
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
                    tabKucharz.Visibility = Visibility.Collapsed;
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
                    tabKucharz.Visibility = Visibility.Collapsed;
                    break;

                case "Kucharz":
                    tabControl1.SelectedIndex = 14;
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
                    tabZadania.Visibility = Visibility.Collapsed;
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
                    tabKucharz.Visibility = Visibility.Collapsed;
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
            buttonPobytyZarzadzajList.Add(buttonPobytyPowrot);
            buttonPobytyZarzadzajList.Add(buttonPobytyZarzadzajPosilki);
            buttonPobytyZarzadzajList.Add(buttonPobytyZarzadzajUslugi);
            buttonPobytyDeafultList.Add(buttonPobytySum);
            buttonPobytyDeafultList.Add(buttonPobytyNowy);
            buttonPobytyDeafultList.Add(buttonPobytyDrukuj);
            buttonPobytyBackOkList.Add(buttonPobytyPowrot);
            buttonPobytyBackOkList.Add(buttonPobytyOk);
            buttonPobytyOkList.Add(buttonPobytyOk);
            buttonPobytyBackPrintList.Add(buttonPobytyPowrot);
            buttonPobytyBackPrintList.Add(buttonPobytyDrukuj);

            buttonKlienciDeafultList.Add(buttonKlienciAdd);
            buttonKlienciDeafultList.Add(buttonKlienciEdit);
            buttonKlienciDeafultList.Add(buttonKlienciSzczegoly);
            buttonKlienciBackOkList.Add(buttonKlienciPowrot);
            buttonKlienciBackList.Add(buttonKlienciPowrot);
            buttonKlienciBackOkList.Add(buttonKlienciOk);

            buttonPokojeDeafultList.Add(buttonPokojeUsun);
            buttonPokojeDeafultList.Add(buttonPokojeEdytuj);
            buttonPokojeDeafultList.Add(buttonPokojeSzczegoly);
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
            buttonStandPokoiDeafultList.Add(buttonStandPokoiSzczegoly);
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
            buttonZadaniaBackList.Add(buttonZadaniaZrealizuj);


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
            grid.Height = Double.NaN;
            grid.MinHeight = 500;
            grid.MaxHeight = 900;
            grid.Visibility = Visibility.Visible;
            pokazButtonList(buttonList);
            currentGrid = grid;
            if (grid == gridRezerwacjeDeafult)
                dataGridRezerwacjeSzukaj.ItemsSource = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeKlienci();
            
        }
        private void zwinRezerwacje()
        {
            gridRezerwacjeDeafult.Visibility = Visibility.Collapsed;
            gridRezerwacjeAdd.Visibility = Visibility.Collapsed;
            gridRezerwacjeAdd2.Visibility = Visibility.Collapsed; ;
            gridRezerwacjeDel.Visibility = Visibility.Collapsed;
            gridRezerwacjeCheck.Visibility = Visibility.Collapsed;
            gridRezerwacjeAddKlient.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonRezerwacjeBackForwardList);
            zwinButtonList(buttonRezerwacjeDeafultList);
            zwinButtonList(buttonRezerwacjeBackOkList); 
        }

       
        private void zwinPobyty()
        {
            gridPobytyDeafult.Visibility = Visibility.Collapsed;
            gridPobytyServices.Visibility = Visibility.Collapsed;
            gridPobytySum.Visibility = Visibility.Collapsed;
            gridPobytyUslugi.Visibility = Visibility.Collapsed;
            gridPobytyPosilki.Visibility = Visibility.Collapsed;
            gridPobytyNowy.Visibility = Visibility.Collapsed;
            gridPobytyWybierzKlienta.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonPobytyBackOkList);
            zwinButtonList(buttonPobytyBackOkList);
            zwinButtonList(buttonPobytyBackPrintList);
            zwinButtonList(buttonPobytyDeafultList);
            zwinButtonList(buttonPobytyZarzadzajList);
        }

        private void zwinKlienci()
        {
            gridKlienciDeafult.Visibility = Visibility.Collapsed;
            gridKlienciAdd.Visibility = Visibility.Collapsed;
            gridKlienciEdit.Visibility = Visibility.Collapsed;
            gridKlienciSzczegoly.Visibility = Visibility.Collapsed;
            zwinButtonList(buttonKlienciBackOkList);
            zwinButtonList(buttonKlienciDeafultList);
        }
        private void zwinPokoje()
        {
            gridPokojeDeafult.Visibility = Visibility.Collapsed;
            gridPokojeEdycja.Visibility = Visibility.Collapsed;
            gridPokojeSzczegoly.Visibility = Visibility.Collapsed;
            gridKlienciSzczegoly.Visibility = Visibility.Collapsed;
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
            gridStandPokoiSzczegoly.Visibility = Visibility.Collapsed;
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
                    TimeSpan liczbaDni = datePickerRezerwacjeAddTerminDo.SelectedDate.Value.Date - datePickerRezeracjeAddTerminOd.SelectedDate.Value.Date;
                    textBoxRezerwacjeAdd2Zaliczka.Text = RozliczenieHelper.liczZaliczke(RezerwacjePokojeDodajList, liczbaDni.Days, 0.2).ToString();
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
            if (rezerwacjePokojeIloscOsob > 0)
            {
                System.Windows.MessageBox.Show("Przydzielono zbyt mało pokoi.", "Dodawanie rezerwacji", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (rezerwacjePokojeIloscOsob < 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Wybrano większą liczbę pokoi niż osób. Czy chcesz kontynuować?", "Dodawanie rezerwacji", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                    return true;
                else
                    return false;
            }
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
				decimal zaliczka;
				if (decimal.TryParse(textBoxRezerwacjeAdd2Zaliczka.Text, out zaliczka))
				{
                    List<int> idList = new List<int>();
                    foreach(var elem in RezerwacjePokojeDodajList)
                    {
                        idList.Add(elem.Id_pokoju);
                    }
                    RezerwacjeHelper.dodajRezerwacje((int)labelRezerwacjeAddId.Content, int.Parse(labelRezerwacjeAdd2IlOsob.Content.ToString()), zaliczka,
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
        List<PokojeStandardy> RezerwacjePokojeList = new List<PokojeStandardy>();
        List<PokojeStandardy> RezerwacjePokojeDodajList = new List<PokojeStandardy>();
        List<PokojeDS.Pokoje_slownikRow> RezerwacjePokojeSlownikList = new List<PokojeDS.Pokoje_slownikRow>();
        int rezerwacjePokojeIloscOsob;
        private void dataGridRezerwacjeAddWybranePokoje_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridRezerwacjeAddWybranePokoje.ItemsSource = RezerwacjePokojeDodajList;
        }

 
        private void buttonRezerwacjeDodajPokoje_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxRezerwacjeAddKlient.Text != "" && datePickerRezeracjeAddTerminOd.SelectedDate != null && datePickerRezerwacjeAddTerminDo.SelectedDate != null
                && textBoxRezerwacjeAddIlOsob.Text != "")
            {
                int liczbaOsob;
                if (int.TryParse(textBoxRezerwacjeAddIlOsob.Text, out liczbaOsob))
                {
                    buttonRezerwacjeAddKlient.IsEnabled = false;
                    textBoxRezerwacjeAddIlOsob.IsEnabled = false;
                    datePickerRezeracjeAddTerminOd.IsEnabled = false;
                    datePickerRezerwacjeAddTerminDo.IsEnabled = false;
                    DodajPokojdeDoComboBoxa();
                    RezerwacjePokojeDodajList.Clear();
                    dataGridRezerwacjeAddWybranePokoje.Items.Refresh();
                    rezerwacjePokojeIloscOsob = liczbaOsob;
                    labelRezerwacjeAddPozostaloOsob.Content = rezerwacjePokojeIloscOsob;
                    System.Windows.MessageBox.Show("Liczba znalezionych wolnych pokoi w podanym terminie: " + comboBoxRezerwacjeAddPokoje.Items.Count, "Wyszukiwanie wolnych pokoi", MessageBoxButton.OK, MessageBoxImage.Information);
                    comboBoxRezerwacjeAddPokoje.IsDropDownOpen = true;
                }
                else
                    System.Windows.MessageBox.Show("Pole liczba osób może zawierać tylko cyfry.", "Nowa rezerwacja", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola!", "Nowa rezerwacja", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void buttonRezerwacjeDodajZmien_Click(object sender, RoutedEventArgs e)
        {
            buttonRezerwacjeAddKlient.IsEnabled = true;
            textBoxRezerwacjeAddIlOsob.IsEnabled = true;
            datePickerRezeracjeAddTerminOd.IsEnabled = true;
            datePickerRezerwacjeAddTerminDo.IsEnabled = true;
            labelRezerwacjeAddPozostaloOsob.Content = "";
            rezerwacjePokojeIloscOsob = 0;
            RezerwacjePokojeDodajList.Clear();
            comboBoxRezerwacjeAddPokoje.ItemsSource = null;
            dataGridRezerwacjeAddWybranePokoje.Items.Refresh();
        }
        private void datePickerRezeracjeAddTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzTermin(ref datePickerRezeracjeAddTerminOd, ref datePickerRezerwacjeAddTerminDo);
        }

        private void datePickerRezerwacjeAddTerminDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzTermin(ref datePickerRezeracjeAddTerminOd, ref datePickerRezerwacjeAddTerminDo);
        }

      

        private void buttonRezerwacjeAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinRezerwacje();
            showWindow(gridRezerwacjeAdd, buttonRezerwacjeBackForwardList);
            rezerwacjePokojeIloscOsob = 0;
            textBoxRezerwacjeAddIlOsob.Text = "";
            textBoxRezerwacjeAddKlient.Text = "";
            labelRezerwacjeAddId.Content = "";
            datePickerRezeracjeAddTerminOd.SelectedDate = null;
            datePickerRezerwacjeAddTerminDo.SelectedDate = null;
            buttonRezerwacjeAddKlient.IsEnabled = true;
            textBoxRezerwacjeAddIlOsob.IsEnabled = true;
            datePickerRezeracjeAddTerminOd.IsEnabled = true;
            datePickerRezerwacjeAddTerminDo.IsEnabled = true;
            comboBoxRezerwacjeAddPokoje.ItemsSource = null;
            RezerwacjePokojeDodajList.Clear();
            dataGridRezerwacjeAddWybranePokoje.Items.Refresh();
        }

        
        private void buttonRezerwacjeAddDodajPokoj_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxRezerwacjeAddPokoje.SelectedItem != null && !RezerwacjePokojeDodajList.Contains(RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex]))
            {
                RezerwacjePokojeDodajList.Add(RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex]);
                rezerwacjePokojeIloscOsob -= RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex].L_osob;
                labelRezerwacjeAddPozostaloOsob.Content = rezerwacjePokojeIloscOsob;
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
                    if (row.Id_pokoju == RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex].Id_pokoju)
                    {
                        RezerwacjePokojeDodajList.Remove(row);
                        rezerwacjePokojeIloscOsob += RezerwacjePokojeList[comboBoxRezerwacjeAddPokoje.SelectedIndex].L_osob;
                        labelRezerwacjeAddPozostaloOsob.Content = rezerwacjePokojeIloscOsob;
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
        private wolnePokoje sprawdzTermin(ref DatePicker terminOd,ref DatePicker terminDo)
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
			if (sprawdzTermin(ref datePickerRezeracjeAddTerminOd, ref datePickerRezerwacjeAddTerminDo) == wolnePokoje.Ok)
			{
				RezerwacjePokojeList.Clear();
				RezerwacjePokojeStringList.Clear();
				PokojeDS.PokojeDataTable pokojeTable = TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeStandardByTermin(datePickerRezeracjeAddTerminOd.SelectedDate
						   , datePickerRezeracjeAddTerminOd.SelectedDate, datePickerRezerwacjeAddTerminDo.SelectedDate, datePickerRezerwacjeAddTerminDo.SelectedDate,
						   datePickerRezeracjeAddTerminOd.SelectedDate, datePickerRezerwacjeAddTerminDo.SelectedDate);
				foreach (PokojeDS.PokojeRow row in pokojeTable)
				{
					RezerwacjePokojeList.Add(new PokojeStandardy((string)row["dodatkowy_opis"],row.id_pokoju, row.nr_pokoju,(int)row["ilosc_osob"],(decimal)row["cena"]));
					RezerwacjePokojeStringList.Add("Nr. " + row.nr_pokoju + " (" + row["dodatkowy_opis"]+")"+ " - "+row["cena"]+" zł.");
				}
				comboBoxRezerwacjeAddPokoje.ItemsSource = RezerwacjePokojeStringList;
			}
        }

        private void dataGridRezerwacjeAddDostepnePokoje_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola

            }
        }
        private void RefreshRezerwacjeNowaPokoje()
        {
            DodajPokojdeDoComboBoxa();
            comboBoxRezerwacjeAddPokoje.Items.Refresh();
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

        private void deafultGridRefresh()
        {
            if(radioButtonPobytyIndywidualne.IsChecked == true)
                dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokoje();
            else
                dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyUnikalneAktualne();        
        }

        private void buttonPobytyPowrot_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            if (currentGrid == gridPobytyPosilki || currentGrid == gridPobytyUslugi)
            {
                showWindow(gridPobytyServices, buttonPobytyZarzadzajList);
                dataGridPobytyPosilki.ItemsSource =
                TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(((int)labelPobytyServicesId.Content));
                dataGridPobytyUslugi.ItemsSource =
                TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(((int)labelPobytyServicesId.Content));
            }
            else if (currentGrid == gridPobytyWybierzKlienta)
            {
                showWindow(gridPobytyNowy, buttonPobytyBackOkList);
            }
            else{
                showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
                deafultGridRefresh();
            }
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
                    pobytyNowyKlientImie = (string)selectedRow["imie"];
                    pobytyNowyKlientNazwisko = (string)selectedRow["nazwisko"];
                    pobytyNowyKlientPesel = (string)selectedRow["pesel"];
                    pobytyNowyKlientId = selectedRow.id_klienta;
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
                if ((bool)radioButtonPobytyNowyNowy.IsChecked == true)
                {
                    if (textBoxPobytyNowyKlient.Text != null  && comboBoxPobytyNowyPokoj.SelectedItem != null
                        && datePickerPobytyNowyTerminDo.SelectedDate != null && datePickerPobytyNowyTerminOd.SelectedDate != null)
                    {
                        List<int> idKlientowList = new List<int>();
                        List<int> idPokoiList = new List<int>();
                        foreach (var pozycja in PobytyNowyPokojeKlienciList)
                        {
                            idKlientowList.Add(pozycja.Id_osoby);
                            idPokoiList.Add(pozycja.Id_pokoju);
                        }
                        if (radioButtonPobytyNowyNowy.IsChecked == true)
                        {
                            RezerwacjeHelper.dodajNowyPobyt(idKlientowList,
                               idPokoiList, (DateTime)datePickerPobytyNowyTerminOd.SelectedDate,
                               (DateTime)datePickerPobytyNowyTerminDo.SelectedDate);
                        }
                        else
                        {
                            RezerwacjeHelper.dodajNowyPobytZRezerwacji(idKlientowList,
                              idPokoiList,(int)labelPobytyNowyIdRezerwacji.Content, (DateTime)datePickerPobytyNowyTerminOd.SelectedDate,
                              (DateTime)datePickerPobytyNowyTerminDo.SelectedDate);
                        }
                        zwinPobyty();
                        showWindow(gridPobytyDeafult, buttonPobytyDeafultList);
                        dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokoje();
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Wypełnij wszytkie pola", "Dodawanie pobytu", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                if (radioButtonPobytyNowyZRez.IsChecked == true)
                {
                    if (dataGridPobytyNowyRezerwacje.SelectedItem != null)
                    {
                        RezerwacjeDS.RezerwacjeRow selectedRow = (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridPobytyNowyRezerwacje.SelectedItem).Row;
                        RezerwacjeHelper.dodajKlientaDoPobytuNaPodstawieRezerwacji(selectedRow.id_rezerwacji, selectedRow.id_klienta, (int)selectedRow["id_pokoju"]);

                    }
                    else
                        System.Windows.MessageBox.Show("Wybierz rezerwację", "Dodawanie pobytu", MessageBoxButton.OK, MessageBoxImage.Error);
                }


			}
			else if (currentGrid == gridPobytySum)
			{
				decimal cena=-1;
				if (Decimal.TryParse((string)labelPobytySumDoZaplaty.Content, out cena) && cena>=0)
				{

					if ((bool)radioButtonPobytyIndywidualne.IsChecked == true)
						RozliczenieHelper.rozliczPobyt((int)labelPobytySumId.Content, cena);
					else
						RozliczenieHelper.rozliczRezerwacje((int)labelPobytySumIdRezerwacji.Content, cena);
					System.Windows.MessageBox.Show("Rozliczono poprawnie.", "Rozliczanie pobytu", MessageBoxButton.OK, MessageBoxImage.Information);
                    zwinPobyty();
					showWindow(gridPobytyDeafult, buttonPobytyDeafultList);			
				}else
					System.Windows.MessageBox.Show("Wystąpił błąd w rozliczeniu (ujemna cena, bądź program nie potrafi pobrać id, ceny)", "Rozliczanie pobytu", MessageBoxButton.OK, MessageBoxImage.Error);
			}
            else if (currentGrid == gridPobytyUslugi || currentGrid == gridPobytyPosilki)
            {
                zwinPobyty();
                showWindow(gridPobytyServices, buttonPobytyZarzadzajList);
                dataGridPobytyPosilki.ItemsSource =
                    TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(((int)labelPobytyServicesId.Content));
                dataGridPobytyUslugi.ItemsSource =
                    TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(((int)labelPobytyServicesId.Content));
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
        private void radioButtonPobytyIndywidualne_Checked(object sender, RoutedEventArgs e)
        {
            dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokoje();
        }

        private void radioButtonPobytyGrupowe_Checked(object sender, RoutedEventArgs e)
        {
            dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyUnikalneAktualne();
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
                           dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeAktualneByIDPobytu(id);
                        else
                            dataGridPobytySzukaj.ItemsSource = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeByIDPobytu(id);
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


        //----------------------------------------------POBYTY->ZARZADZANIE----------------------------------------------
        List<int> PobytyUslugiIdList = new List<int>();
        List<int> PobytyUslugiIdPracownikaList = new List<int>();
        private void buttonPobytyServices_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                if (selectedRow.Isid_rachunkuNull())
                {
                    zwinPobyty();
                    showWindow(gridPobytyServices, buttonPobytyZarzadzajList);
                    
                    labelPobytyServicesKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
                    labelPobytyZarzadzajPESEL.Content = (string)selectedRow["pesel"];
                    labelPobytyZarzadzajTelefon.Content = selectedRow["nr_telefonu"].ToString();
                    labelPobytyZarzadzajPokoj.Content = selectedRow["nr_pokoju"].ToString();

                    labelPobytyZarzadzajLOsob.Content = TablesManager.Manager.RezerwacjeTableAdapter.ScalarQueryIloscOsobByIdPobytu(selectedRow.id_pobytu);
                    labelPobytyServicesId.Content = selectedRow.id_pobytu;
                    labelPobytyZarzadzajTermin.Content = selectedRow.termin_start.ToLongDateString() + " - " + selectedRow.termin_koniec.ToLongDateString();
                    labelPobtyZarzadzajRezerwacja.Content = selectedRow.id_rezerwacji;
                    dataGridPobytyPosilki.ItemsSource = TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(((int)labelPobytyServicesId.Content));
                    dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(selectedRow.id_pobytu);
                    dataGridPobytyZarzadzajOsoby.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciNierozliczoneByIdRezerwacji(selectedRow.id_rezerwacji);
                    if (radioButtonPobytyGrupowe.IsChecked == true)
                    {
                        labelPobytyZarzadzajGrupowy.Visibility = Visibility.Visible;
                        groupBoxPobytyUslugi.IsEnabled = false;
                        groupBoxPobytyUslugi.Opacity = 0.5;
                        buttonPobytyZarzadzajUslugi.IsEnabled = false;
                    }
                    else
                    {
                        labelPobytyZarzadzajGrupowy.Visibility = Visibility.Hidden;
                        groupBoxPobytyUslugi.IsEnabled = true;
                        groupBoxPobytyUslugi.Opacity = 1;
                        buttonPobytyZarzadzajUslugi.IsEnabled = true;
                    }
                }
                else
                    System.Windows.MessageBox.Show("Nie można zarządzać pobytem, który nie jest aktywny - został już rozliczony.", "Zarządzanie pobytem", MessageBoxButton.OK, MessageBoxImage.Warning);  
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Zarządzanie pobytem", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        
        //-----ZARZADZANIE->POSIŁKI
        private void RefreshPobytyPosilkiSlownik()
        {
            List<string> lst = new List<string>();
            PobytyPosilkiIdList.Clear();
            DS.PosilkiDS.Posilki_slownikDataTable posilkiTable = TablesManager.Manager.Posilki_slownikTableAdapter.GetData();
            foreach (DS.PosilkiDS.Posilki_slownikRow row in posilkiTable)
            {
                lst.Add(row.nazwa_opcji + ":" + row.cena + "zł");
                PobytyPosilkiIdList.Add(row.id_slownikowe_posilku);
            }
            comboBoxPobytyZarzadzaniePosilki.ItemsSource = lst;
            comboBoxPobytyZarzadzaniePosilki.Items.Refresh();
        }
        List<int> PobytyPosilkiIdList = new List<int>();
        private void buttonPobytyZarzadzajPosilki_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyPosilki, buttonPobytyOkList);
            RefreshPobytyPosilkiSlownik();
            dataGridPobytyZarzadzaniePosilki.ItemsSource = 
                TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(((int)labelPobytyServicesId.Content));
            PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
            datePickerPobytyZarzadzaniePosilkiTerminOd.SelectedDate = selectedRow.termin_start;
            datePickerPobytyZarzadzaniePosilkiTerminDo.SelectedDate = selectedRow.termin_koniec;            
        }
        private void buttonPobytyZarzadzaniePosilkiDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPobytyZarzadzaniePosilki.SelectedItem != null && datePickerPobytyZarzadzaniePosilkiTerminOd.SelectedDate != null
                && datePickerPobytyZarzadzaniePosilkiTerminDo.SelectedDate != null)
            {
                if (radioButtonPobytyIndywidualne.IsChecked == true)
                {
                    DateTime data = (DateTime)datePickerPobytyZarzadzaniePosilkiTerminOd.SelectedDate;
                    while (data <= (DateTime)datePickerPobytyZarzadzaniePosilkiTerminDo.SelectedDate)
                    {
                        PosilkiHelper.dodajPosilek((int)labelPobytyServicesId.Content, PobytyPosilkiIdList[comboBoxPobytyZarzadzaniePosilki.SelectedIndex], data);
                        data = data.AddDays(1.0);
                    }
                }
                else
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Posiłki w wybranym terminie zostaną przydzielone wszystkim osobom powiązanym z pobytem. Czy chcesz kontynuować?"
                        , "Dodawanie posiłku", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        PobytyDS.PobytyDataTable pobytyTable =
                            TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRezerwacjiNierozliczone((int)labelPobtyZarzadzajRezerwacja.Content);
                        foreach (PobytyDS.PobytyRow row in pobytyTable)
                        {
                            DateTime data = (DateTime)datePickerPobytyZarzadzaniePosilkiTerminOd.SelectedDate;
                            while (data <= (DateTime)datePickerPobytyZarzadzaniePosilkiTerminDo.SelectedDate)
                            {
                                PosilkiHelper.dodajPosilek(row.id_pobytu, PobytyPosilkiIdList[comboBoxPobytyZarzadzaniePosilki.SelectedIndex], data);
                                data = data.AddDays(1.0);
                            }
                        }
                    }
                }
                dataGridPobytyZarzadzaniePosilki.ItemsSource =
                TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(((int)labelPobytyServicesId.Content));
            }
            else
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Dodawanie posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void datePickerPobytyZarzadzaniePosilkiTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(datePickerPobytyZarzadzaniePosilkiTerminOd.SelectedDate>DateTime.Now.Date)
                sprawdzTermin(ref datePickerPobytyZarzadzaniePosilkiTerminOd, ref datePickerPobytyZarzadzaniePosilkiTerminDo);
           // else
               // System.Windows.MessageBox.Show("Termin nie może być wcześniejszy niż obecna data.", "Dodawanie posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void datePickerPobytyZarzadzaniePosilkiTerminDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzTermin(ref datePickerPobytyZarzadzaniePosilkiTerminOd, ref datePickerPobytyZarzadzaniePosilkiTerminDo);
        }

        private void buttonPobytyZarzadzanieUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytyZarzadzaniePosilki.SelectedItem != null)
            {
                PosilkiDS.PosilkiRow selectedRow = (PosilkiDS.PosilkiRow)((DataRowView)dataGridPobytyZarzadzaniePosilki.SelectedItem).Row;
                if (selectedRow.data < DateTime.Now.Date)
                {
                    System.Windows.MessageBox.Show("Termin usuwanego posiłku nie może być wcześniejszy niż dzisiejsza data.", "Usuwanie posiłku", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    PosilkiHelper.usunPosilek(selectedRow.id_posilku);
                    dataGridPobytyZarzadzaniePosilki.ItemsSource = TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(((int)labelPobytyServicesId.Content));
                }
            }
        }

        //-----ZARZADZANIE->USŁUGI
        private void RefreshPobytyUslugiSlownik()
        {
            PobytyUslugiIdList.Clear();
            List<string> lst = new List<string>();
            DS.UslugiDS.Uslugi_slownikDataTable rabatyTable = TablesManager.Manager.Uslugi_slownikTableAdapter.GetData();
            foreach (DS.UslugiDS.Uslugi_slownikRow row in rabatyTable)
            {
                lst.Add(row.nazwa + " -" + row.cena + "zł");
                PobytyUslugiIdList.Add(row.id_slownikowe_uslugi);
            }
            comboBoxPobytyUslugi.ItemsSource = lst;
            comboBoxPobytyUslugi.Items.Refresh();
        }
        private void buttonPobytyZarzadzajUslugi_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyUslugi, buttonPobytyOkList);
            //datePickerPobytyServicesTermin.Set = DateTime.Today;
            dataGridPobytyZarzadzajUslug.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytyServicesId.Content);
            RefreshPobytyUslugiSlownik();
        }
        
        private void buttonPobytyZarzadzajCzysc_Click(object sender, RoutedEventArgs e)
        {
            comboBoxPobytyUslugi.IsEnabled = true;
            datePickerPobytyServicesTermin.IsEnabled = true;
            comboBoxPobytyUslugi.SelectedItem = null;
            datePickerPobytyServicesTermin.Value = null;
            comboBoxPobytyPracownicy.IsEnabled = false;
            textBoxPobytyUslugiCzas.IsEnabled = true;
            comboBoxPobytyPracownicy.SelectedItem = null;
            comboBoxPobytyPracownicy.IsDropDownOpen = false;
            textBoxPobytyUslugiUwagi.Clear();
            textBoxPobytyUslugiCzas.Clear();
        }

        private void buttonPobytyUslugiUsun_Click(object sender, RoutedEventArgs e)
        {

            if (dataGridPobytyZarzadzajUslug.SelectedItem != null)
            {
                UslugiDS.UslugiRow selectedRow = (UslugiDS.UslugiRow)((DataRowView)dataGridPobytyZarzadzajUslug.SelectedItem).Row;
                if (selectedRow.termin_start < DateTime.Now)
                {
                    System.Windows.MessageBox.Show("Termin rozpoczęcia usuwanej usługi nie może być wcześniejszy niż dzisiejsza data", "Usuwanie usługi", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    UslugiHelper.usunPracownika(selectedRow.id_uslugi);
                    UslugiHelper.usunUsluge(selectedRow.id_uslugi);
                    dataGridPobytyZarzadzajUslug.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytyServicesId.Content);
                }
            }
        }

        private void buttonPobytyZarzadzajSzukaj_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPobytyUslugi.SelectedItem != null && datePickerPobytyServicesTermin.Value != null)
            {
                int czasTrwania;   
                bool szukaj;
                if(int.TryParse(textBoxPobytyUslugiCzas.Text,out czasTrwania))
                {
                    if (czasTrwania == 0)
                    {
                        MessageBoxResult result = System.Windows.MessageBox.Show("Czas trwania usługi ustawiony na 0 minut. Czy chcesz kontynuować?",
                            "Znajdowanie wolnego pracownika", MessageBoxButton.YesNo, MessageBoxImage.Information);

                        if (result == MessageBoxResult.Yes)
                            szukaj = true;
                        else
                            szukaj = false;
                    }
                    else
                    {
                        szukaj = true;
                    }
                    if (szukaj)
                    {
                        List<string> lst = new List<string>();
                        PobytyUslugiIdPracownikaList.Clear();
                        DateTime koniec = (DateTime)datePickerPobytyServicesTermin.Value.Value;
                        koniec = koniec.AddMinutes(czasTrwania);
                        PracownicyDS.PracownicyDataTable pracownicyTable = UslugiHelper.znajdzWolnegoPracownika(datePickerPobytyServicesTermin.Value.Value, koniec, PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex]);//TablesManager.Manager.PracownicyTableAdapter.

                        foreach (PracownicyDS.PracownicyRow row in pracownicyTable)
                        {
                            lst.Add(row.imie + " " + row.nazwisko);
                            PobytyUslugiIdPracownikaList.Add(row.id_pracownika);
                        }
                        comboBoxPobytyPracownicy.ItemsSource = lst;

                        if (comboBoxPobytyPracownicy.Items.Count == 0)
                        {
                            DateTime termin = UslugiHelper.znajdzPierwszyWolnyTermin(datePickerPobytyServicesTermin.Value.Value, czasTrwania, PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex]);
                            System.Windows.MessageBox.Show("W podanym terminie nie znaleziono wolnych pracowników.\nPierwszy wolny termin dla wybranej usługi i czasu trwania to: "+ termin,"Wyszukiwanie wolnych pracowników", MessageBoxButton.OK, MessageBoxImage.Information);
                            datePickerPobytyServicesTermin.Value = termin;
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Liczba znalezionych wolnych pracowników w podanym terminie: " + comboBoxPobytyPracownicy.Items.Count, "Wyszukiwanie wolnych pracowników", MessageBoxButton.OK, MessageBoxImage.Information);
                            comboBoxPobytyPracownicy.IsDropDownOpen = true;
                            comboBoxPobytyPracownicy.IsEnabled = true;
                            comboBoxPobytyUslugi.IsEnabled = false;
                            datePickerPobytyServicesTermin.IsEnabled = false;
                            textBoxPobytyUslugiCzas.IsEnabled = false; 
                        }
                    }
                }
                else
                    System.Windows.MessageBox.Show("Pole czas trwania może zawierać tylko cyfry", "Znajdowanie wolnego pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Znajdowanie wolnego pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);
      
        }

        private void buttonPobytyServicesAdd_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPobytyUslugi.SelectedItem != null && datePickerPobytyServicesTermin.Value!= null && comboBoxPobytyPracownicy.SelectedItem != null)
            {
                int czasTrwania;
                 if(int.TryParse(textBoxPobytyUslugiCzas.Text,out czasTrwania))
                {
                    DateTime koniec = (DateTime)datePickerPobytyServicesTermin.Value.Value;
                    koniec = koniec.AddMinutes(czasTrwania);
                    //UslugiHelper.przydzielPracownika((int)PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex], (int)PobytyUslugiIdPracownikaList[comboBoxPobytyPracownicy.SelectedIndex]);
                    UslugiHelper.dodajUsluge((int)labelPobytyServicesId.Content, (int)PobytyUslugiIdPracownikaList[comboBoxPobytyPracownicy.SelectedIndex], datePickerPobytyServicesTermin.Value.Value, koniec, textBoxPobytyUslugiUwagi.Text, PobytyUslugiIdList[comboBoxPobytyUslugi.SelectedIndex]);
                    dataGridPobytyUslugi.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytyServicesId.Content);
                    dataGridPobytyZarzadzajUslug.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytyServicesId.Content);
                    buttonPobytyZarzadzajCzysc_Click(sender, e);
                 }
                 else
                     System.Windows.MessageBox.Show("Pole czas trwania może zawierać tylko cyfry", "Znajdowanie wolnego pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);
           
            
            }
            else
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Dodawanie usługi", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        

        //----------------------------------------------POBYTY->ROZLICZ----------------------------------------------
        List<RachunkiDS.RabatyRow> PobytyRabatyList = new List<RachunkiDS.RabatyRow>();
        List<RachunkiDS.RabatyRow> PobytyRabatyDodajList = new List<RachunkiDS.RabatyRow>();
        private void buttonPobytySum_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
				PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
				if (selectedRow.Isid_rachunkuNull())
				{
					//rzeczy niezalezne od rodzaju rozliczenia
					List<string> lst = new List<string>();
					DS.RachunkiDS.RabatyDataTable rabatyTable = TablesManager.Manager.RabatyTableAdapter.GetDataByAktywne();
					foreach (DS.RachunkiDS.RabatyRow row in rabatyTable)
					{
						lst.Add(row.nazwa + " -" + row.wartosc + ((row.procentowy == true) ? "%" : "zł"));
						PobytyRabatyList.Add(row);
					}
					comboBoxPobytySumRabat.ItemsSource = lst;
					//dataGrid rabatów
					PobytyRabatyDodajList = new List<RachunkiDS.RabatyRow>();
					dataGridPobytySumRabaty.ItemsSource = PobytyRabatyDodajList;

					//czyszczenie
					comboBoxPobytySumId.Visibility = System.Windows.Visibility.Hidden;
					comboBoxPobytySumKlient.Visibility = System.Windows.Visibility.Hidden;
					comboBoxPobytySumPokoj.Visibility = System.Windows.Visibility.Hidden;
					labelPobytySumId.Visibility = System.Windows.Visibility.Visible;
					labelPobytySumKlient.Visibility = System.Windows.Visibility.Visible;
					labelPobytySumPokoj.Visibility = System.Windows.Visibility.Visible;

					//dataGrid dodatkowy
					dataGridPobytySumLista.Visibility = System.Windows.Visibility.Collapsed;
					dataGridPobytySumLista.ItemsSource = null;
					dataGridPobytySumLista.Columns.Clear();

					//id rezerwacji
					labelPobytySumIdRezerwacji.Content = selectedRow.id_rezerwacji;

					if (radioButtonPobytyIndywidualne.IsChecked == true)	//indywidualne
					{
						labelPobytySumKlient.Content = (string)selectedRow["imie"] + ' ' + (string)selectedRow["nazwisko"];
						labelPobytySumPokoj.Content = (string)selectedRow["nr_pokoju"];
						labelPobytySumId.Content = selectedRow.id_pobytu; 
						labelPobytySumTermin.Content = selectedRow.termin_start.ToLongDateString() + " - " + selectedRow.termin_koniec.ToLongDateString();
					

						//wypenienie labeli i przyciskow związanych z ceną
						decimal cenaTmp;
						cenaTmp = RozliczenieHelper.pobierzPodstawowaCenaUslug(selectedRow.id_pobytu);
						labelPobytySumCenaUslugi.Content = cenaTmp.ToString("0.00");
						buttonPobytySumRozwinUslugi.Content = "+";
						buttonPobytySumRozwinUslugi.IsEnabled = (cenaTmp == 0) ? false : true;
						cenaTmp = RozliczenieHelper.pobierzPodstawowaCenaPosilkow(selectedRow.id_pobytu);
						labelPobytySumCenaPosilki.Content = cenaTmp.ToString("0.00");
						buttonPobytySumRozwinPosilki.Content = "+";
						buttonPobytySumRozwinPosilki.IsEnabled = (cenaTmp == 0) ? false : true;
						labelPobytySumCenaPobyt.Content = RozliczenieHelper.pobierzPodstawowaCenaPobytu(selectedRow.id_pobytu).ToString("0.00");
						labelPobytySumCena.Content = RozliczenieHelper.pobierzPodstawowaCenaLaczna(selectedRow.id_pobytu).ToString("0.00");
						labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCena(selectedRow.id_pobytu, PobytyRabatyDodajList).ToString("0.00");
						
					}
					else
					{
						comboBoxPobytySumId.Visibility = System.Windows.Visibility.Visible;
						comboBoxPobytySumKlient.Visibility = System.Windows.Visibility.Visible;
						comboBoxPobytySumPokoj.Visibility = System.Windows.Visibility.Visible;
						labelPobytySumId.Visibility = System.Windows.Visibility.Hidden;
						labelPobytySumKlient.Visibility = System.Windows.Visibility.Hidden;
						labelPobytySumPokoj.Visibility = System.Windows.Visibility.Hidden;

						List<string> lst1 = new List<string>();
						List<string> lst2 = new List<string>();
						List<string> lst3 = new List<string>();
						bool koniec = false;
						decimal cenaTmp, tmpCenaUslugi = 0, tmpCenaPobyt = 0, tmpCenaPosilki = 0;
						PobytyDS.PobytyDataTable tab = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeByIdRezerwacjiNierozliczone(selectedRow.id_rezerwacji);
						foreach (var row in tab)
						{
							//lista z pobytem
							foreach(var rowL in lst1)
								if (rowL.Equals(row["id_pobytu"].ToString()))
								{
									koniec = true;
									break;
								}
							if(koniec==false)
								lst1.Add(row["id_pobytu"].ToString());

							koniec=false;
							foreach (var rowL in lst2)
								if (rowL.Equals((string)row["imie"]+" "+(string)row["nazwisko"]))
								{
									koniec = true;
									break;
								}
							if (koniec == false)
								lst2.Add((string)row["imie"]+" "+(string)row["nazwisko"]);

							koniec=false;
							foreach (var rowL in lst3)
								if (rowL.Equals(row["nr_pokoju"]))
								{
									koniec = true;
									break;
								}
							if (koniec == false)
								lst3.Add(row["nr_pokoju"].ToString());


							tmpCenaUslugi += RozliczenieHelper.pobierzPodstawowaCenaUslug(row.id_pobytu);
							tmpCenaPosilki += RozliczenieHelper.pobierzPodstawowaCenaPosilkow(row.id_pobytu);
							tmpCenaPobyt += RozliczenieHelper.pobierzPodstawowaCenaPobytu(row.id_pobytu);
							
							

						}
						labelPobytySumCenaUslugi.Content = tmpCenaUslugi.ToString("0.00");
						labelPobytySumCenaPosilki.Content = tmpCenaPosilki.ToString("0.00");
						labelPobytySumCenaPobyt.Content = tmpCenaPobyt.ToString("0.00");
						buttonPobytySumRozwinUslugi.Content = "+";
						buttonPobytySumRozwinUslugi.IsEnabled = (tmpCenaUslugi == 0) ? false : true;
						buttonPobytySumRozwinPosilki.Content = "+";
						buttonPobytySumRozwinPosilki.IsEnabled = (tmpCenaPosilki == 0) ? false : true;
						labelPobytySumCena.Content = (tmpCenaUslugi + tmpCenaPosilki + tmpCenaPobyt).ToString("0.00");
						labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCenaRezerwacji(selectedRow.id_rezerwacji, PobytyRabatyDodajList).ToString("0.00");


						comboBoxPobytySumId.ItemsSource = lst1;
						comboBoxPobytySumKlient.ItemsSource = lst2;
						comboBoxPobytySumPokoj.ItemsSource = lst3;
						comboBoxPobytySumId.SelectedIndex = 0;
						comboBoxPobytySumKlient.SelectedIndex = 0;
						comboBoxPobytySumPokoj.SelectedIndex = 0;


					}
					zwinPobyty();
					showWindow(gridPobytySum, buttonPobytyBackOkList);
				}else
					System.Windows.MessageBox.Show("Próbujesz rozliczać pobyt, który ma już naliczony rachunek.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pobyt.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void PobytySumRabatyDodaj_Click(object sender, RoutedEventArgs e)
        {
			if (comboBoxPobytySumRabat.SelectedItem != null && !PobytyRabatyDodajList.Contains(PobytyRabatyList[comboBoxPobytySumRabat.SelectedIndex]))
			{
				PobytyRabatyDodajList.Add(PobytyRabatyList[comboBoxPobytySumRabat.SelectedIndex]);
				if (radioButtonPobytyIndywidualne.IsChecked == true)
					labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCena((int)labelPobytySumId.Content, PobytyRabatyDodajList).ToString("0.00");
				else
					labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCenaRezerwacji((int)labelPobytySumIdRezerwacji.Content, PobytyRabatyDodajList).ToString("0.00");
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
						if (radioButtonPobytyIndywidualne.IsChecked == true)
							labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCena((int)labelPobytySumId.Content, PobytyRabatyDodajList).ToString("0.00");
						else
							labelPobytySumDoZaplaty.Content = RozliczenieHelper.pobierzRabatowaCenaRezerwacji((int)labelPobytySumIdRezerwacji.Content, PobytyRabatyDodajList).ToString("0.00");
						break;
                    }
                }
            }
            dataGridPobytySumRabaty.Items.Refresh();

        }

		/// <summary>
		/// Wyświetlanie w datagridzie listy ze szczegółowymi informacjami nt. posiłków, bądź ew. jej zwinięcie
		/// </summary>
		private void buttonPobytySumRozwinUslugi_Click(object sender, RoutedEventArgs e)
		{
			if (((String)((Button)sender).Content).Equals("+"))
			{
				((Button)sender).Content = "-";
				buttonPobytySumRozwinPosilki.Content = "+";
				dataGridPobytySumLista.ItemsSource = null;
				dataGridPobytySumLista.Columns.Clear();

				DataGridTextColumn column = new DataGridTextColumn();
				column.Header = "Początek"; column.Binding = new Binding("termin_start"); dataGridPobytySumLista.Columns.Add(column);
				column = new DataGridTextColumn(); column.Header = "Koniec"; column.Binding = new Binding("termin_koniec"); dataGridPobytySumLista.Columns.Add(column);
				column = new DataGridTextColumn(); column.Header = "Nazwa usługi"; column.Binding = new Binding("nazwa"); dataGridPobytySumLista.Columns.Add(column);

				if (radioButtonPobytyIndywidualne.IsChecked == true) 
					dataGridPobytySumLista.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu((int)labelPobytySumId.Content);
				else
					dataGridPobytySumLista.ItemsSource = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugiSlownikPobytyByIdRezerwacji((int)labelPobytySumIdRezerwacji.Content);
				dataGridPobytySumLista.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{
				//czyszczenie
				((Button)sender).Content = "+";
				dataGridPobytySumLista.Visibility = System.Windows.Visibility.Collapsed;

			}
		}
		/// <summary>
		/// Wyświetlanie w datagridzie listy ze szczegółowymi informacjami nt. posiłków, bądź ew. jej zwinięcie
		/// </summary>
		private void buttonPobytySumRozwinPosilki_Click(object sender, RoutedEventArgs e)
		{
			if (((String)((Button)sender).Content).Equals("+"))
			{
				((Button)sender).Content = "-";
				buttonPobytySumRozwinUslugi.Content = "+";
				dataGridPobytySumLista.ItemsSource = null;
				dataGridPobytySumLista.Columns.Clear();

				DataGridTextColumn column = new DataGridTextColumn();
				column.Header = "Data"; column.Binding = new Binding("data"); dataGridPobytySumLista.Columns.Add(column);
				column = new DataGridTextColumn(); column.Header = "Nazwa"; column.Binding = new Binding("nazwa_opcji"); dataGridPobytySumLista.Columns.Add(column);
				column = new DataGridTextColumn(); column.Header = "Cena"; column.Binding = new Binding("cena"); dataGridPobytySumLista.Columns.Add(column);
				
				if (radioButtonPobytyIndywidualne.IsChecked == true) 
					dataGridPobytySumLista.ItemsSource = TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById((int)labelPobytySumId.Content);
				else 
					dataGridPobytySumLista.ItemsSource = TablesManager.Manager.PosilkiTableAdapter.GetDataPosilkiSlownikPobytyByIdRezerwacji((int)labelPobytySumIdRezerwacji.Content);
				
				dataGridPobytySumLista.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{
				//czyszczenie
				((Button)sender).Content = "+";
				dataGridPobytySumLista.Visibility = System.Windows.Visibility.Collapsed;

			}
		}
        //----------------------------------------------POBYTY->DRUKUJ FAKTURE ----------------------------------------------
        private void buttonPobytyDrukuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytySzukaj.SelectedItem != null)
            {
                PobytyDS.PobytyRow selectedRow = (PobytyDS.PobytyRow)((DataRowView)dataGridPobytySzukaj.SelectedItem).Row;
                if (selectedRow.Isid_rachunkuNull())
                {
                    System.Windows.MessageBox.Show("Wybrany pobyt nie ma jeszcze wystawionego rachunku. Aby wydrukować fakturę, rozlicz najpierw pobyt.", "Rozliczanie pobytu.", MessageBoxButton.OK, MessageBoxImage.Warning);       
                }
                else
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.DefaultExt = ".pdf";
                    dlg.Filter = "Portable Document Format (.pdf)|*.pdf";
                    if (dlg.ShowDialog() == true)
                    {
                        string filename = dlg.FileName;
                        if(RachunekPDFHelper.stworzWydruk(selectedRow.id_rachunku, filename))
                            System.Windows.MessageBox.Show("Dokument pdf z rachunkiem wygenerowano pomyślnie.", "Generowanie PDF.", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                   //Superfunkcja drukowania faktury
                }
            }
            else
                System.Windows.MessageBox.Show("Aby wygenerować pdf z rachunkiem, najpierw wybierz pobyt.", "Generowanie PDF.", MessageBoxButton.OK, MessageBoxImage.Warning);
 
        }
        //----------------------------------------------POBYTY->NOWY----------------------------------------------
        private void RefreshPobytyNowyPokoje()
        {
            PrzypiszWolnePokoje();
        }
        string pobytyNowyKlientImie;
        string pobytyNowyKlientNazwisko;
        string pobytyNowyKlientPesel;
        int pobytyNowyKlientId;
        List<PokojeKlienci> PobytyNowyPokojeKlienciList = new List<PokojeKlienci>();
        List<Pokoje> PobytyNowyPokojePozostaloList = new List<Pokoje>();
        private void buttonPobytyNowy_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyNowy, buttonPobytyBackOkList);
            pobytyNowyClear();
        }

        private void buttonPobytyNowyRezerwacjeWybierz_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytyNowyRezerwacje.SelectedItem != null)
            {
                gridPobytyNowyNowy.Visibility = Visibility.Visible;
                gridPobytyNowyZRez.Visibility = Visibility.Collapsed;
                //textBoxPobytyNowyIlOsob.IsEnabled = false;
                datePickerPobytyNowyTerminOd.IsEnabled = false;
                datePickerPobytyNowyTerminDo.IsEnabled = false;
                RezerwacjeDS.RezerwacjeRow selectedRow = (RezerwacjeDS.RezerwacjeRow)((DataRowView)dataGridPobytyNowyRezerwacje.SelectedItem).Row;
                datePickerPobytyNowyTerminOd.SelectedDate = (DateTime)selectedRow["termin_start"];
                datePickerPobytyNowyTerminDo.SelectedDate = (DateTime)selectedRow["termin_koniec"];
                textBoxPobytyNowyKlient.Text = (string)selectedRow["imie"] + " " + (string)selectedRow["nazwisko"];
                labelPobytyNowyIdKlienta.Content = selectedRow.id_klienta;
                //textBoxPobytyNowyIlOsob.Text = selectedRow.ilosc_osob.ToString();
                labelPobytyNowyIdRezerwacji.Content = selectedRow.id_rezerwacji;
                pobytyNowyKlientImie = (string)selectedRow["imie"];
                pobytyNowyKlientNazwisko = (string)selectedRow["nazwisko"];
                pobytyNowyKlientPesel = (string)selectedRow["pesel"];
                pobytyNowyKlientId = selectedRow.id_klienta;
                buttonPobytyNowyKlient.IsEnabled = false;
                PrzypiszWolnePokoje();
            }
            else 
                System.Windows.MessageBox.Show("Najpierw wybierz rezerwację.", "Nowy pobyt.", MessageBoxButton.OK, MessageBoxImage.Warning);
        
        }
        private void buttonPobytyNowyUsun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPobytyNowyLOsob.SelectedItem != null)
            {
                PobytyNowyPokojeKlienciList.Remove((PokojeKlienci)dataGridPobytyNowyLOsob.SelectedItem);
                dataGridPobytyNowyLOsob.Items.Refresh();
            }
        }

        private void buttonPobytyNowyDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPobytyNowyPokoj.SelectedItem != null && textBoxPobytyNowyKlient.Text != "" && comboBoxPobytyNowyPokoj.SelectedItem != null)
            {
                PokojeKlienci osoba = new PokojeKlienci(pobytyNowyKlientImie, pobytyNowyKlientNazwisko, pobytyNowyKlientPesel, pobytyNowyKlientId,
                    PobytyNowyIdPokoje[comboBoxPobytyNowyPokoj.SelectedIndex],
                    PobytyNowyStringPokoje[comboBoxPobytyNowyPokoj.SelectedIndex], PobytyNowyLOsobList[comboBoxPobytyNowyPokoj.SelectedIndex]);
                bool istnieje = false;
                bool dodawac = false;
                foreach (var element in PobytyNowyPokojeKlienciList)
                {
                    if (element.Id_osoby == osoba.Id_osoby)
                    {
                        istnieje = true;
                    }
                }
                if (!istnieje)
                {                    
                    buttonPobytyNowyKlient.IsEnabled = true;
                    bool znaleziono = false;
                    foreach (var element in PobytyNowyPokojePozostaloList) 
                    {
                        if (element.Id_pokoju == osoba.Id_pokoju)
                        {
                            znaleziono = true;
                            if (element.Pozostalo > 0)
                            {
                                dodawac = true;
                                element.Pozostalo--;
                            }
                            else
                            {
                                dodawac = false;
                                System.Windows.MessageBox.Show("W pokoju nie ma wolnych miejsc.", "Dodawanie osoby do pobytu", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }
                    }
                    if (!znaleziono)
                    {
                        dodawac = true;
                        PobytyNowyPokojePozostaloList.Add(new Pokoje(osoba.Id_pokoju,osoba.Nr_pokoju.Split(' ')[0],osoba.L_osob));
                    }
                    if (dodawac)
                    {
                        dataGridPobytyNowyPozostalo.DataContext = PobytyNowyPokojePozostaloList;
                        dataGridPobytyNowyPozostalo.Items.Refresh();
                        PobytyNowyPokojeKlienciList.Add(osoba);
                        dataGridPobytyNowyLOsob.DataContext = PobytyNowyPokojeKlienciList;
                        dataGridPobytyNowyLOsob.Items.Refresh();
                    }
                }
                else
                    System.Windows.MessageBox.Show("Wybrana osoba została już dodana do pobytu.", "Dodawanie osoby do pobytu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Uzupełnij wszystkie pola", "Dodawanie osoby do pobytu", MessageBoxButton.OK, MessageBoxImage.Warning);
    
        }

        private void buttonPobytyNowyKlient_Click(object sender, RoutedEventArgs e)
        {
            zwinPobyty();
            showWindow(gridPobytyWybierzKlienta, buttonPobytyBackOkList);
        }
        private void pobytyNowyClear()
        {
            //textBoxPobytyNowyIlOsob.Text = "";
            textBoxPobytyNowyKlient.Text = "";
            datePickerPobytyNowyTerminOd.SelectedDate = null;
            datePickerPobytyNowyTerminDo.SelectedDate = null;
            PobytyNowyPokojeKlienciList.Clear();
            dataGridPobytyNowyLOsob.Items.Refresh();
            PobytyNowyStringPokoje.Clear();
            comboBoxPobytyNowyPokoj.Items.Refresh();
            PobytyNowyPokojePozostaloList.Clear();
            dataGridPobytyNowyPozostalo.Items.Refresh();
            buttonPobytyNowyKlient.IsEnabled = true;

        }
        private void buttonPobytyNowyZnajdzPokoje_Click(object sender, RoutedEventArgs e)
        {
            if ( datePickerPobytyNowyTerminDo.SelectedDate != null &&
                datePickerPobytyNowyTerminOd.SelectedDate != null)
            {
               // textBoxPobytyNowyIlOsob.IsEnabled = false;
                datePickerPobytyNowyTerminOd.IsEnabled = false;
                datePickerPobytyNowyTerminDo.IsEnabled = false;
                PrzypiszWolnePokoje();
                System.Windows.MessageBox.Show("Liczba znalezionych wolnych pokoi w podanym terminie: " + comboBoxPobytyNowyPokoj.Items.Count, "Wyszukiwanie wolnych pokoi", MessageBoxButton.OK, MessageBoxImage.Information);
                comboBoxPobytyNowyPokoj.IsDropDownOpen = true;
            }
            else
                System.Windows.MessageBox.Show("Uzupełnij wszystkie pola", "Nowy pobyt", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void buttonPobytyNowyCzysc_Click(object sender, RoutedEventArgs e)
        {
            if (radioButtonPobytyNowyNowy.IsChecked == true)
            {
                pobytyNowyClear();
                //textBoxPobytyNowyIlOsob.IsEnabled = true;
                datePickerPobytyNowyTerminOd.IsEnabled = true;
                datePickerPobytyNowyTerminDo.IsEnabled = true;
            }
            else
            {
                pobytyNowyClear();
                gridPobytyNowyZRez.Margin = new Thickness(25, 50, 25, 0);
                gridPobytyNowyNowy.Visibility = Visibility.Collapsed;
                gridPobytyNowyZRez.Visibility = Visibility.Visible;
            }
        }
        private void radioButtonPobytyNowyNowy_Checked(object sender, RoutedEventArgs e)
        {
            pobytyNowyClear();
            //textBoxPobytyNowyIlOsob.IsEnabled = true;
            datePickerPobytyNowyTerminOd.IsEnabled = true;
            datePickerPobytyNowyTerminDo.IsEnabled = true;
            gridPobytyNowyNowy.Visibility = Visibility.Visible;
            gridPobytyNowyZRez.Visibility = Visibility.Collapsed;
            buttonPobytyNowyKlient.IsEnabled = true;
            buttonPobytyNowyCzysc.Content = "Czyść";
            buttonPobytyNowyKlient.IsEnabled = true;
        }

        private void radioButtonPobytyNowyZRez_Checked(object sender, RoutedEventArgs e)
        {
            pobytyNowyClear();
            PobytyNowyPokojeKlienciList.Clear();
            dataGridPobytyNowyLOsob.Items.Refresh();
            gridPobytyNowyZRez.Margin = new Thickness(25, 50, 25, 0);
            gridPobytyNowyNowy.Visibility = Visibility.Collapsed;
            gridPobytyNowyZRez.Visibility = Visibility.Visible;
            buttonPobytyNowyCzysc.Content = "Zmień";

        }
        private void buttonPobytyNowyZmien_Click(object sender, RoutedEventArgs e)
        {
            gridPobytyNowyZRez.Margin = new Thickness(25, 50, 25, 0);
            gridPobytyNowyNowy.Visibility = Visibility.Collapsed;
            gridPobytyNowyZRez.Visibility = Visibility.Visible;
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
        List<int> PobytyNowyLOsobList = new List<int>();
        List<string> PobytyNowyStringPokoje = new List<string>();
        private void PrzypiszWolnePokoje()
        {
            DateTime terminOd = (DateTime)datePickerPobytyNowyTerminOd.SelectedDate;
            DateTime terminDo = (DateTime)datePickerPobytyNowyTerminDo.SelectedDate;
            PobytyNowyIdPokoje.Clear();
            PobytyNowyStringPokoje.Clear();
            PobytyNowyLOsobList.Clear();
            PokojeDS.PokojeDataTable pokojeTable;
            if(radioButtonPobytyNowyNowy.IsChecked == true)
                 pokojeTable= TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeStandardByTermin(terminOd, terminOd, terminDo, terminDo, terminOd, terminDo);
            else
                pokojeTable = TablesManager.Manager.PokojeTableAdapter.GetDataRezerwacjeByIdRezerwacji((int)labelPobytyNowyIdRezerwacji.Content); 
            
            foreach (PokojeDS.PokojeRow row in pokojeTable)
            {
                PobytyNowyIdPokoje.Add(row.id_pokoju);
                PobytyNowyStringPokoje.Add(row.nr_pokoju + " (" + (string)row["dodatkowy_opis"]+")" + " - " + row["cena"] + " zł.");
                PobytyNowyLOsobList.Add((int)row["ilosc_osob"]);
            }
            comboBoxPobytyNowyPokoj.ItemsSource = PobytyNowyStringPokoje;
            comboBoxPobytyNowyPokoj.Items.Refresh();
        }

        private void datePickerPobytyNowyTerminDo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzTermin(ref datePickerPobytyNowyTerminOd, ref datePickerPobytyNowyTerminDo);

        }

        private void datePickerPobytyNowyTerminOd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            sprawdzTermin(ref datePickerPobytyNowyTerminOd, ref datePickerPobytyNowyTerminDo);

        }
        //----------------------------------------------POBYTY->PODSUMOWANIE----------------------------------------------
       


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
			textBoxKlienciEdycjaMiejscowoscAuto.Visibility = System.Windows.Visibility.Hidden;
            zwinKlienci();
            showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
        }
        private void buttonKlienciOk_Click(object sender, RoutedEventArgs e)
		{
			if (currentGrid == gridKlienciEdit)
			{
				KlienciHelper.edytujKlienta(int.Parse(labelKlienciEdytujId.Content.ToString()), textBoxKlienciEdycjaImie.Text, textBoxKlienciEdycjaNazwisko.Text, textBoxKlienciEdycjaFirma.Text,
					textBoxKlienciEdycjaMiejscowoscAuto.Text, textBoxKlienciEdycjaAdres.Text, textBoxKlienciEdycjaKodPocztowy.Text, int.Parse(textBoxKlienciEdycjaNIP.Text),
					   textBoxKlienciEdycjaPESEL.Text, int.Parse(textBoxKlienciEdycjaTelefon.Text), textBoxKlienciEdycjaMail.Text);
				dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
				System.Windows.MessageBox.Show("Wyedytowano pomyślnie.", "Edycja klienta", MessageBoxButton.OK, MessageBoxImage.Information);

				textBoxKlienciEdycjaMiejscowoscAuto.Visibility = System.Windows.Visibility.Hidden;
				zwinKlienci();
				showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
			}
			else if (currentGrid == gridKlienciAdd)
			{
				int nip, tel;
				if (radioButtonKlientAddFirma.IsChecked == false)
				{
					textBoxKlienciAddFirma.Text = "";
					textBoxKlienciAddNIP.Text = "0";
				}
				if (int.TryParse(textBoxKlienciAddNIP.Text, out nip) && int.TryParse(textBoxKlienciAddTelefon.Text, out tel))
				{
					//dodawanie klienta
					if (KlienciHelper.dodajKlienta(
						textBoxKlienciAddImie.Text,
						textBoxKlienciAddNazwisko.Text,
						textBoxKlienciAddFirma.Text,
						textBoxKlienciAddMiejscowoscAuto.Text,
						textBoxKlienciAddAdres.Text,
						textBoxKlienciAddKodPocztowy.Text,
						nip,
						textBoxKlienciAddPESEL.Text,
						tel,
						textBoxKlienciAddMail.Text) != 0)
					{
						MessageBox.Show("Pomyślnie dodano klienta do bazy", "Dodawanie klienta", MessageBoxButton.OK, MessageBoxImage.Information);
					}
					zwinKlienci();
					showWindow(gridKlienciDeafult, buttonKlienciDeafultList);
				}
				else
					MessageBox.Show("Błąd, wypełnij pola NIPu oraz telefonu liczbą", "Dodawanie klienta", MessageBoxButton.OK, MessageBoxImage.Error);
			}


		}
        //----------------------------------------------KLIENCI->DEAFULT----------------------------------------------
        private void dataGridKlienci_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
				dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci(); 
				
				//wypelnianie pól z miejscowością
				KlienciDS.Miejscowosci_slownikDataTable tab = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetData();
				textBoxKlienciAddMiejscowoscAuto.clearItems();
				textBoxKlienciEdycjaMiejscowoscAuto.clearItems();
				foreach (KlienciDS.Miejscowosci_slownikRow row in tab)
				{
					textBoxKlienciAddMiejscowoscAuto.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(row.nazwa, row.nazwa));
					textBoxKlienciEdycjaMiejscowoscAuto.AddItem(new WPFAutoCompleteTextbox.AutoCompleteEntry(row.nazwa, row.nazwa));
				}
				//chowanie kontrolki edycji 
				textBoxKlienciEdycjaMiejscowoscAuto.Visibility = System.Windows.Visibility.Hidden;
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
			if (toggleButtonKlienciSearchExtend.IsChecked == false)
			{
				if (textBoxKlienciSearch.Text == "")
					dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetKlienciMiejscowosci();
				else
				{
					if ((bool)radioButtonKlienciSearchIdKlienta.IsChecked)
					{
						int id;
						if (int.TryParse(textBoxKlienciSearch.Text, out id))
							dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciMiejsconowsciByIdKlienta(id);
						else
							System.Windows.MessageBox.Show("Niepoprawne ID klienta.\nNumer identyfikacyjny klienta może zawierać tylko cyfry.", "Wyszukiwanie klienta", MessageBoxButton.OK, MessageBoxImage.Error);
					}
					else if ((bool)radioButtonKlienciSearchKlient.IsChecked)
					{
						if (textBoxKlienciSearch.Text.Contains(' '))
						{
							string[] szukaj = textBoxKlienciSearch.Text.Split(' ');
							dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataByKlienciMiejscowosciByImieNazwiskoKlienta(szukaj[0], szukaj[1]);
						}
						else
							dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataByKlienciMiejscowosciByNazwiskoKlienta(textBoxKlienciSearch.Text);
					}
				}
			}
			else
			{
				//KlienciDS.KlienciDataTable k = TablesManager.Manager.KlienciTableAdapter.GetDataByAllCriteria(null, "Mateusz", null, null, null, null, null, null, null, null);
				//Tworzenie warunków zapytania
				StringBuilder sb = new StringBuilder();
				sb.Append((textBoxKlienciSearchExtendImie.Text != "") ? (" AND UCASE(Klienci.imie) LIKE UCASE('%" + textBoxKlienciSearchExtendImie.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendNazwisko.Text != "") ? (" AND UCASE(Klienci.nazwisko) LIKE UCASE('%" + textBoxKlienciSearchExtendNazwisko.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendPesel.Text != "") ? (" AND UCASE(Klienci.pesel) LIKE UCASE('%" + textBoxKlienciSearchExtendPesel.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendAdres.Text != "") ? (" AND UCASE(Klienci.ulica) LIKE UCASE('%" + textBoxKlienciSearchExtendAdres.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendMiejscowosc.Text != "") ? (" AND UCASE(Miejscowosci_slownik.nazwa) LIKE UCASE('%" + textBoxKlienciSearchExtendMiejscowosc.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendKodPocztowy.Text != "") ? (" AND UCASE(Klienci.kod_pocztowy) LIKE UCASE('%" + textBoxKlienciSearchExtendKodPocztowy.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendTelefon.Text != "") ? (" AND UCASE(Klienci.nr_telefonu) LIKE UCASE('%" + textBoxKlienciSearchExtendTelefon.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendMail.Text != "") ? (" AND UCASE(Klienci.email) LIKE UCASE('%" + textBoxKlienciSearchExtendMail.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendFirma.Text != "") ? (" AND UCASE(Klienci.nazwa) LIKE UCASE('%" + textBoxKlienciSearchExtendFirma.Text + "%')") : "");
				sb.Append((textBoxKlienciSearchExtendNip.Text != "") ? (" AND UCASE(Klienci.nip) LIKE UCASE('%" + textBoxKlienciSearchExtendNip.Text + "%')") : "");

				//tworzenie komendy
				System.Data.Odbc.OdbcCommand cmd = TablesManager.Manager.KlienciTableAdapter.Connection.CreateCommand();
				//otwarcie połączenie
				TablesManager.Manager.KlienciTableAdapter.Connection.Open();
				cmd.CommandText = "SELECT Klienci.email, Klienci.imie, Klienci.nazwisko, Klienci.id_miejscowosci, Klienci.ulica, Klienci.nip, Klienci.pesel, Klienci.id_klienta, Klienci.nr_telefonu, Klienci.nazwa, " +
							" Miejscowosci_slownik.nazwa AS miejscowosc, Klienci.kod_pocztowy " +
							"FROM Klienci, Miejscowosci_slownik " +
							"WHERE Klienci.id_miejscowosci = Miejscowosci_slownik.id_miejscowosci " +
							sb.ToString();	//dodanie warunkow
				//pobranie readera
				System.Data.Odbc.OdbcDataReader rd = cmd.ExecuteReader();
				KlienciDS.KlienciDataTable tab = new KlienciDS.KlienciDataTable();
				//wypenienie DataTable za pomoca readera
				tab.Load(rd);
				//wypelnienie DGrida
				dataGridKlienci.ItemsSource = tab;
				dataGridKlienci.Items.Refresh();
				//zamkniecie polaczenia
				TablesManager.Manager.KlienciTableAdapter.Connection.Close();

			}
        }
        private void buttonKlienciSearch_Click(object sender, RoutedEventArgs e)
        {
            klienciSearch();
        }

		private void toggleButtonKlienciSearchExtend_Checked(object sender, RoutedEventArgs e)
		{
			if (toggleButtonKlienciSearchExtend.IsChecked == true)
			{
				//wyłączanie pol do wyszukiwania prostego
				textBoxKlienciSearch.IsEnabled = false;
				radioButtonKlienciSearchIdKlienta.IsEnabled = false;
				radioButtonKlienciSearchKlient.IsEnabled = false;

				gridKlienciSearchExtend.Visibility = System.Windows.Visibility.Visible;
			}
			else
			{
				//włączanie pol do wyszukiwania prostego
				textBoxKlienciSearch.IsEnabled = true;
				radioButtonKlienciSearchIdKlienta.IsEnabled = true;
				radioButtonKlienciSearchKlient.IsEnabled = true;

				gridKlienciSearchExtend.Visibility = System.Windows.Visibility.Collapsed;
			}
		}


        //----------------------------------------------KLIENCI->DODAJ----------------------------------------------
        private void buttonKlienciAdd_Click(object sender, RoutedEventArgs e)
        {
            zwinKlienci();
            showWindow(gridKlienciAdd, buttonKlienciBackOkList);
			textBoxKlienciAddMail.Text = "";
			textBoxKlienciAddImie.Text = "";
			textBoxKlienciAddNazwisko.Text = "";
			textBoxKlienciAddMiejscowoscAuto.Text = "";
			textBoxKlienciAddAdres.Text = "";
			textBoxKlienciAddNIP.Text = "";
            textBoxKlienciAddFirma.Text = "";
			textBoxKlienciAddPESEL.Text = "";
			textBoxKlienciAddTelefon.Text = "";
            textBoxKlienciAddKodPocztowy.Text = "";
        }

		private void buttonKlienciAddDodaj_Click(object sender, RoutedEventArgs e)
		{
			int nip, tel;
			if (radioButtonKlientAddFirma.IsChecked == false)
			{
				textBoxKlienciAddFirma.Text = "";
				textBoxKlienciAddNIP.Text = "0";
			}
			if(int.TryParse(textBoxKlienciAddNIP.Text, out nip) && int.TryParse(textBoxKlienciAddTelefon.Text, out tel))
			{
				//dodawanie klienta
				if (KlienciHelper.dodajKlienta(
					textBoxKlienciAddImie.Text,
					textBoxKlienciAddNazwisko.Text,
					textBoxKlienciAddFirma.Text,
					textBoxKlienciAddMiejscowoscAuto.Text,
					textBoxKlienciAddAdres.Text,
					textBoxKlienciAddKodPocztowy.Text,
					nip,
					textBoxKlienciAddPESEL.Text,
					tel,
					textBoxKlienciAddMail.Text)!=0)
				{
					MessageBox.Show("Pomyślnie dodano klienta do bazy", "Dodawanie klienta", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
			else
				MessageBox.Show("Błąd, wypełnij pola NIPu oraz telefonu liczbą", "Dodawanie klienta", MessageBoxButton.OK, MessageBoxImage.Error);
            
		}
		/// <summary>
		/// Ustawia pola w Gridzie add klienta odpowiednio dla "osoby prytwantej"/firmy
		/// </summary>
		private void klienciAddUstawPola()
		{
			if (radioButtonKlientAddOsoba.IsChecked==true)
			{
				groupBoxKlienciAdd1.Header = "Dane klienta";
				groupBoxKlienciAdd2.Visibility = System.Windows.Visibility.Collapsed;
			}
			else if (radioButtonKlientAddFirma.IsChecked == true)
			{
				groupBoxKlienciAdd1.Header = "Dane przedstawiciela";
				groupBoxKlienciAdd2.Visibility = System.Windows.Visibility.Visible;
			}
		}
		private void radioButtonKlientAdd_Checked(object sender, RoutedEventArgs e)
		{
			this.klienciAddUstawPola();
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
				if (!selectedRow.IsnazwaNull() && !selectedRow.nazwa.Equals(""))
					radioButtonKlientEdycjaFirma.IsChecked = true;
				else
					radioButtonKlientEdycjaOsoba.IsChecked = true;
				textBoxKlienciEdycjaImie.Text = selectedRow.imie;
                textBoxKlienciEdycjaNazwisko.Text = selectedRow.nazwisko;
                textBoxKlienciEdycjaPESEL.Text = selectedRow.pesel;
                textBoxKlienciEdycjaNIP.Text = selectedRow.nip.ToString();
                textBoxKlienciEdycjaTelefon.Text = selectedRow.nr_telefonu.ToString();
                textBoxKlienciEdycjaMail.Text = selectedRow.email;
				textBoxKlienciEdycjaMiejscowoscAuto.Visibility = System.Windows.Visibility.Visible;
                textBoxKlienciEdycjaMiejscowoscAuto.Text = (string)selectedRow["miejscowosc"];
                textBoxKlienciEdycjaKodPocztowy.Text = selectedRow.kod_pocztowy;
                textBoxKlienciEdycjaAdres.Text = selectedRow.ulica;
                textBoxKlienciEdycjaFirma.Text = selectedRow.IsnazwaNull() ? "" : selectedRow.nazwa;
                labelKlienciEdytujId.Content = selectedRow.id_klienta;
            }
            else  
                System.Windows.MessageBox.Show("Najpierw wybierz klienta.", "Edycja klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
		/// <summary>
		/// Ustawia pola w Gridzie edycji klienta odpowiednio dla "osoby prytwantej"/firmy
		/// </summary>
		private void klienciEditUstawPola(RadioButton rb)
		{
			if (rb.IsChecked == true)
			{
				groupBoxKlienciEdycja1.Header = "Dane klienta";
				groupBoxKlienciEdycja2.Visibility = System.Windows.Visibility.Collapsed;
			}
			else if (radioButtonKlientEdycjaFirma.IsChecked == true)
			{
				groupBoxKlienciEdycja2.Header = "Dane przedstawiciela";
				groupBoxKlienciEdycja2.Visibility = System.Windows.Visibility.Visible;
			}
		}
		private void radioButtonKlientEdycja_Checked(object sender, RoutedEventArgs e)
		{
            this.klienciEditUstawPola(radioButtonKlientEdycjaOsoba);
		}
        //----------------------------------------------KLIENCI->SZCZEGOLY----------------------------------------------
        private void buttonKlienciSzczegoly_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridKlienci.SelectedItem != null)
            {
                zwinKlienci();
                showWindow(gridKlienciSzczegoly, buttonKlienciBackList);
     
                KlienciDS.KlienciRow selectedRow = (KlienciDS.KlienciRow)((DataRowView)dataGridKlienci.SelectedItem).Row;
                //dataGridKlienci.ItemsSource = TablesManager.Manager.KlienciTableAdapter.GetDataKlienciMiejsconowsciByIdKlienta(selectedRow.id_klienta);
                if (!selectedRow.IsnazwaNull() && !selectedRow.nazwa.Equals(""))
                {
                    groupBoxKlienciSzczegolyFirma.Visibility = Visibility.Visible;
                    radioButtonKlienciSzczegolyFirma.IsChecked = true;
                }
                else
                {
                    groupBoxKlienciSzczegolyFirma.Visibility = Visibility.Collapsed;
                    radioButtonKlienciSzczegolyPrywatna.IsChecked = true;
                }
                labelKlienciSzczegolyImie.Content = selectedRow.imie;
                labelKlienciSzczegolyNazwisko.Content = selectedRow.nazwisko;
                labelKlienciSzczegolyPesel.Content = selectedRow.pesel;
                labelKlienciSzczegolyNip.Content = selectedRow.nip.ToString();
                labelKlienciSzczegolyTelefon.Content = selectedRow.nr_telefonu.ToString();
                labelKlienciSzczegolyMail.Content = selectedRow.email;
                labelKlienciSzczegolyMiejscowosc.Content = (string)selectedRow["miejscowosc"];
                labelKlienciSzczegolyKodPocztowy.Content = selectedRow.kod_pocztowy;
                labelKlienciSzczegolyAdres.Content = selectedRow.ulica;
                labelKlienciSzczegolyFirma.Content = selectedRow.IsnazwaNull() ? "" : selectedRow.nazwa;
            }
            else  
                System.Windows.MessageBox.Show("Najpierw wybierz klienta.", "Szczegóły klienta", MessageBoxButton.OK, MessageBoxImage.Warning);
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
        private void RefreshConnectionsPokoje()
        {
            RefreshRezerwacjeNowaPokoje();
            RefreshPobytyNowyPokoje();
        }
        private void RefreshPokoje()
        {
            PokojeWczytajStandardy();
            comboBoxPokojeEdycjaStandard.Items.Refresh();
            comboBoxPokojeStandard.Items.Refresh();
        }

        private void dataGridPokojeDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
            }
        }
        private void PokojeWczytajStandardy()
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
            comboBoxPokojeEdycjaStandard.ItemsSource = PokojeStringLst;
        }
        List<int> PokojeIdLst = new List<int>();
        List<string> PokojeStringLst = new List<string>();

        private void comboBoxPokojeStandard_Loaded(object sender, RoutedEventArgs e)
        {
            PokojeWczytajStandardy();
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
            if (currentGrid == gridPokojeEdycja)
            {
                if (textBoxPokojeEdycjaNrPokoju.Text != "" && comboBoxPokojeEdycjaStandard.SelectedItem != null)
                {
                    PokojeHelper.edytujPokoj((int)labelPokojeEdycjaId.Content, PokojeIdLst[comboBoxPokojeEdycjaStandard.SelectedIndex], textBoxPokojeEdycjaNrPokoju.Text);
                    dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
                    RefreshConnectionsPokoje();
                    zwinPokoje();
                    showWindow(gridPokojeDeafult, buttonPokojeDeafultList);
                }
                else
                {
                    System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Edycja pokoju", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                zwinPokoje();
                showWindow(gridPokojeDeafult, buttonPokojeDeafultList);

        }

        private void buttonPokojeDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxPokojeNrPokoju.Text != "" && comboBoxPokojeStandard.SelectedItem != null)
            {
                PokojeHelper.dodajPokoj(PokojeIdLst[comboBoxPokojeStandard.SelectedIndex], textBoxPokojeNrPokoju.Text);
                dataGridPokojeDeafult.ItemsSource = TablesManager.Manager.PokojeTableAdapter.GetDataPokojeStandardy();
                textBoxPokojeNrPokoju.Text = "";
                comboBoxPokojeStandard.SelectedItem = null;
                RefreshConnectionsPokoje();
            }
            else
            {
                System.Windows.MessageBox.Show("Wypełnij wszystkie pola.", "Dodawanie pokoju", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void buttonPokojeSzczegoly_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPokojeDeafult.SelectedItem != null)
            {
                zwinPokoje();
                showWindow(gridPokojeSzczegoly, buttonPokojeBackOkList);

                PokojeDS.PokojeRow selectedRow = (PokojeDS.PokojeRow)((DataRowView)dataGridPokojeDeafult.SelectedItem).Row;
                labelPokojeSzczegolyNr.Content = selectedRow.nr_pokoju;
                labelPokojeSzczegolyStandard.Content = selectedRow["dodatkowy_opis"];
                labelPokojeSzczegolyCena.Content = selectedRow["cena"];
                labelPokojeSzczegolyLosob.Content = selectedRow["ilosc_osob"];
                dataGridPokojeSzczegolyWyposazenie.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetDataListaWyposazenByID(selectedRow.id_slownikowe_pokoju);

            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pokój.", "Podgląd pokoju", MessageBoxButton.OK, MessageBoxImage.Warning);
     
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
        private void RefreshConnectionsStandPokoi()
        {
            RefreshPokoje();
        }
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
            przypiszWyposazeniaDoComboBoxa();
            StandPokoiDodajList.Clear();
            comboBoxStandPokoiDodajWyposazenie.ItemsSource = StandPokoiLabelLst;
            dataGridStandPokoiDodajWyposazenie.ItemsSource = StandPokoiDodajList;
            textBoxStandPokoiDodajCena.Text = "";
            textBoxStandPokoiDodajIlOsob.Text = "";
            textBoxStandPokoiDodajOpis.Text = "";
        }

        private void przypiszWyposazeniaDoComboBoxa()
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

        private void comboBoxStandPokoiDodajWyposazenie_Loaded(object sender, RoutedEventArgs e)
        {
           przypiszWyposazeniaDoComboBoxa();
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
					decimal cena;
                    int ilOsob;
                    if (decimal.TryParse(textBoxStandPokoiEdycjaCena.Text, out cena) && int.TryParse(textBoxStandPokoiEdycjaIlOsob.Text, out ilOsob))
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
					decimal cena;
                    int ilOsob;
                    if (decimal.TryParse(textBoxStandPokoiDodajCena.Text, out cena) && int.TryParse(textBoxStandPokoiDodajIlOsob.Text, out ilOsob))
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

        private void buttonStandPokoiSzczegoly_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridStandPokoiDeafult.SelectedItem != null)
            {
                zwinStandPokoi();
                showWindow(gridStandPokoiSzczegoly, buttonStandPokoiBackOkList);

                PokojeDS.Pokoje_slownikRow selectedRow = (PokojeDS.Pokoje_slownikRow)((DataRowView)dataGridStandPokoiDeafult.SelectedItem).Row;
                labelStandPokoiSzczegolyCena.Content = selectedRow.cena;
                labelStandPokoiSzczegolyLosob.Content = selectedRow.ilosc_osob;
                labelStandPokoiSzczegolyOpis.Content = selectedRow.dodatkowy_opis;

                dataGridStandPokoiSzczegWyp.ItemsSource = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetDataListaWyposazenByID(selectedRow.id_slownikowe_pokoju);

            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz standard pokoi.", "Podgląd standardu pokoi", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    checkBoxRabatyPobyty.IsChecked = true;
                    checkBoxRabatyPosilki.IsChecked = false;
                    checkBoxRabatyUslugi.IsChecked = false;
                    checkBoxRabatyAktywny.IsChecked = true;
                    checkBoxRabatyEdycjaProcentowy.IsChecked = false;
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
        private void RefreshConnectionsPosilki()
        {
            RefreshPobytyPosilkiSlownik();
        }
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
				decimal cena;
				if (decimal.TryParse(textBoxPosilkiEdycjaCena.Text, out cena))
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
				decimal cena;
				if (decimal.TryParse(textBoxPosilkiCena.Text, out cena))
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
        private void RefreshConnectionsUslugi()
        {
            RefreshPobytyUslugiSlownik();
        }
        private void dataGridUslugiDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {//pojawienie sie pola
                dataGridUslugiDeafult.ItemsSource = TablesManager.Manager.Uslugi_slownikTableAdapter.GetDataPlusSlownikPracownicy();
            }
        }
        private void RefreshUslugi()
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
            comboBoxUslugiEdycjaWykonawca.ItemsSource = uslugiStanowiskaStringLst;
            comboBoxUslugiWykonawca.Items.Refresh();
            comboBoxUslugiEdycjaWykonawca.Items.Refresh();
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
				decimal cena;
				if (decimal.TryParse(textBoxUslugiEdycjaCena.Text, out cena))
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
				decimal cena;
				if (decimal.TryParse(textBoxUslugiCena.Text, out cena))
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
                    UslugiSlownikHelper.usunTypUslugi((int)selectedRow.id_slownikowe_uslugi);
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
        private void przypiszStanowiskaDoComboBoxa(ref ComboBox comboBox){
            stanowiskaIdList.Clear();
            stanowiskaStringList.Clear();
            PracownicyDS.Pracownicy_slownikDataTable stanowiskaTable = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();
            foreach (PracownicyDS.Pracownicy_slownikRow row in stanowiskaTable)
            {
                stanowiskaStringList.Add(row.nazwa + " (" + row.opis + ")");
                stanowiskaIdList.Add(row.id_stanowiska);
            }
            comboBox.ItemsSource = stanowiskaStringList;
        }
        private void comboBoxPracownicyDodajStanowisko_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            przypiszStanowiskaDoComboBoxa(ref comboBoxPracownicyDodajStanowisko);
        }

        private void comboBoxPracownicyEdycjaStanowisko_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            przypiszStanowiskaDoComboBoxa(ref comboBoxPracownicyEdycjaStanowisko);
        }

        //----------------------------------------------PRACOWNICY->MENU
        private void RefreshConnectionsPracownicy()
        {
            //RefreshPobytyUslugi();
        }
        private void RefreshPracownicyDodaj()
        {
            przypiszStanowiskaDoComboBoxa(ref comboBoxPracownicyDodajStanowisko);
            comboBoxPracownicyDodajStanowisko.Items.Refresh();
        }
        private void RefreshPracownicyEdytuj()
        {
            przypiszStanowiskaDoComboBoxa(ref comboBoxPracownicyEdycjaStanowisko);
            comboBoxPracownicyEdycjaStanowisko.Items.Refresh();
        }
        private void buttonPracownicySzukaj_Click(object sender, RoutedEventArgs e)
        {
            SzukajPracownika();
        }
       

        private void buttonPracownicyDodaj_Click(object sender, RoutedEventArgs e)
        {
            zwinPracownicy();
            showWindow(gridPracownicyDodaj, buttonPracownicyBackOkList);
            przypiszStanowiskaDoComboBoxa(ref comboBoxPracownicyDodajStanowisko);
            textBoxPracownicyDodajImie.Clear();
            textBoxPracownicyDodajNazwisko.Clear();
            textBoxPracownicyDodajLogin.Clear();
            textBoxPracownicyDodajPESEL.Clear();
            textBoxPracownicyDodajTelefon.Clear();
            
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
                    RefreshConnectionsPracownicy();
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
                        textBoxPracownicyEdycjaLogin.Text,textBoxPracownicyEdycjaHaslo.Password, (int)labelPracownicyEdycjaId.Content, stanowiskaIdList[comboBoxPracownicyEdycjaStanowisko.SelectedIndex]);    

                    dataGridPracownicyDeafult.ItemsSource = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyStanowiska();
                    RefreshConnectionsPracownicy();
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
                przypiszStanowiskaDoComboBoxa(ref comboBoxPracownicyEdycjaStanowisko); 

                PracownicyDS.PracownicyRow selectedRow = (PracownicyDS.PracownicyRow)((DataRowView)dataGridPracownicyDeafult.SelectedItem).Row;
                comboBoxPracownicyEdycjaStanowisko.SelectedIndex = stanowiskaIdList.IndexOf(selectedRow.id_stanowiska);
                textBoxPracownicyEdycjaImie.Text = selectedRow.imie;
                textBoxPracownicyEdycjaNazwisko.Text = selectedRow.nazwisko;
                textBoxPracownicyEdycjaLogin.Text = selectedRow.login;
                labelPracownicyEdycjaId.Content = selectedRow.id_pracownika;
                textBoxPracownicyEdycjaHaslo.Password = "";
                /*
                textBoxPracownicyEdycjaPESEL.Text = selectedRow.Pesel;
                textBoxPracownicyEdycjaNIP.Text = selectedRow.Nip;
                textBoxPracownicyEdycjaAdres.Text = selectedRow.Adres;
                textBoxPracownicyEdycjaMiejscowosc.Text = selectedRow.Miejscowosc;
                textBoxPracownicyEdycjaKodPocztowy.Text = selectedRow.KodPocztowy;
                textBoxPracownicyEdycjaTelefon.Text = selectedRow.Telefon;
                */
                comboBoxPracownicyEdycjaStanowisko.ItemsSource = stanowiskaStringList;
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
                DateTime czasObecny = DateTime.Now;
                int rok = czasObecny.Year;
                int miesiac = czasObecny.Month;
                int dzien = czasObecny.Day;
                DateTime czasStart = new DateTime(rok, miesiac, dzien, 0, 0, 0);
                DateTime czasStop = new DateTime(rok, miesiac, dzien, 23, 59, 59);
                dataGridPracownicyZadania.ItemsSource = UslugiHelper.znajdzZadaniaDlaPracownikaWCzasie(selectedRow.id_pracownika, czasStart, czasStop);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz pracownika.", "Zadania pracownika", MessageBoxButton.OK, MessageBoxImage.Warning);       
        }
       
//----------------------------------------------STANOWISKA----------------------------------------------
        private void RefreshConnectionsStanowiska()
        {
            RefreshUslugi();
            RefreshPracownicyDodaj();
            RefreshPracownicyEdytuj();
        }

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
                RefreshConnectionsStanowiska();
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
                RefreshConnectionsStanowiska();
                textBoxStanowiskaNazwa.Clear();
                textBoxStanowiskaOpis.Clear(); 
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

                if (selectedRow.id_stanowiska > 3)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno chcesz usunąć: " + (string)selectedRow["nazwa"], "Usuwanie stanowiska", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        PracownicyHelper.usunStanowisko(selectedRow.id_stanowiska);
                        dataGridStanowiskaDeafult.ItemsSource = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetData();

                    }
                }
                else
                    System.Windows.MessageBox.Show("Nie można usunąć stanowiska.", "Usuwanie stanowiska", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                DateTime czasStop = new DateTime(rok, miesiac, dzien, 23, 59, 59);
                dataGridZadaniaDeafult.ItemsSource = UslugiHelper.znajdzZadaniaDlaPracownikaWCzasie(this.id, DateTime.Now, czasStop);
            }
        }

        private void dataGridArchiwumDeafult_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)(e.NewValue) == true)
            {
                dataGridArchiwumDeafult.ItemsSource = UslugiHelper.znajdzZadaniaPracownikaDoCzasu(this.id, DateTime.Now);
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

        private void buttonZadaniaZrealizuj_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridArchiwumDeafult.SelectedItem != null)
            {
                UslugiDS.UslugiRow selectedRow = (UslugiDS.UslugiRow)
                ((DataRowView)dataGridArchiwumDeafult.SelectedItem).Row;

                if (selectedRow.zrealizowane == false)
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Czy napewno zrealizować: " + (string)selectedRow["opis"], "Realizacja zadania", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        TablesManager.Manager.UslugiTableAdapter.UpdateZrealizowano(selectedRow.id_uslugi);
                        dataGridArchiwumDeafult.ItemsSource = UslugiHelper.znajdzZadaniaPracownikaDoCzasu(this.id, DateTime.Now);
                    }
                }
                else
                    System.Windows.MessageBox.Show("Zadanie zostało już zrealizowane.", "Realizacja zadania", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                System.Windows.MessageBox.Show("Najpierw wybierz zadanie.", "Realizacja zadania", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private void gridKucharz_Initialized(object sender, EventArgs e)
        {
            if (this.stanowisko == "Kucharz")
            {
                labelKucharz1day.Content = DateTime.Today.ToLongDateString();
                labelKucharz2day.Content = DateTime.Today.AddDays(1.0).ToLongDateString();
                labelKucharz3day.Content = DateTime.Today.AddDays(2.0).ToLongDateString();
                labelKucharz4day.Content = DateTime.Today.AddDays(3.0).ToLongDateString();
                labelKucharz5day.Content = DateTime.Today.AddDays(4.0).ToLongDateString();
                dataGridKucharz1day.Items.Add(PosilkiHelper.getPosilkiPoTerminie(DateTime.Today));
                dataGridKucharz2day.Items.Add(PosilkiHelper.getPosilkiPoTerminie(DateTime.Today.AddDays(1.0)));
                dataGridKucharz3day.Items.Add(PosilkiHelper.getPosilkiPoTerminie(DateTime.Today.AddDays(2.0)));
                dataGridKucharz4day.Items.Add(PosilkiHelper.getPosilkiPoTerminie(DateTime.Today.AddDays(3.0)));
                dataGridKucharz5day.Items.Add(PosilkiHelper.getPosilkiPoTerminie(DateTime.Today.AddDays(4.0)));
            }
        }


        //-----------------------------------ZMIANA HASŁA---------------------------------------------

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (LogowanieHelper.sprawdzHaslo(this.id, obecneHaslo.Password))
            {
                if (noweHaslo.Password != "")
                {
                    if (noweHaslo.Password == powtorzHaslo.Password)
                    {
                        LogowanieHelper.zmienHaslo(this.id, noweHaslo.Password);
                        System.Windows.MessageBox.Show("Hasło zostało zmienione.", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Information);
                        obecneHaslo.Clear();
                        noweHaslo.Clear();
                        powtorzHaslo.Clear();
                    }
                    else
                        System.Windows.MessageBox.Show("Powtórzone hasło jest niepoprawne.", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    System.Windows.MessageBox.Show("Nowe hasło jest niepoprawne.", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
                System.Windows.MessageBox.Show("Obecne hasło jest niepoprawne.", "Zmiana hasła", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void buttonZmianaHasla_Checked(object sender, RoutedEventArgs e)
        {
            if (buttonZmianaHasla.IsChecked == true)
            {
                obecneHaslo.Clear();
                noweHaslo.Clear();
                powtorzHaslo.Clear();
                groupBoxZmianaHasla.Visibility = Visibility.Visible;
            }
            else
                groupBoxZmianaHasla.Visibility = Visibility.Hidden;
        }





    }

}
