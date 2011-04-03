using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Pensjonat.Tools;

namespace WpfApplication3.Kucharz_model
{
    class KucharzModel
    {
        //termin w formacie #miesiac/dzien/rok# np. #11/20/2012#
        public static DbDataReader pobierzPosilki(string termin)
        {

            DbCommand cmd = Db.Con.CreateCommand();
            cmd.CommandText = "SELECT Sum(Posilki_slownik.obiad) AS SumaOfobiad, Posilki.data, Sum(Posilki_slownik.sniadanie) AS SumaOfsniadanie, Sum(Posilki_slownik.kolacja) AS SumaOfkolacja, Sum(Posilki_slownik.drugie_sniadanie) AS SumaOfdrugie_sniadanie, Sum(Posilki_slownik.lunch) AS SumaOflunch, Sum(Posilki_slownik.obiadokolacja) AS SumaOfobiadokolacja, Sum(Posilki_slownik.podwieczorek) AS SumaOfpodwieczorek" 
                             +"FROM Posilki_slownik INNER JOIN Posilki ON Posilki_slownik.id_slownikowe_posilku = Posilki.id_slownikowe_posilku"
                             +"GROUP BY Posilki.data"
                             +"HAVING (((Posilki.data)="+termin+"));";
            DbDataReader reader = cmd.ExecuteReader();
            return reader;

        }
    }
}
