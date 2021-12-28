﻿using AstarWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AstarWeb.Controllers
{
    public class PoleController : Controller
    {
        // mpublic bool flaga;
        const int DLUGOSC_SIATKI=10;
        int DlugoscSiatki;
        static List<PoleModel> Pola = new List<PoleModel>();
        int start = 1;
        int koniec = 91;

        public IActionResult Pole()
        {
            Pola.Clear();
            if (DlugoscSiatki==0 )
            {
                for (int i = 1; i <= DLUGOSC_SIATKI * DLUGOSC_SIATKI; i++)
                {
                    if (i == start)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DLUGOSC_SIATKI) { StartKon = 's', Osiagalny = true });
                    }
                    else if (i == koniec)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DLUGOSC_SIATKI) { StartKon = 'k', Osiagalny = true });
                    }
                    else
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DLUGOSC_SIATKI) { StartKon = 'n', Osiagalny = true });
                    }

                }
            }
            else 
            {
                for (int i = 1; i <= DlugoscSiatki * DlugoscSiatki; i++)
                {
                    if (i == start)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 's', Osiagalny = true });
                    }
                    else if (i == koniec)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'k', Osiagalny = true });
                    }
                    else
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'n', Osiagalny = true });
                    }

                }
            }
            

            return View(Pola);
        }


        /////////////////////////////////////      PRZYCISKI        //////////////////////////////
        
        public IActionResult HandleButtonClickWyznaczenieTrasy()
        {   // Odejmujemy 1 bo id(zmienna wyżej "i") jest większe o 1
            Algorytm(Pola[start-1], Pola[koniec-1]);
            return View("Pole",Pola);
        }

        public IActionResult HandleButtonClickPrzeszkody()
        {
            var rand = new Random();
            for (int i = 0; i < rand.Next(1, (DlugoscSiatki* DlugoscSiatki)/2); i++)
            {
                int Nrprzeszkody=rand.Next(1, DlugoscSiatki * DlugoscSiatki);
                if (Nrprzeszkody != start && Nrprzeszkody != koniec)
                {
                    Pola[Nrprzeszkody].Osiagalny = false;
                }

                
            }
            
            return  View("Pole", Pola);
        }

        public IActionResult HandleButtonClickReset()
        {
            for (int i = 0; i < DlugoscSiatki*DlugoscSiatki; i++)
            {
                Pola[i].Osiagalny = true;
            }
            ViewBag.Sciezka = null;
            Pole();
            return View("Pole");
        }

 
        public IActionResult PobierzDlsiatki(int Dl)
        {
            DlugoscSiatki = Dl;
            ViewBag.DlugoscSiatki = Dl;
            //return View("Pole", Pola);
            Pole();
            return View("Pole");
        }

        public IActionResult PoleStart(int poleId)
        {
            Pola.ElementAt(poleId - 1).StartKon = 's';
            return PartialView("PoleStart", Pola.ElementAt(poleId - 1));
        }

        /*
                public IActionResult PoleStart(int poleId)
                {
                    string PoleNaCzarneString=null;
                    for (int i = 0; i < Pola.Count; i++)
                    {
                        if (Pola.ElementAt(i).StartKon == 's')
                        {
                            Pola.ElementAt(i).StartKon = 'n';
                            //return PartialView(Pola.ElementAt(i));
                            PoleNaCzarneString = RenderRazorViewToString(this, "PoleCzarne", Pola.ElementAt(i));
                        }
                    }

                    Pola.ElementAt(poleId -1).StartKon = 's';
                    string PoleNaZieloneString = RenderRazorViewToString(this, "PoleStart", Pola.ElementAt(poleId - 1));

                    var package = new { part1 = PoleNaCzarneString, part2 = PoleNaZieloneString,  };
                    return Json(package);
                }

                public static string RenderRazorViewToString(Controller controller, string viewName, object model=null)
                {
                    controller.ViewData.Model = model;
                    using(var sw=new StringWriter())
                    {
                        IViewEngine viewEngine = controller.HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                        ViewEngineResult viewResult = viewEngine.FindView(controller.ControllerContext, viewName, false);

                        ViewContext viewContext = new ViewContext(
                            controller.ControllerContext,
                            viewResult.View,
                            controller.ViewData,
                            controller.TempData,
                            sw,
                            new HtmlHelperOptions()
                            );
                        viewResult.View.RenderAsync(viewContext);
                        return sw.GetStringBuilder().ToString();
                    }
                }
        */

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
                        break;
                        //return View("Pole",Pola);
                    
                    }

                    // dodanie nowo sprawdzonego elementu do tablicy PolaPrzejrzane
                    PolaPrzejrzane.Add(poleNajnizszeF);//dodajemy obiekt

                    // usunięcie nowo sprawdzonego elementu z tablicy PolaNieodwiedzoneSasiadujace 
                    PolaNieodwiedzoneSasiadujace.Remove(poleNajnizszeF);               

                    //przeszukujemy pola sąsiadujące z polem "poleNajnizszeF"
                    for (int j = 0; j < poleNajnizszeF.PolaSasiadujace.Count; j++)
                    {
                     // sprawdzenie czy danego pola sąsiadującego nie ma w tablicy PolaPrzejrzanec
                            if (!(PolaPrzejrzane.Exists(x => x.Id == poleNajnizszeF.PolaSasiadujace[j])) &&  Pola[poleNajnizszeF.PolaSasiadujace[j]-1].Osiagalny!=false)
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

        
        public static List<PoleModel> RekonstrukcjaSciezki(PoleModel PunktStartowy, PoleModel PunktKoncowy)
        {
            List<PoleModel> Sciezka = new(new[] { PunktKoncowy });
            while (PunktKoncowy != PunktStartowy)
            {
                Sciezka.Add(PunktKoncowy.Rodzic);
                PunktKoncowy = PunktKoncowy.Rodzic;
            }
            return Sciezka; 
        }




    }
}
