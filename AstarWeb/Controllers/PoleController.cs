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
                Pola.Add(new PoleModel { Id = i, Otwarty=true }) ;
            }
            
            return View(Pola);
        }
    }
}
