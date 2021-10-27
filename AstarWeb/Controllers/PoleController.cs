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
        int DlugoscSiatki = 10;
        static List<PoleModel> Pola = new List<PoleModel>();
        
        public IActionResult Pole()
        {
            for (int i = 1; i <= DlugoscSiatki * DlugoscSiatki; i++)
            {
                ViewBag.Sciezka = null;
             /*   if (i > 10 && i < 17)
                    Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'n', Osiagalny = false });
                else */ if (i == 3)
                {
                    Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 's', Osiagalny = true });
                }
                else if (i == 50)
                {
                    Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'k', Osiagalny = true });
                }
                else
                {
                    Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'n', Osiagalny = true });
                }

            }

            return View(Pola);
        }


        public IActionResult HandleButtonClick()
        {   // Odejmujemy 1 bo bo id(zmienna wyżej "i") jest większe o 1
            Algorytm(Pola[3-1], Pola[50-1]);
            return View("Pole",Pola);
        }


        //////////////////////////////           ALGORYTM       //////////////////////////////
        public IActionResult Algorytm(PoleModel PoleS, PoleModel PoleK)
        {
            // tablice przechowują pola
            List<PoleModel> PolaNieodwiedzoneSasiadujace = new(new[] { PoleS });  // Zbiór wierzchołków nieodwiedzonych, sąsiadujących z odwiedzonymi. 
            List<PoleModel> PolaPrzejrzane = new(); 
            PoleModel poleNajnizszeF = null; // przechowuje pole z najniższym F


            while (PolaNieodwiedzoneSasiadujace != null)
            {   // wybranie wierzchołka ze zbioru PolaNieodwiedzoneSasiadujace o najniższym F 
                for (int i = 0; i < PolaNieodwiedzoneSasiadujace.Count; i++)
                {
                    if (i==0)
                    {
                        poleNajnizszeF = PolaNieodwiedzoneSasiadujace[0];
                    }
                    else if(PolaNieodwiedzoneSasiadujace[i].F < poleNajnizszeF.F)
                    {
                        poleNajnizszeF = PolaNieodwiedzoneSasiadujace[i];
                    }
                }       
                    
                        
                    
                    //sprawdzenie czy to węzęł końcowy
                    if (poleNajnizszeF.Id == PoleK.Id)
                    {
                        ViewBag.Sciezka=RekonstrukcjaSciezki(PoleS, PoleK);
                        //break;
                        return View("Pole",Pola);
                    
                    }

                    // dodanie nowo sprawdzonego elementu do tablicy PolaPrzejrzane
                    PolaPrzejrzane.Add(poleNajnizszeF);//dodajemy obiekt

                    // usunięcie nowo sprawdzonego elementu z tablicy PolaNieodwiedzoneSasiadujace (zmienia Id pola na 0)
                    PolaNieodwiedzoneSasiadujace.Remove(poleNajnizszeF);

               

                    //przeszukujemy pola sąsiadujące z polem "poleNajnizszeF"
                    for (int j = 0; j < poleNajnizszeF.PolaSasiadujace.Count; j++)
                    {
                     // sprawdzenie czy danego pola sąsiadującego nie ma w tablicy PolaPrzejrzane
                            if (!(PolaPrzejrzane.Exists(x => x.Id == poleNajnizszeF.PolaSasiadujace[j])))
                            {
                               int tempG = 0;        // prawo, lewo, góra, dół
                                if (poleNajnizszeF.Id+1== poleNajnizszeF.PolaSasiadujace[j] || poleNajnizszeF.Id - 1 == poleNajnizszeF.PolaSasiadujace[j] || poleNajnizszeF.Id + DlugoscSiatki == poleNajnizszeF.PolaSasiadujace[j] || poleNajnizszeF.Id - DlugoscSiatki == poleNajnizszeF.PolaSasiadujace[j])
                                {
                                    tempG = poleNajnizszeF.G + 10;
                                }
                                else // po skosie
                                {
                                    tempG = poleNajnizszeF.G + 14;
                                }
                                    

                                // jeżeli pole sąsiadujące jest w tablicy PolaNieodwiedzoneSasiadujace to sprawdź czy nie dostaniesz się tam szybciej                              
                                if (!(PolaNieodwiedzoneSasiadujace.Count==0))
                                {
                                    bool zawiera = false;  // zmienna pomocnicza
                                    for (int l = 0; l < PolaNieodwiedzoneSasiadujace.Count; l++)
                                    {
                                    if (PolaNieodwiedzoneSasiadujace[l].Id == poleNajnizszeF.PolaSasiadujace[j])
                                        {   // jeżeli można się dostać szybciej to zapisz to
                                            if (tempG < Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G)
                                            {
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Rodzic = poleNajnizszeF;
                                                // dodajemy heurystykę czyli oszacowaną odl z badanego pkt sąsiadującego do końca 
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H = Heurystyka(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1], PoleK);
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].F = Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G + Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H;
                                            }
                                            // jeżeli  pole sąsiadujące jest w tablicy PolaNieodwiedzoneSasiadujace to zapisz to do zmiennej pomocniczej
                                            zawiera = true;
                                        }
                                    }
                                    if (zawiera !=true)// jeżeli nie ma w tab PolaNieodwiedzoneSasiadujace to dodaj i przypisz tempG do G
                                    {
                                        Pola[(poleNajnizszeF.PolaSasiadujace[j]) - 1].G = tempG;
                                        PolaNieodwiedzoneSasiadujace.Add(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1]);
                                        Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Rodzic = poleNajnizszeF;
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H = Heurystyka(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1], PoleK);
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].F = Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G + Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H;
                                    }

                                }
                                else // jeżeli nie ma w tab PolaNieodwiedzoneSasiadujace (nie na żadnych elementów w tablicy) to dodaj i przypisz tempG do G
                                {
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                    PolaNieodwiedzoneSasiadujace.Add(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1]);
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Rodzic = poleNajnizszeF; 
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H = Heurystyka(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1], PoleK);
                                    Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].F = Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G + Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H;
                                }

                                




                            }
                        
                    }
                
            }
            return View("Error"); //error !!!
        }


        /////////////////////////////         FUNKCJE            ////////////////////

        public static int Heurystyka(PoleModel pkt, PoleModel koniec)
        {
            int a = koniec.X - pkt.X;
            int b = koniec.Y - pkt.Y;
            int H = (int)(10 * (Math.Sqrt((a * a) + (b * b))));
            return H;
        }

        public static List<PoleModel> Sciezka = new();
        public static List<PoleModel> RekonstrukcjaSciezki(PoleModel PunktStartowy, PoleModel PunktKoncowy)
        {
            
            while (PunktKoncowy != PunktStartowy)
            {
                Sciezka.Add(PunktKoncowy.Rodzic);
                PunktKoncowy = PunktKoncowy.Rodzic;
            }
            return Sciezka; 
        }




    }
}
