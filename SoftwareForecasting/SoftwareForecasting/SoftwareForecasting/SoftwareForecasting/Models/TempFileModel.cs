using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareForecasting.Models
{
    public class TempFileModel
    {
        public TempFileModel()
        {
            id = Guid.NewGuid();
        }
        public Guid id { get; set; }
        public string FilePath { get; set; }
        public List<InputDeck> InputDecks { get; set; }
    }
}
