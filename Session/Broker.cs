using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;
using System.Windows.Forms;

using System.Data;

namespace Session
{
    public class Broker
    {
        SqlConnection connection;
        SqlConnectionStringBuilder connecton_String_Build;


        /// <summary>
        /// metoda inicjalizująca nasze dane bazy
        /// </summary>
        void ConnectTo()
        {
            //Data Source=DESKTOP-E2RUPB8;Initial Catalog=DatabaseKlient;Integrated Security=True
            connecton_String_Build = new SqlConnectionStringBuilder();
            connecton_String_Build.DataSource = "DESKTOP-E2RUPB8";
            connecton_String_Build.InitialCatalog = "DatabaseKlient";
            connecton_String_Build.IntegratedSecurity = true;

            connection = new SqlConnection(connecton_String_Build.ToString());



        }

        /// <summary>
        /// Konstruktor broker, odpala metode ConnectTo
        /// </summary>
        public Broker()
        {
            ConnectTo();
        }

        /// <summary>
        /// Metoda odpowiedzialna za zapytanie do bazy, otworzenie jej oraz wywołanie zapytania
        /// </summary>
        /// <param name="klient"></param>
        public void InsertClient(Klient klient)
        {
            try
            {
                string commandText = "INSERT INTO dbo.Klienci(PESEL, FirstName, LastName, Age, [Drive license], [Client type], [Phone number])" +
                    " VALUES(@PESEL, @FirstName, @LastName, @Age, @Drive_license, @Client_type, @Phone_number)";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@PESEL", klient.Pesel);
                command.Parameters.AddWithValue("@FirstName", klient.First_Name);
                command.Parameters.AddWithValue("@LastName", klient.Last_Name);
                command.Parameters.AddWithValue("@Age", klient.Age);
                command.Parameters.AddWithValue("@Drive_license", klient.DriveLicense);
                command.Parameters.AddWithValue("@Client_type", klient.ClientType);
                command.Parameters.AddWithValue("@Phone_number", klient.PhoneNumber);

                connection.Open();          // Otwieramy baze 
                command.ExecuteNonQuery();  // wywołuje zapytanie do bazy
            }
            catch (Exception ex)
            {         
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
            
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
                
            }

        }
     
        /// <summary>
        /// Metoda która wywołuje zapytanie zwracające wszystkich klientów z bazy
        /// </summary>
        /// <returns></returns>
        public string SelectAllClients()
        {

            string klienci = "";
            try
            {
                string commandText = "SELECT * from dbo.Klienci";
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Klient klient = new Klient();
                    klient.First_Name = reader["FirstName"].ToString();
                    klient.Last_Name = reader["LastName"].ToString();
                    klient.Pesel = reader["PESEL"].ToString();
                    klient.Age = int.Parse(reader["Age"].ToString());
                    klienci += klient.ToString() + Environment.NewLine + Environment.NewLine;
                   
                }
                return klienci;

            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
            return klienci;



        }

        /// <summary>
        /// Metoda wykonująca zapytanie, zwraca konkretnego klienta poprzez podany pesel
        /// </summary>
        /// <param name="peselKlienta"></param>
        /// <returns></returns>

        public string SelectOneClient(string peselKlienta)
        {

            string klientNasz = "";
            try
            {
                string commandText = "SELECT * from dbo.Klienci where PESEL ="+peselKlienta;
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Klient klient = new Klient();
                    klient.First_Name = reader["FirstName"].ToString();
                    klient.Last_Name = reader["LastName"].ToString();
                    klient.Pesel = reader["PESEL"].ToString();
                    klient.Age = int.Parse(reader["Age"].ToString());
                    klientNasz += klient.ToString() + Environment.NewLine + Environment.NewLine;

                }
                return klientNasz;


            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
            return klientNasz;



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pojazd"></param>
        public void InsertPojazd(Pojazd pojazd)
        {

            try
            {
                string commandText = "INSERT INTO dbo.Pojazdy(Rejestracja, Marka, Model, Silnik, Cena, Uprawnienia, Opis)" +
                    " VALUES(@Rejestracja, @Marka, @Model, @Silnik, @Cena, @Uprawnienia, @Opis)";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue("@Rejestracja", pojazd.Rejestracja);
                command.Parameters.AddWithValue("@Marka", pojazd.Marka);
                command.Parameters.AddWithValue("@Model", pojazd.Model);
                command.Parameters.AddWithValue("@Silnik", pojazd.Silnik);
                command.Parameters.AddWithValue("@Cena", pojazd.Cena);
                command.Parameters.AddWithValue("@Uprawnienia", pojazd.Wymagane_Uprawnienia);
                command.Parameters.AddWithValue("@Opis", pojazd.Opis);

                connection.Open();          // Otwieramy baze 
                command.ExecuteNonQuery();  // wywołuje zapytanie do bazy
            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }







        }

        /// <summary>
        /// Select do bazy pojazdy all
        /// </summary>
        /// <returns></returns>
        public string SelectAllVehicle()
        {
            string pojazdy = "";
            
            try
            {
                string commandText = "SELECT * from dbo.Pojazdy";
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                   
                    Pojazd pojazd = new Pojazd();
                    pojazd.Marka = reader["Marka"].ToString();
                    pojazd.Rejestracja = reader["Rejestracja"].ToString();
                    pojazd.Model = reader["Model"].ToString();
                    pojazd.Cena = int.Parse(reader["Cena"].ToString());
                    pojazd.Opis = reader["Opis"].ToString();
                    pojazdy += pojazd.ToString() + Environment.NewLine + Environment.NewLine;

                }
                return pojazdy;

            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
            return pojazdy;
        }

        /// <summary>
        /// Zwraca klienta o podanym peselu z bazy
        /// </summary>
        /// <param name="peselKlienta"></param>
        /// <returns></returns>
        public Klient KlientWypozyczajacy(string peselKlienta)
        {

            Klient klient = new Klient();

            try
            {
                string commandText = "SELECT * from dbo.Klienci where PESEL ="+peselKlienta;
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    klient.Id = int.Parse(reader["Id"].ToString());
                    klient.First_Name = reader["FirstName"].ToString();
                    klient.Last_Name = reader["LastName"].ToString();
                    klient.Pesel = reader["PESEL"].ToString();
                    klient.Age = int.Parse(reader["Age"].ToString());
                    klient.DriveLicense = reader["Drive license"].ToString();
                    klient.ClientType = reader["Client type"].ToString();
                    klient.PhoneNumber = reader["Phone number"].ToString();
                   

                }
                


            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

            return klient;
        }


        /// <summary>
        /// Swraca pojazd o podanej rejestracji z bazy
        /// </summary>
        /// <param name="rejestracjaPojazdu"></param>
        /// <returns></returns>

        public Pojazd PojazdDoWypozyczenia(string rejestracjaPojazdu)
        {


            Pojazd pojazd = new Pojazd();

            try
            {
                string commandText = "SELECT * from dbo.Pojazdy where Rejestracja like '" + rejestracjaPojazdu+"'";
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    pojazd.Id = int.Parse(reader["Id"].ToString());
                    pojazd.Rejestracja = reader["Rejestracja"].ToString();
                    pojazd.Marka = reader["Marka"].ToString();
                    pojazd.Model = reader["Model"].ToString();
                    pojazd.Silnik = reader["Silnik"].ToString();
                    pojazd.Cena = int.Parse(reader["Cena"].ToString());
                    pojazd.Wymagane_Uprawnienia = reader["Uprawnienia"].ToString();
                    pojazd.Opis = reader["Opis"].ToString();

                }



            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

            return pojazd;
        }



        /// <summary>
        /// Dodawanie wypozyczenia do bazy danych
        /// </summary>
        /// <param name="wypozyczenie"></param>
        public void DodajWypozyczenieDoBazy(Wypozyczenie wypozyczenie)
        {


            try
            {
                string commandText = "INSERT INTO dbo.Wypozyczenie(Id_Klienta, Id_Pojazdu, DataWynajmu, CenaWypozyczenia, FirstName, LastName, PESEL, Marka, Model, Rejestracja)" +
                    " VALUES(@Id_Klienta, @Id_Pojazdu, @DataWynajmu, @CenaWypozyczenia,@FirstName, @LastName, @PESEL, @Marka, @Model, @Rejestracja)";
                SqlCommand command = new SqlCommand(commandText, connection);

                command.Parameters.AddWithValue("@Id_Klienta", wypozyczenie.Klient.Id);
                command.Parameters.AddWithValue("@Id_Pojazdu", wypozyczenie.Pojazd.Id);
                command.Parameters.AddWithValue("@DataWynajmu", wypozyczenie.DataWynajmu);
               // command.Parameters.AddWithValue("@DataZwrotu", wypozyczenie.DataZwrotu);
                command.Parameters.AddWithValue("@CenaWypozyczenia", wypozyczenie.CenaWypozyczenia);
                command.Parameters.AddWithValue("@FirstName", wypozyczenie.Klient.First_Name);
                command.Parameters.AddWithValue("@LastName", wypozyczenie.Klient.Last_Name);
                command.Parameters.AddWithValue("@PESEL", wypozyczenie.Klient.Pesel);
                command.Parameters.AddWithValue("@Marka", wypozyczenie.Pojazd.Marka);
                command.Parameters.AddWithValue("@Model", wypozyczenie.Pojazd.Model);
                command.Parameters.AddWithValue("@Rejestracja", wypozyczenie.Pojazd.Rejestracja);


                connection.Open();          // Otwieramy baze 
                command.ExecuteNonQuery();  // wywołuje zapytanie do bazy
            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

        }

        /// <summary>
        /// Wyswietlenie wszystkich wypozyczen pojazdu
        /// </summary>
        /// <returns></returns>
        public string PokazWszystkieWypozyczenia()
        {

            Wypozyczenie wypozyczenie = new Wypozyczenie();
          

            
            string wypozyczeniaString = " ";
            try
            {
                string commandText = "SELECT * from dbo.Wypozyczenie";
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                string data = " ";

                while (reader.Read())
                {

                    wypozyczenie.Klient.First_Name = reader["FirstName"].ToString();
                    wypozyczenie.Klient.Last_Name = reader["LastName"].ToString();
                    wypozyczenie.Klient.Pesel = reader["PESEL"].ToString();
                    wypozyczenie.Pojazd.Marka = reader["Marka"].ToString();
                    wypozyczenie.Pojazd.Model = reader["Model"].ToString();
                    wypozyczenie.Pojazd.Rejestracja = reader["Rejestracja"].ToString();
                    wypozyczenie.CenaWypozyczenia = int.Parse(reader["CenaWypozyczenia"].ToString());
                    wypozyczenie.DataWynajmu = DateTime.Parse(reader["DataWynajmu"].ToString());


                    wypozyczeniaString += wypozyczenie.ToString() + Environment.NewLine + Environment.NewLine;            

                }
                return wypozyczeniaString;

            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }
            return wypozyczeniaString;



        }

        /// <summary>
        /// Zwroc id wypozyczenia
        /// </summary>
        /// <param name="rejestracja"></param>
        /// <returns></returns>
        public int ZwrocIdWypozyczenia(string rejestracja)
        {       
            int IdWypozyczenia = 0 ;
            Wypozyczenie wypozyczenie = new Wypozyczenie();

            try
            {
                string commandText = "SELECT Id from dbo.Wypozyczenie where Rejestracja like '" + rejestracja+"'";
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();


                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    wypozyczenie.Id = int.Parse(reader["Id"].ToString());
                  

                }
                IdWypozyczenia = wypozyczenie.Id;
            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

            return IdWypozyczenia;


        }


        /// <summary>
        /// aktualizacja wypozyczenia
        /// </summary>
        /// <param name="stareWypozyczenie"></param>
        /// <param name="noweWypozyczenie"></param>
        public void ZakonczWypozyczenie(Wypozyczenie stareWypozyczenie, Wypozyczenie noweWypozyczenie)
        {
            try
            {
                string zapytanie = "UPDATE dbo.Wypozyczenie SET DataZwrotu=@DataZwrotu, CenaWypozyczenia=@CenaWypozyczenia WHERE Id=@Id";
                SqlCommand command = new SqlCommand(zapytanie, connection);
                command.Parameters.AddWithValue("@DataZwrotu", noweWypozyczenie.DataZwrotu);
                command.Parameters.AddWithValue("@CenaWypozyczenia", noweWypozyczenie.ObliczCene(stareWypozyczenie.DataWynajmu, noweWypozyczenie.DataZwrotu, stareWypozyczenie.Pojazd.Cena));
                command.Parameters.AddWithValue("@Id", stareWypozyczenie.Id);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

        }

        /// <summary>
        /// zwraca cale wypozyczenie po id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Wypozyczenie ZwrocStareWypozyczenie(int id)
        {

           
            Wypozyczenie wypozyczenie = new Wypozyczenie();

            try
            {
                string commandText = "SELECT * from dbo.Wypozyczenie where Id=" + id ;
                SqlCommand command = new SqlCommand(commandText, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    wypozyczenie.Id = int.Parse(reader["Id"].ToString());
                    wypozyczenie.Klient.First_Name = reader["FirstName"].ToString();
                    wypozyczenie.Klient.Last_Name = reader["LastName"].ToString();
                    wypozyczenie.Klient.Pesel = reader["PESEL"].ToString();
                    wypozyczenie.Pojazd.Marka = reader["Marka"].ToString();
                    wypozyczenie.Pojazd.Model = reader["Model"].ToString();
                    wypozyczenie.Pojazd.Rejestracja = reader["Rejestracja"].ToString();
                    wypozyczenie.CenaWypozyczenia = int.Parse(reader["CenaWypozyczenia"].ToString());
                    wypozyczenie.DataWynajmu = DateTime.Parse(reader["DataWynajmu"].ToString());

                }



            }
            catch (Exception ex)
            {
                string blad = string.Format("Masz błąd :/{0}", ex.Message); // {0} mówi o błędzie jaki wystąpił
                MessageBox.Show(blad, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

            return wypozyczenie;

        }

    }
}
