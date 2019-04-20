using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class NemFerBeAlapbolException : AlapException
    {
        public int Sorozatszam { get; set; }
    }
}
