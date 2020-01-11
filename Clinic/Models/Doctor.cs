using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Models;
using Clinic.Enums;
namespace Clinic.Models
{
    class Doctor : Person
    {
        private List<WorkDay> DoctorAvalibity = new List<WorkDay>();
        
        public Doctor(string name, string surname, int[] pesel) : base(name, surname, pesel)
        {
            DoctorAvalibity = GenerateDoctorAvalibity();
        }

        List<WorkDay> GenerateDoctorAvalibity()
        {
            List<WorkDay> week = new List<WorkDay>();

            for(int i = 0; i < 5; i++)
            {
                week[i] = new WorkDay();
            }

            return week;
        }
    }
}
