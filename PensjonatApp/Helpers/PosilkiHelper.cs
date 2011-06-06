using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class PosilkiHelper
    {
        public static int dodajPosilek(int? id_pobytu, int? id_slownikowe_posilku, DateTime? data)
        {
            return TablesManager.Manager.PosilkiTableAdapter.Insert(id_pobytu, id_slownikowe_posilku, data);
        }
        public static int edytujPosilek(int id_posilku, int? id_pobytu, int? id_slownikowe_posilku, DateTime? data)
        {
            return TablesManager.Manager.PosilkiTableAdapter.UpdateQuery(id_pobytu, id_slownikowe_posilku, data, id_posilku);
        }
        public static int usunPosilek(int id_posilku)
        {
            return TablesManager.Manager.PosilkiTableAdapter.DeleteQueryById(id_posilku);
        }

        public static SumaPosilkow getPosilkiPoTerminie(DateTime? data)
        {
            SumaPosilkow suma = new SumaPosilkow();

            suma.Sniadania = TablesManager.Manager.PosilkiTableAdapter.GetSumSniadaniabyTermin(data).GetValueOrDefault(0);
            suma.Dsniadania = TablesManager.Manager.PosilkiTableAdapter.GetSumDsniadania(data).GetValueOrDefault(0);
            suma.Obiady = TablesManager.Manager.PosilkiTableAdapter.GetSumObiadyByTermin(data).GetValueOrDefault(0);
            suma.Lunche = TablesManager.Manager.PosilkiTableAdapter.GetSumLunchbyTermin(data).GetValueOrDefault(0);
            suma.Podwieczorki = TablesManager.Manager.PosilkiTableAdapter.GetSumPodw(data).GetValueOrDefault(0);
            suma.Obiadokolacje = TablesManager.Manager.PosilkiTableAdapter.GetSumObiadokolacjeByTermin(data).GetValueOrDefault(0);
            suma.Kolacje = TablesManager.Manager.PosilkiTableAdapter.GetSumKolacjeByTermin(data).GetValueOrDefault(0);

            return suma;
        }

        public class SumaPosilkow
        {
            int sniadania;
            public int Sniadania
            {
                get { return sniadania; }
                set { sniadania = value; }
            }
            
            int dsniadania;
            public int Dsniadania
            {
                get { return dsniadania; }
                set { dsniadania = value; }
            }

            int lunche;

            public int Lunche
            {
                get { return lunche; }
                set { lunche = value; }
            }
            int obiady;

            public int Obiady
            {
                get { return obiady; }
                set { obiady = value; }
            }
            int obiadokolacje;

            public int Obiadokolacje
            {
                get { return obiadokolacje; }
                set { obiadokolacje = value; }
            }
            int podwieczorki;

            public int Podwieczorki
            {
                get { return podwieczorki; }
                set { podwieczorki = value; }
            }
            int kolacje;

            public int Kolacje
            {
                get { return kolacje; }
                set { kolacje = value; }
            }
        }
    }
}
