using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class Program
    {
        static void OnNemFerBe(object source, ButorEventArgs e)
        {
            Console.WriteLine(e.SorozatSzam + " nem fer be");
        }

        static void Main(string[] args)
        {
            Raktar raktar = new Raktar(600,3600,45);
            raktar.lista.NemFerBe += OnNemFerBe;
            Console.WriteLine("Az adatok beolvasasa közbeni problémák:");
            raktar.AdatHelyessegEllenorzes();
            Console.ReadLine();
            bool vege = false;
            while (vege != true)
            {
                Console.WriteLine("123");
                Console.ReadLine();
            }
            raktar.lista.Bejaras();
        }
    }
}
