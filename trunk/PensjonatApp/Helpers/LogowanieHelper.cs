using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static void zalogujPracownika(string login, string haslo)
        {
            int id_stanowiska;
            PracownicyDS.PracownicyDataTable pracownik = TablesManager.Manager.PracownicyTableAdapter.GetPracownicyByLoginHaslo(login, haslo);
            if (pracownik.Count > 0)
                id_stanowiska = pracownik[0].id_stanowiska;
            else
                throw new Exception();
            PracownicyDS.Pracownicy_slownikDataTable stanowisko = TablesManager.Manager.Pracownicy_slownikTableAdapter.GetDataByID(id_stanowiska);
            ID = pracownik[0].id_pracownika;
            Imie = pracownik[0].imie;
            Nazwisko = pracownik[0].nazwisko;
            Stanowisko = stanowisko[0].nazwa;
        }
    }
}
