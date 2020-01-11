using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    class Adress
    {
        private string street;
        private string city;
        private Enum countryCode;
        private int[] postalCode;

        private string Street { get => street; set => street = value; }
        private string City { get => city; set => city = value; }
        public int[] PostalCode
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

        public Adress(string street, string city, Enum countryCode, int[] postalCode)
        {
            this.street = street;
            this.city = city;
            this.countryCode = countryCode;
            this.postalCode = postalCode;
        }
    }
}
