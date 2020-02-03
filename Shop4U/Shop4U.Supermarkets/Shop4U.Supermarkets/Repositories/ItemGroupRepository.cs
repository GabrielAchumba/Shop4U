using Shop4U.Supermarkets.Models;
using Shop4U.Supermarkets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Repositories
{
    public class ItemGroupRepository : IItemGroupRepository
    {
        private readonly SupermarketDbContext context;

        public async Task<ItemGroup> Add(ItemGroup itemGroup)
        {
            if (itemGroup.Id == null) itemGroup.Id = Guid.NewGuid();
            await context.ItemGroups.AddAsync(itemGroup);
            await context.SaveChangesAsync();
            return itemGroup;
        }

        public async Task<ItemGroup> Delete(Guid Id)
        {
            ItemGroup itemGroup = await context.ItemGroups.FindAsync(Id);
            if (itemGroup != null)
            {
                context.ItemGroups.Remove(itemGroup);
                await context.SaveChangesAsync();
            }
            return itemGroup;
        }

        public async Task<ItemGroup> Get(Guid Id)
        {
            return await context.ItemGroups.FindAsync(Id);
        }

        public IEnumerable<ItemGroup> Get()
        {
            IEnumerable<ItemGroup> _itemGroups = context.ItemGroups;
            return _itemGroups;
        }

        public async Task<ItemGroup> Update(ItemGroup itemGroup)
        {
            var _itemGroup = context.ItemGroups.Attach(itemGroup);
            _itemGroup.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return itemGroup;
        }
    }
}
