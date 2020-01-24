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
        private List<WorkDay> DoctorAvailibity = new List<WorkDay>();
        private Enum specialization;

        public Doctor(string name, string surname, int[] pesel, SpecjalizationEnum specialization) : base(name, surname, pesel)
        {
            this.specialization = specialization;
            DoctorAvailibity = GenerateDoctorAvailibity();
        }

        List<WorkDay> GenerateDoctorAvailibity()
        {
            List<WorkDay> week = new List<WorkDay>();

            for(int i = 0; i < 5; i++)
            {
                week.Add(new WorkDay());
            }

            return week;
        }

        public List<WorkDay> GetDoctorAvailibity()
        {
            return DoctorAvailibity;
        }

        public void SetDoctorAvailibity(List<WorkDay> DoctorAvailibity)
        {
            this.DoctorAvailibity = DoctorAvailibity;
        }

        public WorkDay GetSignleWorkDay(int day)
        {
            return DoctorAvailibity[day];
        }

        public override string ToString()
        {
            return base.ToString() +
                ", SPECJALIZACJA: "
                + specialization
                + "]";
        }
    }
}
