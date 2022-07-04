using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб7
{
    internal class Hashtable
    {
        public Entry[] table { get; set; }
        public int loadness { get; set; }
        public int size { get; set; }
        public Hashtable(Entry[] table, int loadness, int size)
        {
            this.table = table;
            this.loadness = loadness;
            this.size = size;
        }

        
    }
}
