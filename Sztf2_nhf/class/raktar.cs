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
        public int ButorDarab { get; set; } //lista hossza is egyben
        public int Szelesseg { get; private set; }
        public int Hosszusag { get; private set; }
        public int Magassag { get; private set; }

        public Raktar(int szelesseg, int hossz, int magassag)
        {
            this.ButorDarab = 0;
            this.Szelesseg = szelesseg;
            this.Hosszusag = hossz;
            this.Magassag = magassag;
            this.lista = new LancoltLista();
            AdatBeolvasas.Beolvas(this);
        }
    }
}
