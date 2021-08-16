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

        [Required]
        public Guid CategoryId { get; set; }

        public Dictionary<string, string> Attributes { get; set; } 
        public class Handler : IRequestHandler<CreateMobileCommand, GResult>
        {
            private readonly IMobileRepository _mobileRepository;
            public Handler(IMobileRepository mobileRepository)
            {
                _mobileRepository = mobileRepository;
            }
            public async Task<GResult> Handle(CreateMobileCommand request, CancellationToken cancellationToken)
            {
                var mobile = new MobileEntity.Mobile
                {
                    Name = request.Name,
                    CategoryId = request.CategoryId
                };
                var attributes = new List<MobileEntity.MobileAttribute>();
                foreach(var attr in request.Attributes)
                {
                    attributes.Add(new MobileEntity.MobileAttribute { Key = attr.Key, Value = attr.Value, MobileId = mobile.Id});
                }
                mobile.MobileAttribute = attributes; 

                
                
                var result = await _mobileRepository.AddAsync(mobile);
                if (result != null)
                {
                    return GResult.Success;
                }
                return GResult.Failed();
            }
        }
    }
}