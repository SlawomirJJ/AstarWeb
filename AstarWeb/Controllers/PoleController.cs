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
                Pola.Add(new PoleModel(100) { Id = i, Rodzic=0, G=1000, H=1000, StartKon='n', Osiagalny = false, X=i%DlugoscSiatki,Y=i%DlugoscSiatki,}) ;
                else if(i==3)
                {
                Pola.Add(new PoleModel(100) { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 's', Osiagalny = true, X = i % DlugoscSiatki, Y = i % DlugoscSiatki });
                }
                else if (i == 56)
                {
                    Pola.Add(new PoleModel(100) { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 'k', Osiagalny = true, X = i % DlugoscSiatki, Y = i % DlugoscSiatki });
                }
                else
                {
                    Pola.Add(new PoleModel(100) { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 'n', Osiagalny = true, X = i % DlugoscSiatki, Y = i % DlugoscSiatki });
                }

            }

            return View(Pola);
        }
        /*
        int[] PrzyleglePola(int[] PolaPrzejrzane)
        {
            int[] PolaNieodwiedzone=new int[DlugoscSiatki* DlugoscSiatki];
            for (int i = 0; i < PolaPrzejrzane.Length; i++)
            {
                if (Pola[PolaPrzejrzane[i]].X % DlugoscSiatki==1)//lewy bok
                {
                    if(Pola[PolaPrzejrzane[i]].X ==1)
                    {

                    }
                }
                else if (Pola[PolaPrzejrzane[i]].X % DlugoscSiatki == 0)//prawy bok
                {
                    
                }
                else if (Pola[PolaPrzejrzane[i]].Y % DlugoscSiatki == 1)//góra
                {

                }
                else if (Pola[PolaPrzejrzane[i]].Y % DlugoscSiatki == 0)//dół
                {

                }
                else
                {
                    //int[] NowePolaNieodwiedzone = new int[] { i - DlugoscSiatki, i + DlugoscSiatki, i + 1, i - 1, i - DlugoscSiatki - 1, i - DlugoscSiatki + 1, i + DlugoscSiatki - 1, i + DlugoscSiatki + 1 };

                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i - DlugoscSiatki);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i + DlugoscSiatki);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i + 1);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i - 1);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i - DlugoscSiatki - 1);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i - DlugoscSiatki + 1);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i + DlugoscSiatki - 1);
                    PolaNieodwiedzone = (int[])PolaNieodwiedzone.Append(i + DlugoscSiatki + 1);
                }
                

            }

            return PolaNieodwiedzone;
        }
        */
        public IActionResult HandleButtonClick( PoleModel PoleS, PoleModel PoleK)
        {
            // tablice przechowują Id pól
            PoleModel[] PolaPrzejrzane=new PoleModel[] {PoleS };
            PoleModel[] PolaNieodwiedzoneSasiadujace=new PoleModel[DlugoscSiatki * DlugoscSiatki]; // Zbiór wierzchołków nieodwiedzonych, sąsiadujących z odwiedzonymi.
            
            //double najnizszeF = double.PositiveInfinity; // przechowuje najniższe F
            PoleModel poleNajnizszeF=null ; // przechowuje Id pola z najniższym F
            
            

            while (PolaNieodwiedzoneSasiadujace != null)
            {
                for (int i = 0; i < PolaNieodwiedzoneSasiadujace.Length; i++)
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
                    Array.Clear(PolaNieodwiedzoneSasiadujace, i-1, 1);

                    // dodanie nowo sprawdzonego elementu do tablicy PolaPrzejrzane
                    PolaPrzejrzane = (PoleModel[])PolaPrzejrzane.Append(PolaNieodwiedzoneSasiadujace[i]);//dodajemy obiekt

                    //przeszukujemy pola sąsiadujące z poleNajnizszeF
                    for (int j = 0; j < poleNajnizszeF.GetPolaSasiadujace().Length; j++)
                        {
                        //sprawdzenie czy danego pola nie ma w tablicy PolaPrzejrzane
                        for (int k = 0; k < PolaPrzejrzane.Length; k++)
                        {
                            int[] TablicaSasiadow = poleNajnizszeF.GetPolaSasiadujace();
                            if (PolaPrzejrzane[k].Id== TablicaSasiadow[k]) { }
                        }
                        }
                        
                    

                }
                return View("Pole");
            }
            return View("Pole");

        }

        












    }
}
