using System;
using System.Collections.Generic;
using System.Text;

namespace Sztf2_nhf
{
    class NormalButor : ButorAlap
    {
        public NormalButor(int szel, int magas, int hossz, int ID) : base(szel, magas, hossz, ID)
        {
        }

        public override string ToString()
        {
            string szoveg = string.Format("ID: {0} , NORM, SZELESSEG: {1} + MAGASSAG: {2} HOSSZUSAG: {3}", ID.ToString(), Szelesseg.ToString(), Magassag.ToString(), Hosszusag.ToString());
            return szoveg;
        }
    }
}
