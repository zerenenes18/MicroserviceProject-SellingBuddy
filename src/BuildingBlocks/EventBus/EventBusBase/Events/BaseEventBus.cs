using EventBusBase.Abstraction;
using EventBusBase.SubManager;

namespace EventBusBase.Events
{
    public abstract class BaseEventBus : IEventBus
    {
        public readonly IEventBus ServiceProvider;
        public readonly IEventBusSubscriptionManager SubsManager;


        private EventBusConfig eventBusConfig;
        public BaseEventBus(EventBusConfig config, IServiceProvider serviceProvider)
        {
            eventBusConfig = config;
            ServiceProvider = serviceProvider;
            SubsManager = new InMemoryEventBusSubscriptionManager(ProcessEventName);
        }

        public virtual string ProcessEventName(string eventName)
        {
            if (eventBusConfig.DeleteEventPrefix)
                eventName = eventName.TrimStart(eventBusConfig.EventNamePrefix.ToArray());
            if (eventBusConfig.DeleteEventSuffix)
                eventName = eventName.TrimEnd(eventBusConfig.EventNameSuffix.ToArray());

            return eventName;

        }

        public virtual string GetSubName(string eventName)
        {
            return ($"{eventBusConfig.SubscriberClientAppName}.{ProcessEventName(eventName)}");
        }

        public virtual void Dispose()
        {
            eventBusConfig = null;
        }

        public async Task<bool> ProcessEvent(string eventName, string message)
        {
            eventName = ProcessEventName(eventName);

            var proccess = false;

            if (SubsManager.HasSubscriptionForEvent(eventName))
            {
                var subscriptions = SubsManager.GetHandlersForEvent(eventName);

                using (var scope = ServiceProvider.CreateScope()) ;
            }
        }








        public void Publish(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }

        public void UnSubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}
