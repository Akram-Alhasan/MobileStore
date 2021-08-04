using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using MobileStore.Services.Catalog.Domain.Entities.Mobile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.Domain.Interfaces.IRepositories
{
    public interface IMobileRepository : IRepository<Mobile>
    {
        Task<Mobile> AddAsync(Mobile mobile);
        Mobile Update(Mobile mobile);
        Task<List<Mobile>> FindAllAsync();
        Task<Mobile> FindByIdAsync(string id);
    }
}
