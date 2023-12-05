using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    }
}
