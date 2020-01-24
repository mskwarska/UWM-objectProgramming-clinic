using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Interfaces;
using Clinic.Models;


namespace Clinic.Services
{
    class ClinicService : IClinicService
    {

        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();

        public ClinicService(List<Patient> patients, List<Doctor> doctors)
        {
            this.patients = patients;
            this.doctors = doctors;
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }
        public void RemovePatient(int[] pesel)
        {
            for(int i=0; i<patients.Count; i++)
            {
                bool isEqual = Enumerable.SequenceEqual(pesel, patients[i].PESEL);

                if (isEqual)
                {
                    patients.Remove(patients[i]);
                }
            }
        }

        public void SortPatients()//(string surname)
        {
            patients = patients.OrderBy(x => x.Surname).ThenBy(x => x.Name).ToList(); ;
        }

        public void SearchByMedicineName()
        {
            throw new NotImplementedException();
        }

        public void SearchBySurname(string surname)
        {
            int hMany = 0;
            //=> patients.Where(x => x.Surname == surname).ToList();
            for(int i=0; i < patients.Count; i++)
            {
                if(patients[i].Surname==surname)
                {
                    Console.WriteLine(patients[i].ToString());
                    hMany++;               
                }
            }
            if(hMany == 0)
            {
                Console.WriteLine("Nie ma pacjenta o podoanmy nazwisku");
            }
        }
        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }
        public void RemoveDoctor(int[] pesel)
        {
            for (int i = 0; i <doctors.Count; i++)
            {

                bool isEqual = Enumerable.SequenceEqual(pesel, doctors[i].PESEL);

                if (isEqual)
                {
                    doctors.Remove(doctors[i]);
                }
            }
        }

        public List<Patient> GetPatients()
        {
            return patients;
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }

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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;//TODO: TEGO NIE MOZE BYC!!! GOD 23:27 NIE MAM SIL:)
        }

        public void ShowInfoAboutDoctors(int day, int hour)
        {
            if (doctors.Count > 0)
            {
                List<Doctor> info = IsDoctorFreeToday(day, hour);
                if (info.Count > 0)
                {
                    Console.WriteLine("LISTA DOSTEPNYCH DOKTOROW: ");
                    foreach (var el in info)
                    {
                        Console.WriteLine(el.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Brak brak dostepnego doktora o podanych wartosciach!");
                }
            }
            else
            {
                Console.WriteLine("Brak doktorow w klinice...");
            }
        }

        public void ArrangeThePactient()
        {
            Patient patient;
            Doctor doctor;
            int valuePatien;
            bool IsNumberPatient = false;
            bool workPatien = true;
            int valueDoctor;
            bool IsNumberDoctor = false;
            bool workDoctor = true;

            Console.WriteLine("Wybierz pacjenta ktorego chcesz zapisac: ");
            ShowPatient();
           
            do
            {
                Console.WriteLine("Wybierz numer pacjenta: ");
                string answer = Console.ReadLine();
                if(IsNumberPatient = int.TryParse(answer, out valuePatien) && (valuePatien > 0 && valuePatien <= patients.Count))
                {
                    workPatien = false;
                }
            } while (workPatien);

            patient = patients[valuePatien - 1];

            int day = CheackDay();
            int hour = CheackHour();

            List<Doctor> aviDoctros = IsDoctorFreeToday(day, hour);
            ShowDoctors(aviDoctros);

            do
            {
                Console.WriteLine("Wybierz numer doktora: ");
                string answer = Console.ReadLine();
                if (IsNumberDoctor = int.TryParse(answer, out valueDoctor) && (valueDoctor > 0 && valueDoctor <= doctors.Count))
                {
                    workDoctor = false;
                }
            } while (workDoctor);

            for(int i = 0; i < doctors.Count; i++)
            {
                bool isEqual = Enumerable.SequenceEqual(aviDoctros[valueDoctor-1].PESEL, doctors[i].PESEL);

                if(isEqual)
                {
                    List<WorkDay> workDays = doctors[i].GetDoctorAvailibity();
                    workDays[day].ChangeHourToBusy(hour);
                    doctors[i].SetDoctorAvailibity(workDays);
                    patients[valuePatien - 1].ListaZapisow.Add(doctors[i]);
                    patients[valuePatien - 1].ListaGodzinZapisow.Add(hour);
                    patients[valuePatien - 1].ListaDniZapisow.Add(day);

                    break;
                }
            }
           
            Console.WriteLine("Pacjent zostal umówiony na wizytę!");
        }

        public void ShowPatientVisits()
        {
            Console.WriteLine("Wybierz pacjenta ktorego wizyty chcesz wyswietlic: ");
            ShowPatient();
            int valuePatien;
            bool IsNumberPatient = false;
            bool workPatien = true;

            do
            {
                Console.WriteLine("Wybierz numer pacjenta: ");
                string answer = Console.ReadLine();
                if (IsNumberPatient = int.TryParse(answer, out valuePatien) && (valuePatien > 0 && valuePatien < patients.Count))
                {
                    workPatien = false;
                }
            } while (workPatien);

            if (patients[valuePatien - 1].ListaZapisow.Count >0)
            {
                for (int i = 0; i < patients[valuePatien - 1].ListaZapisow.Count; i++)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Doktor: ");
                    Console.WriteLine(patients[valuePatien - 1].ListaZapisow[i]);
                    ConvertNumberToDayAndShow(patients[valuePatien - 1].ListaDniZapisow[i]);
                    ConvertNumberToHourAndShow(patients[valuePatien - 1].ListaGodzinZapisow[i]);
                }
            }
            else
            {
                Console.WriteLine("BRAK WIZYT!");
            }
           
        }

        private void ConvertNumberToHourAndShow(int value)
        {
            value++;
           switch(value)
            {
                case 1:
                    Console.WriteLine("1) Godz: 8:00 - 9:00");
                    break;
                case 2:
                    Console.WriteLine("2) Godz: 9:00 - 10:00");
                    break;
                case 3:
                    Console.WriteLine("3) Godz: 10:00 - 11:00");
                    break;
                case 4:
                    Console.WriteLine("4) Godz: 11:00 - 12:00");
                    break;
                case 5:
                    Console.WriteLine("5) Godz: 12:00 - 13:00");
                    break;
                case 6:
                    Console.WriteLine("6) Godz: 13:00 - 14:00");
                    break;
                case 7:
                    Console.WriteLine("7) Godz: 14:00 - 15:00");
                    break;
                case 8:
                    Console.WriteLine("8) Godz: 15:00 - 16:00");
                    break;
            }
        }

        private void ConvertNumberToDayAndShow(int value)
        {
            value++;
            switch (value)
            {
                case 1:
                    Console.WriteLine("poniedzialek");
                    break;
                case 2:
                    Console.WriteLine("wtorek");
                    break;
                case 3:
                    Console.WriteLine("sroda");
                    break;
                case 4:
                    Console.WriteLine("czwartek");
                    break;
                case 5:
                    Console.WriteLine("piatek");
                    break;
            }
        }

        private bool ArgumentValidate(int day, int hour)
        {
            return (day >= 0 && day <= 4) && (hour >= 0 && hour <= 7);
        }

        public void ShowPatient()
        {
            int index = 1;
            for(int i = 0; i < patients.Count; i++)
            {
                Console.WriteLine(index + ") " + patients[i].ToString());
                index++;
            }
           
        }

        public void ShowDoctors(List<Doctor> doctors)
        {
            int index = 1;

            for (int i = 0; i < doctors.Count; i++)
            {
                Console.WriteLine(index + ") " + doctors[i].ToString());
                index++;
            }
        }
        public void ShowDoctors()
        {
            ShowDoctors(doctors);
        }

        public int CheackHour()
        {
            Console.WriteLine("1) Godz: 8:00 - 9:00");
            Console.WriteLine("2) Godz: 9:00 - 10:00");
            Console.WriteLine("3) Godz: 10:00 - 11:00");
            Console.WriteLine("4) Godz: 11:00 - 12:00");
            Console.WriteLine("5) Godz: 12:00 - 13:00");
            Console.WriteLine("6) Godz: 13:00 - 14:00");
            Console.WriteLine("7) Godz: 14:00 - 15:00");
            Console.WriteLine("8) Godz: 15:00 - 16:00");
            int choose = 0;
            string odp;
            do
            {
                odp = Console.ReadLine();
                choose = int.Parse(odp);
            } while (!(choose > 0 && choose < 9));

            return choose - 1; //odejmowanie ze wzgledu na dlugosc listy (podajemy element na pozycji 1 czyli chcemy pobrac element z pozycji 0)
        }

        public int CheackDay()
        {
            Console.WriteLine("1) poniedzialek");
            Console.WriteLine("2) wtorek");
            Console.WriteLine("3) sroda");
            Console.WriteLine("4) czwartek");
            Console.WriteLine("5) piatek");

            int choose = 0;
            string odp;
            do
            {
                odp = Console.ReadLine();
                choose = int.Parse(odp);
            } while (!(choose > 0 && choose < 6));

            return choose - 1;
        }
    }
}
