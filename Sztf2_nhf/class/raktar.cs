using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class Raktar
    {
        public LancoltLista lista { get; private set; }
        public int ButorDarab { get; set; } 
        public int Szelesseg { get; private set; }
        public int Hosszusag { get; private set; }
        public int Magassag { get; private set; }
        public int[,] raktarButorokkal { get; set; }


        public Raktar(int szelesseg, int magassag, int hossz)
        {
            this.Szelesseg = szelesseg;
            this.Hosszusag = hossz;
            this.Magassag = magassag;
            lista = new LancoltLista();
            lista = AdatBeolvasas.Beolvas(lista,ButorDarab);
            raktarButorokkal = new int[Szelesseg,Hosszusag];
        }

        public void AdatHelyessegEllenorzes()
        {
            int darabseged = 0;
            lista = lista.ListaFeldolgozas(lista, Szelesseg, Hosszusag, Magassag, ref darabseged);
            ButorDarab = darabseged;
            Console.WriteLine(ButorDarab);
        }

        public void OsszesButorElhelyezeseARaktarban()
        {
            bool osszes = false;
            int[,] raktarButorokkalseged = raktarButorokkal;
            BTS.Rendezes(ButorDarab,ref raktarButorokkalseged, ref osszes,lista, this);
        }
        
        public string getHely(ref int[,] E, ButorAlap elem)
        {
            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    if (E[i,j] == 0)
                    {
                        bool joHely = HelyEllenorzes(ref E, i, j);
                        if (joHely == true)
                        {
                            return i.ToString()+" "+j.ToString();
                        }
                    }
                }
            }
            return "nincs hely";
        }

        private bool HelyEllenorzes(ref int[,] E, int szel, int hossz)
        {
            for (int i = 0; i < szel; i++)
            {
                for (int j = 0; j < hossz; j++)
                {
                    if (E[i, j] != 0)
                        return false;
                }
            }
            return true;
        }
    }
}
