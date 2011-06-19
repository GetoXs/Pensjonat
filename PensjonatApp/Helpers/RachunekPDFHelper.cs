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
            naglowek2.Add("Data wygenerowania: "+DateTime.Now.Date.ToString("d-MM-yyyy")+"\n\n\n\n");
            doc.Add(naglowek2);

            PobytyDS.PobytyDataTable pobyty = TablesManager.Manager.PobytyTableAdapter.GetDataPobytyByIdRachunku(id_rachunku);

            decimal sumAll = 0;
            foreach (PobytyDS.PobytyRow p in pobyty)
            {
                PdfPTable tabk = new PdfPTable(5);
                tabk.SpacingBefore = 15;
                tabk.SpacingAfter = 0;

                BaseColor kolor=new BaseColor(133,203,118);
                PdfPCell komorka;

                komorka = new PdfPCell(new Phrase("Imię:", sredni));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Nazwisko:", sredni));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("PESEL:", sredni));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Adres:", sredni));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Miejscowość:", sredni));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
     

                KlienciDS.KlienciRow klient=TablesManager.Manager.KlienciTableAdapter.GetDataByIdKlienta(p.id_klienta)[0];
                KlienciDS.Miejscowosci_slownikRow msc=TablesManager.Manager.Miejscowosci_slownikTableAdapter.GetDataByID(klient.id_miejscowosci)[0];

                kolor = new BaseColor(182,224,173);

                komorka=new PdfPCell(new Phrase(klient.imie, sredniB));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase(klient.nazwisko, sredniB));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase(klient.pesel, sredniB));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase(klient.ulica, sredniB));
                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                komorka = new PdfPCell(new Phrase(msc.nazwa, sredniB));
                                komorka.BackgroundColor = kolor;
                tabk.AddCell(komorka);
                
                doc.Add(tabk);


                PdfPTable tabp = new PdfPTable(5);
                tabp.SpacingBefore = 0;
                tabp.SpacingAfter = 15;

                kolor=new BaseColor(239,233,112);

                komorka = new PdfPCell(new Phrase("Początek pobytu:", sredni));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Koniec pobytu:", sredni));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Opłata za pokój:", sredni));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Opłata za posiłki:", sredni));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
                komorka = new PdfPCell(new Phrase("Opłata za usługi:", sredni));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);

                decimal suma = 0;
                decimal koszt = 0;

                kolor = new BaseColor(244, 240, 162);

                komorka = new PdfPCell(new Phrase(p.termin_start.Date.ToString("d-MM-yyyy"), sredniB));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
                komorka = new PdfPCell(new Phrase(p.termin_koniec.Date.ToString("d-MM-yyyy"), sredniB));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
               
                koszt = RozliczenieHelper.pobierzPodstawowaCenaPobytu(p.id_pobytu);
                suma += koszt;
                komorka = new PdfPCell(new Phrase(koszt.ToString("0.00") + " PLN", sredniB));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);
                
                koszt = RozliczenieHelper.pobierzPodstawowaCenaPosilkow(p.id_pobytu);
                suma += koszt;
                komorka = new PdfPCell(new Phrase(koszt.ToString("0.00") + " PLN", sredniB));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);

                koszt = RozliczenieHelper.pobierzPodstawowaCenaUslug(p.id_pobytu);
                suma += koszt;
                komorka = new PdfPCell(new Phrase(koszt.ToString("0.00") + " PLN", sredniB));
                komorka.BackgroundColor = kolor;
                tabp.AddCell(komorka);

                sumAll += suma;
                komorka = new PdfPCell(new Phrase("Suma: "+suma.ToString("0.00") + " PLN",sredniB));
                komorka.HorizontalAlignment = Element.ALIGN_RIGHT;
                komorka.Colspan = 5;
                komorka.BackgroundColor = BaseColor.LIGHT_GRAY;
                tabp.AddCell(komorka);

                doc.Add(tabp);

            }
            
            PdfPTable tabela= new PdfPTable(1);
            PdfPCell kom = new PdfPCell(new Phrase("Suma całkowita "+sumAll.ToString("0.00") + " PLN",sredniB));
            kom.HorizontalAlignment = Element.ALIGN_RIGHT;
            kom.BackgroundColor=BaseColor.LIGHT_GRAY;
            tabela.AddCell(kom);
            doc.Add(tabela);

            sredniB.Color = BaseColor.RED;
            sredniB.Size = 13;
            Paragraph doZaplaty = new Paragraph("",sredniB);
            RachunkiDS.RachunkiRow r=TablesManager.Manager.RachunkiTableAdapter.GetDataById(id_rachunku)[0];
            doZaplaty.Add("\n\n\nDo zapłacenia po uwzględnieniu rabatów i zaliczki: "+r.wartosc.ToString("0.00")+" PLN\n");
            doZaplaty.Alignment = Element.ALIGN_RIGHT;
            doc.Add(doZaplaty);

            doc.Close();
            return true;
        }
    }
}
