using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;


namespace PensjonatApp.Helpers
{
    class UslugiHelper
    {
        public static int dodajUsluge(int id_pobytu, DateTime termin, string d_opis, int id_slownikowe)
        {

            return TablesManager.Manager.UslugiTableAdapter.Insert(id_pobytu, null, d_opis, termin, id_slownikowe);

        }

        public static int przydzielPracownika(int id_uslugi, int id_pracownika)
        {
            UslugiDS.UslugiDataTable tab= TablesManager.Manager.UslugiTableAdapter.GetDataUslugiByID(id_uslugi);
            tab[0].id_pracownika=id_pracownika;
            return TablesManager.Manager.UslugiTableAdapter.Update(tab);
        }
    }
}
