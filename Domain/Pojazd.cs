using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Pojazd
    {
        private int id;
        private string rejestracja;
        private string marka;
        private string model;
        private string silnik;
        private int cena;
        private string wymagane_Uprawnienia;
        private string opis;

        public string Rejestracja { get => rejestracja; set => rejestracja = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string Silnik { get => silnik; set => silnik = value; }
        public int Cena { get => cena; set => cena = value; }
        public string Wymagane_Uprawnienia { get => wymagane_Uprawnienia; set => wymagane_Uprawnienia = value; }
        public string Opis { get => opis; set => opis = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return "Marka pojazdu: "+Marka + " Model: " + Model + " Rejestracja: " +
                Rejestracja + " Cena: " + Cena + " "+Opis;
        }
    }



}
