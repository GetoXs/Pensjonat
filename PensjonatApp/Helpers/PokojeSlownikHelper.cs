using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class PokojeSlownikHelper
    {
        /// <summary>
        /// Dodaje klase pokoi (slownik).
        /// Wymagane parametry to wszystkie pola niezbedne do wypelnienia bazy danych oraz tablica zawierajaca ID elementow wyposazenia.
        /// Tablica ta jest wymagana, poniewaz przy jej pomocy dokonywane jest powiazanie klasy pokoju z konkretnymi elementami wyposazenia.
        /// </summary>
        public static int dodajKlasePokoi(decimal cena, string dodatkowy_opis, int ilosc_osob, int[] tablicaIdElementowWyposazenia)
        {
            TablesManager.Manager.Pokoje_slownikTableAdapter.Insert(cena, dodatkowy_opis, ilosc_osob);
            int? rekordZMaxID = TablesManager.Manager.Pokoje_slownikTableAdapter.GetDataMaxID();
            for (int i = 0; i < tablicaIdElementowWyposazenia.Length; i++)
                WyposazeniaHelper.dodajWyposazenie((int)rekordZMaxID, tablicaIdElementowWyposazenia[i]);
            return 1;
        }

        /// <summary>
        /// Edytuje klase pokoi (slownik).
        /// Wymagane parametry to wszystkie pola niezbedne do wypelnienia bazy danych, tablica zawierajaca ID elementow wyposazenia oraz ID edytowanej kategorii pokoju.
        /// Tablica elementow wyposazenia jest wymagana, poniewaz przy jej pomocy dokonywane jest powiazanie klasy pokoju z konkretnymi elementami wyposazenia.
        /// </summary>
        public static int edytujKlasePokoi(int id_slownikowe_pokoju, decimal cena, string dodatkowy_opis, int ilosc_osob, int[] tablicaIdElementowWyposazenia)
        {
			TablesManager.Manager.Pokoje_slownikTableAdapter.UpdateQuery(cena, dodatkowy_opis, ilosc_osob, id_slownikowe_pokoju);

            TablesManager.Manager.WyposazeniaTableAdapter.DeleteByID(id_slownikowe_pokoju);
            for (int i = 0; i < tablicaIdElementowWyposazenia.Length; i++)
                WyposazeniaHelper.dodajWyposazenie(id_slownikowe_pokoju, tablicaIdElementowWyposazenia[i]);
            return 1;
        }
		/// <summary>
		/// Kasuje klase pokoi
		/// </summary>
		public static int kasujKlasePokoi(int id_slownikowe_pokoju)
		{
			TablesManager.Manager.WyposazeniaTableAdapter.DeleteByID(id_slownikowe_pokoju);
			return TablesManager.Manager.Pokoje_slownikTableAdapter.DeleteByID(id_slownikowe_pokoju);
		}
    }
}
