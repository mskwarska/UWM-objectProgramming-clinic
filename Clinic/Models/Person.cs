using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    class Person
    {
        //get i set  wielkimi
        private string name;
        private string surname;
        private int[] pesel= new int[11];

        public string Name //WALIDATORY- SPRAWDZANIE PODANYCH WARTOSCI
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public int[] PESEL
        {
            get
            {
                return pesel;
            }
            set
            {
                pesel = value;
            }
        }

        public Person(string name, string surname, int[] pesel)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
        }

        public override string ToString()
        {
            return String.Concat(name + surname, PESEL);
        }
    }
}
