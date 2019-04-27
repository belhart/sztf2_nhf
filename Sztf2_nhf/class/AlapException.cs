using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class AlapException : Exception
    {
        public string HibaUzenet { get; set; }
        public ButorAlap elem { get; set; }
    }
}
