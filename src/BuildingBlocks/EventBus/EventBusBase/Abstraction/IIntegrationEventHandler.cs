using EventBusBase.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusBase.Abstraction
{
    public interface IIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent: IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
     
    }

    public interface IIntegrationEventHandler
    {


    }
}
