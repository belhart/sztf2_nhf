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
            lista = lista.ReID(lista,darabseged);
        }

        public void OsszesButorElhelyezeseARaktarban()
        {
            bool osszes = false;
            bool van = false;
            int butorDarabSeged = ButorDarab;
            int[,] raktarButorokkalseged = raktarButorokkal;
            bool[,] R = new bool[Szelesseg, 2];
            for (int i = 0; i < Szelesseg; i++)
            {
                R[i, 0] = true;
                R[i, 1] = false;
            }
            bool[] E = new bool[ButorDarab];
            BTS2.BTS(0,ref E, R,ref van, this);
            Console.WriteLine("\n\nBefer-e(true/false) + annak a butornak az adatai");
            for (int i = 0; i < ButorDarab; i++)
            {
                Console.Write(E[i] + " ");
                Console.WriteLine(lista.IDthElem(i+1));
            }
            Console.ReadLine();
            //BTS.Rendezes(0,ref raktarButorokkalseged, ref osszes,lista, this, butorDarabSeged);
        }
        
        /*public string getHely(ref int[,] E, ButorAlap elem)
        {
            for (int i = 0; i < E.GetLength(0) - elem.Hosszusag; i++)
            {
                for (int j = 0; j < E.GetLength(1) - elem.Szelesseg; j++)
                {
                    if (E[i,j] == 0)
                    {
                        bool joHely = HelyEllenorzes(ref E, i, j, elem.Szelesseg,elem.Hosszusag);
                        if (joHely == true)
                        {
                            return i.ToString()+" "+j.ToString();
                        }
                    }
                }
            }
            return "nincs hely";
        }*/

        public bool getHely(ButorAlap elem)
        {
            for (int i = 0; i < raktarButorokkal.GetLength(0) - elem.Hosszusag; i++)
            {
                for (int j = 0; j < raktarButorokkal.GetLength(1) - elem.Szelesseg; j++)
                {
                    if (raktarButorokkal[i, j] == 0)
                    {
                        bool joHely = HelyEllenorzes(i, j, elem.Szelesseg, elem.Hosszusag);
                        if (joHely == true)
                        {
                            Elemelhelyez(elem, i, j);
                            elem.BalFelsoKoordinata = i.ToString() + " " + j.ToString();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void Elemelhelyez(ButorAlap elem, int szel, int hossz)
        {
            for (int j = hossz; j < hossz + elem.Szelesseg; j++)
            {
                for (int k = szel; k < szel+ elem.Hosszusag; k++)
                {
                    
                    raktarButorokkal[k, j] = elem.ID;
                }
            }
        }

        public void ElemKivetel(int ID)
        {
            ButorAlap elem = lista.IDthElem(ID);
            int bal = int.Parse(elem.BalFelsoKoordinata.Split()[0]);
            int jobb = int.Parse(elem.BalFelsoKoordinata.Split()[1]);
            for (int i = bal; i < bal + elem.Hosszusag; i++)
            {
                for (int j = jobb; j < jobb + elem.Szelesseg; j++)
                {
                    raktarButorokkal[i, j] = 0;
                }
            }
            elem.BalFelsoKoordinata = "";
        }

        private bool HelyEllenorzes(int szel, int hossz, double elemSzel, double elemHossz)
        {
            if (raktarButorokkal.GetLength(0) - szel - elemSzel < 0)
                return false;
            if (raktarButorokkal.GetLength(1) - hossz - elemHossz < 0)
                return false;
            for (int i = szel; i < szel + elemSzel; i++)
            {
                for (int j = hossz; j < hossz + elemHossz; j++)
                {
                    if (raktarButorokkal[i, j] != 0)
                        return false;
                }
            }
            return true;
        }

        public void RaktarGrafKiir()
        {
            Console.Clear();
            for (int i = 0; i < raktarButorokkal.GetLength(0); i++)
            {
                for (int j = 0; j < raktarButorokkal.GetLength(1); j++)
                {
                    Console.Write(raktarButorokkal[i, j]);
                }
                Console.WriteLine();
            }
        }

        /*private bool HelyEllenorzes(ref int[,] E,int szel, int hossz, double elemSzel, double elemHossz)
        {
            if (E.GetLength(0) - szel - elemSzel < 0)
                return false;
            if (E.GetLength(1) - hossz - elemHossz < 0)
                return false;
            for (int i = szel; i < szel + elemSzel; i++)
            {
                for (int j = hossz; j < hossz + elemHossz; j++)
                {
                    if (E[i, j] != 0)
                        return false;
                }
            }
            return true;
        }*/
    }
}
