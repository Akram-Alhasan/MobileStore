
using MobileStore.BuildingBlocks.RabbitMQ.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.BuildingBlocks.RabbitMQ.Domain.Bus
{
    public interface IEventHandler <in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);

    }
    public interface IEventHandler
    {

    }
}
