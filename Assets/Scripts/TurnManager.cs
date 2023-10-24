using System;
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
        Debug.Log($"{name}: Before Turn Manager Singleton: {BasicSingleton<TurnManager>.Instance}");
        Debug.Log($"{name}: Before Floor Manager Singleton: {BasicSingleton<FloorManager>.Instance}");
        if (name.Equals("TurnManager"))
        {
            GameObject temp = new GameObject("TestingTurnManager");
            temp.AddComponent<TurnManager>().SetSingletonInstance();
        }
        Debug.Log($"{name}: After Turn Manager Singleton: {BasicSingleton<TurnManager>.Instance}");
        Debug.Log($"{name}: After Floor Manager Singleton: {BasicSingleton<FloorManager>.Instance}");
    }


    /*
     * Interface methods
     */
    public void ExecuteState()
    {
        throw new NotImplementedException();
    }

    public void NextState()
    {
        throw new NotImplementedException();
    }

    public void ResetState()
    {
        throw new NotImplementedException();
    }

    public ISingletonUser GetSingletonInstance()
    {
        throw new NotImplementedException();
    }

    public void SetSingletonInstance()
    {
        BasicSingleton<TurnManager>.Instance = this;
    }
}
