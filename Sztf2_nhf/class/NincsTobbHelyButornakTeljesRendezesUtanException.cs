﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class NincsTobbHelyButornakTeljesRendezesUtanException : AlapException
    {
        public LancoltLista elemek { get; set; }
    }
}
