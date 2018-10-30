using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
   public class Wypozyczenie
    {
        private int id;
        private Klient klient;
        private Pojazd pojazd;
        private DateTime dataWynajmu;
        private DateTime dataZwrotu;
        private int cenaWypozyczenia = 0;

        public Wypozyczenie()
        {
            this.klient = new Klient();
            this.pojazd = new Pojazd();
            this.dataWynajmu = new DateTime();
            this.dataZwrotu = new DateTime();

        }

        public Klient Klient { get => klient; set => klient = value; }
        public Pojazd Pojazd { get => pojazd; set => pojazd = value; }
        public DateTime DataWynajmu { get => dataWynajmu; set => dataWynajmu = value; }
        public DateTime DataZwrotu { get => dataZwrotu; set => dataZwrotu = value; }
        public int CenaWypozyczenia { get => cenaWypozyczenia; set => cenaWypozyczenia = value; }
        public int Id { get => id; set => id = value; }

        public int ObliczCene(DateTime wynajem, DateTime zwrot, int cena)
        {
            TimeSpan iloscDni = zwrot - wynajem;
            CenaWypozyczenia = int.Parse(iloscDni.Days.ToString()) * cena;
            



            return CenaWypozyczenia;
        }

        public override string ToString()
        {
            return "Imie: "+klient.First_Name + " Nazwisko: " + klient.Last_Name + " PESEL: " + 
                klient.Pesel + " Marka pojazdu: " + pojazd.Marka + " Model pojazdu: " + 
                pojazd.Model + " Rejestracja: " + pojazd.Rejestracja + " Cena Wypożyczenia: " + 
                cenaWypozyczenia + " Data Wynajmu "+DataWynajmu ;
        }




    }
}
