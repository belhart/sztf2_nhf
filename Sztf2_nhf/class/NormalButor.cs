using System;
using System.Collections.Generic;
using System.Text;

namespace Sztf2_nhf
{
    class NormalButor : ButorAlap
    {
        public NormalButor(int szel, int magas, int hossz) : base(szel, magas, hossz)
        {
        }

        public override double Alapterulet { get { return Alapterulet; } set { Alapterulet = AlapTeruletek(); } }

        /*public override string ToString()
        {
            throw new NotImplementedException();
        }*/

        private double AlapTeruletek()
        {
            double terulet1 = Szelesseg * Magassag;
            double terulet2 = Szelesseg * Hosszusag;
            double terulet3 = Hosszusag * Magassag;
            if (Szelesseg < Hosszusag)
            {
                return Math.Min(terulet2, terulet3);
            }
            else return Math.Min(terulet1, terulet2);

        }
    }
}
