using MediatR;
using MobileStore.BuildingBlocks.Shared.Shared.Models.Results;
using MobileStore.Services.Catalog.Application.Commands.Category;
using MobileStore.Services.Catalog.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobileEntity = MobileStore.Services.Catalog.Domain.Entities.Mobile; 
namespace MobileStore.Services.Catalog.Application.Commands.Mobile
{
    public class CreateMobileCommand : IRequest<GResult>
    {
        [Required]
        public string Name { get; set; }

        public class Handler : IRequestHandler<CreateMobileCommand, GResult>
        {
            private readonly IMobileRepository _mobileRepository;
            public Handler(IMobileRepository mobileRepository)
            {
                _mobileRepository = mobileRepository;
            }
            public async Task<GResult> Handle(CreateMobileCommand request, CancellationToken cancellationToken)
            {
                var category = new MobileEntity.Mobile
                {
                    Name = request.Name
                };
                var result = await _mobileRepository.AddAsync(category);
                if (result != null)
                {
                    return GResult.Success;
                }
                return GResult.Failed();
            }
        }
    }
}