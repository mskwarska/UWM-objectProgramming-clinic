using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Models
{
    class WorkDay
    {
        public bool[] day = new bool [8];

        public WorkDay()
        {
            for(int i = 0; i < 8; i++)
            {
                day[i] = true;
            }
        }

        public void ChangeHourToBusy(int hour) //Mozna dodac WorkDayValidate ktory bedzie badal te dodawanie narazie to jest w jednym set:)
        {
            if(hour>=0 && hour<= 7)
            {
                if(day[hour] == true)
                {
                    day[hour] = false;
                } 
                else
                {
                    Console.WriteLine("TA GODZINA JEST JUZ ZAREZERWOWANA!!!");
                }
            } 
            else
            {
                Console.WriteLine("BLEDNY PRZEZDIAL GODZIN!!!");
            }
        }

        public bool IsFreeHour(int hour)
        {
            return (day[hour] == true);
        }
    }
}
