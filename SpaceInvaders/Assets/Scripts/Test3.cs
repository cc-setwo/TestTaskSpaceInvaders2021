using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpaceInvaders.Game
{
    public class Test3 : MonoBehaviour
    {
        private void Start()
        {
            Debug.LogError(solution(2014, "April", "May", "Wednesday"));
        }

        private readonly List<string> months = new List<string>
        {
            "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
            "November", "December"
        };

        private readonly List<string> days = new List<string> {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

        public int solution(int Y, string A, string B, string W)
        {
            VacationCalendar calendar = new VacationCalendar(days.IndexOf(W), Y);

            int startMonthIndex = months.IndexOf(A);
            int endMonthIndex = months.IndexOf(B);

            while (calendar.MonthIndex != startMonthIndex || !string.Equals(days[calendar.DayOfMonthIndex],
                "Monday", StringComparison.OrdinalIgnoreCase))
            {
                calendar.UpdateCalendar();
            }

            int numDaysSpent = 0;
            while (calendar.MonthIndex <= endMonthIndex)
            {
                numDaysSpent++;
                calendar.UpdateCalendar();
            }


            return numDaysSpent / 7;
        }

        class VacationCalendar
        {
            public int MonthIndex => month;
            public int DayOfMonthIndex => dayOfYear;
            
            private int day, month, year;
            private int dayOfYear;
            private static readonly int[] numDays = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

            public VacationCalendar(int dayOfYear, int year)
            {
                day = 1;
                month = 0;
                this.year = year;
                this.dayOfYear = dayOfYear;
            }
            
            public void UpdateCalendar()
            {
                dayOfYear = (dayOfYear + 1) % 7;
                day++;
                int maxDaysInMonth = GetDays(month, year);

                if (day <= maxDaysInMonth)
                {
                    return;
                }
                
                day = 1;
                month++;
                
                if (month <= 12)
                {
                    return;
                }
                
                month = 0;
                year++;
            }

            public override string ToString()
            {
                return "MyCalendar [nday: " + day + "nmonth: " + month + "nyear: " + year + "ndayOfYear: " + dayOfYear + "]";
            }

            private bool IsLeapYear(int yearToCheck)
            {
                return yearToCheck % 4 == 0 && yearToCheck % 100 != 0 || yearToCheck % 400 == 0;
            }

            private int GetDays(int monthToCheck, int yearToCheck)
            {
                if (IsLeapYear(yearToCheck) && monthToCheck == 1)
                {
                    return numDays[monthToCheck] + 1;
                }

                return numDays[monthToCheck];
            }
        }
    }
}