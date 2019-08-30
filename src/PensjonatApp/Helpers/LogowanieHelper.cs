using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class LogowanieHelper
    {
        public static int ID;
        public static string Imie;
        public static string Nazwisko;
        public static string Stanowisko;

        public static bool zalogujPracownika(string login, string haslo)
        {
            int id_stanowiska;
            PracownicyDS.PracownicyDataTable pracownik = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyByLoginHaslo(login, haszujHaslo(haslo));
            if (pracownik.Count > 0)
                id_stanowiska = pracownik[0].id_stanowiska;
            else
                return false;
            PracownicyDS.Pracownicy_slownikDataTable stanowisko = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetDataByID(id_stanowiska);
            ID = pracownik[0].id_pracownika;
            Imie = pracownik[0].imie;
            Nazwisko = pracownik[0].nazwisko;
            Stanowisko = stanowisko[0].nazwa;
            return true;
        }

        public static bool sprawdzHaslo(int id_pracownika, string haslo)
        {
            PracownicyDS.PracownicyDataTable pracownik = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyByHaslo(haszujHaslo(haslo), id_pracownika);
            if (pracownik.Count > 0)
                return true;
            return false;
        }

        public static int zmienHaslo(int id_pracownika, string haslo)
        {
            return TablesManager.Manager.PracownicyTableAdapter.UpdateHaslo(haszujHaslo(haslo), id_pracownika);
        }

        public static string haszujHaslo(string haslo)
        {
            return BitConverter.ToString(SHA1Managed.Create().ComputeHash(Encoding.Default.GetBytes(haslo))).Replace("-", "");
        }
    }
}
