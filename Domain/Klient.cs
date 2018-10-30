using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Klient
    {
        private int id;
        private string pesel;
        private string first_Name;
        private string last_Name;
        private int age;
        private string driveLicense;
        private string clientType;
        private string phoneNumber;

        public int Id { get => id; set => id = value; }
        public string Pesel { get => pesel; set => pesel = value; }
        public string First_Name { get => first_Name; set => first_Name = value; }
        public string Last_Name { get => last_Name; set => last_Name = value; }
        public int Age { get => age; set => age = value; }
        public string DriveLicense { get => driveLicense; set => driveLicense = value; }
        public string ClientType { get => clientType; set => clientType = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }


        public override string ToString()
        {
            return First_Name + " "+ Last_Name + " PESEL: " + Pesel + " Wiek: "+ Age ;
        }
    }
}
