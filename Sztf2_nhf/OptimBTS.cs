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

        static bool Fk(int szint, bool r, Raktar raktar, bool[] E, LancoltLista lista)
        {
            if (r == false)
            {
                return true;
            }
            bool seged;
            seged = raktar.getHely(lista.NthElem(szint), false);
            return seged;
        }

        public static void OPTIMBTS(int szint, ref bool[] E, bool[,] R, ref bool van, Raktar raktar, ref bool[] OPT,LancoltLista lista)
        {
            int i = -1;
            while (i < 1)
            {
                if (szint == lista.DarabElem(lista) - 1)
                {
                    ;
                }
                i++;
                if (Ft(szint, R[szint, i], raktar, E))
                {
                    if (Fk(szint, R[szint, i], raktar, E,lista))
                    {
                        E[szint] = R[szint, i];
                        if (szint == lista.DarabElem(lista)-1)
                        {
                            if (!van || (Josag(E) > Josag(OPT)))
                            {
                                for (int j = 0; j < E.Length; j++)
                                {
                                    OPT[j] = E[j];
                                }
                            }
                            van = true;
                        }
                        else
                            OPTIMBTS(szint + 1, ref E, R, ref van, raktar,ref OPT, lista);
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
