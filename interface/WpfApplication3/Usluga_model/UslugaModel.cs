using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Pensjonat.Tools;

namespace WpfApplication3.Usluga_model
{
    class UslugaModel
    {
        //termin w formacie #miesiac/dzien/rok h:min:s# np. #2012-10-20 10:55:12#
        public static int dodajUsluge(int id_pobytu, string termin, string d_opis, int id_slownikowe)
        {

            DbCommand cmd = Db.Con.CreateCommand();
            cmd.CommandText = "INSERT INTO Uslugi(id_pobytu, dodatkowy_opis, termin, id_slownikowe_uslugi)"
                + "VALUES(" + id_pobytu.ToString() + ", " + d_opis + ", " + termin + ", " + id_slownikowe.ToString() + ");";
            return cmd.ExecuteNonQuery();

        }

        public static int przydzielPracownika(int id_uslugi, int id_pracownika)
        {
            DbCommand cmd = Db.Con.CreateCommand();
            cmd.CommandText = "UPDATE Uslugi "
                + "SET id_pracownika=" + id_pracownika.ToString() + " "
                + "WHERE id_uslugi=" + id_uslugi.ToString() + ";";
            return cmd.ExecuteNonQuery();
        }
    }
}
