using AstarWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstarWeb.Controllers
{
    public class PoleController : Controller
    {
        int DlugoscSiatki=10;
        static List<PoleModel> Pola = new List<PoleModel>();
        public IActionResult Pole()
        {
            for (int i = 1; i <= DlugoscSiatki*DlugoscSiatki; i++)
            {
                if(i>10 && i<17)
                Pola.Add(new PoleModel(i,0,0,0,DlugoscSiatki) { StartKon='n', Osiagalny = false }) ;
                else if(i==3)
                {
                Pola.Add(new PoleModel(i, 0, 0, 0, DlugoscSiatki) { StartKon = 's', Osiagalny = true });
                }
                else if (i == 56)
                {
                    Pola.Add(new PoleModel(i, 0, 0, 0, DlugoscSiatki) { StartKon = 'k', Osiagalny = true });
                }
                else
                {
                    Pola.Add(new PoleModel(i, 0, 0, 0, DlugoscSiatki) { StartKon = 'n', Osiagalny = true });
                }

            }

            return View(Pola);
        }






        public IActionResult HandleButtonClick(PoleModel PoleS, PoleModel PoleK)
        {
            // tablice przechowują pola
            List<PoleModel> PolaPrzejrzane = new List<PoleModel>(new[] { PoleS });
            List<PoleModel> PolaNieodwiedzoneSasiadujace = new List<PoleModel>();  // Zbiór wierzchołków nieodwiedzonych, sąsiadujących z odwiedzonymi. 

            PoleModel poleNajnizszeF = null; // przechowuje pole z najniższym F



            while (PolaNieodwiedzoneSasiadujace != null)
            {
                for (int i = 0; i < PolaNieodwiedzoneSasiadujace.Count; i++)
                {
                    if (i == 0)
                    {
                        poleNajnizszeF = PolaNieodwiedzoneSasiadujace[i];

                    }
                    else
                    {
                        if (PolaNieodwiedzoneSasiadujace[i].G + PolaNieodwiedzoneSasiadujace[i].H < (poleNajnizszeF.G + poleNajnizszeF.H))//wybranie wierzchołka ze zbioru PolaNieodwiedzoneSasiadujace o najniższym F 

                            poleNajnizszeF = PolaNieodwiedzoneSasiadujace[i];
                    }
                    //sprawdzenie czy to węzęł końcowy
                    if (PolaNieodwiedzoneSasiadujace[i].Id == PoleK.Id)
                    {
                        return View("Pole");
                    }

                    // usunięcie nowo sprawdzonego elementu z tablicy PolaNieodwiedzoneSasiadujace (zmienia Id pola na 0)
                    PolaNieodwiedzoneSasiadujace.Remove(PolaNieodwiedzoneSasiadujace[i]);

                    // dodanie nowo sprawdzonego elementu do tablicy PolaPrzejrzane
                    PolaPrzejrzane.Add(PolaNieodwiedzoneSasiadujace[i]);//dodajemy obiekt

                    //przeszukujemy pola sąsiadujące z polem "poleNajnizszeF"
                    for (int j = 0; j < poleNajnizszeF.PolaSasiadujace.Count; j++)
                    {
                        //sprawdzenie czy danego pola nie ma w tablicy PolaPrzejrzane
                        for (int k = 0; k < PolaPrzejrzane.Count; k++)
                        {
                            if (!(PolaPrzejrzane[k].Id == poleNajnizszeF.PolaSasiadujace[j]))
                            {
                                int tempG = PolaNieodwiedzoneSasiadujace[i].G + 10;//trzeba dodać czy po skosie !!!

                                // jeżeli pole jest w tablicy PolaNieodwiedzoneSasiadujace to sprawdź czy nie dostaniesz się tam szybciej
                                for (int l = 0; l < PolaNieodwiedzoneSasiadujace.Count; l++)
                                {
                                    if (PolaNieodwiedzoneSasiadujace[l].Id == Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Id)
                                    {
                                        if (tempG < Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G)
                                        {
                                            Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                        }
                                    }
                                    else // jeżeli nie ma w tab PolaNieodwiedzoneSasiadujace to dodaj iprzypisz tempG do G
                                    {
                                        Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                        PolaNieodwiedzoneSasiadujace.Add(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1]);
                                    }
                                    // dodajemy heurystykę czyli oszacowaną odl z badanego pkt sąsiadującego do końca 
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H = heurystyka(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1], PoleK);

                                }
                                
                                
                            }

                        }




                    }
                    return View("Pole");
                }
                return View("Pole");

            }

            static int heurystyka(PoleModel pkt, PoleModel koniec)
            {
                int a = koniec.X - pkt.X;
                int b = koniec.Y - pkt.Y;
                int H = (int)Math.Sqrt( (a * a) + (b * b));
                return H;
            }

            /*
            PoleModel[] PolaPrzylegle(PoleModel Obiekt ,int DlugoscSiatki)
            {
                if (Obiekt.X % DlugoscSiatki == 1)//lewy bok
                {
                    if (Obiekt.X == 1 && Obiekt.Y == 1) // lewy górny róg
                    {
                        Obiekt.PolaSasiadujace = (PoleModel[])Obiekt.PolaSasiadujace.Append(Obiekt.Id + DlugoscSiatki);
                        Obiekt.PolaSasiadujace = (int[])PolaSasiadujace.Append(Obiekt.Id + DlugoscSiatki + 1);
                        Obiekt.PolaSasiadujace = (int[])PolaSasiadujace.Append(Obiekt.Id + 1);

                        //return PolaSasiadujace;
                    }

                    else if (Obiekt.X == 1 && Obiekt.Y == DlugoscSiatki) // lewy górny róg
                    {
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);

                        //return PolaSasiadujace;
                    }

                    else
                    {
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki + 1);

                        //return PolaSasiadujace;
                    }
                }
                else if (Obiekt.X % DlugoscSiatki == 0)//prawy bok
                {
                    if (Obiekt.X == DlugoscSiatki && Obiekt.Y == 1)// prawy górny róg
                    {
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);

                        //return PolaSasiadujace;
                    }

                    else if (Obiekt.X == DlugoscSiatki && Obiekt.Y == DlugoscSiatki) // prawy dolny róg
                    {
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);

                        //return PolaSasiadujace;
                    }

                    else
                    {
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                        PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);

                        //return PolaSasiadujace;
                    }
                }
                else if (Obiekt.Y % DlugoscSiatki == 1)//góra
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);

                    //return PolaSasiadujace;
                }
                else if (Obiekt.Y % DlugoscSiatki == 0)//dół
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);

                    //return PolaSasiadujace;
                }
                else
                {

                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki + 1);

                    //return PolaSasiadujace;
                }

            }
            */





        }

    }
}
