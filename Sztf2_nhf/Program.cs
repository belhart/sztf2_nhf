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
            raktar.AdatHelyessegEllenorzes();
            raktar.lista.Bejaras();
        }
    }
}
