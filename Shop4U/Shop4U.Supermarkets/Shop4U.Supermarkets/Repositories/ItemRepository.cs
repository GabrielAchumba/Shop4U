using Shop4U.Supermarkets.Models;
using Shop4U.Supermarkets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly SupermarketDbContext context;
        public async Task<Item> Add(Item item)
        {
           
            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> Delete(Guid Id)
        {
            Item item = await context.Items.FindAsync(Id);
            if (item != null)
            {
                context.Items.Remove(item);
                await context.SaveChangesAsync();
            }
            return item;
        }

        public async Task<Item> Get(Guid Id)
        {
            return await context.Items.FindAsync(Id);
        }

        public IEnumerable<Item> Get()
        {
            IEnumerable<Item> _Items = context.Items;
            return _Items;
        }

        public async Task<Item> Update(Item item)
        {
            var _item = context.Items.Attach(item);
            _item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return item;
        }
    }
}
