using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WireFrame.Data
{
    public class StudentRecord
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName {get; set; }

        public int CalendarYear { get; set; }

        public int SemesterNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
