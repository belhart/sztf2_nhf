using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class kihoz
    {
        public static void ButorKihozatal(int ID, Raktar raktar)
        {
            ButorAlap elem = raktar.lista.IDthElem(ID);
            int[] UtbanVanIDk = new int[raktar.ButorDarab-1];
            Utbanvan(ref UtbanVanIDk, elem, raktar);
            for (int i = 0; i < raktar.ButorDarab-1; i++)
            {
                Console.WriteLine(UtbanVanIDk[i]);
            }
        }

        private static void Utbanvan(ref int[] lista, ButorAlap elem, Raktar raktar)
        {
            int balalsoKoordinata = int.Parse(elem.BalFelsoKoordinata.Split()[0]) - elem.Hosszusag;
            int db = 0;
            for (int i = balalsoKoordinata; i < raktar.raktarButorokkal.GetLength(1); i++)
            {
                for (int j = int.Parse(elem.BalFelsoKoordinata.Split()[1]); j < elem.Szelesseg; j++)
                {
                    if (!lista.Contains(raktar.raktarButorokkal[i,j]))
                    {
                        lista[db] = raktar.raktarButorokkal[i, j];
                    }
                }
            }
        }
    }
}
