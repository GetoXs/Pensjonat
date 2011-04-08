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
		/// Sprawdza czy można dodać klienta zostawiajac info nt. bledu w lastMsg
		/// </summary>
		/// <returns>Zwraca true jesli można dodawać</returns>
		public static bool verifyAddKlient(string email, string imie, string nazwisko, string miejscowosc, string ulica, int? nip, string pesel, int? nr_telefonu, string nazwa, string kod_pocztowy)//dokonczyc wszystkie parametry
		{
			lastMsg = "";
			//1. Sprawdzanie warunków "niepustości" dla wymagających tego atrybutów
			if (pesel==null || pesel == "")
				lastMsg = "Pole PESEL jest puste";
			else if(imie==null || imie == "")
				lastMsg = "Pole imię jest puste";
			else if (nazwisko==null || nazwisko == "")
				lastMsg = "Pole nazwisko jest puste";
			else if(miejscowosc==null || miejscowosc=="")
				lastMsg = "Pole miejscowosci jest puste";

			if (lastMsg != "")
				return false;
			//2. Sprawdzenie czy unikalne wartosci istnieją w DB dla wymagających tego atrybutów

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
			 **/
			//Druga metoda pobieranie tabela po tabeli
			if (nip!=null && TablesManager.Manager.KlienciTableAdapter.GetDataByNip(nip).Count > 0)
				lastMsg = "NIP się dubluje";
			else if (TablesManager.Manager.KlienciTableAdapter.GetDataByPesel(pesel).Count > 0)
				lastMsg = "PESEL się dubluje";

			if (lastMsg != "")
				return false;

			return true;
		}
		/// <summary>
		/// Dodaje klienta, ustawia wiadomosc powrotna z niepowodzeniem w lastMsg
		/// </summary>
		/// <returns>Zwraca true jeśli się udało</returns>
		public static bool addKlient(string email, string imie, string nazwisko, string miejscowosc, string ulica, int? nip, string pesel, int? nr_telefonu, string nazwa, string kod_pocztowy)//dokonczyc wszystkie parametry
		{
			//1. Weryfikacja przekazanych parametrów
			if (KlienciHelper.verifyAddKlient(email, imie, nazwisko, miejscowosc, ulica, nip, pesel, nr_telefonu, nazwa, kod_pocztowy) == false)
			{
				return false;
			}
			//2. Obsługa tabel zewnetrznych (jak np. Miejscowosc)
			int id_miejscowosci=-1;
			KlienciDS.Miejscowosci_slownikDataTable table1 = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(miejscowosc);
			if (table1.Count > 0)
			{
				id_miejscowosci = table1[0].id_miejscowosci;
			}
			else
			{
				//robienie pierwszej litery dużej
				miejscowosc = miejscowosc.ToLower();
				char[] tmp = miejscowosc.ToCharArray();
				tmp[0] = char.ToUpper(tmp[0]);
				miejscowosc = new string(tmp);
				//zapisanie do DB
				TablesManager.Manager.Miejscowosci_slownikTableAdapter.Insert(miejscowosc);
				//pobieranie id_miejscowosci
				id_miejscowosci = TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByNazwa(miejscowosc)[0].id_miejscowosci;
			}
			TablesManager.Manager.KlienciTableAdapter.Insert(email, imie, nazwisko, id_miejscowosci, ulica, nip, pesel, nr_telefonu, nazwa, kod_pocztowy);
			
			return true;
		}
	}
}
