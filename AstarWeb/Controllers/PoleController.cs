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
                Pola.Add(new PoleModel { Id = i, Osiagalny = true }) ;

                if(i==10) Pola[i].StartKon = 's';
                else if(i==38) Pola[i].StartKon = 'k';
                else if(i>20 && i<30) Pola[i].Osiagalny = false;
            }
            
            return View(Pola);
        }
    }
}
