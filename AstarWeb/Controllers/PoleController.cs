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
                if (i > 10 && i < 17)
                    Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'n', Osiagalny = false });
                else if (i == 3)
                {
                    Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 's', Osiagalny = true });
                }
                else if (i == 56)
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


        public void HandleButtonClick()
        {
            Algorytm(Pola[3], Pola[56]);
            //return View("Pole");
        }


        //////////////////////////////           ALGORYTM       //////////////////////////////
        public IActionResult Algorytm(PoleModel PoleS, PoleModel PoleK)
        {
            // tablice przechowują pola
            List<PoleModel> PolaNieodwiedzoneSasiadujace = new(new[] { PoleS });  // Zbiór wierzchołków nieodwiedzonych, sąsiadujących z odwiedzonymi. 
            List<PoleModel> PolaPrzejrzane = new(); 
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
                        ViewBag.Sciezka=RekonstrukcjaSciezki(PoleS, PoleK);
                        return View("Pole");
                    
                    }

                    // dodanie nowo sprawdzonego elementu do tablicy PolaPrzejrzane
                    PolaPrzejrzane.Add(PolaNieodwiedzoneSasiadujace[i]);//dodajemy obiekt

                    // usunięcie nowo sprawdzonego elementu z tablicy PolaNieodwiedzoneSasiadujace (zmienia Id pola na 0)
                    PolaNieodwiedzoneSasiadujace.Remove(PolaNieodwiedzoneSasiadujace[i]);

               

                    //przeszukujemy pola sąsiadujące z polem "poleNajnizszeF"
                    for (int j = 0; j < poleNajnizszeF.PolaSasiadujace.Count; j++)
                    {
   /* Do poprawy */           //sprawdzenie czy danego pola sąsiadującego nie ma w tablicy PolaPrzejrzane
                        for (int k = 0; k < PolaPrzejrzane.Count; k++)
                        {
    /* Do poprawy  */
                            if (!(PolaPrzejrzane[k].Id == poleNajnizszeF.PolaSasiadujace[j]))
                            {   //trzeba dodać czy po skosie !!!                              
                                
                                  int tempG =  poleNajnizszeF.G + 10;

                                // jeżeli pole sąsiadujące jest w tablicy PolaNieodwiedzoneSasiadujace to sprawdź czy nie dostaniesz się tam szybciej                              
                                if (!(PolaNieodwiedzoneSasiadujace.Count==0))
                                {
                                    bool zawiera = false;  // zmienna pomocnicza
                                    for (int l = 0; l < PolaNieodwiedzoneSasiadujace.Count; l++)
                                    {
                                        if (PolaNieodwiedzoneSasiadujace[l].Id == Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Id)
                                        {   // jeżeli można się dostać szybciej to zapisz to
                                            if (tempG < Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G)
                                            {
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Rodzic = poleNajnizszeF;
                                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].F = Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G + Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H;
                                            }
                                            // jeżeli  pole sąsiadujące jest w tablicy PolaNieodwiedzoneSasiadujace to zapisz to do zmiennej pomocniczej
                                            zawiera = true;
                                        }
                                    }
                                    if (zawiera !=true)// jeżeli nie ma w tab PolaNieodwiedzoneSasiadujace to dodaj i przypisz tempG do G
                                    {
                                        Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                        PolaNieodwiedzoneSasiadujace.Add(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1]);
                                        Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Rodzic = poleNajnizszeF;
                                        Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].F = Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G + Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H;
                                    }

                                }
                                else // jeżeli nie ma w tab PolaNieodwiedzoneSasiadujace (nie na żadnych elementów w tablicy) to dodaj i przypisz tempG do G
                                {
                                            Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G = tempG;
                                            PolaNieodwiedzoneSasiadujace.Add(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1]);
                                            Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].Rodzic = poleNajnizszeF;
                                            Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].F = Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].G + Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H;
                                }

                                // dodajemy heurystykę czyli oszacowaną odl z badanego pkt sąsiadującego do końca 
                                Pola[poleNajnizszeF.PolaSasiadujace[j] - 1].H = Heurystyka(Pola[poleNajnizszeF.PolaSasiadujace[j] - 1], PoleK);




                            }
                        }
                    }
                }
            }
            return View("Error"); //error !!!
        }


        /////////////////////////////         FUNKCJE            //////////////////////////
 
        public static int Heurystyka(PoleModel pkt, PoleModel koniec)
        {
            int a = koniec.X - pkt.X;
            int b = koniec.Y - pkt.Y;
            int H = (int)Math.Sqrt((a * a) + (b * b));
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
