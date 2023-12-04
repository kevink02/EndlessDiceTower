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

        OnTurnStart += EnableDiceRolling;

        OnTurnEnd += DisableDiceRolling;

        _playerInputActions.DiceRolling.RollDie1.performed += cxt => OnDieRolled?.Invoke(0);
        _playerInputActions.DiceRolling.RollDie2.performed += cxt => OnDieRolled?.Invoke(1);
        _playerInputActions.DiceRolling.RollDie3.performed += cxt => OnDieRolled?.Invoke(2);
        _playerInputActions.DiceAttack.Attack.performed += cxt => DoTurn();

        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    private new void OnDisable()
    {
        base.OnDisable();

        OnTurnStart -= EnableDiceRolling;

        OnTurnEnd -= DisableDiceRolling;

        _playerInputActions.DiceRolling.RollDie1.performed -= cxt => OnDieRolled?.Invoke(0);
        _playerInputActions.DiceRolling.RollDie2.performed -= cxt => OnDieRolled?.Invoke(1);
        _playerInputActions.DiceRolling.RollDie3.performed -= cxt => OnDieRolled?.Invoke(2);
        _playerInputActions.DiceAttack.Attack.performed -= cxt => DoTurn();

        _playerInputActions.DiceRolling.Disable();
        _playerInputActions.DiceAttack.Disable();
    }


    /*
     * Instance methods
     */
    private void EnableDiceRolling()
    {
        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    private void DisableDiceRolling(object sender, EventArgs eventArgs)
    {
        _playerInputActions.DiceRolling.Disable();
        _playerInputActions.DiceAttack.Disable();
    }

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

    public override void ResetInstance(object sender, EventArgs eventArgs)
    {
        Debug.Log($"Resetting {name}'s instance");
    }

    public override void DoTurn()
    {
        OnAttackStart?.Invoke();

        EndTurn();
    }

    public override void DoAttack()
    {
        foreach (KeyValuePair<ElementType, int> fighterAttack in FighterAttacks)
        {
            BasicSingleton<FighterGenerator>.Instance.CurrentEnemyFighter.TakeDamage(fighterAttack.Value, fighterAttack.Key);
            Debug.Log($"{name}: Added {fighterAttack.Value} {fighterAttack.Key} damage");
        }
    }
}
