using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PojazdCiezarowy : Pojazd
    {
        private int ladownosc;
        
        public PojazdCiezarowy()
        {
            Opis = "Pojazd cieżarowy o dużej ładowności";
        }

        public int Ladownosc { get => ladownosc; set => ladownosc = value; }
       

        public override string ToString()
        {
            return Marka + " " + Model + " " + Rejestracja + " " + Cena +" "+ Ladownosc ;
        }
    }
}
