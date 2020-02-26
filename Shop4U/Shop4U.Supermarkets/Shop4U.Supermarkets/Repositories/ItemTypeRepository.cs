using Shop4U.Supermarkets.Models;
using Shop4U.Supermarkets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Repositories
{
    public class ItemTypeRepository : IItemTypeRepository
    {
        private readonly SupermarketDbContext context;

        public async Task<ItemType> Add(ItemType itemType)
        {
           
            await context.ItemTypes.AddAsync(itemType);
            await context.SaveChangesAsync();
            return itemType;
        }

        public async Task<ItemType> Delete(Guid Id)
        {
            ItemType itemType = await context.ItemTypes.FindAsync(Id);
            if (itemType != null)
            {
                context.ItemTypes.Remove(itemType);
                await context.SaveChangesAsync();
            }
            return itemType;
        }

        public async Task<ItemType> Get(Guid Id)
        {
            return await context.ItemTypes.FindAsync(Id);
        }

        public IEnumerable<ItemType> Get()
        {
            IEnumerable<ItemType> _ItemTypes = context.ItemTypes;
            return _ItemTypes;
        }

        public async Task<ItemType> Update(ItemType itemType)
        {
            var _itemType = context.ItemTypes.Attach(itemType);
            _itemType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return itemType;
        }
    }
}
