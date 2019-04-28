using System;
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
            elem = lista.NElem(darab);
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

        public static void Rendezes(int darab, ref int[,] E, ref bool van, LancoltLista lista, Raktar raktar)
        {
            int i = -1;
            while (!van && i < 2)
            {
                i++;
                if (Ft(darab, lista))
                {
                    string seged = "";
                    ButorAlap elemSeged = new AlloButor(0,0,0,-1);
                    if (Fk(ref E, lista, darab, raktar,ref seged, ref elemSeged))
                    {
                        int szelesStart = int.Parse(seged.Split()[0]);
                        int hosszStart = int.Parse(seged.Split()[1]);
                        for (int j = hosszStart; j < hosszStart + elemSeged.Hosszusag; j++)
                        {
                            for (int k = szelesStart; k < szelesStart + elemSeged.Szelesseg; k++)
                            {
                                E[j, k] = elemSeged.ID;
                            }
                        }
                        if (raktar.ButorDarab == darab)
                            van = true;
                        else
                            Rendezes(darab + 1, ref E, ref van, lista, raktar);
                    }
                }
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
