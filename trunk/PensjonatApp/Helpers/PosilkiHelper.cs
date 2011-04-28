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
    }
}
