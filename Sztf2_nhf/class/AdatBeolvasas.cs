using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Sztf2_nhf
{
    class AdatBeolvasas
    {
        public static LancoltLista Beolvas(LancoltLista lista)
        {
            string[] lines = File.ReadAllLines(@"adatok.txt");
            foreach (string line in lines)
            {
                string[] SplittedLine = line.Split();
                if(SplittedLine[0] == "NORM")
                {
                    NormalButor uj = new NormalButor(int.Parse(SplittedLine[1]),int.Parse(SplittedLine[2]),int.Parse(SplittedLine[3]));
                    lista.VegereBeszuras(uj);
                }
                else if (SplittedLine[0] == "ALLO")
                {
                    AlloButor uj = new AlloButor(int.Parse(SplittedLine[1]), int.Parse(SplittedLine[2]), int.Parse(SplittedLine[3]));
                    lista.VegereBeszuras(uj);
                }
                else
                {
                    AlacsonyButor uj = new AlacsonyButor(int.Parse(SplittedLine[1]), int.Parse(SplittedLine[2]), int.Parse(SplittedLine[3]));
                    lista.VegereBeszuras(uj);
                }
            }

            return lista;
        }
    }
}
