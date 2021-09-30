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
                Pola.Add(new PoleModel { Id = i, Rodzic=0, G=1000, H=1000, StartKon='n', Osiagalny = false, X=i%DlugoscSiatki,Y=i%DlugoscSiatki }) ;
                else if(i==3)
                {
                Pola.Add(new PoleModel { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 's', Osiagalny = true, X = i % DlugoscSiatki, Y = i % DlugoscSiatki });
                }
                else if (i == 56)
                {
                    Pola.Add(new PoleModel { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 'k', Osiagalny = true, X = i % DlugoscSiatki, Y = i % DlugoscSiatki });
                }
                else
                {
                    Pola.Add(new PoleModel { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 'n', Osiagalny = true, X = i % DlugoscSiatki, Y = i % DlugoscSiatki });
                }

            }

            return View(Pola);
        }

        int[] PrzyleglePola(int[] PolaPrzejrzane)
        {
            int[] PolaNieodwiedzone=new int[DlugoscSiatki* DlugoscSiatki];
            for (int i = 0; i < PolaPrzejrzane.Length; i++)
            {
                if (Pola[PolaPrzejrzane[i]].X % DlugoscSiatki==1)//lewy bok
                {

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

        public IActionResult HandleButtonClick( PoleModel PoleS, PoleModel PoleK)
        {
            int[] PolaPrzejrzane=new int[] {PoleS.Id };
            //int[] PolaNieodwiedzone=new int[DlugoscSiatki * DlugoscSiatki]; // Zbiór wierzchołków nieodwiedzonych, sąsiadujących z odwiedzonymi.
            //int[] PolaNieodwiedzone = new int[] { PoleS.Id - DlugoscSiatki, PoleS.Id + DlugoscSiatki, PoleS.Id + 1, PoleS.Id -1, PoleS.Id - DlugoscSiatki-1, PoleS.Id - DlugoscSiatki+1, PoleS.Id + DlugoscSiatki - 1, PoleS.Id + DlugoscSiatki +1};
            double najnizszeF = double.PositiveInfinity;

            

            while (PolaNieodwiedzone !=null)
            {
                for (int i = 0; i < PolaNieodwiedzone.Length; i++)
                {
                    //Pola[i].G=
                    //Pola[i].H=
                

                    if(Pola[PolaNieodwiedzone[i]].G + Pola[PolaNieodwiedzone[i]].H < najnizszeF)//wybranie wierzchołka ze zbioru PolaNieodwiedzone o najniższym F
                    {
                        najnizszeF = i;
                        if (i==PoleK.Id)
                        {
                            return View("Pole");
                        }
                    }
                    
                }
                return View("Pole");
            }
            return View("Pole");

        }

        












    }
}
