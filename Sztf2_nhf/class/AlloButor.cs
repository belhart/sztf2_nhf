using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class AlloButor : ButorAlap
    {
        public override double Alapterulet { get { return Alapterulet; } set { Alapterulet = Szelesseg * Hosszusag; } }

        public AlloButor(int szel, int magas, int hossz) : base(szel, magas, hossz)
        {
        }

        /*public override string ToString()
        {
            throw new NotImplementedException();
        }*/
    }
}
