using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : DiceFighter
{
    private PlayerInputActions _playerInputActions;


    private new void Awake()
    {
        base.Awake();

        _playerInputActions = new PlayerInputActions();
    }
}
