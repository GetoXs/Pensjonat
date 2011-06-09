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
        List<int> wybranePokoje;

        const String baza = @"C:\__informatyka\bd\_projekt\Pensjonat_akt\baza.mdb";
        const String login = "Administrator";
        const String haslo = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Db.setUpAccesFile(baza, login, haslo);   
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Db.Con.Open();
            DbCommand cmd = Db.Con.CreateCommand();

            bool blad = false;
            GridView1.Visible = false;

            String start = Calendar1.SelectedDate.ToString("#MM/dd/yy#");
            String koniec = Calendar2.SelectedDate.ToString("#MM/dd/yy#");
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate || Calendar1.SelectedDate < Calendar1.TodaysDate)
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
                    //Button3.Visible = true;
                    //Button4.Visible = true;
                    
                    
                }
                else
                {
                    Label1.Text = "Brak dostępnych pokojów.";
                    GridView1.Visible = false;
                    //Button3.Visible = false;
                    //Button4.Visible = false;
                }

                Db.Con.Close();
            }

        }

         
        protected void Button2_Click(object sender, EventArgs e)
        {
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
                Label2.Text = "Nie ma takiej rezerwacji, bądź nieprawidłowe dane!";
            }

            if (id_rez <= 0)
            {
                blad = true;
                Label2.Text = "Nie ma takiej rezerwacji, bądź nieprawidłowe dane!";
            }

            if (!blad)
            {
                cmd.CommandText = "SELECT r1.zaplacono_zaliczke, r1.zaliczka FROM Rezerwacje r1, Klienci k1 WHERE r1.id_klienta = k1.id_klienta AND r1.id_rezerwacji = " + id_rez + " AND k1.pesel LIKE '"+ pesel +"'";
                DbDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    reader.Read();
                    Label2.Text = "Zaliczka: " + reader.GetFloat(1).ToString() + " - " + (reader.GetBoolean(0) ? "wpłacono" : "nie wpłacono");
                }
                else
                {
                    Label2.Text = "Nie ma takiej rezerwacji, bądź nieprawidłowe dane!";
                }

                Db.Con.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (GridView1.SelectedIndex != -1)
            {
                wybranePokoje.Add(Convert.ToInt32(GridView1.SelectedRow.Cells[0].Text));
                Label3.Text = "Id: ";
                foreach (int pokoj in wybranePokoje)
                   Label3.Text += pokoj + ", ";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count-1 == GridView1.SelectedIndex)
                GridView1.SelectRow(0);
            else
                GridView1.SelectRow(GridView1.SelectedIndex + 1);
        }

            
    }
}