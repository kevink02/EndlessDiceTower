/// <summary>
/// To be used as a parameter in EventHandlers
/// </summary>
public abstract class EventArgs
{
}

public class DummyArgs : EventArgs
{
}

public class IndexArgs : EventArgs
{
    /*
     * Properties
     */
    public int Index { get; private set; }


    /*
     * Constructors
     */
    public IndexArgs(int index)
    {
        Index = index;
    }
}
