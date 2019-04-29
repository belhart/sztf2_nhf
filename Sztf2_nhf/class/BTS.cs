﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class BTS
    {
        static bool Ft(int darab, LancoltLista lista)
        {
            return true;
        }

        static bool Fk(ref int[,] E, LancoltLista lista, int darab, Raktar raktar,ref string seged,ref ButorAlap elem)
        {
            Console.WriteLine("123");
            elem = lista.IDthElem(darab);
            seged = raktar.getHely(ref E,elem);
            if (seged == "nincs hely")
            {
                lista.KitorolListabol(elem.ID, lista);
                throw new NincsTobbHelyButornakTeljesRendezesUtanException()
                {
                    HibaUzenet = "Nincs hely a raktarban a jelenlegi butor elhelyezesehez",
                    elem = elem
                };
            }
            return true;
        }

        public static void Rendezes(int darab, ref int[,] E, ref bool van, LancoltLista lista, Raktar raktar, int Osszdarab)
        {
            int i = -1;
            while (!van && i < 0)
            {
                i++;
                if (Ft(darab, lista))
                {
                    string seged = "";
                    ButorAlap elemSeged = new AlloButor(0,0,0,-1);
                    try
                    {
                        if (Fk(ref E, lista, darab+1, raktar, ref seged, ref elemSeged))
                        {
                            int szelesStart = int.Parse(seged.Split()[1]);
                            int hosszStart = int.Parse(seged.Split()[0]);
                            if (elemSeged.ID == 8)
                                ;
                            elemSeged.BalFelsoKoordinata = seged;
                            for (int j = hosszStart; j < hosszStart + elemSeged.Szelesseg; j++)
                            {
                                for (int k = szelesStart; k < szelesStart + elemSeged.Hosszusag; k++)
                                {
                                    E[j, k] = elemSeged.ID;
                                }
                            }
                            if (raktar.ButorDarab == darab+1)
                                van = true;
                            else
                                Rendezes(darab + 1, ref E, ref van, lista, raktar, Osszdarab);
                        }
                    }
                    catch (NincsTobbHelyButornakTeljesRendezesUtanException)
                    {
                        //OnNemFerBe(elemSeged.ID);
                        //Forgatasal elfer?
                        Console.WriteLine("NEMFERBEEXCEPTIONIDE");
                        if (darab+1 == raktar.ButorDarab)
                        {
                            return;
                        }
                        Rendezes(darab + 1, ref E, ref van, lista, raktar, Osszdarab-1);
                    }
                    catch (Exception)
                    {
                        //log
                    }
                }
            }
        }

        public static void Kihoz(int ID, Raktar raktar) 
        {
            string utbanVanID = "";
            ButorAlap elem = raktar.lista.IDthElem(ID);
            Console.WriteLine(elem.BalFelsoKoordinata);
            int balAlsoSzel = int.Parse(elem.BalFelsoKoordinata.Split()[1]); //0 30
            for (int i = balAlsoSzel; i < elem.Hosszusag + balAlsoSzel+1; i++)
            {
                if (raktar.raktarButorokkal[int.Parse(elem.BalFelsoKoordinata.Split()[0])+ elem.Szelesseg , i] != elem.ID && raktar.raktarButorokkal[i, int.Parse(elem.BalFelsoKoordinata.Split()[1])] != 0)
                    utbanVanID += raktar.raktarButorokkal[i, int.Parse(elem.BalFelsoKoordinata.Split()[1])].ToString() + " ";
            }
            Console.WriteLine(utbanVanID);
        }


        public static void RaktarGrafKiir(int[,] E)
        {
            Console.Clear();
            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    Console.Write(E[i,j]);
                }
                Console.WriteLine();
            }
        }

        public delegate void NemFerBeEventHandler(object source, ButorEventArgs args);
        public event NemFerBeEventHandler NemFerBe;
        protected virtual void OnNemFerBe(int sorozatszam)
        {
            if (NemFerBe != null)
                NemFerBe(this, new ButorEventArgs() { SorozatSzam = sorozatszam });
        }
    }
}
