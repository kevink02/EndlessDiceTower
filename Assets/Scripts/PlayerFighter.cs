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
        _playerInputActions.DiceRolling.RollDie1.Enable();
        _playerInputActions.DiceRolling.RollDie2.Enable();
        _playerInputActions.DiceRolling.RollDie3.Enable();
    }

    private void Start()
    {
        // _playerInputActions.DiceRolling.RollDie1.performed += cxt => RollDie(cxt);
        // Debug.Log($"keyBindingsArr: {_playerInputActions.DiceRolling.RollDice.bindings}");
        _playerInputActions.DiceRolling.RollDie1.performed += cxt => RollDie(0);
        _playerInputActions.DiceRolling.RollDie2.performed += cxt => RollDie(1);
        _playerInputActions.DiceRolling.RollDie3.performed += cxt => RollDie(2);
    }

    private void OnDisable()
    {
        _playerInputActions.DiceRolling.RollDie1.Disable();
        _playerInputActions.DiceRolling.RollDie2.Disable();
        _playerInputActions.DiceRolling.RollDie3.Disable();
    }


    /*
     * Instance methods
     */
    private void TempFunction()
    {

    }

    private void RollDie(int index)
    {
        Debug.Log($"{name}: Rolling die #{index}");
    }

    private void RollDie(InputAction.CallbackContext context)
    {
        Debug.Log($"key: {context}");
        Debug.Log($"keyControl: {context.control}");
        // Debug.Log($"keyValue: {context.ReadValue<float>()}");

        // Does work in checking if a specific key is pressed, but not flexible if wanting to rebind keys
        // Debug.Log($"keyboardPress: {Keyboard.current.digit1Key.isPressed}");

        var arr = context.action.bindings;
        int index = 0;
        foreach (var v in arr)
        {
            Debug.Log($"keyInArr: {v}");
            index++;
        }
    }
}
