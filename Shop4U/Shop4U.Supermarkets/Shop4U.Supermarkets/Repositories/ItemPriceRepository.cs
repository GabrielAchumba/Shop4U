using Shop4U.Supermarkets.Models;
using Shop4U.Supermarkets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Repositories
{
    public class ItemPriceRepository : IItemPriceRepository
    {
        private readonly SupermarketDbContext context;

        public async Task<ItemPrice> Add(ItemPrice itemPrice)
        {
            await context.ItemPrices.AddAsync(itemPrice);
            await context.SaveChangesAsync();
            return itemPrice;
        }

        public async Task<ItemPrice> Delete(Guid Id)
        {
            ItemPrice itemPrice = await context.ItemPrices.FindAsync(Id);
            if (itemPrice != null)
            {
                context.ItemPrices.Remove(itemPrice);
                await context.SaveChangesAsync();
            }
            return itemPrice;
        }

        public async Task<ItemPrice> Get(Guid Id)
        {
            return await context.ItemPrices.FindAsync(Id);
        }

        public IEnumerable<ItemPrice> Get()
        {
            IEnumerable<ItemPrice> ItemPrices = context.ItemPrices;
            return ItemPrices;
        }

        public async Task<ItemPrice> Update(ItemPrice itemPrice)
        {
            var _itemPrice = context.ItemPrices.Attach(itemPrice);
            _itemPrice.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return itemPrice;
        }
    }
}
