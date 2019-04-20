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
        public delegate void NemFerBeEventHandler(object source, EventArgs args);
        public event NemFerBeEventHandler NemFerBe;

        public Raktar(int szelesseg, int magassag, int hossz)
        {
            this.ButorDarab = 0;
            this.Szelesseg = szelesseg;
            this.Hosszusag = hossz;
            this.Magassag = magassag;
            this.lista = new LancoltLista();
            lista = AdatBeolvasas.Beolvas(lista,ButorDarab);
            lista = LancoltLista.ListaFeldolgozas(lista,Szelesseg,Hosszusag,Magassag);
        }

        protected virtual void OnNemFerBe(int sorozatszam)
        {
            if (NemFerBe != null)
                NemFerBe(this, new ButorEventArgs() { SorozatSzam = sorozatszam });
        }
    }
}
