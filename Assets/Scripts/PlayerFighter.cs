using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : DiceFighter
{
    private PlayerInputActions _playerInputActions;


    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();

        _playerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        _playerInputActions.DiceRolling.RollDice.performed += cxt => TempFunction();
    }

    private void TempFunction()
    {

    }
}
