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
				return -1;
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
					if (row.procentowy == true)
						rabatPobytu += row.wartosc * cenaPobytu;
					else
						rabatPobytu += row.wartosc;
				else if (row.na_posilki == true)
					if (row.procentowy == true)
						rabatPosilku += row.wartosc * cenaPosilku;
					else
						rabatPosilku += row.wartosc;
				else if (row.na_uslugi == true)
					if (row.procentowy == true)
						rabatUslug += row.wartosc * cenaUslug;
					else
						rabatUslug += row.wartosc;
			}
			return ((cenaPobytu - rabatPobytu < 0) ? 0 : (cenaPobytu - rabatPobytu)) + 
				((cenaPosilku - rabatPosilku < 0) ? 0 : (cenaPosilku - rabatPosilku)) + 
				((cenaUslug - rabatUslug < 0) ? 0 : (cenaUslug - rabatUslug));
		}
	}
}
