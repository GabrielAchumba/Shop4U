using Shop4U.Supermarkets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Services
{
    public interface ISupermarketRepository
    {
        Task<Supermarket> Get(Guid Id);
        IEnumerable<Supermarket> Get();
        Task<Supermarket> Add(Supermarket supermarket);
        Task<Supermarket> Update(Supermarket supermarket);
        Task<Supermarket> Delete(Guid Id);
    }
}
