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
		/// <summary>
		/// dodaje uslugę o danym typie, terminie do danego pobytu
		/// </summary>
        public static int dodajUsluge(int id_pobytu, int id_pracownika, DateTime terminStart, DateTime terminKoniec, string d_opis, int? id_slownikowe)
        {
            return TablesManager.Manager.UslugiTableAdapter.Insert(id_pobytu, id_pracownika, d_opis, terminStart, terminKoniec, id_slownikowe);
        }
		/// <summary>
		/// edytuje w usludze o danym id: typ, termin i id pobytu
		/// </summary>
        public static int edytujUsluge(int id_uslugi, int? id_pobytu, DateTime terminStart, DateTime terminKoniec, string d_opis, int? id_slownikowe)
		{
            

			return TablesManager.Manager.UslugiTableAdapter.UpdateQuery(id_pobytu, d_opis, id_slownikowe, terminStart, terminKoniec, id_uslugi);
		}
		/// <summary>
		/// usuwa uslugę o danym id
		/// </summary>
		public static int usunUsluge(int id_uslugi)
		{
			return TablesManager.Manager.UslugiTableAdapter.DeleteById(id_uslugi);
		}
		//przydziały pracownicze
		/// <summary>
		/// edytuje w usludze o danym id: id_pracownika
		/// </summary>
        public static int przydzielPracownika(int id_uslugi, int? id_pracownika)
        {
			return TablesManager.Manager.UslugiTableAdapter.UpdateIdPracownika(id_pracownika, id_uslugi);
        }
		/// <summary>
		/// ustawia w usludze o danym id: id_pracownika na null
		/// </summary>
		public static int usunPracownika(int id_uslugi)
		{
			return przydzielPracownika(id_uslugi, null);
		}

        public static PensjonatApp.DS.PracownicyDS.PracownicyDataTable znajdzWolnegoPracownika(DateTime? terminStart, DateTime? terminKoniec, int id_slownikoweUslugi)
        {
            return TablesManager.Manager.PracownicyTableAdapter.GetIdPracownikaWolny(id_slownikoweUslugi, terminKoniec, terminStart);
        }



        /// <summary>
        /// Znajdzs the pierwszy wolny termin.
        /// </summary>
        /// <param name="terminStart">The termin start.</param>
        /// <param name="czasTrwania">The czas trwania.</param>
        /// <param name="id_slownikoweUslugi">The id_slownikowe uslugi.</param>
        /// <returns></returns>
        public static DateTime znajdzPierwszyWolnyTermin(DateTime terminStart, int czasTrwania, int id_slownikoweUslugi)
        {
            PensjonatApp.DS.PracownicyDS.PracownicyDataTable tabela;
            DateTime start = terminStart;
            DateTime koniec = terminStart.AddMinutes(czasTrwania);
            TimeSpan krok = new TimeSpan(0,5,0); //sprawdzane terminy z dokladnoscia do 5min
            while (true)
            {
                tabela=TablesManager.Manager.PracownicyTableAdapter.GetIdPracownikaWolny(id_slownikoweUslugi, koniec, start);
                if (tabela.Count != 0)
                    break;
                koniec += krok;
                start += krok;
            }
            return start;
        }

        public static PensjonatApp.DS.UslugiDS.UslugiDataTable znajdzZadaniaDlaPracownikaWCzasie(int? id_pracownika, DateTime? poczatekCzasu, DateTime? koniecCZasu)
        {
            return TablesManager.Manager.UslugiTableAdapter.GetDataByIdPracownikaPrzedzialCzasu(id_pracownika, poczatekCzasu, koniecCZasu);
        }

        public static PensjonatApp.DS.UslugiDS.UslugiDataTable znajdzZadaniaPracownikaDoCzasu(int? id_pracownika,  DateTime? Czas)
        {
            return TablesManager.Manager.UslugiTableAdapter.GetDataByIDPracownikaDoCzasu(id_pracownika, Czas);
        }
    }
}
