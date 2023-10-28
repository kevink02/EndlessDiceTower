using System.Collections.Generic;
using UnityEngine;

public class TurnManager : BasicSingleton<TurnManager>
{
    /*
     * Instance variables
     */
    private bool _isPlayerTurn;
    private Queue<DiceFighter> _fighterTurnQueue;


    /*
     * Properties
     */
    public Queue<DiceFighter> FighterTurnQueue
    {
        get
        {
            return _fighterTurnQueue;
        }
    }


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
        _isPlayerTurn = true;
        _fighterTurnQueue = new Queue<DiceFighter>();
    }

    private void OnEnable()
    {
        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor += ResetTurnQueue;
    }

    private void OnDisable()
    {
        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor -= ResetTurnQueue;
    }


    /*
     * Instance methods
     */
    private void ResetTurnQueue()
    {
        DiceFighter diceFighter = FighterTurnQueue.Peek();
        if (diceFighter == null)
        {
            Debug.LogWarning("The fighter queue is empty");
        }
        // Rotate through the turn queue until the player is at the front
        else if (!(diceFighter is PlayerFighter))
        {
            // In case the while-loop continues forever
            int whileBreaker = 0;
            while (!(FighterTurnQueue.Peek() is PlayerFighter) && whileBreaker < 100)
            {
                DiceFighter dequeuedFighter = FighterTurnQueue.Dequeue();
                FighterTurnQueue.Enqueue(dequeuedFighter);

                whileBreaker++;
            }
        }
    }


    /*
     * Interface methods
     */
    public override void SetSingletonInstance()
    {
        BasicSingleton<TurnManager>.Instance = this;
    }
}
