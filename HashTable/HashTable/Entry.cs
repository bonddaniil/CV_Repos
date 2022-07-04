using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    internal class Entry
    {
        public Key key;
        public Value value;
        public Entry next;

        public Entry (Key key, Value value)
        {
            this.key = key;
            this.value = value;
        }

        public Entry(Key key, Value value, Entry next)
        {
            this.key = key;
            this.value = value;
            this.next = next;
        }
    }
}
