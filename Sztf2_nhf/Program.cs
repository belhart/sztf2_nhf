using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sztf2_nhf
{
    class Program
    {
        static void OnNemFerBeAlap(object source, ButorEventArgs e)
        {
            Console.WriteLine(e.SorozatSzam + ". sorbani butor nem fer be");
        }

        static void OnUjHely(object source, ButorEventArgs e)
        {
            Console.WriteLine(e.SorozatSzam + ". ID butor athelyezve, uj balfselso sarok: " + e.BalfFelsoKoordinata);
        }

        static void Main(string[] args)
        {
            Raktar raktar = new Raktar(50,50,45);
            raktar.lista.NemFerBeAlap += OnNemFerBeAlap;
            raktar.UjHely += OnUjHely;
            Console.WriteLine("Az adatok beolvasasa közbeni problémák:");
            raktar.AdatHelyessegEllenorzes();
            Console.WriteLine("Sikeresen beolvasott butorok");
            raktar.lista.Bejaras();
            raktar.OsszesButorElhelyezeseARaktarban(false);
            Console.WriteLine("Enter a folytatashoz");
            Console.ReadLine();
            bool vege = false;
            while (vege != true)
            {
                Console.Clear();
                Console.WriteLine("Opciók\n\n1. bútorok kilistázása\n2. bútor kihozás\n3. kilépés");
                Console.Write("Választott opció: ");
                string opcio = Console.ReadLine();
                switch (opcio)
                {
                    case "1":
                        Console.Clear();
                        raktar.lista.Bejaras();
                        Console.WriteLine("Enter a folytatashoz");
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Clear();
                        raktar.RaktarGrafKiir();
                        Console.Write("Kihozni kivant butor ID-je: ");
                        int kihozButorId = int.Parse(Console.ReadLine());
                        if (kihozButorId <= 0 || kihozButorId > raktar.lista.DarabElem(raktar.lista))
                        {
                            Console.WriteLine("Az ID-nek nagyobbnak kell lennie mint 0 és kisebb mint " + (raktar.lista.DarabElem(raktar.lista)+1));
                        }
                        else
                        {
                            try
                            {
                                raktar.ButorKihozatal(kihozButorId, raktar);
                            }
                            catch(NincsARaktarbanException e)
                            {
                                Console.WriteLine(e.HibaUzenet);
                            }
                            catch (NincsTobbHelyButornakTeljesRendezesElottException)
                            {
                                raktar.raktarButorokkal = new int[raktar.Szelesseg, raktar.Hosszusag];
                                raktar.OsszesButorElhelyezeseARaktarban(true);
                            }
                            catch (NincsTobbHelyButornakTeljesRendezesUtanException e)
                            {
                                Console.WriteLine(e.HibaUzenet);
                                for (int i = 0; i < e.elemek.DarabElem(e.elemek); i++)
                                {
                                    Console.WriteLine(e.elemek.NthElem(i));
                                }
                            }
                        }
                        Console.WriteLine("Enter a folytatashoz");
                        Console.ReadLine();
                        break;
                    case "3":
                        vege = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
