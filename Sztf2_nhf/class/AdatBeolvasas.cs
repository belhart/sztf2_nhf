using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Sztf2_nhf
{
    class AdatBeolvasas
    {
        public delegate void NemFerBeEventHandler(object source, EventArgs args);
        public event NemFerBeEventHandler NemFerBe;

        public static void Beolvas(Raktar raktar)
        {
            string[] lines = File.ReadAllLines(@"adatok.txt");
            foreach (string line in lines)
            {
                string[] SplittedLine = line.Split();
                if(SplittedLine[0] == "NORM")
                {
                    NormalButor uj = new NormalButor(int.Parse(SplittedLine[1]),int.Parse(SplittedLine[2]),int.Parse(SplittedLine[3]));
                    raktar.lista.VegereBeszuras(uj);
                    raktar.ButorDarab++;
                }
                else if (SplittedLine[0] == "ALLO")
                {
                    AlloButor uj = new AlloButor(int.Parse(SplittedLine[1]), int.Parse(SplittedLine[2]), int.Parse(SplittedLine[3]));
                    raktar.lista.VegereBeszuras(uj);
                    raktar.ButorDarab++;
                }
                else
                {
                    AlacsonyButor uj = new AlacsonyButor(int.Parse(SplittedLine[1]), int.Parse(SplittedLine[2]), int.Parse(SplittedLine[3]));
                    raktar.lista.VegereBeszuras(uj);
                    raktar.ButorDarab++;
                }
            }
        }
    }
}
