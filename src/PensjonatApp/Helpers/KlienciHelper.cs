using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
	class KlienciHelper
	{
        /// <summary>
        /// Dodaje klienta i przypisuje go do odopowieniego miasta, jezeli miasto nie istnieje dodaje nowe.
        /// Wymagane parametry to wszystkie pola niezbedne do wypelnienia bazy danych.
        /// Jezeli jest to klient indywidualny, do pola nip nalezy przekazac null, a do pola nazwa_firmy pusty string.
        /// W przypadku klienta firmowego do pola pesel nalezy przekazac pusty string.
        /// </summary>
        public static int dodajKlienta(string imie, string nazwisko, string nazwa_firmy, string miejscowosc, string ulica, string kod_pocztowy, int? nip, string pesel, int nr_telefonu, string email)
        {
            int id_miejscowosci;
            KlienciDS.Miejscowosci_slownikDataTable szukanaMiejscowosc = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(miejscowosc);
            if (szukanaMiejscowosc.Count > 0)
                id_miejscowosci = szukanaMiejscowosc[0].id_miejscowosci;
            else
            {
                TablesManager.Manager.Miejscowosci_slownikTableAdapter.Insert(miejscowosc);
                id_miejscowosci = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(miejscowosc)[0].id_miejscowosci;
            }
            return TablesManager.Manager.KlienciTableAdapter.Insert(email, imie, nazwisko, id_miejscowosci, ulica, nip, pesel, nr_telefonu, nazwa_firmy, kod_pocztowy);
        }

        /// <summary>
        /// Edytuje klienta i przypisuje go do odopowieniego miasta, jezeli miasto nie istnieje dodaje nowe.
        /// Wymagane parametry to wszystkie pola niezbedne do wypelnienia bazy danych oraz ID edytowanego klienta.
        /// Jezeli jest to klient indywidualny, do pola nip nalezy przekazac null, a do pola nazwa_firmy pusty string.
        /// W przypadku klienta firmowego do pola pesel nalezy przekazac pusty string.
        /// </summary>
        public static int edytujKlienta(int id_klienta, string imie, string nazwisko, string nazwa_firmy, string miejscowosc, string ulica, string kod_pocztowy, int nip, string pesel, int nr_telefonu, string email)
        {
            int id_miejscowosci;
            KlienciDS.Miejscowosci_slownikDataTable szukanaMiejscowosc = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(miejscowosc);
            if (szukanaMiejscowosc.Count > 0)
                id_miejscowosci = szukanaMiejscowosc[0].id_miejscowosci;
            else
            {
                TablesManager.Manager.Miejscowosci_slownikTableAdapter.Insert(miejscowosc);
                id_miejscowosci = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(miejscowosc)[0].id_miejscowosci;
            }
            KlienciDS.KlienciDataTable doZmiany = TablesManager.Manager.KlienciTableAdapter.GetDataByIdKlienta(id_klienta);
            doZmiany[0].imie = imie;
            doZmiany[0].nazwisko = nazwisko;
            doZmiany[0].nazwa = nazwa_firmy;
            doZmiany[0].ulica = ulica;
            doZmiany[0].kod_pocztowy = kod_pocztowy;
            doZmiany[0].nip = nip;
            doZmiany[0].pesel = pesel;
            doZmiany[0].nr_telefonu = nr_telefonu;
            doZmiany[0].email = email;
            doZmiany[0].id_miejscowosci = id_miejscowosci;
            return TablesManager.Manager.KlienciTableAdapter.Update(doZmiany);
        }

        /*
         * Scisle tajny kod GetOxxxa
         * 
		private static _AddKlient _addKlient { get; set; }
		/// <summary>
		/// Wiadomośc do pobrania z innych modułów nt. np. które pole się dubluje
		/// </summary>
		public static string lastMsg { get; private set; }
		/// <summary>
		/// Bezargumentowy konstruktor statyczny, zeruje ostatnia wiadomosc
		/// </summary>
		static KlienciHelper()
		{
			lastMsg = "";
		}
		/// <summary>
		/// Sprawdza parametry, ich unikalność i wyłusuje z nich informacje przekazane do DB, info nt. bledu w lastMsg
		/// </summary>
		/// <returns>Zwraca true jesli wszystko jest zgodne</returns>
		public static bool addKlientVerifyParams(string email, string imie, string nazwisko, string miejscowosc, string ulica, string nip, string pesel, string nr_telefonu, string kod_pocztowy)
		{
			lastMsg = "";
			StringBuilder dialog = new StringBuilder("");

			//1. Wyłuskiwanie parametrów dodania z przekazanych stringów
			_addKlient = new _AddKlient();
			_addKlient.email = (email == "") ? null : email;
			_addKlient.imie = (imie == "") ? null : imie;
			_addKlient.nazwisko = (nazwisko == "") ? null : nazwisko;
			_addKlient.miejscowosc = (miejscowosc == "") ? null : miejscowosc;
			_addKlient.pesel = (pesel == "") ? null : pesel;
			_addKlient.kod_pocztowy = (kod_pocztowy == "") ? null : kod_pocztowy;		
			int tmp;
			
			//2. Inicjalizacja pól z intami
			if (nip == "")	//jeśli puste to null
				_addKlient.nip = null;
			else if (int.TryParse(nip, out tmp))	//jesli nie puste to sprawdz czy mozna z tego zrobic inta
				_addKlient.nip = tmp;
			else
				dialog.Append("NIP nie jest liczbą\n"); //blad nie ma liczby

			if (nr_telefonu == "")	//jeśli puste to null
				_addKlient.nr_telefonu = null;
			else if (int.TryParse(nr_telefonu, out tmp))	//jesli nie puste to sprawdz czy mozna z tego zrobic inta
				_addKlient.nr_telefonu = tmp;
			else
				dialog.Append("Numer telefonu nie jest liczbą\n"); //blad nie ma liczby


			//3. Sprawdzanie warunków "niepustości" dla wymagających tego atrybutów
			if (pesel==null || pesel == "")
				dialog.Append("Pole PESEL jest puste\n");
			if(imie==null || imie == "")
				dialog.Append("Pole imię jest puste\n");
			if (nazwisko==null || nazwisko == "")
				dialog.Append("Pole nazwisko jest puste\n");
			if(miejscowosc==null || miejscowosc=="")
				dialog.Append("Pole miejscowosci jest puste\n");
			
			//Można dodac sprawdzanie numerów kontrolnych (np NIP czy PESEL)

			lastMsg = dialog.ToString();
			if (lastMsg != "")
				return false;
			return true;
		}
		/// <summary>
		/// Sprawdza duplikacje, parametry, ich unikalność i wyłusuje z nich informacje przekazane do DB, info nt. bledu w lastMsg
		/// </summary>
		/// <returns>True jeśli wszystko jest poprawne</returns>
		public static bool addKlientVerifyParamsAndDb(string email, string imie, string nazwisko, string miejscowosc, string ulica, string nip, string pesel, string nr_telefonu, string kod_pocztowy)
		{
			StringBuilder dialog = new StringBuilder("");

			//1. Weryfikacja przekazanych parametrów
			if (KlienciHelper.addKlientVerifyParams(email, imie, nazwisko, miejscowosc, ulica, nip, pesel, nr_telefonu, kod_pocztowy) == false)
			{
				return false;
			}
			//2. Sprawdzenie czy unikalne wartosci istnieją w DB dla wymagających tego atrybutów, albo czy podana usługa/pracownik istnieje

			/** Pierwsza metoda, pobieranie całej tabeli i weryfikowanie wiersza po wierszu
			KlienciDS.KlienciDataTable klienciTable = TablesManager.Manager.KlienciTableAdapter.GetData();
			foreach(KlienciDS.KlienciRow row in klienciTable)
			{
				//sprawdzanie czy istnieje i czy jest taki sam w bazie
				if (PESEL!=null && PESEL == row.pesel)
				{
					lastMsg = "PESEL";
					return false;
				}
				else if (NIP!=0 && NIP == row.nip)
				{
					lastMsg = "NIP";
					return false;
				}//kolejne warunki
			}
			 * 
			 *
			//Druga metoda pobieranie tabela po tabeli
			if (_addKlient.nip != null && TablesManager.Manager.KlienciTableAdapter.GetDataByNip(_addKlient.nip).Count > 0)
				dialog.Append("NIP się dubluje");
			if (TablesManager.Manager.KlienciTableAdapter.GetDataByPesel(_addKlient.pesel).Count > 0)
				dialog.Append("PESEL się dubluje");

			lastMsg = dialog.ToString();
			if (lastMsg != "")
				return false;
			return true;
		}
		/// <summary>
		/// Sprawdza parametry i dodaje klienta, ustawia wiadomosc powrotna z niepowodzeniem w lastMsg
		/// </summary>
		/// <returns>Zwraca true jeśli się udało</returns>
		public static bool addKlient(string email, string imie, string nazwisko, string miejscowosc, string ulica, string nip, string pesel, string nr_telefonu, string kod_pocztowy)
		{
			//1. Weryfikacja przekazanych parametrów, wyłuskanie z nich danych do _addKlient i sprawdzenie unikalnych pozycji(DB)
			if (KlienciHelper.addKlientVerifyParamsAndDb(email, imie, nazwisko, miejscowosc, ulica, nip, pesel, nr_telefonu, kod_pocztowy) == false)
			{
				return false;
			}

			//2. Obsługa tabel zewnetrznych (jak np. Miejscowosc)
			int id_miejscowosci=-1;
			KlienciDS.Miejscowosci_slownikDataTable table1 = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(_addKlient.miejscowosc);
			if (table1.Count > 0)
			{
				id_miejscowosci = table1[0].id_miejscowosci;
			}
			else
			{
				//robienie pierwszej litery dużej
				_addKlient.miejscowosc = _addKlient.miejscowosc.ToLower();
				char[] tmp = _addKlient.miejscowosc.ToCharArray();
				tmp[0] = char.ToUpper(tmp[0]);
				_addKlient.miejscowosc = new string(tmp);
				//zapisanie do DB
				TablesManager.Manager.Miejscowosci_slownikTableAdapter.Insert(_addKlient.miejscowosc);
				//pobieranie id_miejscowosci
				id_miejscowosci = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(_addKlient.miejscowosc)[0].id_miejscowosci;
			}
			TablesManager.Manager.KlienciTableAdapter.Insert(_addKlient.email, _addKlient.imie, _addKlient.nazwisko, id_miejscowosci, _addKlient.ulica, _addKlient.nip, _addKlient.pesel, _addKlient.nr_telefonu, null, _addKlient.kod_pocztowy);
			_addKlient = null;
			return true;
		}
		private class _AddKlient
		{
			public String email{get;set;}
			public String imie{get;set;}
			public String nazwisko{get;set;}
			public String miejscowosc{get;set;}
			public String ulica{get;set;}
			public int? nip{get;set;}
			public String pesel{get;set;}
			public int? nr_telefonu{get;set;}
			public String kod_pocztowy{get;set;}
		}*/

	}
}
