using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop4U.Supermarkets.Models;

namespace Shop4U.Supermarkets.Services
{
    public interface IItemPriceRepository
    {
        Task<ItemPrice> Get(Guid Id);
        IEnumerable<ItemPrice> Get();
        Task<ItemPrice> Add(ItemPrice itemPrice);
        Task<ItemPrice> Update(ItemPrice itemPrice);
        Task<ItemPrice> Delete(Guid Id);
    }
}
