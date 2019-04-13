using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class Program
    {
        static void Main(string[] args)
        {
            LancoltLista lista = new LancoltLista();
            AdatBeolvasas.Beolvas(lista);
            lista.Bejaras();
        }
    }
}
