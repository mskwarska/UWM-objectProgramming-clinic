using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clinic.Models
{
    class Clinic
    {
        private List<Doctor> doctors;
        //private Queue<Patient> patients;
        private List<Patient> patients;

        public Clinic()
        {
            doctors = new List<Doctor>(); 
            patients = new List<Patient>();
        }

        /*public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }*/
        
    }
}
