using MobileStore.BuildingBlocks.Shared.Shared.EntityParent;
using MobileStore.BuildingBlocks.Shared.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Services.Catalog.Domain.Entities.Mobile
{
    public class MobileAttribute : EntityParent, IAggregateRoot
    {

        public string Key { get; set; }

        public string Value { get; set; }

        public Guid MobileId { get; set; }

        public Mobile Mobile { get; set; }

    }
}