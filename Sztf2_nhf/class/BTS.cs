using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class BTS
    {
        static bool Ft(int szint, string xEmber)
        {
            // A mi esetünkben mindig igazat ad vissza, mondván: X ember alkalmas Y feladatra
            return true;
        }

        static bool Fk(string[] eredmenyek, string ember, int szint)
        {
            for (int i = 0; i < szint; i++)  // szint fontos, hogy csak eddig nézzük az eredményeket is
                if (eredmenyek[i] == ember)
                    return false;
            return true;
        }

        static void Rendezes(int szint, ref string[] E, ref bool van, int[] M, string[,] R)
        {
            int i = -1;
            while (!van && i < M[szint])
            {
                i++;
                if (Ft(szint, R[szint, i]))
                {
                    if (Fk(E, R[szint, i], szint))
                    {
                        E[szint] = R[szint, i];
                        if (szint == (R.GetLength(0) - 1))
                            van = true;
                        else
                            Rendezes(szint + 1, ref E, ref van, M, R);
                    }
                }
            }
        }
    }
}
