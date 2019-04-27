using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class LancoltLista
    {
        private ListaElem fej;

        class ListaElem
        {
            public ButorAlap tartalom;
            public ListaElem kovetkezo;
        }

        public void ElejereBeszuras(ButorAlap elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = fej;
            fej = uj;
        }

        public void VegereBeszuras(ButorAlap elem)
        {
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = null;
            if(fej == null)
            {
                fej = uj;
                return;
            }
            else
            {
                ListaElem p = fej;
                while (p.kovetkezo != null)
                {
                    p = p.kovetkezo;
                }
                p.kovetkezo = uj;
                return;
            }     
        }

        public ButorAlap NElem(int i)
        {
            ListaElem p = fej;
            int n = 0;
            while (p != null)
            {
                if (n == i)
                    return p.tartalom;
                else
                {
                    i++;
                    p = p.kovetkezo;
                }
            }
            p = fej;
            return p.kovetkezo.tartalom;
        }

        public void Bejaras()
        {
            ListaElem p = fej;
            while (p != null)
            {
                Feldolgoz(p);
                p = p.kovetkezo;
            }
        }
        private void Feldolgoz(ListaElem elem)
        {
            Console.WriteLine(">\t{0} \t|", elem.tartalom);
        }

        private static LancoltLista Kitorol(ListaElem elem, LancoltLista lista)
        {
            ListaElem elozoElem = null, p = lista.fej;
            while (p != null)
            {
                if (p.tartalom.Equals(elem.tartalom))
                {
                    if (elozoElem == null)
                    {
                        lista.fej.kovetkezo = p.kovetkezo;
                    }
                    else
                    {
                        elozoElem.kovetkezo = p.kovetkezo;
                    }
                }
                else
                {
                    elozoElem = p;
                }
                p = p.kovetkezo;
            }
            return lista;
        }

        public LancoltLista ListaFeldolgozas(LancoltLista lista,int szelesseg, int hosszusag, int magassag,ref int darab)
        {
            ListaElem p = lista.fej;
            int nemFerBeDB = 0;
            while (p != null)
            {
                if (JoAdat(p, szelesseg, hosszusag, magassag) == false)
                {
                    OnNemFerBe(p.tartalom.ID);
                    lista = Kitorol(p, lista); 
                    nemFerBeDB++;
                    p = p.kovetkezo;
                }
                else
                {
                    p = p.kovetkezo;
                    darab++;
                }
                
            }
            return lista;
        }

        private bool JoAdat(ListaElem elem, int szelesseg, int hosszusag, int magassag)
        {
            if (elem.tartalom.Hosszusag > hosszusag)
                return false;
            else if (elem.tartalom.Szelesseg > szelesseg)
                return false;
            else if (elem.tartalom.Magassag > magassag)
                return false;
            else return true;
        }
        public delegate void NemFerBeEventHandler(object source, ButorEventArgs args);
        public event NemFerBeEventHandler NemFerBeAlap;
        protected virtual void OnNemFerBe(int sorozatszam)
        {
            if (NemFerBeAlap != null)
                NemFerBeAlap(this, new ButorEventArgs() { SorozatSzam = sorozatszam});
        }
    }
}