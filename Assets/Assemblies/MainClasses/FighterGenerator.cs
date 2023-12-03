using System;
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
    public EnemyFighter CurrentEnemyFighter
    {
        get
        {
            // If the enemy is active, then it is the current enemy
            // All inactive enemies will become active when they are chosen to spawn on a new floor
            foreach (EnemyFighter enemyFighter in EnemyFighters)
            {
                if (enemyFighter.gameObject.activeInHierarchy)
                {
                    return enemyFighter;
                }
            }
            return null;
        }
    }
    public PlayerFighter CurrentPlayerFighter
    {
        get
        {
            // If the player is active, then it is the current player
            foreach (PlayerFighter playerFighter in PlayerFighters)
            {
                if (playerFighter.gameObject.activeInHierarchy)
                {
                    return playerFighter;
                }
            }
            return null;
        }
    }


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (_enemyFightersParent == null)
        {
            throw new NullReferenceException("Enemy fighters parent object is not set");
        }
        if (_playerFightersParent == null)
        {
            throw new NullReferenceException("Player fighters parent object is not set");
        }

        if (_enemyFightersParent.transform.childCount == 0)
        {
            throw new Exception("The enemy fighters parent object contains no child objects");
        }
        if (_playerFightersParent.transform.childCount == 0)
        {
            throw new Exception("The player fighters parent object contains no child objects");
        }

        EnemyFighters = new List<EnemyFighter>();
        PlayerFighters = new List<PlayerFighter>();

        AddPlayerFightersToList();
        AddEnemyFightersToList();
    }

    private void OnEnable()
    {
        BasicSingleton<FloorManager>.Instance.OnInitializeFighters += InitializePlayerFighter;
        BasicSingleton<FloorManager>.Instance.OnInitializeFighters += DisableEnemyFighters;
        BasicSingleton<FloorManager>.Instance.OnInitializeFighters += InitializeRandomEnemyFighter;
    }

    private void OnDisable()
    {
        BasicSingleton<FloorManager>.Instance.OnInitializeFighters -= InitializePlayerFighter;
        BasicSingleton<FloorManager>.Instance.OnInitializeFighters -= DisableEnemyFighters;
        BasicSingleton<FloorManager>.Instance.OnInitializeFighters -= InitializeRandomEnemyFighter;
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

    private void InitializePlayerFighter(object sender, EventArgs eventArgs)
    {
        PlayerFighter playerFighter = PlayerFighters[0];
        if (playerFighter != null)
        {
            playerFighter.gameObject.SetActive(true);
            Debug.Log($"{name}: Activating player {playerFighter}");
        }
    }

    private void DisableEnemyFighters(object sender, EventArgs eventArgs)
    {
        foreach (EnemyFighter enemyFighter in EnemyFighters)
        {
            enemyFighter.gameObject.SetActive(false);
        }
    }

    private void InitializeRandomEnemyFighter(object sender, EventArgs eventArgs)
    {
        EnemyFighter enemyFighter = EnemyFighters[Random.Range(0, EnemyFighters.Count)];
        if (enemyFighter != null)
        {
            enemyFighter.gameObject.SetActive(true);
            Debug.Log($"{name}: Activating enemy {enemyFighter}");
        }
    }
}
