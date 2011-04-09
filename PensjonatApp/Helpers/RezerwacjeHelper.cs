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
            if(pokoje.Count == 0)
                dialog.Append("Nieprawidłowa lista pokoi\n");

            if (lastMsg != "")
                return false;
            return true;
        }


        /// <summary>
        /// Potwierdzenie zaliczki rezerwacji na podstawie id_rezerwacji, podawana wartość kwoty zaliczki (?)
        /// </summary>
        /// <returns></returns>
        public static int potwierdzZaliczke(int id_rezerwacji, decimal kwota)
        {
            RezerwacjeDS.RezerwacjeDataTable tab = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeByID(id_rezerwacji);
            tab[0].zaplacono_zaliczke = true;
            tab[0].zaliczka = kwota;
            return TablesManager.Manager.RezerwacjeTableAdapter.Update(tab);
        }

        /// <summary>
        /// Zwaraca pokoje wolne w podanym terminie
        /// </summary>
        /// <returns>Wolne pokoje</returns>
        public PokojeDS.PokojeDataTable pobierzPokojeWolne(DateTime start_pobytu, DateTime koniec_pobytu)
        {
            return TablesManager.Manager.PokojeTableAdapter.GetDataWolnePokojeByTermin(koniec_pobytu, start_pobytu);
        }

        /// <summary>
        /// Dodawanie rezerwacji
        /// pokoje wybrane w procesie rezerwacji przechowywane w typie PokojeDS.PokojeDataTable. jeżeli tak jest źle mogę to zmienić na zwykłą tablicę
        /// </summary>
        /// <returns></returns>
        public static int dodajRezerwacje(int id_klienta_rezerwujacego, int ilosc_osob, decimal zaliczka, PokojeDS.PokojeDataTable pokoje, DateTime start_pobytu, DateTime koniec_pobytu)
        {
            TablesManager.Manager.RezerwacjeTableAdapter.Insert(zaliczka, false, ilosc_osob, id_klienta_rezerwujacego);
            RezerwacjeDS.RezerwacjeDataTable tabRez = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjaOstatnia();

            foreach (PokojeDS.PokojeRow pokoj in pokoje)
            {
                TablesManager.Manager.PobytyTableAdapter.Insert(pokoj.id_pokoju, tabRez[0].id_rezerwacji, start_pobytu, koniec_pobytu, null, null);
            }

            return 1;
        }

        /// <summary>
        /// Dodawanie rezerwacji, dodatkowo dodawane posilki, tak jak pokoje
        /// </summary>
        /// <returns></returns>
        public static int dodajRezerwacjePosilki(int id_klienta_rezerwujacego, int ilosc_osob, decimal zaliczka, PokojeDS.PokojeDataTable pokoje, PosilkiDS.PosilkiDataTable posilki, DateTime start_pobytu, DateTime koniec_pobytu)
        {
            TablesManager.Manager.RezerwacjeTableAdapter.Insert(zaliczka, false, ilosc_osob, id_klienta_rezerwujacego);
            RezerwacjeDS.RezerwacjeDataTable tabRez = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjaOstatnia();

            foreach (PokojeDS.PokojeRow pokoj in pokoje)
            {
                TablesManager.Manager.PobytyTableAdapter.Insert(pokoj.id_pokoju, tabRez[0].id_rezerwacji, start_pobytu, koniec_pobytu, null, null);
                PobytyDS.PobytyDataTable tabPob = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyOstatni();

                foreach (PosilkiDS.PosilkiRow posilek in posilki)
                {
                    TablesManager.Manager.PosilkiTableAdapter.Insert(tabPob[0].id_pobytu, posilek.id_slownikowe_posilku, posilek.data);
                }
            }

            return 1;
        }

        /// <summary>
        /// Usuwanie rezerwacji na podstawie id_rezerwacji
        /// </summary>
        /// <returns></returns>
        public static int usunRezerwacje(int id_rezerwacji)
        {
            RezerwacjeDS.RezerwacjeDataTable tab = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeByID(id_rezerwacji);
            //?
            return 1;
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
    }
}
