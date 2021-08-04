using MediatR;
using MobileStore.BuildingBlocks.Shared.Shared.Models.Results;
using MobileStore.Services.Catalog.Domain.Entities.Category;
using MobileStore.Services.Catalog.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileStore.Services.Catalog.Application.Queries
{
    public class FindAllQuery : IRequest<GResult<List<Category>>>
    {
        public class Handler : IRequestHandler<FindAllQuery, GResult<List<Category>>>
        {
            private readonly ICategoryRepository _categoryRepository;
            public Handler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository;
            }
            public async Task<GResult<List<Category>>> Handle(FindAllQuery request, CancellationToken cancellationToken)
            {
                var result = await _categoryRepository.FindAllAsync();
                if (result != null)
                {
                    return GResult<List<Category>>.Success(result);
                }
                return GResult<List<Category>>.Failed();
            }
        }
    }
}