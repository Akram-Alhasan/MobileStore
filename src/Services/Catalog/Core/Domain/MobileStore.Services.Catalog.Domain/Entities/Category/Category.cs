using MobileStore.BuildingBlocks.Shared.Shared.EntityParent;
using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Services.Catalog.Domain.Entities.Category
{
    public class Category : EntityParent , IAggregateRoot
    {
  
        public string Name { get; set; }



    }
}
