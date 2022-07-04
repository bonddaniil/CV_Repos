using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    internal struct Date
    {
        public int year { get;}
        public int month { get;}
        public int day { get;}

        public Date(int year, int month, int day) 
        {
            this.year = year; 
            this.month = month; 
            this.day = day;
        }  
    }
}
