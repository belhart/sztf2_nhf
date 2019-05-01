using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class AlacsonyButor : ButorAlap
    {
        public bool rajtaVanButor { get; set; }
        public bool rahelyezhetoMegButor { get; set; }
        public int osszMagassag { get; set; }
        public string rajtaLevoButorIDk { get; set; }
        public AlacsonyButor(int szel, int magas, int hossz, int ID) : base(szel, magas, hossz, ID)
        {
            rajtaLevoButorIDk = "";
            rajtaVanButor = false;
            rahelyezhetoMegButor = true;
            osszMagassag = magas;
        }

        public override string ToString()
        {
            string szoveg = string.Format("ID: {0} , ALA, SZELESSEG: {1} + MAGASSAG: {2} HOSSZUSAG: {3}", ID.ToString(), Szelesseg.ToString(), Magassag.ToString(), Hosszusag.ToString());
            return szoveg;
        }
    }
}
