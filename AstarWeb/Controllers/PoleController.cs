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
        static List<PoleModel> Pola = new List<PoleModel>();
        public IActionResult Pole()
        {
            for (int i = 1; i <= 100; i++)
            {
                if(i>10 && i<17)
                Pola.Add(new PoleModel { Id = i, Rodzic=0, G=1000, H=1000, StartKon='n', Osiagalny = false }) ;
                else if(i==3)
                {
                Pola.Add(new PoleModel { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 's', Osiagalny = true });
                }
                else if (i == 56)
                {
                    Pola.Add(new PoleModel { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 'k', Osiagalny = true });
                }
                else
                {
                    Pola.Add(new PoleModel { Id = i, Rodzic = 0, G = 1000, H = 1000, StartKon = 'n', Osiagalny = true });
                }

            }

            return View(Pola);
        }
    }
}
