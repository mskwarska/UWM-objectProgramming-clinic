using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    class Receptionist : Person
    {
        public Receptionist(string name, string surname, int[] pesel) : base(name, surname, pesel)
        {
        }

        private bool CzyMogeZapisac(WorkDay workDay)
        {
            return true;
        }
        public bool ZapisDoDoktora()
        {
            return true;
        }
        

    }
}
