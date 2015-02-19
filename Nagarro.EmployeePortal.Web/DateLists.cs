using System;
using System.Collections.Generic;

namespace Nagarro.EmployeePortal.Web
{
    /// <summary>
    /// class containing list of days, months and years
    /// </summary>
    public class DateLists
    {
        /// <summary>
        /// List used to store days
        /// </summary>
        private List<int> dayList = new List<int>();

        /// <summary>
        /// List used to store months
        /// </summary>
        private List<string> monthList = new List<string>() 
        { 
             "January", "Ferbuary", "March", "April", "May", "June", "July",
             "August", "September", "October", "November", "December"
        };

        /// <summary>
        /// List used to store years
        /// </summary>
        private List<int> yearList = new List<int>();

        /// <summary>
        /// Initializes a new instance of the DateLists class
        /// </summary>
        public DateLists()
        {
            // adds years from 1950 onwards into the year list
            for (int year = DateTime.Now.Year; year >= 1950; year--)
            {
                this.yearList.Add(year);
            }

            // adds 31 days in the day list
            for (int day = 1; day <= 31; day++)
            {
                this.dayList.Add(day);
            }
        }

        /// <summary>
        /// Gets the yearlist
        /// </summary>
        public List<int> YearList
        {
            get
            {
                return this.yearList;
            }
        }

        /// <summary>
        /// Gets the monthlist
        /// </summary>
        public List<string> MonthList
        {
            get
            {
                return this.monthList;
            }
        }

        /// <summary>
        /// Gets the daylist 
        /// </summary>
        public List<int> DayList
        {
            get
            {
                return this.dayList;
            }
        }
    }
}
