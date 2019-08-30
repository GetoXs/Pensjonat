using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class RabatyHelper
    {
		public static int dodajRabat(string nazwa, bool procentowy, int? wartosc, bool aktywny, bool na_pobyt, bool na_uslugi, bool na_posilki)
        {
			return TablesManager.Manager.RabatyTableAdapter.Insert(nazwa, procentowy, wartosc, aktywny, na_pobyt, na_uslugi, na_posilki);
        }
		public static int edytujRabat(int Original_id_rabatu, string nazwa, bool procentowy, int? wartosc, bool aktywny, bool na_pobyt, bool na_uslugi, bool na_posilki)
        {
            return TablesManager.Manager.RabatyTableAdapter.UpdateQuery(nazwa, procentowy, wartosc, aktywny, na_pobyt, na_uslugi, na_posilki,  Original_id_rabatu);
        }
        public static int kasujRabat(int id_rabatu)
        {
            return TablesManager.Manager.RabatyTableAdapter.DeleteQueryById(id_rabatu);
        }
    }
}
