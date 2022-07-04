using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    internal class DLNode
    {
        public int grade;
        public string disciplineName;
        public DLNode next;

        public DLNode(string disciplineName, int grade)
        {
            this.grade = grade;
            this.disciplineName = disciplineName;
        }

        public DLNode(string disciplineName, int grade, DLNode next)
        {
            this.grade = grade;
            this.disciplineName = disciplineName;
            this.next = next;
        }

    }
}
