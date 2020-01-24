using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Enums;

namespace Clinic.Models
{
    class Adress
    {
        private string street;
        private string city;
        private Enum countryCode;
        private string postalCode;
        private string Street { get => street; set => street = value; }
        private string City { get => city; set => city = value; }
        public string PostalCode
        {
            get
            {
                return postalCode;
            }
            set
            {
                postalCode = value;
            }
        }
        private Enum CountryCode { get => countryCode; set => countryCode = value; }

        public Adress(string street, string city, CountryCode countryCode, string postalCode)
        {
            this.street = street;
            this.city = city;
            this.CountryCode = countryCode;
            this.postalCode = postalCode;
        }

        public String ToString()
        {
            return " [MIASTO: " + city
                + " ,ULICA: " + street
                + " ,KOD PANSTWA: " + countryCode.ToString()
                + " ,KOD POCZTOWY: " + postalCode
                + "]";
        }
    }
}
