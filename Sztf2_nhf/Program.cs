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
            Console.WriteLine("Sikeresen beolvasott butorok");
            raktar.lista.Bejaras();
            Console.WriteLine("Enter a folytatashoz");
            Console.ReadLine();
            bool vege = false;
            while (vege != true)
            {
                Console.Clear();
                Console.WriteLine("Opciók\n\n1. bútorok kilistázása\n2. bútor kihozás\n3. kilépés");
                Console.Write("Választott opció: ");
                string opcio = Console.ReadLine();
                switch (opcio)
                {
                    case "1":
                        Console.Clear();
                        raktar.lista.Bejaras();
                        Console.WriteLine("Enter a folytatashoz");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Kihozni kivant butor ID-je");
                        int kihozButorId = int.Parse(Console.ReadLine());
                        break;
                    case "3":
                        vege = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
