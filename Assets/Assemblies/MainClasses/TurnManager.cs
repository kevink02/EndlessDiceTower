using System.Collections.Generic;
using UnityEngine;

public class TurnManager : BasicSingleton<TurnManager>
{
    /*
     * Instance variables
     */
    private bool _isPlayerTurn;


    /*
     * Properties
     */
    public Queue<DiceFighter> FighterTurnQueue { get; private set; }


    /*
     * Unity methods
     */
    private void Awake()
    {
        /*
         * Initialize instance variables
         */
        _isPlayerTurn = true;
        FighterTurnQueue = new Queue<DiceFighter>();
    }

    private void OnEnable()
    {
        BasicSingleton<FloorManager>.Instance.OnQueueFighters += AddFightersToTurnQueue;

        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor += ResetTurnQueue;
    }

    private void OnDisable()
    {
        BasicSingleton<FloorManager>.Instance.OnQueueFighters -= AddFightersToTurnQueue;

        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor -= ResetTurnQueue;
    }


    /*
     * Instance methods
     */
    private void AddFightersToTurnQueue()
    {
        foreach (PlayerFighter pf in BasicSingleton<FighterGenerator>.Instance.PlayerFighters)
        {
            FighterTurnQueue.Enqueue(pf);
        }
        foreach (EnemyFighter ef in BasicSingleton<FighterGenerator>.Instance.EnemyFighters)
        {
            FighterTurnQueue.Enqueue(ef);
        }
    }

    private void ResetTurnQueue()
    {
        Debug.Log($"{name}: Resetting turn queue...");
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

        Debug.Log($"{name}: Checking turn queue...");
        foreach (DiceFighter df in FighterTurnQueue)
        {
            Debug.Log($"Queue item: {df}");
        }
    }
}
