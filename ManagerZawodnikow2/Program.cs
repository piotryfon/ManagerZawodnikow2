using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerZawodnikow2
{
    class Program
    {
        static void Main(string[] args)
        {
            Zawodnik[] zawodnicy;
            string url = "http://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";

            ManagerZawodnikow mz = new ManagerZawodnikow(url);
            mz.WczytajZawodnikow();

            zawodnicy = mz.Filtruj(Filtr.Kraj, "4");

            foreach (var z in zawodnicy)
            {
                Console.WriteLine(z.PrzedstawSię());
            }
            if(zawodnicy.Length == 0)
                Console.WriteLine("Brak danych...");
            Console.ReadKey();
        }
    }
}
