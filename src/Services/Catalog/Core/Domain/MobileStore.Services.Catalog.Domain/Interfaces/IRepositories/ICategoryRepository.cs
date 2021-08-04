using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.Domain.Interfaces.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> AddAsync(Category buyer);
        Category Update(Category buyer);
        Task<List<Category>> FindAllAsync();
        Task<Category> FindByIdAsync(string id);
    }
}
