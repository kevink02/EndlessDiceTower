using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : BasicSingleton<LevelUIManager>
{
    /*
     * Instance variables
     */
    [SerializeField]
    [Tooltip("The gameobject that the player will be positioned at in the scene view")]
    private GameObject _playerFighterPosition;
    [SerializeField]
    [Tooltip("The gameobject that the enemy will be positioned at in the scene view")]
    private GameObject _enemyFighterPosition;
    [SerializeField]
    private Text _currentFloorText;


    /*
     * Properties
     */
    public GameObject PlayerPosition
    {
        get
        {
            return _playerFighterPosition;
        }
    }

    public GameObject EnemyPosition
    {
        get
        {
            return _enemyFighterPosition;
        }
    }

    public Text CurrentFloorText
    {
        get
        {
            return _currentFloorText;
        }
    }


    /*
     * Unity methods
     */
    private void Awake()
    {
        if (PlayerPosition == null)
        {
            throw new System.NullReferenceException("Player position object is not set");
        }
        if (EnemyPosition == null)
        {
            throw new System.NullReferenceException("Enemy position object is not set");
        }
        if (CurrentFloorText == null)
        {
            throw new System.NullReferenceException("Current floor text is not set");
        }
    }
}
