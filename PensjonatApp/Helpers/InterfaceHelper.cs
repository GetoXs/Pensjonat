using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PensjonatApp.Helpers
{
    class PokojeKlienci
    {
        string imie;
        string nazwisko;
        string pesel;
        string nr_pokoju;
        int l_osob;
        int id_osoby;
        int id_pokoju;

        public string Imie { get { return imie; } set { imie = value; } }
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public string PESEL { get { return pesel; } set { pesel = value; } }
        public string Nr_pokoju { get { return nr_pokoju; } set { nr_pokoju = value; } }
        public int L_osob { get { return l_osob; } set { l_osob = value; } }
        public int Id_osoby{ get { return id_osoby; } set { id_osoby = value; } }
        public int Id_pokoju{ get { return id_pokoju; } set { id_pokoju = value; } }
        public PokojeKlienci(string imie, string nazwisko, string PESEL,int id_osoby,int id_pokoju, string nr_pokoju,int l_osob)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.PESEL = PESEL;
            this.nr_pokoju = nr_pokoju;
            this.l_osob = l_osob;
            this.id_osoby = id_osoby;
            this.id_pokoju = id_pokoju;
        }
    }
    class PokojeStandardy
    {
        string nr_pokoju;
        int l_osob;
        int id_pokoju;
        string opis;
        decimal cena;

        public decimal Cena { get { return cena; } set { cena = value; } }
        public string Opis { get { return opis; } set { opis = value; } }
        public string Nr_pokoju { get { return nr_pokoju; } set { nr_pokoju = value; } }
        public int L_osob { get { return l_osob; } set { l_osob = value; } }
        public int Id_pokoju { get { return id_pokoju; } set { id_pokoju = value; } }
        public PokojeStandardy(string opis, int id_pokoju, string nr_pokoju, int l_osob, decimal cena)
        {
            this.nr_pokoju = nr_pokoju;
            this.l_osob = l_osob;
            this.opis = opis;
            this.id_pokoju = id_pokoju;
            this.cena = cena;
        }
    }

}
