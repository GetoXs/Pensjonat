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

            FontFactory.RegisterDirectory("C:\\WINDOWS\\Fonts");

            Font duzy = FontFactory.GetFont("Verdana",BaseFont.CP1250,16);
            Font sredni = FontFactory.GetFont("Verdana", BaseFont.CP1250, 10);
            Font sredniB = FontFactory.GetFont("Verdana", BaseFont.CP1250, 10);
            Font maly = FontFactory.GetFont("Verdana", BaseFont.CP1250, 9);
            duzy.SetStyle(Font.BOLD);
            sredniB.SetStyle(Font.BOLD);

            Paragraph naglowek = new Paragraph("",duzy);
            naglowek.Add("\nRachunek\n\n");
            naglowek.Alignment = Element.ALIGN_CENTER;
            doc.Add(naglowek);

            Paragraph naglowek2 = new Paragraph("",maly);
            naglowek2.Add("Id rachunku: "+id_rachunku.ToString()+"\n");
            naglowek2.Add("Data wygenerowania: "+DateTime.Now.Date.ToString("d-MM-yyyy")+"\n\n");
            doc.Add(naglowek2);

            PobytyDS.PobytyDataTable pobyty = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRachunku(id_rachunku);

            PdfPTable tabela = new PdfPTable(7);
            tabela.SpacingBefore=40;
            tabela.SpacingAfter=40;
            tabela.AddCell(new Phrase("Klient:",sredniB));
            //tabela.AddCell(new Phrase("PESEL:", sredniB));
            tabela.AddCell(new Phrase("Początek pobytu:", sredniB));
            tabela.AddCell(new Phrase("Koniec pobytu:", sredniB));
            tabela.AddCell(new Phrase("Opłata za pokój:",sredniB));
            tabela.AddCell(new Phrase("Opłata za posiłki:",sredniB));
            tabela.AddCell(new Phrase("Opłata za usługi:",sredniB));
            tabela.AddCell(new Phrase("Suma:", sredniB));

            decimal sumAll = 0;
            foreach (PobytyDS.PobytyRow p in pobyty)
            {
                KlienciDS.KlienciRow klient=TablesManager.Manager.KlienciTableAdapter.GetDataByIdKlienta(p.id_klienta)[0];

                decimal suma = 0;
                decimal koszt = 0;
                tabela.AddCell(new Phrase(klient.imie + " " + klient.nazwisko,sredniB));
                //tabela.AddCell(new Phrase(klient.pesel, sredniB));
                tabela.AddCell(new Phrase(p.termin_start.Date.ToString("d-MM-yyyy"), sredni));
                tabela.AddCell(new Phrase(p.termin_koniec.Date.ToString("d-MM-yyyy"), sredni));
               
                koszt = RozliczenieHelper.pobierzPodstawowaCenaPobytu(p.id_pobytu);
                suma += koszt;
                tabela.AddCell(koszt.ToString("0.00") + " PLN");

                koszt = RozliczenieHelper.pobierzPodstawowaCenaPosilkow(p.id_pobytu);
                suma += koszt;
                tabela.AddCell(koszt.ToString("0.00") + " PLN");

                koszt = RozliczenieHelper.pobierzPodstawowaCenaUslug(p.id_pobytu);
                suma += koszt;
                tabela.AddCell(koszt.ToString("0.00") + " PLN");

                sumAll += suma;
                tabela.AddCell(suma.ToString("0.00") + " PLN");

            }
            
            PdfPCell c = new PdfPCell(new Phrase("Suma całkowita "+sumAll.ToString("0.00") + " PLN",sredniB));
            c.HorizontalAlignment = Element.ALIGN_RIGHT;
            c.Colspan = 7;
            tabela.AddCell(c);

            doc.Add(tabela);

            Paragraph doZaplaty = new Paragraph("",sredniB);
            RachunkiDS.RachunkiRow r=TablesManager.Manager.RachunkiTableAdapter.GetDataById(id_rachunku)[0];
            doZaplaty.Add("\nDo zapłacenia po uwzględnieniu rabatów i zaliczki:\n"+r.wartosc.ToString("0.00")+" PLN\n");
            doc.Add(doZaplaty);

            doc.Close();
            return true;
        }
    }
}
