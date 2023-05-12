namespace EventDriven.MessageBus;

public abstract class Event
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}