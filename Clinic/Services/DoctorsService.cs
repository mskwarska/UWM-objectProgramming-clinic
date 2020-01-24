using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Serwis ten, przyjmuje jako argument konstruktora listę doktorów. 
 * Następnie na tej liście wywołuje różne metody (Bada listę doktorów)
 * 
*/
namespace Clinic.Services
{
    class DoctorsService
    {

        List<Doctor> doctors;

        public DoctorsService(List<Doctor> doctors)
        {
            this.doctors = doctors;
        }

       //Metoda zwraca liste doktorow dostepnych o danej godzinie danego dnia
       //przyjmuje dwa argumenty, dzien oraz godzine
      
    }
}
