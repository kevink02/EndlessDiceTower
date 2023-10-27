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

    private void Start()
    {
    }


    /*
     * Interface methods
     */
    public override void SetSingletonInstance()
    {
        BasicSingleton<TurnManager>.Instance = this;
    }
}
