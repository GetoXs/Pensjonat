using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class PosilkiSlownikHelper
    {
        public static int dodajTypPosilku(decimal? cena, string nazwa_opcji, bool obiad, bool sniadanie, bool kolacja, bool drugie_sniadanie, bool lunch, bool obiadokolacja, bool podwieczorek)
        {
            return TablesManager.Manager.Posilki_slownikTableAdapter.Insert(cena, nazwa_opcji, obiad, sniadanie, kolacja, drugie_sniadanie, lunch, obiadokolacja, podwieczorek);
        }
        public static int edytujTypPosilku(int Original_id_slownikowe_posilku, decimal? cena, string nazwa_opcji, bool obiad, bool sniadanie, bool kolacja, bool drugie_sniadanie, bool lunch, bool obiadokolacja, bool podwieczorek)
        {
            return TablesManager.Manager.Posilki_slownikTableAdapter.UpdateQuery(cena, nazwa_opcji, obiad, sniadanie, kolacja, drugie_sniadanie, lunch, obiadokolacja, podwieczorek, Original_id_slownikowe_posilku);
        }
        public static int kasujTypPosilku(int id_slownikowe_posilku)
        {
            return TablesManager.Manager.Posilki_slownikTableAdapter.DeleteQueryById(id_slownikowe_posilku);
        }
    }
}
