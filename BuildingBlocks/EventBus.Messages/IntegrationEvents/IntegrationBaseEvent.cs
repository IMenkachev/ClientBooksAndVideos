namespace EventBus.Messages.IntegrationEvents
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent(Guid id) 
        { 
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
