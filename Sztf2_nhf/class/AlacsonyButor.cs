using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class AlacsonyButor : ButorAlap
    {
        public override double Alapterulet { get { return Alapterulet; } set { Alapterulet = Szelesseg* Hosszusag; } }

        public AlacsonyButor(int szel, int magas, int hossz) : base(szel, magas, hossz)
        {

        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
