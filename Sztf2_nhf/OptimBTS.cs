using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class OptimBTS
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
            seged = raktar.getHely(raktar.lista.IDthElem(szint + 1), false);
            return seged;
        }

        public static void OPTIMBTS(int szint, ref bool[] E, bool[,] R, ref bool van, Raktar raktar, ref bool[] OPT)
        {
            int i = -1;
            while (i < 2)
            {
                i++;
                if (Ft(szint, R[szint, i], raktar, E))
                {
                    if (Fk(szint, R[szint, i], raktar, E))
                    {
                        E[szint] = R[szint, i];
                        if (szint == raktar.ButorDarab - 1)
                        {
                            if (!van || Josag(E) > Josag(OPT))
                            {
                                OPT = E;
                            }
                            van = true;
                        }
                        else
                            OPTIMBTS(szint + 1, ref E, R, ref van, raktar,ref OPT);
                    }
                }
            }
        }

        private static int Josag(bool[] E)
        {
            int dbTrue = 0;
            for (int i = 0; i < E.Length; i++)
            {
                if (E[i] == true)
                    dbTrue++;
            }
            return dbTrue;
        }
    }
}
