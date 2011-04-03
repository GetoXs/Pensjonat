using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Pensjonat.Tools;

namespace WpfApplication3.Pracownik_zadania_model
{
    class PracownikZadania
    {
        //termin w formacie #miesiac/dzien/rok# np. #11/20/2012#
        public static DbDataReader pobierzZadania(string termin, int id_pracownika)
        {

            DbCommand cmd = Db.Con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Uslugi WHERE (((Uslugi.id_pracownika)=" + id_pracownika.ToString() + ") AND ((Uslugi.termin)=" + termin + "))";
            DbDataReader reader = cmd.ExecuteReader();
            return reader;

        }
    }
}
