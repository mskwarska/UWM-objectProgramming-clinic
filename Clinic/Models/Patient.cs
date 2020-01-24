using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    class Patient : Person
    {
        private Adress adress;
        public List<Doctor> ListaZapisow = new List<Doctor>();
        public List<int> ListaGodzinZapisow = new List<int>();
        public List<int> ListaDniZapisow = new List<int>();

        public Adress Address { get; set; }
        public Patient(string name, string surname, int[] pesel, Adress adress) : base(name, surname, pesel)
        {
            this.adress = adress;
        }

        public override string ToString()
        {
            return base.ToString() + adress.ToString();
        }
    }
}
