using System;

public class EventManager : BasicSingleton<EventManager>
{
    /*
     * Delegates
     */
    public event EventHandler<EventArgs> OnInitializeFighters;
    public event EventHandler<EventArgs> OnCreateNewFloor;
    public event EventHandler<EventArgs> OnResetTurnQueue;
    public void InitializeFighters(object sender, EventArgs eventArgs) => OnInitializeFighters(sender, eventArgs);
    public void CreateNewFloor(object sender, EventArgs eventArgs) => OnCreateNewFloor(sender, eventArgs);
    public void ResetTurnQueue(object sender, EventArgs eventArgs) => OnResetTurnQueue(sender, eventArgs);
}
