using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class LancoltLista
    {
        ListaElem fej;

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
            ListaElem p = fej;
            ListaElem uj = new ListaElem();
            uj.tartalom = elem;
            uj.kovetkezo = null;
            if(p == null)
            {
                fej = uj;
            }
            else
            {
                while (p.kovetkezo != null)
                {
                    p = p.kovetkezo;
                }
                p.kovetkezo = uj;
            }     
        }

        public void Bejaras()
        {
            ListaElem p = fej; // referencia mutató !
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
    }
}