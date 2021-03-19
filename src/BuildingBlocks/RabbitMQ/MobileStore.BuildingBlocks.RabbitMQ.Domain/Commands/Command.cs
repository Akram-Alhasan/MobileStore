
using MobileStore.BuildingBlocks.RabbitMQ.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.BuildingBlocks.RabbitMQ.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set;  }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
