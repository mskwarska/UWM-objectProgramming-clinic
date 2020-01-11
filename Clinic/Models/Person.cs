using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    abstract class Person
    {
        //get i set  wielkimi
        private string name;
        private string surname;
        private int[] pesel= new int[11];

        public string Name { get => name; set => name = value; } 
        //WALIDATORY- SPRAWDZANIE PODANYCH WARTOSCI
        
        public string Surname { get => surname; set => surname = value; }
        
        public int[] PESEL { get => pesel; set => pesel = value; }

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
