using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class PokojeHelper
    {
        /// <summary>
        /// Dodaje pokoj.
        /// Wymagane parametry to id_slownikowe_pokoju wskazujace klase/kategorie pokoju oraz nr_pokoju.
        /// </summary>
        public static int dodajPokoj(int? id_slownikowe_pokoju, string nr_pokoju)
        {
            return TablesManager.Manager.PokojeTableAdapter.Insert(id_slownikowe_pokoju, nr_pokoju);
        }

        /// <summary>
        /// Edytuje pokoj.
        /// Wymagane parametry to id_slownikowe_pokoju wskazujace klase/kategorie pokoju, nr_pokoju oraz ID edytowanego pokoju.
        /// </summary>
        public static int edytujPokoj(int id_pokoju, int id_slownikowe_pokoju, string nr_pokoju)
        {
			return TablesManager.Manager.PokojeTableAdapter.UpdateById(id_slownikowe_pokoju, nr_pokoju, id_pokoju);
        }

        /// <summary>
        /// Usuwa pokoj.
        /// </summary>
		public static int usunPokoj(int idPokoju)
		{
			return TablesManager.Manager.PokojeTableAdapter.DeletByID(idPokoju);
		}
    }
}
