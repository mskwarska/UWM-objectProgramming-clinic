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
        private Queue<Patient> patients;

        public Clinic()
        {
            doctors = new List<Doctor>(); 
            patients = new Queue<Patient>();
        }

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }
        public void AddPatient(Patient patient)
        {
            patients.Enqueue(patient);
        }
    }
}
