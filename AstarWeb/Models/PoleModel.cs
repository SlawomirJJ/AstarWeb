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
        public int X { get; set; } //wspóżędna x
        public int Y { get; set; } // wspóżędna y

        private int[] PolaSasiadujace;

        public int[] getPolaSasiadujace(int DlugoscSiatki)
        {
            if (X % DlugoscSiatki == 1)//lewy bok
            {
                if (X == 1 && Y==1) // lewy górny róg
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki +1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id +1);

                    return PolaSasiadujace;
                }

                else if (X==1 && Y==DlugoscSiatki) // lewy górny róg
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);

                    return PolaSasiadujace;
                }

                else 
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki + 1);

                    return PolaSasiadujace;
                }
            }
            else if (X % DlugoscSiatki == 0)//prawy bok
            {
                if (X == DlugoscSiatki && Y == 1)// prawy górny róg
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id -1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki -1);
                    
                    return PolaSasiadujace;
                }

                else if (X == DlugoscSiatki && Y == DlugoscSiatki) // prawy dolny róg
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki -1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);

                    return PolaSasiadujace;
                }

                else
                {
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                    PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);

                    return PolaSasiadujace;
                }
            }
            else if (Y % DlugoscSiatki == 1)//góra
            {
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki + 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);

                return PolaSasiadujace;
            }
            else if (Y % DlugoscSiatki == 0)//dół
            {
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);

                return PolaSasiadujace;
            }
            else
            {

                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki - 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id - DlugoscSiatki + 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki - 1);
                PolaSasiadujace = (int[])PolaSasiadujace.Append(Id + DlugoscSiatki + 1);

                return PolaSasiadujace;
            }


        }
            
        }




    }
