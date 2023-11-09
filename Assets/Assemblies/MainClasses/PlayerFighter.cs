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
        _playerInputActions.DiceRolling.Enable();
        _playerInputActions.DiceAttack.Enable();
    }

    private new void Start()
    {
        base.Start();

        _playerInputActions.DiceRolling.RollDie1.performed += cxt => RollDie(0);
        _playerInputActions.DiceRolling.RollDie2.performed += cxt => RollDie(1);
        _playerInputActions.DiceRolling.RollDie3.performed += cxt => RollDie(2);

        _playerInputActions.DiceAttack.Attack.performed += cxt => DoAttack();
    }

    private void OnDisable()
    {
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
        int totalDamage = 0;
        foreach (RollableDie rollableDie in FighterDice)
        {
            totalDamage += rollableDie.RolledValue;
        }
        Debug.Log($"{name}: Doing a total of {totalDamage} damage");
        BasicSingleton<FighterGenerator>.Instance.CurrentEnemyFighter.TakeDamage(totalDamage, FighterElement);
    }

    public new void EndTurn()
    {
        base.EndTurn();

        _playerInputActions.DiceRolling.Disable();
        _playerInputActions.DiceAttack.Disable();
    }

    public override void DoAttack()
    {
        throw new System.NotImplementedException();
    }
}
