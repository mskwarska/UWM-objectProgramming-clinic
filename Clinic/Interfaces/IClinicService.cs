using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Models;
namespace Clinic.Interfaces
{
    interface IClinicService
    {
        void SearchBySurname(string surname);
        void SearchByMedicineName();
        void SortPatients();
        void AddPatient(Patient patient);
        void RemovePatient(int[] pesel);
        void AddDoctor(Doctor doctor);
        void RemoveDoctor(int[] pesel);
    }
}
