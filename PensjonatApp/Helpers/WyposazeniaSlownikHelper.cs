using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class WyposazeniaSlownikHelper
    {
        public static int dodajElementWyposazenia(string opis)
        {
            return TablesManager.Manager.Wyposazenia_slownikTableAdapter.Insert(opis);
        }

        public static int edytujElementWyposazenia(int id_wyposazenia, string opis)
        {
            WyposazeniaDS.Wyposazenia_slownikDataTable doZmiany = TablesManager.Manager.Wyposazenia_slownikTableAdapter.GetDataByID(id_wyposazenia);
            doZmiany[0].opis = opis;
            return TablesManager.Manager.Wyposazenia_slownikTableAdapter.Update(doZmiany);
        }
    }
}
