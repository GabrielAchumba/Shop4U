using Shop4U.Supermarkets.Models;
using Shop4U.Supermarkets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Repositories
{
    public class ItemCartegoryRepository : IItemCartegoryRepository
    {
        private readonly SupermarketDbContext context;
        public async Task<ItemCartegory> Add(ItemCartegory itemCartegory)
        {
            
            await context.ItemCartegories.AddAsync(itemCartegory);
            await context.SaveChangesAsync();
            return itemCartegory;
        }

        public async Task<ItemCartegory> Delete(Guid Id)
        {
            ItemCartegory itemCartegory = await context.ItemCartegories.FindAsync(Id);
            if (itemCartegory != null)
            {
                context.ItemCartegories.Remove(itemCartegory);
                await context.SaveChangesAsync();
            }
            return itemCartegory;
        }

        public async Task<ItemCartegory> Get(Guid Id)
        {
            return await context.ItemCartegories.FindAsync(Id);
        }

        public IEnumerable<ItemCartegory> Get()
        {
            IEnumerable<ItemCartegory> _itemCartegories = context.ItemCartegories;
            return _itemCartegories;
        }

        public async Task<ItemCartegory> Update(ItemCartegory itemCartegory)
        {
            var _itemCartegory = context.ItemCartegories.Attach(itemCartegory);
            _itemCartegory.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return itemCartegory;

        }
    }
}
