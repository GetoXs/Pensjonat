using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PensjonatApp.DS;
using PensjonatApp.Tools;

namespace PensjonatApp.Helpers
{
    class WyposazeniaHelper
    {
        /// <summary>
        /// Dodaje wyposazenie (powiazanie miedzy kategoria pokoju i slownikiem wyposazenia).
        /// Prosze nie wywolywac jej z poziomu interfejsu.
        /// </summary>
        public static int dodajWyposazenie(int id_slownikowe_pokoju, int id_wyposazenia)
        {
            return TablesManager.Manager.WyposazeniaTableAdapter.Insert(id_slownikowe_pokoju, id_wyposazenia);
        }
    }
}
