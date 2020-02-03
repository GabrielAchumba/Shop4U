using Shop4U.Supermarkets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Services
{
    public interface IItemTypeRepository
    {
        Task<ItemType> Get(Guid Id);
        IEnumerable<ItemType> Get();
        Task<ItemType> Add(ItemType itemType);
        Task<ItemType> Update(ItemType itemType);
        Task<ItemType> Delete(Guid Id);
    }
}
