using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PojazdOsobowy : Pojazd
    {
        int maxPredkosc;

        public PojazdOsobowy()
        {
            Opis = "Pojazd Osobowy osiągajacy Duże prędkości";
        }

        public int MaxPredkosc { get => maxPredkosc; set => maxPredkosc = value; }

        public override string ToString()
        {
            return Marka + " " + Model + " " + Rejestracja + " " + Cena + " " + MaxPredkosc;
        }
    }
}
