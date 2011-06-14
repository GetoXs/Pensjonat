using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class RachunekPDFHelper
    {
        /// <summary>
        /// Stworz wydruk.
        /// </summary>
        /// <param name="id_rachunku">The id_rachunku.</param>
        /// <param name="sciezka">sciezka w jakiej ma byc stworozny plik- JUZ Z NAZWA PLIKU WYDRUKU!!</param>
        /// <returns>true-jesli wszystko wykonalo sie poprawnie</returns>
        public static bool stworzWydruk(int id_rachunku, string sciezka)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(sciezka, FileMode.Create));
            doc.Open();

            Paragraph naglowek = new Paragraph();
            naglowek.Add("Rachunek\n");
            Paragraph naglowek2 = new Paragraph();
            naglowek2.Add("Id rachunku: "+id_rachunku.ToString()+"\n");
            naglowek2.Add(DateTime.Now.Date.ToString()+"\n\n");

            doc.Add(naglowek);
            doc.Add(naglowek2);

            PobytyDS.PobytyDataTable pobyty = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRachunku(id_rachunku);

            foreach (PobytyDS.PobytyRow p in pobyty)
            {
                Paragraph par = new Paragraph();
                KlienciDS.KlienciRow klient=TablesManager.Manager.KlienciTableAdapter.GetDataByIdKlienta(p.id_klienta)[0];
                par.Add(klient.imie + " " + klient.nazwisko + "\n");
                if (!(klient.nazwa.Equals("")))
                    par.Add(klient.nazwa+"\n");
                par.Add("Pokój: " + RozliczenieHelper.pobierzPodstawowaCenaPobytu(p.id_pobytu).ToString("0.00") + " PLN\n");
                par.Add("Posiłki: " + RozliczenieHelper.pobierzPodstawowaCenaPosilkow(p.id_pobytu).ToString("0.00") + " PLN\n");
                par.Add("Usługi: " + RozliczenieHelper.pobierzPodstawowaCenaUslug(p.id_pobytu).ToString("0.00") + " PLN\n\n");

                doc.Add(par);
            }

            Paragraph doZaplaty = new Paragraph();
            RachunkiDS.RachunkiRow r=TablesManager.Manager.RachunkiTableAdapter.GetDataById(id_rachunku)[0];
            doZaplaty.Add("Do zapłacenia po uwzględnieniu rabatów i zaliczki: "+r.wartosc.ToString("0.00")+" PLN\n");
            doc.Add(doZaplaty);

            doc.Close();
            return true;
        }
    }
}
