using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class PracownicyHelper
    {
        /// <summary>
        /// dodaje pracownika o zadanym stanowisku
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="login"></param>
        /// <param name="haslo"></param>
        /// <param name="id_p"></param>
        /// <param name="id_s"></param>
        /// <returns></returns>
        public static int dodajPracownika(string imie, string nazwisko, string login, string haslo, int? id_s)
        {
            return TablesManager.Manager.PracownicyTableAdapter.InsertQuery(id_s, imie, nazwisko, login, LogowanieHelper.haszujHaslo(haslo));
        }

        public static int edytujPracownikaByIdPr(string imie, string nazwisko, string login, string haslo, int id_p, int? id_s)
        {
            if (haslo.Equals(""))
                return TablesManager.Manager.PracownicyTableAdapter.UpdateQuerybyIdPrBezHasla(id_s, imie, nazwisko, login, id_p);

            return TablesManager.Manager.PracownicyTableAdapter.UpdateQuerybyIdPr(id_s, imie, nazwisko, login, LogowanieHelper.haszujHaslo(haslo), id_p);
        }

        public static int usunPracownika(int id_p)
        {
            return TablesManager.Manager.PracownicyTableAdapter.DeleteQuery(id_p);
        }

        public static int dodajStanowisko(string nazwa, string opis)
        {
            return TablesManager.Manager.Pracownicy_slownikTableAdapter.DodajStanowisko(nazwa, opis);
        }
        public static int edytujStanowisko(string nazwa, string opis,int id)
        {
            return TablesManager.Manager.Pracownicy_slownikTableAdapter.EdytujStanowiskoByID(nazwa, opis,id);
        }
        public static int usunStanowisko(int id)
        {
            return TablesManager.Manager.Pracownicy_slownikTableAdapter.UsunStanowiskoById(id);
        }
       
    }
}
