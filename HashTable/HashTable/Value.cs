using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    internal class Value
    {
        public string studentId { get; }
        public Date birthDate { get; }
        public string address { get; }
        public int yearOfEntry { get; }
        public LinkedList disciplines { get; }
        public double avarageGarde { get; }

        public Value(string studentId, Date birthDate, string address, int yearOfEntry, LinkedList disciplines, double avarageGarde)
        {
            this.studentId = studentId;
            this.birthDate = birthDate;
            this.address = address;
            this.yearOfEntry = yearOfEntry;
            this.disciplines = disciplines;
            this.avarageGarde = avarageGarde;
        }

    }
}
