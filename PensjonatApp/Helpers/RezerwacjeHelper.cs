using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class RezerwacjeHelper
    {
        /// <summary>
        /// Wiadomośc do pobrania z innych modułów nt. np. które pole się dubluje
        /// </summary>
        public static string lastMsg { get; private set; }

        /// <summary>
        /// Bezargumentowy konstruktor statyczny, zeruje ostatnia wiadomosc
        /// </summary>
        static RezerwacjeHelper()
        {
            lastMsg = "";
        }

        /// <summary>
        /// Sprawdza poprawność id_rezerwacji, info nt. bledu w lastMsg
        /// </summary>
        /// <returns>True jeśli wszystko jest poprawne</returns>
        public static bool idRezeracjiVerify(int id_rezerwacji)
        {
            lastMsg = "";
            StringBuilder dialog = new StringBuilder("");

            if (id_rezerwacji <= 0)  //może jeszcze więcej warunków...
            {
                dialog.Append("Nieprawidłowe ID Rezerwacji\n");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Sprawdza poprawność id_pobytu, info nt. bledu w lastMsg
        /// </summary>
        /// <returns>True jeśli wszystko jest poprawne</returns>
        public static bool idPobytuVerify(int id_pobytu)
        {
            lastMsg = "";
            StringBuilder dialog = new StringBuilder("");

            if (id_pobytu <= 0)
            {
                dialog.Append("Nieprawidłowe ID Pobytu\n");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Sprawdza poprawność id_slownikowe_posilku, info nt. bledu w lastMsg
        /// </summary>
        /// <returns>True jeśli wszystko jest poprawne</returns>
        public static bool idSlownikowePosilkuVerify(int id_slownikowe_posilku)
        {
            lastMsg = "";
            StringBuilder dialog = new StringBuilder("");

            if (id_slownikowe_posilku <= 0)
            {
                dialog.Append("Nieprawidłowe ID Posilku\n");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Sprawdza poprawność terminu pobytu, info nt. bledu w lastMsg
        /// </summary>
        /// <returns>True jeśli wszystko jest poprawne</returns>
        public static bool terminPobytuVerify(DateTime start_pobytu, DateTime koniec_pobytu)
        {
            lastMsg = "";
            StringBuilder dialog = new StringBuilder("");

            if (start_pobytu >= koniec_pobytu)
            {
                dialog.Append("Nieprawidłowy czas pobytu\n");
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Sprawdza poprawność informacji o rezerwacji, info nt. bledu w lastMsg
        /// </summary>
        /// <returns>True jeśli wszystko jest poprawne</returns>
        public static bool dodajRezerwacjeVerify(int id_klienta_rezerwujacego, int ilosc_osob, decimal zaliczka, PokojeDS.PokojeDataTable pokoje, DateTime start_pobytu, DateTime koniec_pobytu)
        {
            lastMsg = "";
            StringBuilder dialog = new StringBuilder("");

            if (start_pobytu >= koniec_pobytu)
                dialog.Append("Nieprawidłowy czas pobytu\n");
            if (id_klienta_rezerwujacego <= 0)
                dialog.Append("Nieprawidłowe ID Rezerwacji\n");
            if (ilosc_osob <= 0)
                dialog.Append("Nieprawidłowa ilość osób\n");
            if (zaliczka < 0)
                dialog.Append("Nieprawidłowa wartość zaliczki\n");
            if (pokoje.Count == 0)
                dialog.Append("Nieprawidłowa lista pokoi\n");

            if (lastMsg != "")
                return false;
            return true;
        }


        /// <summary>
        /// Potwierdzenie zaliczki rezerwacji na podstawie id_rezerwacji
        /// </summary>
        /// <returns></returns>
        public static int potwierdzZaliczke(int id_rezerwacji)
        {
            RezerwacjeDS.RezerwacjeDataTable tab = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeByID(id_rezerwacji);
            tab[0].zaplacono_zaliczke = true;
          
            return TablesManager.Manager.RezerwacjeTableAdapter.Update(tab);
        }

        /// <summary>
        /// Zwaraca pokoje wolne w podanym terminie
        /// </summary>
        /// <returns>Wolne pokoje</returns>
        public static PokojeDS.PokojeDataTable pobierzPokojeWolne(DateTime start_pobytu, DateTime koniec_pobytu)
        {
            return TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeByTermin(start_pobytu, start_pobytu, koniec_pobytu, koniec_pobytu, start_pobytu, koniec_pobytu);
        }

        /// <summary>
        /// Zwaraca pokoje wolne w podanym terminie (z standardem)
        /// </summary>
        /// <returns>Wolne pokoje</returns>
        public static PokojeDS.PokojeDataTable pobierzPokojeWolneStandard(DateTime start_pobytu, DateTime koniec_pobytu)
        {
            return TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeStandardByTermin(start_pobytu, start_pobytu, koniec_pobytu, koniec_pobytu, start_pobytu, koniec_pobytu);
        }

        /// <summary>
        /// Czy pokoj jest wolny w danym retminie?
        /// </summary>
        /// <returns>czy wolny- bool</returns>
         public static bool czyPokojWolny(int id_pokoju, DateTime start_pobytu, DateTime koniec_pobytu)
         {
             PokojeDS.PokojeDataTable tabPo = pobierzPokojeWolne(start_pobytu, koniec_pobytu);
             if (tabPo.Count == 0)
                 return false;
             else
             {
                 bool jest = false;
                 foreach (PokojeDS.PokojeRow pokoj in tabPo)
                 {
                     if (pokoj.id_pokoju == id_pokoju)
                     {
                         jest = true;
                         break;
                     }
                 }

                 if (jest)
                     return true;
                 else
                     return false;
             }
         }
         
        /// <summary>
        /// Sprawdzanie czy pobyt jest aktualny
        /// Na podstawie wystawienia rachunku.
        /// </summary>
        /// <returns>tak czy nie</returns>
        public static bool czyPobytAktualny(int id_pobytu)
        {
            PobytyDS.PobytyDataTable tabPob = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyCzyJestRachunek(id_pobytu);
            if (tabPob.Count == 1)
                if (tabPob[0].id_rezerwacji.Equals(null))
                    return true;
            return false;
        }

        /// <summary>
        /// Dodawanie rezerwacji
        /// pokoje wybrane w procesie rezerwacji przechowywane w typie PokojeDS.PokojeDataTable. jeżeli tak jest źle mogę to zmienić na zwykłą tablicę
        /// </summary>
        /// <returns>1 - ok, -1 - nie ma takiego pokoju, -2 błąd wewnetrzny</returns>
        public static int dodajRezerwacje(Int32 id_klienta_rezerwujacego, Int32 ilosc_osob, Decimal zaliczka, List<Int32> pokoje, DateTime start_pobytu, DateTime koniec_pobytu)
        {
            int a = TablesManager.Manager.RezerwacjeTableAdapter.InsertQuery(zaliczka, false, ilosc_osob, id_klienta_rezerwujacego);
            RezerwacjeDS.RezerwacjeDataTable tabRez = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeOstatnia();

            if (tabRez.Count > 0 && tabRez[0].id_klienta == id_klienta_rezerwujacego)
            {
                bool first = true;
                foreach (int pokoj_id in pokoje)
                {
                    PokojeDS.Pokoje_slownikDataTable pokoj_standard = TablesManager.Manager.Pokoje_slownikTableAdapter.GetDataStandardByIDPokoju(pokoj_id);
                    if (pokoj_standard.Count == 1)
                    {
                        for (int y = 0; y < pokoj_standard[0].ilosc_osob; y++)
                        {
                            //dodaje rezerwujacego
                            if (first)
                            {
                                TablesManager.Manager.PobytyTableAdapter.Insert(pokoj_id, tabRez[0].id_rezerwacji, start_pobytu, koniec_pobytu, null, id_klienta_rezerwujacego);
                                first = false;
                            }else
                                TablesManager.Manager.PobytyTableAdapter.Insert(pokoj_id, tabRez[0].id_rezerwacji, start_pobytu, koniec_pobytu, null, null);
                        }
                    }
                    else
                        return -1;
                }
            }else 
                return -2;


            return 1;
        }

        /*/// <summary>
        /// Dodawanie rezerwacji, dodatkowo dodawane posilki, tak jak pokoje
        /// </summary>
        /// <returns></returns>
        public static int dodajRezerwacjePosilki(int id_klienta_rezerwujacego, int ilosc_osob, decimal zaliczka, List<int> pokoje, PosilkiDS.PosilkiDataTable posilki, DateTime start_pobytu, DateTime koniec_pobytu)
        {
            TablesManager.Manager.RezerwacjeTableAdapter.Insert(zaliczka, false, ilosc_osob, id_klienta_rezerwujacego);
            RezerwacjeDS.RezerwacjeDataTable tabRez = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeOstatnia();

            foreach (int pokoj_id in pokoje)
            {
                TablesManager.Manager.PobytyTableAdapter.Insert(pokoj_id, tabRez[0].id_rezerwacji, start_pobytu, koniec_pobytu, null, null);
                PobytyDS.PobytyDataTable tabPob = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyOstatni();

                foreach (PosilkiDS.PosilkiRow posilek in posilki)
                {
                    TablesManager.Manager.PosilkiTableAdapter.Insert(tabPob[0].id_pobytu, posilek.id_slownikowe_posilku, posilek.data);
                }
            }

            return 1;
        }
        */
        /// <summary>
        /// Usuwanie rezerwacji na podstawie id_rezerwacji
        /// </summary>
        /// <returns></returns>
        public static int usunRezerwacje(int id_rezerwacji)
        {
            RezerwacjeDS.RezerwacjeDataTable tab = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeByID(id_rezerwacji);
/*            PobytyDS.PobytyDataTable tabPo = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRezerwacji(id_rezerwacji);

            for (int i = 0; i < tabPo.Count; i++)
            {
                TablesManager.Manager.PobytyTableAdapter.Delete(tabPo[i].id_pobytu, tabPo[i].id_pokoju, tabPo[i].id_rezerwacji, tabPo[i].termin_start, tabPo[i].termin_koniec, tabPo[i].id_rachunku, tabPo[i].id_klienta);
            }
            */
            return TablesManager.Manager.RezerwacjeTableAdapter.Delete(tab[0].id_rezerwacji, tab[0].zaliczka, tab[0].zaplacono_zaliczke, tab[0].ilosc_osob, tab[0].id_klienta);

        }


        /// <summary>
        /// Przydzielenie klienta na podstawie id_klienta do pobytu: id_pobytu
        /// </summary>
        /// <returns></returns>
        public static int przydzielKlientaDoPobytu(int id_pobytu, int id_klienta)
        {
            PobytyDS.PobytyDataTable tab = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByID(id_pobytu);
            tab[0].id_klienta = id_klienta;
            return TablesManager.Manager.PobytyTableAdapter.Update(tab);
        }

        /// <summary>
        /// Dodanie posilku do pobytu
        /// </summary>
        /// <returns></returns>
        public static int przydzielPosilekDoPobytu(int id_pobytu, int id_slownikowe_posilku, DateTime termin)
        {
            return TablesManager.Manager.PosilkiTableAdapter.Insert(id_pobytu, id_slownikowe_posilku, termin);

        }
        
        /// <summary>
        /// Nowe pobyty, pierwszy element w id_klientow - szef grupy
        /// </summary>
        /// <returns>-1:błąd tablic id_klientow i id_pokojow, 1:udało się</returns>
        public static int dodajNowyPobyt(List<int> id_klientow, List<int> id_pokojow, DateTime termin_start, DateTime termin_koniec)
        {
            try
            {
                //dodaje rezerwacje
                int a = TablesManager.Manager.RezerwacjeTableAdapter.InsertQuery(0, false, id_klientow.Count, id_klientow[0]);
                RezerwacjeDS.RezerwacjeDataTable tabRez = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeOstatnia();

                if (tabRez.Count > 0 && tabRez[0].id_klienta == id_klientow[0])
                {
                    for (int i = 0; i < id_klientow.Count; i++)
                    {
                        TablesManager.Manager.PobytyTableAdapter.Insert(id_pokojow[i], tabRez[0].id_rezerwacji, termin_start, termin_koniec, null, id_klientow[i]);
                    }
                }    
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 1;
        }



        /// <summary>
        /// Tworzy kompletne dodanie klienta który przychodzi z ulicy i chce się zakwaterować, pobiera id_klinta, id_pokokju oraz termin zakwaterowania
        /// </summary>
        /// <returns>-2 :błąd wewnętrzny, -1:podany pokój nie jest wolny, 1:udało się</returns>
        public static int dodajRezerwacjeIZakwaterowanieOdRazu(int id_klienta, int id_pokoju, DateTime termin_start, DateTime termin_koniec)
        {
            if (RezerwacjeHelper.czyPokojWolny(id_pokoju, termin_start, termin_koniec))
            {
                List<int> listaPo = new List<int>();
                listaPo.Add(id_pokoju);
                RezerwacjeHelper.dodajRezerwacje(id_klienta, 1, 0, listaPo, termin_start, termin_koniec);
                RezerwacjeDS.RezerwacjeDataTable tabRez = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeOstatnia();

                return 1;

                /*int tmp = tabRez[0].id_klienta;
                if(tabRez[0].id_klienta == id_klienta)
                {
                    RezerwacjeHelper.dodajKlientaDoPobytuNaPodstawieRezerwacji(tabRez[0].id_rezerwacji, id_klienta, id_pokoju);
                    return 1;
                }
                else
                    return -2;*/

            }else
                return -1;
        }
        

        /// <summary>
        /// Na podstawie isniejącej rezerwacji(id_rezerwacji), w której zostały stworzone rekody dla pobytów, z id zarezerwowanych pokojów, przydziela klienta(id_klienta) do danego pokoju(id_pokoju).
        /// </summary>
        /// <returns>- 1: nie ma takiej rezerwacji, lub dany pokój nie jest zarazerwowany dla tej rezerwacji, -2 :ten pokoj ma już przydzielonego klienta w ramach danej rezerwacji, 1 :udało się</returns>
        public static int dodajKlientaDoPobytuNaPodstawieRezerwacji(int id_rezerwacji, int id_klient, int id_pokoju)
        {
            PobytyDS.PobytyDataTable tabPo = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdPokojuIdRezerwacji(id_pokoju, id_rezerwacji);
            if (tabPo.Count == 0)
                return -1;  //nie ma takiej rezerwacji, lub dany pokój nie jest zarazerwowany dla tej rezerwacji
            else
                if (!tabPo[0].Isid_klientaNull())
                    return -2;  //ten pokoj ma już przydzielonego klienta w ramach danej rezerwacji
                else
                {
                    TablesManager.Manager.PobytyTableAdapter.UpdatePobytyIdKlientaByIdRezerwacjiIdPokoju(id_klient, id_rezerwacji, id_pokoju);
                    return 1;
                }

        }

    }
}
