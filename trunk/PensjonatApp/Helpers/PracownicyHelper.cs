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
        public static int dodajPracownika(string imie, string nazwisko, string login, string haslo, int id_p, int? id_s)
        {
            return TablesManager.Manager.PracownicyTableAdapter.InsertQuery(id_s, imie, nazwisko, login, haslo);
        }

        public static int edytujPracownikaByIdPr(string imie, string nazwisko, string login, string haslo, int id_p, int? id_s)
        {
            return TablesManager.Manager.PracownicyTableAdapter.UpdateQuerybyIdPr(id_s, imie, nazwisko, login, haslo, id_p);
        }

        public static int usunPracownika(int id_p)
        {
            return TablesManager.Manager.PracownicyTableAdapter.DeleteQuery(id_p);
        }
    }
}
