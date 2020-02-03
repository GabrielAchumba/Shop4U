using Shop4U.Supermarkets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Services
{
    public interface IItemCartegoryRepository
    {
        Task<ItemCartegory> Get(Guid Id);
        IEnumerable<ItemCartegory> Get();
        Task<ItemCartegory> Add(ItemCartegory itemCartegory);
        Task<ItemCartegory> Update(ItemCartegory itemCartegory);
        Task<ItemCartegory> Delete(Guid Id);
    }
}
