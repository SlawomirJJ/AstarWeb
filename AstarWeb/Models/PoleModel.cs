using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstarWeb.Models
{
    public class PoleModel
    {
        public int Id { get; set; }
        //public bool Otwarty { get; set; } //otwarty czy zamknięty (wokable)
        public int Rodzic { get; set; }
        public int G { get; set; } //droga po między wierzchołkiem początkowym a x(tym)
        public int H { get; set; } //przewidywana przez heurystykę droga od x do wierzchołka docelowego
       // public int F { get; set; } //funkcja F(x)=g(x)+h(x)
        public char StartKon { get; set; }// "s"-startowy "k"-koncowy "n" -nie

        public bool Osiagalny { get; set; } //"o"-osiągalny "n"-nie osiągalny (wokable)



    }
}
