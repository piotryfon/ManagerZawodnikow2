using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerZawodnikow2
{
    class Zawodnik
    {
        public int Id_zawodnika;
        public int? Id_trenera;
        public string Imie;
        public string Nazwisko;
        public string Kraj;
        public DateTime DataUrodzenia;
        public int Wzrost;
        public int Waga;

        public Zawodnik(string imie, string nazwisko)
        {
            Imie = imie;
            Nazwisko = nazwisko;
        }
        public string PrzedstawSię()
        {
            return String.Format("Cześć, jestem {0} {1} i pochodze z {2}", Imie, Nazwisko, Kraj);
        }
    }
}
