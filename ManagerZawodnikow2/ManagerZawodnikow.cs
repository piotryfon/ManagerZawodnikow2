using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagerZawodnikow2
{
    class ManagerZawodnikow
    {
        public Zawodnik[] zawodnicy;
        private string url;
        public ManagerZawodnikow(string url)
        {
            this.url = url;
        }

        public void WczytajZawodnikow()
        {
            string dane = new WebClient().DownloadString(url);
            string[] wiersze = dane.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            zawodnicy = new Zawodnik[wiersze.Length - 1];

            for (int i = 1; i < wiersze.Length; i++)
            {
                string[] komorkiWiersza = wiersze[i].Split(';');

                Zawodnik z = new Zawodnik(komorkiWiersza[2], komorkiWiersza[3]);
                z.Id_zawodnika = Convert.ToInt32(komorkiWiersza[0]);
                if (!string.IsNullOrEmpty(komorkiWiersza[1]))
                    z.Id_trenera = Convert.ToInt32(komorkiWiersza[1]);
                z.Kraj = komorkiWiersza[4];
                z.DataUrodzenia = Convert.ToDateTime(komorkiWiersza[5]);
                z.Wzrost = Convert.ToInt32(komorkiWiersza[0]);
                z.Waga = Convert.ToInt32(komorkiWiersza[0]);

                zawodnicy[i - 1] = z;
            }
        }
        public Zawodnik[] Filtruj(Filtr filtr, string param)
        {
            List<Zawodnik> przefiltrowani = new List<Zawodnik>();

            foreach (var z in zawodnicy)
            {
                if(filtr == Filtr.Id_trenera)
                {
                    if (Convert.ToString(z.Id_trenera)  == param)
                        przefiltrowani.Add(z);
                }
                else if (filtr == Filtr.Kraj)
                {
                    if (z.Kraj == param)
                        przefiltrowani.Add(z);
                }
            }
            return przefiltrowani.ToArray();
        }
    }
}
