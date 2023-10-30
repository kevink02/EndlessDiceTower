using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterGenerator : BasicSingleton<FighterGenerator>
{
    /*
     * Instance variables
     */
    [SerializeField]
    private GameObject _enemyFightersParent;
    [SerializeField]
    private GameObject _playerFightersParent;


    /*
     * Properties
     */
    public List<EnemyFighter> EnemyFighters { get; private set; }
    public List<PlayerFighter> PlayerFighters { get; private set; }


    /*
     * Delegates
     */
    private event Action CreateFighters;


    /*
     * Unity methods
     */
    private void Awake()
    {
        /*
         * Null checks
         */
        if (_enemyFightersParent == null)
        {
            throw new NullReferenceException("Enemy fighters parent object is not set");
        }
        if (_playerFightersParent == null)
        {
            throw new NullReferenceException("Player fighters parent object is not set");
        }

        /*
         * Initialization
         */
        EnemyFighters = new List<EnemyFighter>();
        PlayerFighters = new List<PlayerFighter>();
    }

    private void OnEnable()
    {
        CreateFighters += CreatePlayerFighters;
        CreateFighters += CreateEnemyFighters;
    }

    private void Start()
    {
        CreateFighters?.Invoke();
    }

    private void OnDisable()
    {
        CreateFighters -= CreatePlayerFighters;
        CreateFighters -= CreateEnemyFighters;
    }


    /*
     * Instance methods
     */
    private void CreatePlayerFighters()
    {
        Debug.Log("${name}: Creating player fighters");
    }

    private void CreateEnemyFighters()
    {
        Debug.Log("${name}: Creating enemy fighters");
    }
}
