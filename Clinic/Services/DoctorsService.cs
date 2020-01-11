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
        public List<Doctor> IsDoctorFreeToday(int day, int hour)
        {
            List<Doctor> availibityDoctors = new List<Doctor>();

            try
            {
                if (ArgumentValidate(day, hour))
                {
                    foreach (var doctor in doctors)
                    {
                        WorkDay singleDay = doctor.GetSignleWorkDay(day);
                        if (singleDay.IsFreeHour(hour))
                        {
                            availibityDoctors.Add(doctor);
                        }
                    }
                }

                return availibityDoctors;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;//TODO: TEGO NIE MOZE BYC!!! GOD 23:27 NIE MAM SIL:)
        }

        private bool ArgumentValidate(int day, int hour)
        {
            return (day >= 0 && day <= 4) && (hour >= 0 && hour <= 7);
        }
    }
}
