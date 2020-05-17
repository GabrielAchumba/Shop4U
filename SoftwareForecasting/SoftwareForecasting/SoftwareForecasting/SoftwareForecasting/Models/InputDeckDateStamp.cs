using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Models
{
    public class InputDeckDateStamp
    {
        public InputDeckDateStamp()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string InputDeckName { get; set; }
        public string DateOfCreation { get; set; }

        public override string ToString()
        {
            return InputDeckName;
        }
    }
}
