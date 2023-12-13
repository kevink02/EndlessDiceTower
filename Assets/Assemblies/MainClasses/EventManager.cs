using System;

public class EventManager : BasicSingleton<EventManager>
{
    /*
     * Delegates
     */
    // Floor delegates
    public event EventHandler<EventArgs> OnInitializeFighters;
    public event EventHandler<EventArgs> OnCreateNewFloor;
    public event EventHandler<EventArgs> OnResetTurnQueue;
    public void InitializeFighters() => OnInitializeFighters(this, new EmptyArgs());
    public void CreateNewFloor() => OnCreateNewFloor(this, new EmptyArgs());
    public void ResetTurnQueue() => OnResetTurnQueue(this, new EmptyArgs());

    // Fighter delegates
    public event EventHandler<EventArgs> OnAttackStart;
    public event EventHandler<EventArgs> OnTurnStart;
    public void StartAttack() => OnAttackStart?.Invoke(this, new EmptyArgs());
    public void StartTurn() => OnTurnStart?.Invoke(this, new EmptyArgs());
}
