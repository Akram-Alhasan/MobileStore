using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using MobileStore.Services.Catalog.Domain.Interfaces.IRepositories;
using MobileStore.Services.Catalog.Infrastructure.ServiceDbContext;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDbContext _context;

        public CategoryRepository(CatalogDbContext context)
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
        public async Task<Category> AddAsync(Category category)
        {
            var result =  _context.Categories
                   .Add(category)
                   .Entity;
            await _context.SaveChangesAsync();
            return result; 
        }

        public Task<Category> FindAsync(string BuyerIdentityGuid)
        {
            throw new NotImplementedException();
        }

        public Task<Category> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category buyer)
        {
            throw new NotImplementedException();
        }
    }
}
