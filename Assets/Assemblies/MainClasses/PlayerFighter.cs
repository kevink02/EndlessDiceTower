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

    private new void OnEnable()
    {
        base.OnEnable();

        OnTurnEnd += _playerInputActions.DiceRolling.Disable;
        OnTurnEnd += _playerInputActions.DiceAttack.Disable;

        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    private new void Start()
    {
        base.Start();

        _playerInputActions.DiceRolling.RollDie1.performed += cxt => OnDieRolled?.Invoke(0);
        _playerInputActions.DiceRolling.RollDie2.performed += cxt => OnDieRolled?.Invoke(1);
        _playerInputActions.DiceRolling.RollDie3.performed += cxt => OnDieRolled?.Invoke(2);

        _playerInputActions.DiceAttack.Attack.performed += cxt => DoTurn();
    }

    private void OnDisable()
    {
        OnTurnEnd -= _playerInputActions.DiceRolling.Disable;
        OnTurnEnd -= _playerInputActions.DiceAttack.Disable;

        _playerInputActions.DiceRolling.Disable();
        _playerInputActions.DiceAttack.Disable();
    }


    /*
     * Instance methods
     */
    private void RollDie(InputAction.CallbackContext context)
    {
        Debug.Log($"key: {context}");
        Debug.Log($"keyControl: {context.control}");
        // Debug.Log($"keyValue: {context.ReadValue<float>()}");

        var arr = context.action.bindings;
        int index = 0;
        foreach (var v in arr)
        {
            Debug.Log($"keyInArr: {v}");
            index++;
        }
    }

    public override void StartTurn()
    {
        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    public override void DoTurn()
    {
        OnAttackPerformed?.Invoke();

        EndTurn();
    }
}
