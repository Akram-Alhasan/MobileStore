using MobileStore.BuildingBlocks.Shared.Shared.EntityParent;
using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Services.Catalog.Domain.Entities.Mobile
{
    public class Mobile : EntityParent, IAggregateRoot
    {

        public string Name { get; set; }

        public string Price { get; set; }

        public Guid MobileAttributeId { get; set; }

        public MobileAttribute MobileAttribute { get; set; }

        public Guid CategoryId { get; set; }

    }
}