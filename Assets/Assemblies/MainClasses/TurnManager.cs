using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : BasicSingleton<TurnManager>
{
    /*
     * Instance variables
     */
    [SerializeField]
    private Text _turnText;
    private TurnState _turnState;
    private enum TurnState : int
    {
        PlayerTurn, EnemyTurn
    }


    /*
     * Properties
     */
    public Queue<DiceFighter> FighterTurnQueue { get; private set; }


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (_turnText == null)
        {
            throw new System.NullReferenceException("Turn text object is not set");
        }

        FighterTurnQueue = new Queue<DiceFighter>();
    }

    private void OnEnable()
    {
        BasicSingleton<FloorManager>.Instance.OnQueueFighters += AddFightersToTurnQueue;

        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor += ResetTurnQueue;

        DiceFighter.OnFighterTurnEnd += QueueNextFighter;
    }

    private void OnDisable()
    {
        BasicSingleton<FloorManager>.Instance.OnQueueFighters -= AddFightersToTurnQueue;

        BasicSingleton<FloorManager>.Instance.OnCreateNewFloor -= ResetTurnQueue;

        DiceFighter.OnFighterTurnEnd -= QueueNextFighter;
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

        _turnState = TurnState.PlayerTurn;
    }

    private void QueueNextFighter()
    {
        Debug.Log($"{name}: Getting next fighter in queue...");
        if (FighterTurnQueue.Count == 0)
        {
            Debug.LogWarning("The fighter queue is empty");
            return;
        }
        DiceFighter dequeuedFighter = FighterTurnQueue.Dequeue();
        FighterTurnQueue.Enqueue(dequeuedFighter);
    }

    private void SwapTurns()
    {
        // Set to enemy's turn
        if (_turnState == TurnState.PlayerTurn)
        {
            _turnState = TurnState.EnemyTurn;
            _turnText.UpdateText("Turn: Enemy's turn");
        }
        // Set to player's turn
        else if (_turnState == TurnState.EnemyTurn)
        {
            _turnState = TurnState.PlayerTurn;
            _turnText.UpdateText("Turn: Player's turn");
        }
    }
}
