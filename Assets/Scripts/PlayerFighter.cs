using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFighter : DiceFighter
{
    /*
     * Instance variables
     */
    private PlayerInputActions _playerInputActions;


    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();

        _playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInputActions.DiceRolling.RollDice.Enable();
    }

    private void Start()
    {
        _playerInputActions.DiceRolling.RollDice.performed += cxt => RollDie(cxt);
    }


    /*
     * Instance methods
     */
    private void TempFunction()
    {

    }

    private void RollDie(InputAction.CallbackContext context)
    {
        Debug.Log($"key: {context}");
        Debug.Log($"key: {context.ReadValue<float>()}");
    }
}
