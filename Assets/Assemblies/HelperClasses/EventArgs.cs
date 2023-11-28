/// <summary>
/// To be used as a parameter in EventHandlers
/// </summary>
public abstract class EventArgs
{
}

public class DummyArgs : EventArgs
{
    public string TestVar;
}
