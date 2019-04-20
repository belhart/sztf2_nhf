using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class raktar
    {
        public LancoltLista lista { get; private set; }
        private int ButorDarab { get; set; }


        public raktar()
        {
            ButorDarab = 0;
            lista = AdatBeolvasas.Beolvas(lista);
        }
    }
}
