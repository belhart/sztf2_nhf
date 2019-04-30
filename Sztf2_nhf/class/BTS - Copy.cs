using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class BTS2
    {
        static bool Ft(int szint, bool r, Raktar raktar, bool[] E)
        {
            return true;
        }

        static bool Fk(int szint, bool r, Raktar raktar, bool[] E)
        {
            if (r == false)
            {
                return true;
            }
            bool seged;
            seged = raktar.getHely(raktar.lista.IDthElem(szint+1));
            return seged;
        }

        public static void BTS(int szint, ref bool[] E, bool[,] R, ref bool van, Raktar raktar)
        {
            int i = -1;
            while (!van && i < 2)
            {
                i++;
                if (Ft(szint, R[szint, i], raktar, E))
                {
                    if (Fk(szint, R[szint, i], raktar, E))
                    {
                        E[szint] = R[szint, i];
                        if (szint == raktar.ButorDarab-1)
                            van = true;
                        else
                            BTS(szint + 1, ref E, R, ref van, raktar);
                    }
                }
            }
        }
    }
}
