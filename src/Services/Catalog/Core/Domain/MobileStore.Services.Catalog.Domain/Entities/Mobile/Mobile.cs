using MobileStore.BuildingBlocks.Shared.Shared.EntityParent;
using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using CategoryEntity = MobileStore.Services.Catalog.Domain.Entities.Category.Category; 

namespace MobileStore.Services.Catalog.Domain.Entities.Mobile
{
    public class Mobile : EntityParent, IAggregateRoot
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<MobileAttribute> MobileAttribute { get; set; }


        public Guid CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

    }
}