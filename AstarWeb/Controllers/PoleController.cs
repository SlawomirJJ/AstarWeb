using AstarWeb.Models;
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
        const int DLUGOSC_SIATKI=10;
        int DlugoscSiatki;
        static List<PoleModel> Pola = new List<PoleModel>();
        PoleModel start;
        PoleModel koniec;
        static List<PoleModel> Sciezka = new List<PoleModel>();

        public IActionResult Pole()
        {
            Pola.Clear();
            if (DlugoscSiatki==0 )
            {
                for (int i = 1; i <= DLUGOSC_SIATKI * DLUGOSC_SIATKI; i++)
                {/*
                    if (i == start)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DLUGOSC_SIATKI) { StartKon = 's', Osiagalny = true });
                    }
                    else if (i == koniec)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DLUGOSC_SIATKI) { StartKon = 'k', Osiagalny = true });
                    }
                    else */

                    //{
                        Pola.Add(new PoleModel(i, 0, 0, DLUGOSC_SIATKI) { StartKon = 'n', Osiagalny = true });
                    //}

                }
            }
            else 
            {
                for (int i = 1; i <= DlugoscSiatki * DlugoscSiatki; i++)
                {/*
                    if (i == start)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 's', Osiagalny = true });
                    }
                    else if (i == koniec)
                    {
                        Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'k', Osiagalny = true });
                    }
                    else */
                    //{
                        Pola.Add(new PoleModel(i, 0, 0, DlugoscSiatki) { StartKon = 'n', Osiagalny = true });
                    //}

                }
            }
            

            return View(Pola);
        }


        /////////////////////////////////////      PRZYCISKI        //////////////////////////////
       
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

 


        public IActionResult PoleStart(int StartId)
        {
            
            Pola.ElementAt(StartId - 1).StartKon = 's';
            //start = StartId;
            return PartialView("PoleStart", Pola.ElementAt(StartId - 1));
        }

        public IActionResult PoleKoniec(int KoniecId)
        {
            Pola.ElementAt(KoniecId - 1).StartKon = 'k';
            //koniec = KoniecId;
            return PartialView("PoleKoniec", Pola.ElementAt(KoniecId - 1));
        }
        public IActionResult Rozmiar(int Rozmiar)
        {
            Pola.Clear();
            for (int i = 1; i <= Rozmiar * Rozmiar; i++)
            {
                Pola.Add(new PoleModel(i, 0, 0, Rozmiar) { StartKon = 'n', Osiagalny = true });
            }
            DlugoscSiatki = Rozmiar;
            ViewBag.DlugoscSiatki = Rozmiar;
            return PartialView("Rozmiar", Pola);
        }

        public IActionResult DodaniePrzeszkod()
        {
            var rand = new Random();
            for (int j = 0; j < Pola.Count; j++)
            {
                if (Pola.ElementAt(j).StartKon == 's')
                {
                    start = Pola.ElementAt(j);
                }
                else if (Pola.ElementAt(j).StartKon == 'k')
                {
                    koniec = Pola.ElementAt(j);
                }
            }
            DlugoscSiatki = (int)Math.Sqrt(Pola.Count);
            for (int i = 0; i < ((DlugoscSiatki * DlugoscSiatki) / 5); i++)
                {
                    int Nrprzeszkody = rand.Next(1, DlugoscSiatki * DlugoscSiatki);
                    for (int j = 0; j < Pola.Count; j++)
                    {
                        if (Pola.ElementAt(j).StartKon == 's')
                        {
                            start = Pola.ElementAt(j);
                        }
                        else if (Pola.ElementAt(j).StartKon == 'k')
                        {
                            koniec = Pola.ElementAt(j);
                        }
                    }
                    if (start == null || koniec == null)
                    {
                        Pola[Nrprzeszkody].Osiagalny = false;
                    }
                    else if (Nrprzeszkody != start.Id - 1 && Nrprzeszkody != koniec.Id - 1)
                    {
                        Pola[Nrprzeszkody].Osiagalny = false;
                    }
                }
            //}
            return PartialView("DodaniePrzeszkod", Pola);
        }

        public IActionResult WyznaczenieTrasy()
        {
            {
                for (int i = 0; i < Pola.Count; i++)
                {
                    if (Pola.ElementAt(i).StartKon=='s')
                    {
                        start = Pola.ElementAt(i);
                    }
                    else if (Pola.ElementAt(i).StartKon == 'k')
                    {
                        koniec = Pola.ElementAt(i);
                    }
                }
                Sciezka.Clear();
                ViewBag.Sciezka = null;
                ViewBag.Sciezka= Algorytm(start, koniec);
                if (Sciezka.Count == 0)// Zwróć wiadomość że nie ma drogi
                {
                    return PartialView("Error");
                }
                return PartialView("WyznaczenieTrasy", Pola);
            }
        }


        //////////////////////////////           ALGORYTM       //////////////////////////////
        public List<PoleModel> Algorytm(PoleModel PoleS, PoleModel PoleK)
        {
            // tablice przechowują pola
            List<PoleModel> PolaNieodwiedzoneSasiadujace = new(new[] { PoleS });  // Zbiór wierzchołków nieodwiedzonych, sąsiadujących z odwiedzonymi. 
            List<PoleModel> PolaPrzejrzane = new(); 
            PoleModel poleNajnizszeF = null; // przechowuje pole z najniższym F
            DlugoscSiatki = (int)Math.Sqrt(Pola.Count);
            //Sciezka


            while (PolaNieodwiedzoneSasiadujace.Count != 0)
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
                    return  RekonstrukcjaSciezki(PoleS, PoleK);
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
                        else if(HaveNeighbourObstacle(poleNajnizszeF.Id, poleNajnizszeF.PolaSasiadujace[j]) ==true) // po skosie, czy nie ma sąsiada przeszkody
                        {
                            continue;
                        }
                        else
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
                            if (zawiera != true)// jeżeli nie ma w tab PolaNieodwiedzoneSasiadujace to dodaj i przypisz tempG do G
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
            return Sciezka;//Sciezka;
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
            //List<PoleModel> Sciezka = new(new[] { PunktKoncowy });
            Sciezka.Add(PunktKoncowy);
            while (PunktKoncowy != PunktStartowy)
            {
                try
                {
                    Sciezka.Add(PunktKoncowy.Rodzic);
                    PunktKoncowy = PunktKoncowy.Rodzic;
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            return Sciezka;
        }

        public static bool HaveNeighbourObstacle(int Id1, int Id2)
        {
            PoleModel PolePoSkosie = null;
            PoleModel PolePierwotne = null;
            PoleModel PoleWspolne = null;
            bool CzyPrzeszkoda = false;
            for (int i = 0; i < Pola.Count; i++)
            {

                if (Pola[i].Id == Id2)
                {
                    PolePoSkosie = Pola[i];
                }
                else if (Pola[i].Id == Id1)
                {
                    PolePierwotne = Pola[i];
                }
            }
            for (int i = 0; i < PolePierwotne.PolaSasiadujace.Count; i++)
            {
                for (int j = 0; j < PolePoSkosie.PolaSasiadujace.Count; j++)
                {


                    if (PolePierwotne.PolaSasiadujace[i] == PolePoSkosie.PolaSasiadujace[j])
                    {
                        for (int m = 0; m < Pola.Count; m++)
                        {
                            if (Pola[m].Id == PolePoSkosie.PolaSasiadujace[j])
                            {
                                PoleWspolne = Pola[m];
                                if (PoleWspolne.Osiagalny == false)
                                {
                                    CzyPrzeszkoda=true;                                   
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return CzyPrzeszkoda;
        }






    }
}
