using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
	class UslugiSlownikHelper
	{
		/// <summary>
		/// dodaje typ usługi z danymi informacjami o: cenie, nazwie, opisie i id stanowiska
		/// </summary>
		public static int dodajTypUslugi(decimal? cena, string nazwa, string opis, int? id_stanowiska)
        {
			return TablesManager.Manager.Uslugi_slownikTableAdapter.Insert(cena, nazwa, opis, id_stanowiska);
        }
		/// <summary>
		/// edytuje w typie usługi o danym id: cenę, nazwę, opis i id stanowiska
		/// </summary>
		public static int edytujTypUslugi(int id_slownikowe_uslugi, decimal? cena, string nazwa, string opis, int? id_stanowiska)
		{
			return TablesManager.Manager.Uslugi_slownikTableAdapter.UpdateQuery(cena, nazwa, opis, id_stanowiska, id_slownikowe_uslugi);
		}
		/// <summary>
		/// usuwa typ usługi o danym id
		/// </summary>
		public static int usunTypUslugi(int id_slownikowe_uslugi)
		{
			return TablesManager.Manager.Uslugi_slownikTableAdapter.DeleteById(id_slownikowe_uslugi);
		}
	}
}
