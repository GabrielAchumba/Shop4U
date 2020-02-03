using Shop4U.Supermarkets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Services
{
    public interface IItemGroupRepository
    {
        Task<ItemGroup> Get(Guid Id);
        IEnumerable<ItemGroup> Get();
        Task<ItemGroup> Add(ItemGroup itemGroup);
        Task<ItemGroup> Update(ItemGroup itemGroup);
        Task<ItemGroup> Delete(Guid Id);
    }
}
