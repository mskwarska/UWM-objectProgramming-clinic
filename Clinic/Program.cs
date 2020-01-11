

using Clinic.Models;
using Clinic.Services;
using System.Collections.Generic;
using Clinic.Enums;

namespace Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pesel = {1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 1 };
            Doctor d1 = new Doctor("Maciej", "Wawrzyniak", pesel);         
            Doctor d2 = new Doctor("Heniek", "asdasd", pesel);         
            Doctor d3 = new Doctor("Ketek", "asf", pesel);         
            Doctor d4 = new Doctor("Retek", "gregerg", pesel);

            WorkDay work = new WorkDay();
            work.ChangeHourToBusy(2);
            List<WorkDay> workDays = new List<WorkDay>();
            workDays.Add(work);
            workDays.Add(work);
            workDays.Add(work);
            workDays.Add(work);
            workDays.Add(work);

            d2.SetDoctorAvailibity(workDays);

            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(d1);
            doctors.Add(d2);
            doctors.Add(d3);
            doctors.Add(d4);
            DoctorsService service = new DoctorsService(doctors);
            List<Doctor> avaDoctors = service.IsDoctorFreeToday(0, 2);

            foreach(var doc in avaDoctors)
            {
                System.Console.WriteLine(doc.Name);
            }
            System.Console.ReadLine();
        }
    }
}
/*
 * 
//TestCommitPush
            //Jednorazowe wywolanie menu zwiazane z przychodnia
            //DisplayPrzychodniaMenu() -> void zlozony z Console.WriteLine(); 1. ... 2. 
            //Console read() z walidacja czy numer jest poprawny :) 
            //na podstawie wyboru wykonasz metode i wejdziesz do nieskonczonej petli
           while(true)
            {
                  //DisplayMainMenu();
                  //GetVal(); 
            }*/