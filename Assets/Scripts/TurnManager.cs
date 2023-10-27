using System.Collections.Generic;
using UnityEngine;

public class TurnManager : BasicSingleton<TurnManager>
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

    private void OnEnable()
    {
        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor += ResetTurnQueue;
        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor += AddToTurnQueue;
    }

    private void OnDisable()
    {
        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor -= ResetTurnQueue;
        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor -= AddToTurnQueue;
    }


    /*
     * Instance methods
     */
    private void ResetTurnQueue()
    {
        _fighterTurnQueue.Clear();
    }

    private void AddToTurnQueue()
    {
        Debug.Log("Adding fighters to turn queue...");
    }


    /*
     * Interface methods
     */
    public override void SetSingletonInstance()
    {
        BasicSingleton<TurnManager>.Instance = this;
    }
}
