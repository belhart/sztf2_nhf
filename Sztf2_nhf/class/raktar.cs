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


        public Raktar(int szelesseg, int magassag, int hossz)
        {
            this.Szelesseg = szelesseg;
            this.Hosszusag = hossz;
            this.Magassag = magassag;
            lista = new LancoltLista();
            lista = AdatBeolvasas.Beolvas(lista,ButorDarab);
        }

        public void AdatHelyessegEllenorzes()
        {
            int darabseged = 0;
            lista = lista.ListaFeldolgozas(lista, Szelesseg, Hosszusag, Magassag, ref darabseged);
            ButorDarab = darabseged;
        }
        
    }
}
