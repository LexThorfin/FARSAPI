using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class US_States
    {
        public US_States()
        {

        }
        public US_States(string? id, string? state)
        {
            ID = id;
            State = state;
        }
        public string? ID { get; set; }
        public string? State { get; set; }
    }
}
