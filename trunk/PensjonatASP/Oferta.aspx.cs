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
        Int32 id_rez;
        String pesel;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Db.setUpAccesFile(@"C:\Users\ttt\Documents\pensjonat\baza.mdb", "Administrator", "");
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
                                    "WHERE        p3.id_slownikowe_pokoju = p4.id_slownikowe_pokoju AND p4.ilosc_osob = " + ile + " AND (p3.id_pokoju NOT IN " +
                                    "(SELECT        id_pokoju " +
                                    "FROM            Pobyty p1 " +
                                    "WHERE        (termin_start <= " + start + ") AND (termin_koniec >= " + start + ") OR " +
                                                             "(termin_start <= " + koniec + ") AND (termin_koniec >= " + koniec + ") OR " +
                                                             "(termin_start >= " + start + ") AND (termin_koniec <= " + koniec + ")))";

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

         
        protected void Button2_Click(object sender, EventArgs e)
        {
            Db.setUpAccesFile(@"C:\Users\ttt\Documents\pensjonat\baza.mdb", "Administrator", "");
            Db.Con.Open();
            DbCommand cmd = Db.Con.CreateCommand();

            bool blad = false;
            pesel = TextBox3.Text;

            try
            {
                id_rez = Int32.Parse(TextBox2.Text);
            }
            catch (Exception ex)
            {
                blad = true;
                Label1.Text = "Nieprawidłowe id rezerwacji.";
            }

            if (id_rez <= 0)
            {
                blad = true;
                Label1.Text = "Nieprawidłowe id rezerwacji.";

            }

            if (!blad)
            {
                cmd.CommandText = "SELECT r1.zaliczka FROM Rezerwacje r1, Pobyty p1, Klienci k1 WHERE r1.id_rezerwacji = p1.id_rezerwacji AND p1.id_klienta = k1.id_klienta AND r1.id_rezerwacji =" + id_rez + " AND k1.pesel LIKE '"+ pesel +"'";

                //Label1.Text = cmd.CommandText;
                DbDataReader reader = cmd.ExecuteReader();
                 
                //int test = reader.GetInt32(0);
                if (reader.HasRows)
                {
                    Label2.Text = "Zaliczka: ";
                }
                else
                {
                    Label2.Text = "Nie ma takiej rezerwacji.";
                }

                Db.Con.Close();
            }
        }

            
    }
}