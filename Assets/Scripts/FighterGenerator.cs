using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterGenerator : BasicSingleton<FighterGenerator>
{
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
