using System;

public class EventManager : BasicSingleton<EventManager>
{
    /*
     * Delegates
     */
    public event EventHandler<EventArgs> OnInitializeFighters;
    public event EventHandler<EventArgs> OnCreateNewFloor;
    public event EventHandler<EventArgs> OnResetTurnQueue;
    public void InitializeFighters() => OnInitializeFighters(this, new EmptyArgs());
    public void CreateNewFloor() => OnCreateNewFloor(this, new EmptyArgs());
    public void ResetTurnQueue() => OnResetTurnQueue(this, new EmptyArgs());
}
