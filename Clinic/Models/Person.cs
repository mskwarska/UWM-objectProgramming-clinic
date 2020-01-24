using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    abstract class Person
    {
        private string name;
        private string surname;
        private  int[] pesel = new int[11];


        public string Name { get => name; set => name = value; } 
        //WALIDATORY- SPRAWDZANIE PODANYCH WARTOSCI
        
        public string Surname { get => surname; set => surname = value; }
        
        public int[] PESEL { get => pesel; private set => pesel = value; }// private bo nie wolno edytować PESELU 

        public Person(string name, string surname, int[] pesel)
        {
            this.name = name;
            this.surname = surname;
            this.pesel = pesel;
        }

        public override string ToString()
        {
            return "[IMIE: " + name
                + " ,NAZWISKO: " + surname
                + ", PESEL: " + PrintPesel();
        }

        private string PrintPesel()
        {
            string ps = "";
            for(int i = 0; i < 10; i++)
            {
                ps +=  pesel[i].ToString();
            }
            return ps;
        }
    }
}
