using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
	class RozliczenieHelper
	{
		/// <summary>
		/// Pobranie ceny podstawowej pobytu - by GetoX
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <returns>cene, badz -1 jesli blad</returns>
		public static Decimal pobierzPodstawowaCenaPobytu(int idPobytu)
		{
			PobytyDS.PobytyDataTable data = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeStandardByIdPobytu(idPobytu);
			if (data.Count != 1)
				throw new ArgumentException("Podano id pobytu nie posiadające bądź posiadające więcej niż swoich odpowiedników w bazie");

			decimal cena = 0;
			PobytyDS.PobytyRow row = data[0];
			TimeSpan diff = row.termin_koniec - row.termin_start;
			cena += (decimal)diff.Days * (decimal)row["cena"];
			return cena;
		}
		/// <summary>
		/// Pobiera cene usług bez uwzględniania rabatów - GetoX
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <returns></returns>
		public static Decimal pobierzPodstawowaCenaUslug(int idPobytu)
		{
			UslugiDS.UslugiDataTable data = TablesManager.Manager.UslugiTableAdapter.GetDataUslugiUslugi_slownikByID_pobytu(idPobytu);

			decimal cena = 0;
			foreach (UslugiDS.UslugiRow row in data)
			{
				cena += (decimal)row["cena"];
			}
			return cena;
		}
		/// <summary>
		/// Pobiera cenę posiłków nie uwzględniając rabatów - GetoX
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <returns></returns>
		public static Decimal pobierzPodstawowaCenaPosilkow(int idPobytu)
		{
			PosilkiDS.PosilkiDataTable data = TablesManager.Manager.PosilkiTableAdapter.GetDataWithPosilkiSlownikById(idPobytu);

			decimal cena = 0;
			foreach (PosilkiDS.PosilkiRow row in data)
			{
				cena += (decimal)row["cena"];
			}
			return cena;
		}
		/// <summary>
		/// Pobiera łączna cenę (pobytu, uslug, posilkow) nie uwzględniając rabatów - GetoX
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <returns></returns>
		public static Decimal pobierzPodstawowaCenaLaczna(int idPobytu)
		{
			decimal cena = 0;
			cena += pobierzPodstawowaCenaPobytu(idPobytu);
			cena += pobierzPodstawowaCenaPosilkow(idPobytu);
			cena += pobierzPodstawowaCenaUslug(idPobytu);
			return cena;
		}
		/// <summary>
		/// Pobiera łączną cenę z uwzględnieniem rabatów podanych argumentem - GetoX
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <param name="rabaty"></param>
		/// <returns></returns>
		public static Decimal pobierzRabatowaCena(int idPobytu, IEnumerable<RachunkiDS.RabatyRow> rabaty)
		{
			decimal cenaPobytu, cenaUslug, cenaPosilku;
			decimal rabatPobytu = 0, rabatUslug = 0, rabatPosilku = 0;

			cenaPobytu = pobierzPodstawowaCenaPobytu(idPobytu);
			cenaUslug = pobierzPodstawowaCenaUslug(idPobytu);
			cenaPosilku = pobierzPodstawowaCenaPosilkow(idPobytu);

			foreach (RachunkiDS.RabatyRow row in rabaty)
			{
                if (row.na_pobyt == true)
                {
                    if (row.procentowy == true)
                        rabatPobytu += (row.wartosc * cenaPobytu) / 100;
                    else
                        rabatPobytu += row.wartosc;
                }
                else if (row.na_posilki == true)
                {
                    if (row.procentowy == true)
                        rabatPosilku += (row.wartosc * cenaPosilku) / 100;
                    else
                        rabatPosilku += row.wartosc;
                }
                else if (row.na_uslugi == true)
                {
                    if (row.procentowy == true)
                        rabatUslug += (row.wartosc * cenaUslug) / 100;
                    else
                        rabatUslug += row.wartosc;
                }
			}
            Decimal suma=((cenaPobytu - rabatPobytu < 0) ? 0 : (cenaPobytu - rabatPobytu)) + 
				((cenaPosilku - rabatPosilku < 0) ? 0 : (cenaPosilku - rabatPosilku)) + 
				((cenaUslug - rabatUslug < 0) ? 0 : (cenaUslug - rabatUslug));

            PobytyDS.PobytyDataTable pobyt = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyKlienciPokojeStandardByIdPobytu(idPobytu);
            RezerwacjeDS.RezerwacjeDataTable rezerwacja = TablesManager.Manager.RezerwacjeTableAdapter.GetDataRezerwacjeByID(pobyt[0].id_rezerwacji);
			if (rezerwacja.Count == 1)	//odejmowanie zaliczki
			{
				if (pobyt[0].id_klienta == rezerwacja[0].id_klienta)
					suma -= rezerwacja[0].zaliczka;
			}

            return suma; 
		}

        public static int liczZaliczke(List<PokojeStandardy> pokoje,int iloscDni, double wspolczynnik)
        {
            double suma = 0;
            foreach (PokojeStandardy p in pokoje)
                suma += (double)p.Cena * iloscDni * wspolczynnik;

            int wynik = ((int)Math.Round(suma) )/ 50;
            wynik *= 50;
            if (((int)Math.Round(suma)) % 50 >= 25)
                wynik += 50;

            return wynik;
        }

        public static Decimal pobierzRabatowaCenaRezerwacji(int idRezerwacji, IEnumerable<RachunkiDS.RabatyRow> rabaty)
        {
            Decimal wynik = 0;

            PobytyDS.PobytyDataTable pobyty = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRezerwacji(idRezerwacji);

            foreach (PobytyDS.PobytyRow p in pobyty)
                wynik += pobierzRabatowaCena(p.id_pobytu, rabaty);
            
            return wynik;
        }
		/// <summary>
		/// Zapisuje podaną ceną do bazy danych oraz przypisuje ją do pobytu
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <param name="cena"></param>
		/// <returns>Zwraca null jeśli wszystko jest ok, bądź opis bledu jesli jest nie okej</returns>
		public static String rozliczPobyt(int idPobytu, decimal cena)
		{
			int lastId=-1;
			PobytyDS.PobytyDataTable tab = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByID(idPobytu);
			if(tab.Count==0 || !tab[0].Isid_rachunkuNull())
				return "Dane id rachunku, albo nie istnieje, albo już posiada rachunek";
			else
			{

				RachunkiHelper.dodajRachunek(true, cena);
				lastId = RachunkiHelper.lastIdRachunek();
				TablesManager.Manager.PobytyTableAdapter.UpdateIdRachunek(lastId, idPobytu);
				return null;
			}
		}		
		/// <summary>
		/// Zapisuje podaną ceną do bazy danych oraz przypisuje ją do pobytów określonych id rezerwacji
		/// </summary>
		/// <param name="idPobytu"></param>
		/// <param name="cena"></param>
		/// <returns>Zwraca null jeśli wszystko jest ok, bądź opis bledu jesli jest nie okej</returns>
		public static String rozliczRezerwacje(int idRezerwacji, decimal cena)
		{
			int lastId = -1;
			PobytyDS.PobytyDataTable tab = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRezerwacjiNierozliczone(idRezerwacji);
			if (tab.Count == 0)
				return "Nie ma pobytów o poanym id rezerwacji";
			else
			{
				RachunkiHelper.dodajRachunek(true, cena);
				lastId = RachunkiHelper.lastIdRachunek();
				foreach (var row in tab)
				{
					TablesManager.Manager.PobytyTableAdapter.UpdateIdRachunek(lastId, row.id_pobytu);
				}
				return null;
			}
		}
	}
}
