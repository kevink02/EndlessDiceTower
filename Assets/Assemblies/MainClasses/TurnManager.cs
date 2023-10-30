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
    private void Awake()
    {
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
        if (FighterTurnQueue.Count == 0)
        {
            Debug.LogWarning("The fighter queue is empty");
            return;
        }
        // Rotate through the turn queue until the player is at the front
        if (!(FighterTurnQueue.Peek() is PlayerFighter))
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
}
