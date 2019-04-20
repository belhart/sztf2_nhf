using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class Raktar
    {
        public LancoltLista lista { get; private set; }
        private int ButorDarab { get; set; }
        public int Szelesseg { get; private set; }
        public int Hosszusag { get; private set; }

        public Raktar(int szelesseg, int hossz)
        {
            ButorDarab = 0;
            lista = new LancoltLista(); 
            lista = AdatBeolvasas.Beolvas(lista);
            this.Szelesseg = szelesseg;
            this.Hosszusag = hossz;
        }
    }
}
