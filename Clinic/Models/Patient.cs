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

        public Adress Address { get; set; }
        public Patient(string name, string surname, int[] pesel, Adress adress) : base(name, surname, pesel)
        {
            this.adress = adress;
        }
    }
}
