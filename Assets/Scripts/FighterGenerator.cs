using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    private event Action StartFirstFloor;


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
         * Verifications
         */
        if (_enemyFightersParent.transform.childCount == 0)
        {
            throw new Exception("The enemy fighters parent object contains no child objects");
        }
        if (_playerFightersParent.transform.childCount == 0)
        {
            throw new Exception("The player fighters parent object contains no child objects");
        }

        /*
         * Initialization
         */
        EnemyFighters = new List<EnemyFighter>();
        PlayerFighters = new List<PlayerFighter>();
    }

    private void OnEnable()
    {
        CreateFighters += AddPlayerFightersToList;
        CreateFighters += AddEnemyFightersToList;

        StartFirstFloor += InitializePlayerFighter;
        StartFirstFloor += InitializeEnemyFighter;
    }

    private void Start()
    {
        CreateFighters?.Invoke();
        StartFirstFloor?.Invoke();
    }

    private void OnDisable()
    {
        CreateFighters -= AddPlayerFightersToList;
        CreateFighters -= AddEnemyFightersToList;

        StartFirstFloor -= InitializePlayerFighter;
        StartFirstFloor -= InitializeEnemyFighter;
    }


    /*
     * Instance methods
     */
    private void AddPlayerFightersToList()
    {
        Debug.Log($"{name}: Adding player fighters");
        // Remember to check for inactive objects, as they should be disabled prior to starting the game
        foreach (PlayerFighter pf in _playerFightersParent.transform.GetComponentsInChildren<PlayerFighter>(true))
        {
            PlayerFighters.Add(pf);
        }
        if (PlayerFighters.Count != 1)
        {
            throw new Exception($"There should only be 1 player fighter object present, not {PlayerFighters.Count}");
        }
    }

    private void AddEnemyFightersToList()
    {
        Debug.Log($"{name}: Adding enemy fighters");
        // Remember to check for inactive objects, as they should be disabled prior to starting the game
        foreach (EnemyFighter ef in _enemyFightersParent.transform.GetComponentsInChildren<EnemyFighter>(true))
        {
            EnemyFighters.Add(ef);
        }
        if (EnemyFighters.Count == 0)
        {
            throw new Exception("There should be at least 1 enemy fighter object present, not 0");
        }
    }

    private void InitializePlayerFighter()
    {
        // Assuming the player object is inactive, which it should be
        PlayerFighter playerFighter = PlayerFighters[0];
        if (playerFighter != null)
        {
            playerFighter.gameObject.SetActive(true);
            Debug.Log($"{name}: Activating player {playerFighter}");
        }
    }

    private void InitializeEnemyFighter()
    {
        // Assuming all enemy objects are inactive, which they should be
        // Pick a random enemy to make active
        EnemyFighter enemyFighter = EnemyFighters[Random.Range(0, EnemyFighters.Count)];
        if (enemyFighter != null)
        {
            enemyFighter.gameObject.SetActive(true);
            Debug.Log($"{name}: Activating enemy {enemyFighter}");
        }
    }
}
