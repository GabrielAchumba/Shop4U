using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public byte[] BackgrounndPicture { get; set; }

        public string Description { get; set; }
    }
}
