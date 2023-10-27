using System.Collections.Generic;
using UnityEngine;

public class TurnManager : BasicSingleton<TurnManager>, IManager, ISingletonUser
{
    /*
     * Instance variables
     */
    private Queue<DiceFighter> _fighterTurnQueue;


    /*
     * Delegates
     */
    // public static event Action<DiceFighter> SetupTurnQueue;


    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();

        /*
         * Initialize instance variables
         */
        _fighterTurnQueue = new Queue<DiceFighter>();
    }

    private void Start()
    {
    }


    /*
     * Interface methods
     */
    public void ExecuteState()
    {
        throw new System.NotImplementedException();
    }

    public void NextState()
    {
        throw new System.NotImplementedException();
    }

    public void ResetState()
    {
        throw new System.NotImplementedException();
    }

    public ISingletonUser GetSingletonInstance()
    {
        return BasicSingleton<TurnManager>.Instance;
    }

    public void SetSingletonInstance()
    {
        BasicSingleton<TurnManager>.Instance = this;
    }
}
