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

        public void OsszesButorElhelyezeseARaktarban(bool UjraRendezes)
        {
            bool van = false;
            int butorDarabSeged = ButorDarab;
            int[,] raktarButorokkalseged = raktarButorokkal;
            bool[,] R = new bool[ButorDarab, 2];
            for (int i = 0; i < ButorDarab; i++)
            {
                R[i, 0] = true;
                R[i, 1] = false;
            }
            bool[] E = new bool[ButorDarab];
            BTS2.BTS(0,ref E, R,ref van, this);
            if (UjraRendezes)
            {
                Console.WriteLine("\n\nBefer-e(true/false) teljes ujrarendezes utan + annak a butornak az adatai");
                int i = 0;
                LancoltLista masikRaktarbaKuldesButorok = new LancoltLista();
                foreach (bool item in E)
                {
                    Console.Write(item + " ");
                    Console.WriteLine(lista.NthElem(i));
                    if (!item)
                    {
                        masikRaktarbaKuldesButorok.VegereBeszuras(lista.NthElem(i));
                    }
                i++;
                }
                if (masikRaktarbaKuldesButorok.DarabElem(masikRaktarbaKuldesButorok) != 0)
                {
                    for (int j = 0; j < masikRaktarbaKuldesButorok.DarabElem(masikRaktarbaKuldesButorok); j++)
                    {
                        lista.KitorolListabol(masikRaktarbaKuldesButorok.NthElem(j).ID, lista);
                    }
                    throw new NincsTobbHelyButornakTeljesRendezesUtanException()
                    {
                        HibaUzenet = "[ERR]Butor(ok)nak nincs hely teljes ujrarendezés után",
                        elemek = masikRaktarbaKuldesButorok
                    };
                }
            }
            else
            {
                Console.WriteLine("\n\nBefer-e(true/false) + annak a butornak az adatai");
                for (int i = 0; i < ButorDarab; i++)
                {
                    Console.Write(E[i] + " ");
                    Console.WriteLine(lista.NthElem(i));
                }
            }
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

        public bool getHely(ButorAlap elem, bool elhelyez)
        {
            if (elem is NormalButor)
            {
                int minimum1 = Math.Min(elem.Szelesseg, elem.Hosszusag);
                int minumum2 = Math.Min(Math.Max(elem.Szelesseg, elem.Hosszusag), elem.Magassag);
                return raktarVegignez(elem, minimum1, minumum2, elhelyez);
            }
            else
            {
                return raktarVegignez(elem, elem.Hosszusag, elem.Szelesseg, elhelyez);
            }
            
        }

        private bool raktarVegignez(ButorAlap elem, int meddig1, int meddig2, bool elhelyez)
        {
            for (int i = 0; i < raktarButorokkal.GetLength(0) - meddig1; i++)
            {
                for (int j = 0; j < raktarButorokkal.GetLength(1) - meddig2; j++)
                {
                    if (raktarButorokkal[i, j] == 0)
                    {
                        bool joHely = HelyEllenorzes(i, j, meddig1, meddig2,0);
                        if (joHely == true)
                        {
                            if (elhelyez)
                            {
                                Elemelhelyez(meddig1, meddig2, i, j, elem.ID);
                                elem.BalFelsoKoordinata = i.ToString() + " " + j.ToString();
                            }
                            return true;
                        }
                    }
                    if (lista.IDthElem(raktarButorokkal[i, j]) is AlacsonyButor)
                    {
                        ButorAlap elemseged = lista.IDthElem(raktarButorokkal[i, j]);
                        if(elemseged.Magassag + elem.Magassag < Magassag && (elemseged as AlacsonyButor).rahelyezhetoMegButor)
                        {
                            bool joHely = false;
                            if (elem is NormalButor)
                            {
                                int minimum1 = Math.Min(elem.Szelesseg, elem.Hosszusag);
                                int minumum2 = Math.Min(Math.Max(elem.Szelesseg, elem.Hosszusag), elem.Magassag);
                                joHely = HelyEllenorzes(i, j, meddig1, meddig2, elemseged.ID);
                            }
                            else
                            {
                                joHely = HelyEllenorzes(i, j, meddig1, meddig2, elemseged.ID);
                            }
                            if (joHely == true)
                            {
                                if (elhelyez)
                                {
                                    elem.BalFelsoKoordinata = i.ToString() + " " + j.ToString();
                                    if (elem is NormalButor)
                                    {
                                        (elemseged as AlacsonyButor).osszMagassag += Math.Max(elem.Magassag, Math.Max(elem.Szelesseg, elem.Hosszusag));
                                        (elemseged as AlacsonyButor).rahelyezhetoMegButor = false;
                                        (elemseged as AlacsonyButor).rajtaLevoButorIDk += elem.ID.ToString();
                                    }
                                    if (elem is AlloButor)
                                    {
                                        (elemseged as AlacsonyButor).osszMagassag += elem.Magassag;
                                        (elemseged as AlacsonyButor).rahelyezhetoMegButor = false;
                                        (elemseged as AlacsonyButor).rajtaLevoButorIDk += elem.ID.ToString();
                                    }
                                    if (elem is AlacsonyButor)
                                    {
                                        (elemseged as AlacsonyButor).osszMagassag += elem.Magassag;
                                        (elemseged as AlacsonyButor).rajtaLevoButorIDk += elem.ID.ToString() + " ";
                                    }
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void Elemelhelyez(int meddig1, int meddig2, int szel, int hossz, int ID)
        {
            for (int j = hossz; j < hossz + meddig2; j++)
            {
                for (int k = szel; k < szel+ meddig1; k++)
                {
                    
                    raktarButorokkal[k, j] = ID;
                }
            }
        }

        public void ElemKivetel(int ID)
        {
            ButorAlap elem = lista.IDthElem(ID);
            int minimum1;
            int minimum2;
            if (elem is NormalButor)
            {
                minimum1 = Math.Min(elem.Szelesseg, elem.Hosszusag);
                minimum2 = Math.Min(Math.Max(elem.Szelesseg, elem.Hosszusag), elem.Magassag);
            }
            else
            {
                minimum1 = elem.Hosszusag;
                minimum2 = elem.Szelesseg;
            }
            int bal = int.Parse(elem.BalFelsoKoordinata.Split()[0]);
            int jobb = int.Parse(elem.BalFelsoKoordinata.Split()[1]);
            for (int i = bal; i < bal + minimum1; i++)
            {
                for (int j = jobb; j < jobb + minimum2; j++)
                {
                    raktarButorokkal[i, j] = 0;
                }
            }
            elem.BalFelsoKoordinata = "";
        }

        private bool HelyEllenorzes(int szel, int hossz, double elemSzel, double elemHossz, int ID)
        {
            if (raktarButorokkal.GetLength(0) - szel - elemSzel < 0)
                return false;
            if (raktarButorokkal.GetLength(1) - hossz - elemHossz < 0)
                return false;
            for (int i = szel; i < szel + elemSzel; i++)
            {
                for (int j = hossz; j < hossz + elemHossz; j++)
                {
                    if (raktarButorokkal[i, j] != ID)
                        return false;
                }
            }
            return true;
        }

        public void ButorKihozatal(int ID, Raktar raktar)
        {
            ButorAlap elem = raktar.lista.IDthElem(ID);
            int[] UtbanVanIDk = new int[raktar.ButorDarab - 1];
            Utbanvan(ref UtbanVanIDk, elem, raktar);
            LancoltLista kihozottButorokLista = new LancoltLista();
            int j = 0;
            while (j < raktar.ButorDarab && UtbanVanIDk[j] != 0)
            {
                kihozottButorokLista.VegereBeszuras(raktar.lista.IDthElem(UtbanVanIDk[j]));
                raktar.ElemKivetel(UtbanVanIDk[j++]);
            }
            raktar.ElemKivetel(ID);
            raktar.lista.KitorolListabol(ID, raktar.lista);
            raktar.ButorDarab--;
            int kihozottDb = kihozottButorokLista.DarabElem(kihozottButorokLista);
            if (kihozottDb != 0)
            {
                bool[] OPT = new bool[kihozottDb];
                bool[] E = new bool[kihozottDb];
                bool[,] R = new bool[kihozottDb, 2];
                for (int i = 0; i < kihozottDb; i++)
                {
                    R[i, 0] = true;
                    R[i, 1] = false;
                }
                bool van = false;
                OptimBTS.OPTIMBTS(0, ref E, R, ref van, this, ref OPT, kihozottButorokLista);
                for (int i = 0; i < kihozottDb; i++)
                {
                    if (OPT[i])
                    {
                        getHely(kihozottButorokLista.NthElem(i), true); // visszarakas a raktarba
                        OnUjHely(kihozottButorokLista.NthElem(i).ID, kihozottButorokLista.NthElem(i).BalFelsoKoordinata);
                    }
                    else
                    {
                        throw new NincsTobbHelyButornakTeljesRendezesElottException()
                        {
                            HibaUzenet = "[ERR]Egy butornak nem sikerült helyet találni",
                            elem = kihozottButorokLista.NthElem(i)
                        };
                    }
                }
            }
        }

        private void Utbanvan(ref int[] lista, ButorAlap elem, Raktar raktar)
        {
            if (elem == null || elem.BalFelsoKoordinata == null)
                throw new NincsARaktarbanException()
                {
                    HibaUzenet = "[ERR]Nincs benne a raktárban"
                };
            int minimum1;
            int minimum2;
            if (elem is NormalButor)
            {
                minimum1 = Math.Min(elem.Szelesseg, elem.Hosszusag);
                minimum2 = Math.Min(Math.Max(elem.Szelesseg, elem.Hosszusag), elem.Magassag);
            }
            else
            {
                minimum1 = elem.Hosszusag;
                minimum2 = elem.Szelesseg;
            }
            int balalsoKoordinata = int.Parse(elem.BalFelsoKoordinata.Split()[0]) + minimum1 + 1;
            int bal = int.Parse(elem.BalFelsoKoordinata.Split()[1]);
            int jobb = bal + minimum2;
            int db = 0;
            for (int i = bal; i < jobb; i++)//i,j-t felcserélni hogy hatékonyabb legyen
            {
                for (int j = balalsoKoordinata; j < raktar.raktarButorokkal.GetLength(1); j++)
                {
                    if (!lista.Contains(raktar.raktarButorokkal[j, i]) && raktar.raktarButorokkal[j, i] != elem.ID)
                    {
                        lista[db++] = raktar.raktarButorokkal[j, i];
                    }
                }
            }
        }

        public void RaktarGrafKiir()
        {
            Console.Clear();
            string kiir = "";
            for (int i = 0; i < raktarButorokkal.GetLength(0); i++)
            {
                for (int j = 0; j < raktarButorokkal.GetLength(1); j++)
                {
                    kiir += raktarButorokkal[i, j].ToString();
                }
                kiir += "\n";
            }
            Console.WriteLine(kiir);
        }

        public delegate void UjHelyEventHandler(object source, ButorEventArgs args);
        public event UjHelyEventHandler UjHely;
        protected virtual void OnUjHely(int sorozatszam, string koordinata)
        {
            if (UjHely != null)
                UjHely(this, new ButorEventArgs() { SorozatSzam = sorozatszam , BalfFelsoKoordinata = koordinata});
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
