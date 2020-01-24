using Clinic.Models;
using Clinic.Services;
using System.Collections.Generic;
using Clinic.Enums;
using System;

namespace Clinic
{
    class Program
    {
        #region ZMIENNE GLOBALNE
        private static string menuAnswer;
        private static bool WorkStatus = true;

        private static Random random = new Random();
        #endregion
        
        #region KOLEKCJE
        public static List<Doctor> doctors = new List<Doctor>();
        public static List<Patient> patients = new List<Patient>();
        public static List<WorkDay> workDays = new List<WorkDay>();
        #endregion

        static void Main(string[] args)
        {
            #region OTHER
            WorkDay work = new WorkDay();
            WorkDay offDay = new WorkDay();
            offDay.ChangeDayToBusy();
            workDays.Add(work);
            workDays.Add(offDay);
            workDays.Add(work);
            workDays.Add(work);
            workDays.Add(work);
            #endregion

            #region DOCTORS
            Doctor d1 = new Doctor("Kuba", "Rzucidło", RandomPESEL(), SpecjalizationEnum.Cardiologist);
            Doctor d2 = new Doctor("Kasia", "Tobuk", RandomPESEL(), SpecjalizationEnum.Laryngologist);
            Doctor d3 = new Doctor("Retek", "Rydzyk", RandomPESEL(), SpecjalizationEnum.Family);

            d2.SetDoctorAvailibity(workDays);

            doctors.Add(d1);
            doctors.Add(d2);
            doctors.Add(d3);
            #endregion

            #region PATIENTS
            Adress a1 = new Adress("Kwiatowa", "Raciąż", CountryCode.PL, "09-140");

            Patient p1 = new Patient("Maciej", "Hawrzyniak", RandomPESEL(), a1);
            Patient p2 = new Patient("Marta", "Kkrawa", RandomPESEL(), a1);
            Patient p3 = new Patient("John", "Akoczny", RandomPESEL(), a1);

            patients.Add(p1);
            patients.Add(p2);
            patients.Add(p3);
            #endregion

           

            ClinicService clinicService = new ClinicService(patients, doctors);

            while (WorkStatus)
            {
                clinicService = RefreshClinicService();


                ShowClinicMenu();
                menuAnswer = Console.ReadLine();
                switch(menuAnswer)
                {
                    case "1":
                        Console.Clear();
                        Patient patient = AddPatient();
                        patients.Add(patient);
                        break;
                    case "2":
                        Console.Clear();
                        if(patients.Count > 0)
                        {
                            Console.WriteLine("Podaj PESEL pacjenta: ");
                            clinicService.RemovePatient(GetPeselFromUser());
                            patients = clinicService.GetPatients();
                        }
                        else
                        {
                            Console.WriteLine("LISTA PACJENTOW JEST PUSTA!!");
                        }
                      
                        break;
                    case "3":
                        Console.Clear();
                        Doctor doctor = AddDoctor();
                        doctors.Add(doctor);
                        break;
                    case "4":
                        Console.Clear();
                        if (doctors.Count > 0)
                        {
                            Console.WriteLine("Podaj PESEL doktora: ");
                            clinicService.RemoveDoctor(GetPeselFromUser());
                            doctors = clinicService.GetDoctors();
                        }
                        else
                        {
                            Console.WriteLine("LISTA DOKTOROW JEST PUSTA!!");
                        }

                        break;
                    case "5":
                        Console.Clear();
                        if (patients.Count > 0)
                        {
                            clinicService.SortPatients();
                            patients = clinicService.GetPatients();
                            Console.WriteLine("----------------");
                            Console.WriteLine("PACJENCI ZOSTALI POSORTOWANI!!!");
                            Console.WriteLine("----------------");
                        }
                        else
                        {
                            Console.WriteLine("LISTA PACJENTOW JEST PUSTA!!");
                        }
                        break;
                    case "6":
                        Console.Clear();
                        clinicService.ShowPatient();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Podaj nazwisko pacjenta: ");
                        string surname = Console.ReadLine();
                        clinicService.SearchBySurname(surname);
                        break;
                    case "8":
                        Console.Clear();
                        int day = clinicService.CheackDay();
                        int hour = clinicService.CheackHour();
                        clinicService.ShowInfoAboutDoctors(day, hour);
                        break;
                    case "9":
                        Console.Clear();
                        clinicService.ArrangeThePactient();
                        patients = clinicService.GetPatients();
                        doctors = clinicService.GetDoctors();

                        break;
                    case "10":
                        Console.Clear();
                        clinicService.ShowDoctors();
                        break;
                    case "11":
                        Console.Clear();
                        clinicService.ShowPatientVisits();
                        break;
                    case "12":
                       
                        break;
                    case "13":
                        Console.Clear();
                        WorkStatus = false;
                        break;
                    default:
                        
                        break;
                }
            }
            EndProgramInfo();
        }

      

        public static void ShowClinicMenu()
        {
            Console.WriteLine("Menu przychodni");
            Console.WriteLine("1- Dodaj pacjenta");
            Console.WriteLine("2- Usuń pacjenta(relokacja/ śmierć)");
            Console.WriteLine("3- Dodaj doktora");
            Console.WriteLine("4- Usuń doktora(koniec współpracy)");
            Console.WriteLine("5- Posortuj pacjentów alfabetycznie");
            Console.WriteLine("6- Wyświetl wszystkich pacjentów");
            Console.WriteLine("7- Znajdź pacjenta po nazwisku");
            Console.WriteLine("8- Sprawdź dostępność doktora danego dnia o danej godzinie");
            Console.WriteLine("9- Umow pacjenta na wizyte");
            Console.WriteLine("10- Wyświetl wszystkich doktorów przyjmujących w tej przychodni");
            Console.WriteLine("11- Wyświetl wizyty pacjenta");
            Console.WriteLine("12- Zaraz bedzie zaimplementowane nie bojcie sie o mnie :)");
            Console.WriteLine("13- Zakończ");
            Console.Write("Podaj numer: ");
        }

        private static ClinicService RefreshClinicService()
        {
            return new ClinicService(patients, doctors);
        }

        public static Patient AddPatient()
        {
            Console.WriteLine("Podaj imie pacjenta: ");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko pacjenta: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Podaj PESEL pacjenta: ");
            int[] PESEL = GetPeselFromUser();

            Console.WriteLine("Podaj ulice pacjenta: ");
            string street = Console.ReadLine();

            Console.WriteLine("Podaj miasto pacjenta: ");
            string city = Console.ReadLine();

            Console.WriteLine("Wybierz county code: ");
            CountryCode cc = CountryCode.ERR;

           
            ShowCountryCode();
            cc = GetCountryCode();
            

            Console.WriteLine("Podaj kod pocztowy: ");
            string postalCode = Console.ReadLine();


            Adress adress = new Adress(street, city, cc, postalCode);

            return new Patient(name, surname, PESEL, adress);
        }

        private static Doctor AddDoctor()
        {
            Console.WriteLine("Podaj imie doktora: ");
            string name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko doktora: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Podaj PESEL doktora: ");
            int[] PESEL = GetPeselFromUser();

            Console.WriteLine("Podaj SPECJALIZACJE doktora: ");
            SpecjalizationEnum specka;
            
            ShowSpecialization();
            specka = GetSpecialization();
            


            return new Doctor(name, surname, PESEL, specka);
        }

        private static int[] GetPeselFromUser()
        {
            string pesel = Console.ReadLine();
            int[] PESEL = new int[10];
            for (int i = 0; i < 10; i++)
            {
                PESEL[i] = int.Parse(pesel[i].ToString());
            }

            return PESEL;
        }

        private static CountryCode GetCountryCode()
        {
            bool work = true;
            int value;
            do
            {
                string spec = Console.ReadLine();

                bool IsNumberPatient = int.TryParse(spec, out value);
                if (IsNumberPatient)
                {
                    work = false;
                }
            } while (work);


            switch (value)
            {
                case 1:
                    return CountryCode.PL;
                case 2:
                    return CountryCode.IT;
                case 3:
                    return CountryCode.ENG;
                case 4:
                    return CountryCode.CA;
                case 5:
                    return CountryCode.BR;
                default:
                    return CountryCode.ERR;
            }
        }
        private static void ShowCountryCode()
        {
            Console.WriteLine("DOSTEPNE COUNTRY CODE: ");
            Console.WriteLine("1) PL");
            Console.WriteLine("2) IT");
            Console.WriteLine("3) ENG");
            Console.WriteLine("4) CA");
            Console.WriteLine("5) BR");
        }

        private static SpecjalizationEnum GetSpecialization()
        {
            bool work = true;
            int value;
            do
            {
                string spec = Console.ReadLine();
              
                bool IsNumberPatient = int.TryParse(spec, out value);
                if(IsNumberPatient)
                {
                    work = false;
                }
            } while (work);

            switch (value)
            {   
                case 1:
                    return SpecjalizationEnum.Family;
                case 2:
                    return SpecjalizationEnum.Laryngologist;
                case 3:
                    return SpecjalizationEnum.Cardiologist;
                default:
                    return SpecjalizationEnum.ERR;
            }
        }

        private static void ShowSpecialization()
        {
            Console.WriteLine("DOSTEPNE SPECJALIZACJE: ");
            Console.WriteLine("1) Family");
            Console.WriteLine("2) Laryngologist");
            Console.WriteLine("3) Cardiologist");
        }

       
        public static void EndProgramInfo()
        {
            Console.WriteLine("PROGRAM ZAKONCZYL SWOJE DZIALANIE! COPYRIGHT BY MARTA SKWARA!");
            Console.ReadLine();
        }

        public static int[] RandomPESEL()
        {
            int[] pesel = new int[10];
            for(int i = 0; i < 10; i++)
            {
                pesel[i] = random.Next(1, 9);
            }

            return pesel;
        }
    }
}
