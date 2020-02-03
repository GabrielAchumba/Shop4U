using Shop4U.Supermarkets.Models;
using Shop4U.Supermarkets.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop4U.Supermarkets.Repositories
{
    public class SupermarketRepository : ISupermarketRepository
    {
        private readonly SupermarketDbContext context;
        public async Task<Supermarket> Add(Supermarket supermarket)
        {
            if (supermarket.Id == null) supermarket.Id = Guid.NewGuid();
            await context.Supermarkets.AddAsync(supermarket);
            await context.SaveChangesAsync();
            return supermarket;
        }

        public async Task<Supermarket> Delete(Guid Id)
        {
            Supermarket supermarket = await context.Supermarkets.FindAsync(Id);
            if (supermarket != null)
            {
                context.Supermarkets.Remove(supermarket);
                await context.SaveChangesAsync();
            }
            return supermarket;
        }

        public async Task<Supermarket> Get(Guid Id)
        {
            return await context.Supermarkets.FindAsync(Id);
        }

        public IEnumerable<Supermarket> Get()
        {
            IEnumerable<Supermarket> _Supermarkets = context.Supermarkets;
            return _Supermarkets;
        }

        public async Task<Supermarket> Update(Supermarket supermarket)
        {
            var _supermarket = context.Supermarkets.Attach(supermarket);
            _supermarket.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return supermarket;
        }
    }
}
