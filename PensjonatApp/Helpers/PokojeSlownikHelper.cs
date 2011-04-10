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
            PokojeDS.Pokoje_slownikDataTable doZmiany = TablesManager.Manager.Pokoje_slownikTableAdapter.GetDataByID(id_slownikowe_pokoju);
            doZmiany[0].cena = cena;
            doZmiany[0].dodatkowy_opis = dodatkowy_opis;
            doZmiany[0].ilosc_osob = ilosc_osob;
            TablesManager.Manager.Pokoje_slownikTableAdapter.Update(doZmiany);
            TablesManager.Manager.WyposazeniaTableAdapter.DeleteData(id_slownikowe_pokoju);
            for (int i = 0; i < tablicaIdElementowWyposazenia.Length; i++)
                WyposazeniaHelper.dodajWyposazenie(id_slownikowe_pokoju, tablicaIdElementowWyposazenia[i]);
            return 1;
        }
    }
}
