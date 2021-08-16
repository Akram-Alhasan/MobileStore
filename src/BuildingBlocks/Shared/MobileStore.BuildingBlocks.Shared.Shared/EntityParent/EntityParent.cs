using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.BuildingBlocks.Shared.Shared.EntityParent
{
    public class EntityParent
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now; 

        public DateTime? UpdatedAt { get; set; }
    }
}
