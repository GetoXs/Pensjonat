using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using PensjonatASP;

namespace PensjonatASP
{
    public partial class Oferta : System.Web.UI.Page
    {
        Int32 ile;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            Db.setUpAccesFile("C:\\Users\\ttt\\Desktop\\baza.mdb", "ttt", "");
            Db.Con.Open();
            DbCommand cmd = Db.Con.CreateCommand();

            bool blad = false;
            GridView1.Visible = false;

            String start = Calendar1.SelectedDate.ToString("#MM/dd/yy#");
            String koniec = Calendar2.SelectedDate.ToString("#MM/dd/yy#");
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)
            {
                blad = true;
                Label1.Text = "Nieprawidłowy termin pobytu.";

            }

            try
            {
                ile = Int32.Parse(TextBox1.Text);
            }
            catch (Exception ex)
            {
                blad = true;
                Label1.Text = "Błędna ilość osób.";
            }

            if (ile <= 0)
            {
                blad = true;
                Label1.Text = "Błędna ilość osób.";
            }


            if (!blad)
            {
                cmd.CommandText = "SELECT        p3.id_pokoju AS ID, p3.nr_pokoju AS NUMER, p4.cena AS CENA, p4.dodatkowy_opis AS OPIS " +
                                    "FROM            Pokoje p3, Pokoje_slownik p4 " +
                                    "WHERE        p3.id_slownikowe_pokoju = p4.id_slownikowe_pokoju AND p4.ilosc_osob = "+ile+" AND (p3.id_pokoju NOT IN " +
                                    "(SELECT        id_pokoju " +
                                    "FROM            Pobyty p1 " +
                                    "WHERE        (termin_start < " + start + ") AND (termin_koniec > " + start + ") OR " +
                                                             "(termin_start < " + koniec + ") AND (termin_koniec > " + koniec + ") OR " +
                                                             "(termin_start > " + start + ") AND (termin_koniec < " + koniec + ")))";

                //Label1.Text = cmd.CommandText;
                DbDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    Label1.Text = "Dostępne pokoje: ";
                    GridView1.Visible = true;
                }
                else
                {
                    Label1.Text = "Brak dostępnych pokojów.";
                    GridView1.Visible = false;
                }

                Db.Con.Close();
            }
        }
    }
}