using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Fastfoods.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public byte[] BackgrounndPicture { get; set; }

        public string Description { get; set; }

        public string Base64String { get; set; }
    }
}
