using Microsoft.AspNetCore.Http;
using Shop4U_Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U_Frontend.ViewModels.Supermarkets
{
    public class CreateSupermarketVM
    {
        public CreateSupermarketVM()
        {
            PageTitle = "Shop4u | create supermarket";
        }

        public Guid Id { get; set; }
        public string PageTitle { get; set; }
        public string Heading { get; set; }
        public IFormFile Attachment { get; set; }
        public string FileLocation { get; set; }

        public string Name { get; set; }

        public byte[] BackgrounndPicture { get; set; }

        public string Description { get; set; }

        public string Base64String { get; set; }

        public Supermarket CreateSupermarket()
        {
            return new Supermarket()
            {
                Name = Name,
                BackgrounndPicture = BackgrounndPicture,
                Description = Description
            };
        }
    }
}
