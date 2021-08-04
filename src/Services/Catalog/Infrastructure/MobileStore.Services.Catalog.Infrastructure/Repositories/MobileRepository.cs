using Microsoft.EntityFrameworkCore;
using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using MobileStore.Services.Catalog.Domain.Entities.Mobile;
using MobileStore.Services.Catalog.Domain.Interfaces.IRepositories;
using MobileStore.Services.Catalog.Infrastructure.ServiceDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.Infrastructure.Repositories
{
    public class MobileRepository : IMobileRepository
    {
        private readonly CatalogDbContext _context; 

        public MobileRepository(CatalogDbContext context)
        {
            _context = context; 
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context; 
            }
        }

        public async Task<Mobile> AddAsync(Mobile mobile)
        {
            var result = _context.Mobiles
                .Add(mobile)
                .Entity;
            await _context.SaveChangesAsync();
            return result; 
        }

        public async Task<List<Mobile>> FindAllAsync()
        {
            var result = await _context.Mobiles.ToListAsync();
            return result; 
        }

        public Task<Mobile> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Mobile Update(Mobile mobile)
        {
            throw new NotImplementedException();
        }
    }
}
