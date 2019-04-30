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
            int balalsoKoordinata = int.Parse(elem.BalFelsoKoordinata.Split()[0]) + elem.Hosszusag + 1;
            int bal = int.Parse(elem.BalFelsoKoordinata.Split()[1]);
            int jobb = bal + elem.Szelesseg;
            int db = 0;
            for (int i = bal; i < jobb; i++)//i,j-t felcserélni hogy hatékonyabb legyen
            {
                for (int j = balalsoKoordinata; j < raktar.raktarButorokkal.GetLength(1); j++)
                {
                    if (!lista.Contains(raktar.raktarButorokkal[i,j]) && raktar.raktarButorokkal[i, j] != elem.ID)
                    {
                        lista[db++] = raktar.raktarButorokkal[i, j];
                    }
                }
            }
        }
    }
}
