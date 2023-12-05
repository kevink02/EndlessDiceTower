using System;
using UnityEngine;

public class FighterGenerator : BasicSingleton<FighterGenerator>
{
    /*
     * Instance variables
     */
    public readonly IntRange FightersPerFloor = new IntRange(2, 2);
    [SerializeField]
    private PlayerFighter _playerFighter;
    [SerializeField]
    private EnemyFighter _enemyFighter;
    [SerializeField]
    private FighterStats[] _fighterStatsAssets;


    /*
     * Properties
     */
    public EnemyFighter CurrentEnemyFighter
    {
        get
        {
            return _enemyFighter;
        }
    }
    public PlayerFighter CurrentPlayerFighter
    {
        get
        {
            return _playerFighter;
        }
    }


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (CurrentEnemyFighter == null)
        {
            throw new NullReferenceException("Enemy fighter is not set");
        }
        if (CurrentPlayerFighter == null)
        {
            throw new NullReferenceException("Player fighter is not set");
        }
        if (_fighterStatsAssets == null)
        {
            throw new NullReferenceException("Figher stats are not set");
        }
    }


    /*
     * Instance methods
     */
    /// <summary>
    /// When "creating a new enemy" load the SO stats of another enemy to apply to an existing enemy object
    /// </summary>
    private void LoadRandomEnemyStats()
    {
        FighterStats newEnemyStats = RandomGetter<FighterStats>.GetRandomItem(_fighterStatsAssets);
        CurrentEnemyFighter.UpdateStats(newEnemyStats);
    }
}
