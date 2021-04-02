using MediatR;
using MobileStore.BuildingBlocks.Shared.Shared.Models.Results;
using MobileStore.Services.Catalog.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CategoryEntity = MobileStore.Services.Catalog.Domain.Entities.Category;
namespace MobileStore.Services.Catalog.Application.Commands.Category
{
    public class CreateCategoryCommand : IRequest<GResult>
    {
        [Required]
        public string Name { get; set; }
        public class Handler : IRequestHandler<CreateCategoryCommand, GResult>
        {
            private readonly ICategoryRepository _categoryRepository;
            public Handler(ICategoryRepository categoryRepository)
            {
                _categoryRepository = categoryRepository; 
            }
            public async Task<GResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new CategoryEntity.Category
                {
                    Name = request.Name 
                };
                var result = await _categoryRepository.AddAsync(category);
                if(result != null)
                {
                    return GResult.Success; 
                }
                return GResult.Failed();
            }
        }
    }
}
