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

        public string Imie { get { return imie; } set { imie = value; } }
        public string Nazwisko { get { return nazwisko; } set { nazwisko = value; } }
        public string PESEL { get { return pesel; } set { pesel = value; } }
        public string Nr_pokoju { get { return nr_pokoju; } set { nr_pokoju = value; } }

        public PokojeKlienci(string imie, string nazwisko, string PESEL, string nr_pokoju)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.PESEL = PESEL;
            this.nr_pokoju = nr_pokoju;
        }
    }

}
