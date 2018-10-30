using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Session;
using System.Data.SqlClient;

namespace Database_Learning_Day1
{
    public partial class Wypozyczalnia : Form
    {
        Klient klient;
        Broker broker;
        Pojazd pojazd;
        Wypozyczenie wypozyczenie;
        /// <summary>
        /// konstruktor 
        /// </summary>
        public Wypozyczalnia()
        {
            InitializeComponent();
          
            broker = new Broker();
      
        }

        /// <summary>
        /// Przycisk pobierajacy tekst z texboxa i wrzucajacy do klienta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Insert_Database_Click(object sender, EventArgs e)
        {
            if (Text_PESEL.Text == "" || Text_Last_Name.Text ==""  || Text_Age.Text == "")
            {
                string blad = string.Format("Nie wypełnione pola");
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForClient();
            }
            else if (Int32.Parse(Text_Age.Text) < 18)
            {
                string blad = string.Format("Jesteś niepełnoletni");
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearForClient();
            }
            else
            {
                klient = new Klient();
                klient.Pesel = Text_PESEL.Text;
                klient.First_Name = Text_First_Name.Text;
                klient.Last_Name = Text_Last_Name.Text;
                klient.Age = Int32.Parse(Text_Age.Text);             
                klient.DriveLicense = comboBox_Uprawienia.Text;         
                klient.ClientType = comboBox_Typ_Klienta.Text;
                klient.PhoneNumber = Text_Phone_Number.Text;

                broker.InsertClient(klient);
                ClearForClient();
            }
        }

        /// <summary>
        /// czyszczenie zawartości TextBoxa
        /// </summary>
        private void ClearForClient()
        {
            Text_PESEL.Text = "";
            Text_First_Name.Text = "";
            Text_Last_Name.Text = "";
            Text_Age.Text = "";         
            comboBox_Uprawienia.Text = "";
            comboBox_Typ_Klienta.Text = "";          
            Text_Phone_Number.Text = "";
        }
        /// <summary>
        /// Czyszczenie zawartosci wypozyczenia
        /// </summary>
        private void ClearForRent()
        {
            Text_Dzien_Wypozyczenia.Text = " ";
            Text_Rejestracja_Pojazdu_Wypozyczanego.Text = " ";
            Text_Rok_Wypozyczenia.Text = " ";
            Text_Miesiac_Wypozyczenia.Text = " ";
            Text_Pesel_Wypozyczajacego.Text = " ";
        }

        /// <summary>
        /// czyszczenie zawartości texBoxa pojazdu
        /// </summary>
        private void ClearForVehicle()
        {

            TextBox_Rejestracja.Text="";
            TextBox_Marka.Text = "";
            TextBox_Model.Text = "";
            TextBox_Silnik.Text = "";
            TextBox_Cena_Wypozyczenia.Text = "";
            TextBox_Uprawnienia.Text = "";

        }

        /// <summary>
        /// Metoda zwraca po naciśniecju na przycisk wszystkich klientów
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Select_Klients_Click(object sender, EventArgs e)
        {
            TextBox_Lista_Klientow.Text = broker.SelectAllClients();
            //ComboBox_Select_Klients.DataSource = broker.Select();
            //ListView_Klientow.DataSource = broker.Selectet();
            //ListView_Klientow.Items.Add(broker.Select2());
            //label2.Text = broker.Select2();


        }

        /// <summary>
        /// metoda po naciśniejcu na przycisk zwraca wybranego klienta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Pokaz_Jednego_Klienta_Click(object sender, EventArgs e)
        {
            if (TextBox_Lista_Klientow.Text == "")
            {
                string blad = string.Format("Nie wypełnione pola lub błędnie podany pesel");
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            else
            {
                string pesel = "";
                pesel = Text_Podaj_Pesel.Text;
                TextBox_Lista_Klientow.Text = broker.SelectOneClient(pesel);
            }

        }

        /// <summary>
        /// Po naciśniecju przycisku dodaje pojazd do bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Dodaj_Pojazd_Click(object sender, EventArgs e)
        {

            klient = new Klient();
            pojazd = new PojazdOsobowy();


            pojazd.Rejestracja = TextBox_Rejestracja.Text;
            pojazd.Marka = TextBox_Marka.Text;
            pojazd.Model = TextBox_Model.Text;
            pojazd.Silnik = TextBox_Silnik.Text;
            pojazd.Cena = int.Parse(TextBox_Cena_Wypozyczenia.Text);
            pojazd.Wymagane_Uprawnienia = TextBox_Uprawnienia.Text;

            broker.InsertPojazd(pojazd);
            ClearForVehicle();


        }

        /// <summary>
        /// Dodawanie pojazdu ciężarowego do bazy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dodaj_Pojazd_Ciezarowy_Click(object sender, EventArgs e)
        {
            klient = new Klient();
            pojazd = new PojazdCiezarowy();

            if(TextBox_Rejestracja.Text == "" || TextBox_Marka.Text =="" || TextBox_Cena_Wypozyczenia.Text =="" || TextBox_Uprawnienia.Text =="")
            {
                string blad = string.Format("Nie wypełnione pola"); 
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            pojazd.Rejestracja = TextBox_Rejestracja.Text;
            pojazd.Marka = TextBox_Marka.Text;
            pojazd.Model = TextBox_Model.Text;
            pojazd.Silnik = TextBox_Silnik.Text;
            pojazd.Cena = int.Parse(TextBox_Cena_Wypozyczenia.Text);
            pojazd.Wymagane_Uprawnienia = TextBox_Uprawnienia.Text;

            broker.InsertPojazd(pojazd);
            ClearForVehicle();
        }

        /// <summary>
        /// metoda po naciśnieciu przycisku pobiera wszystkie pojazdy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Select_ALL_Vehicle_Click(object sender, EventArgs e)
        {
            TextBox_Lista_Klientow.Text = broker.SelectAllVehicle();
        }

        /// <summary>
        /// Dodawanie nowego wypożyczenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Nowe_Wypozyczenie_Click(object sender, EventArgs e)
        {
            string day = Text_Dzien_Wypozyczenia.Text;
            string miesiac = Text_Miesiac_Wypozyczenia.Text;
            string rok = Text_Rok_Wypozyczenia.Text;
            string dataInput = Text_Dzien_Wypozyczenia.Text + "/" + Text_Miesiac_Wypozyczenia.Text + "/" + Text_Rok_Wypozyczenia.Text;
       
            string pesel = " ";
            string rejestracja = " ";
            wypozyczenie = new Wypozyczenie();
            klient = new Klient();
            pojazd = new Pojazd();
            DateTime  dataWynajmuPojazdu = DateTime.Parse(dataInput);

            pesel = Text_Pesel_Wypozyczajacego.Text;
            rejestracja = Text_Rejestracja_Pojazdu_Wypozyczanego.Text;

            klient = broker.KlientWypozyczajacy(pesel);
            pojazd = broker.PojazdDoWypozyczenia(rejestracja);

            wypozyczenie.Klient = klient;
            wypozyczenie.Pojazd = pojazd;
            wypozyczenie.DataWynajmu = dataWynajmuPojazdu;


            broker.DodajWypozyczenieDoBazy(wypozyczenie);
            ClearForRent();
            





        }

        /// <summary>
        /// pokazanie wszystkich wypozyczen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Pokaz_Wypozyczenia_Click(object sender, EventArgs e)
        {
            TextBox_Lista_Klientow.Text = broker.PokazWszystkieWypozyczenia();

            //broker = new Broker();


            //string ccc = "Data Source=DESKTOP-E2RUPB8;Initial Catalog=DatabaseKlient;Integrated Security=True";

            //SqlConnection con = new SqlConnection(ccc);
            //DataTable returnTable = new DataTable();
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
           
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //con.Close();

            //string query = "SELECT LastName, PESEL, Rejestracja, DataWynajmu, CenaWypozyczenia  FROM dbo.Wypozyczenie";
            //adapter.SelectCommand = new SqlCommand(query, con);
            //adapter.Fill(returnTable);
            //this.dataGridView1.DataSource = returnTable;


        }

        /// <summary>
        /// zakonczenie danego wypozyczenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Zakonczenie_Wypozyczenia_Click(object sender, EventArgs e)
        {
            Wypozyczenie stareWypozyczenie = new Wypozyczenie();
            Wypozyczenie noweWypozyczenie = new Wypozyczenie();

            string dataInput = Text_Dzien_Wypozyczenia.Text + "/" + Text_Miesiac_Wypozyczenia.Text + "/" + Text_Rok_Wypozyczenia.Text;

            string pesel = " ";
            string rejestracja = " ";
            int idWypozyczeniaDoZmiany = 0;
            wypozyczenie = new Wypozyczenie();
            klient = new Klient();
            pojazd = new Pojazd();
            DateTime dataOddaniaPojazdu = DateTime.Parse(dataInput);

            pesel = Text_Pesel_Wypozyczajacego.Text;
            rejestracja = Text_Rejestracja_Pojazdu_Wypozyczanego.Text;

            klient = broker.KlientWypozyczajacy(pesel);
            pojazd = broker.PojazdDoWypozyczenia(rejestracja);


            idWypozyczeniaDoZmiany = broker.ZwrocIdWypozyczenia(rejestracja);
            noweWypozyczenie.DataZwrotu = dataOddaniaPojazdu;
            // dokonujemy przypisania starego klienta oraz pojazdu po czym dokonujemy na nich operacji
            stareWypozyczenie = broker.ZwrocStareWypozyczenie(idWypozyczeniaDoZmiany);
            stareWypozyczenie.Klient = klient;
            stareWypozyczenie.Pojazd = pojazd;

            broker.ZakonczWypozyczenie(stareWypozyczenie, noweWypozyczenie);
        

        }
    }
}
