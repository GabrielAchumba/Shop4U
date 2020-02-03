using Shop4U.Supermarkets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Services
{
    public interface IItemRepository
    {
        Task<Item> Get(Guid Id);
        IEnumerable<Item> Get();
        Task<Item> Add(Item item);
        Task<Item> Update(Item item);
        Task<Item> Delete(Guid Id);
    }
}
