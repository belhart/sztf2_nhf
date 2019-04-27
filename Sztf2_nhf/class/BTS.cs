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

        static bool Fk(ref int[,] E, LancoltLista lista, int darab, Raktar raktar)
        {
            ButorAlap elem = lista.NElem(darab);
            string hely = raktar.getHely(ref E,elem);
            if (hely == "nincs hely")
            {
                throw new NincsTobbHelyButornakTeljesRendezesUtanException();
            }
            for (int i = 0; i < szint; i++)  // szint fontos, hogy csak eddig nézzük az eredményeket is
                if (eredmenyek[i] == ember)
                    return false;
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
                    if (Fk(ref E, lista, darab, raktar))//belép hogy megnézzr van-e hely a bútornak
                    {
                        E[szint] = R[szint, i]; //beteszi a bútort
                        if (szint == darab)
                            van = true;
                        else
                            Rendezes(darab + 1, ref E, ref van, lista);
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
